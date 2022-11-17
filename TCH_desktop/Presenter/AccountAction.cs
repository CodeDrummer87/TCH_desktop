using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using TCH_desktop.Models;
using TCH_desktop.Presenter.interfaces;

namespace TCH_desktop.Presenter
{
    internal class AccountAction : IAccountAction
    {
        public string CreateNewAccount(string email, string password, string confirmedPassword)
        {
            string message = String.Empty;

            if (!CheckInputedEmail(email) && (password == confirmedPassword))
            {
                string query = "INSERT INTO Logins VALUES (@login, @password, @salt)";

                byte[] salt = GetSalt();
                string pswdHashImage = GetHashImage(password, salt);

                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = email;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = pswdHashImage;
                command.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;

                DataBase.OpenConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    message = $"Аккаунт для {email} успешно зарегистрирован";
                }
                else message = "Ошибка регистрации";

                DataBase.CloseConnection();
            }
            else message = "Аккаунт с таким email уже существует";

            return message;
        }

        public byte[] GetSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public string GetHashImage(string pswrd, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pswrd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public bool CheckInputedEmail(string email)
        {
            string query = "SELECT * FROM Logins WHERE Email = @uEmail";
            SqlCommand command = new(query, DataBase.GetConnection());
            command.Parameters.Add("@uEmail", SqlDbType.VarChar).Value = email;

            DataTable table = new();

            DataBase.adapter.SelectCommand = command;
            DataBase.adapter.Fill(table);

            return table.Rows.Count == 1 ? true : false;
        }

        public LoginModel GetCurrentLoginData(string email)
        {
            LoginModel mLogin = new();

            string query = "SELECT * FROM Logins WHERE Email=@e";

            SqlCommand command = new(query, DataBase.GetConnection());
            command.Parameters.Add("@e", SqlDbType.VarChar).Value = email;
            DataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                mLogin = new LoginModel
                {
                    LoginId = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Password = reader.GetString(2),
                    Salt = (byte[])reader[3]
                };
            }
            reader.Close();

            return mLogin;
        }
    }
}
