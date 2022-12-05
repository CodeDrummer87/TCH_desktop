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
        private SqlCommand command;
        private SqlDataReader reader;

        public string CreateNewAccount(string email, string password, string confirmedPassword)
        {
            string message = String.Empty;

            if (!CheckInputedEmail(email) && (password == confirmedPassword))
            {
                string query = "INSERT INTO Logins VALUES (@login, @password, @salt)";

                try
                {
                    byte[] salt = GetSalt();
                    string pswdHashImage = GetHashImage(password, salt);

                    command = new(query, DataBase.GetConnection());
                    command.Parameters.Add("@login", SqlDbType.VarChar).Value = email;
                    command.Parameters.Add("@password", SqlDbType.NVarChar).Value = pswdHashImage;
                    command.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;

                    DataBase.OpenConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        message = $"Аккаунт для {email} успешно зарегистрирован";
                        AttachNewUserData(email);
                    }
                    else message = "Ошибка регистрации";

                    DataBase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Получена ошибка со следующим содержанием:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
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

            try
            {
                command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@uEmail", SqlDbType.VarChar).Value = email;

                DataTable table = new();
                DataBase.adapter.SelectCommand = command;
                DataBase.adapter.Fill(table);

                return table.Rows.Count == 1 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка со следующим содержанием:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }
        }

        public LoginModel GetCurrentLoginData(string email)
        {
            LoginModel mLogin = new();

            string query = "SELECT * FROM Logins WHERE Email=@e";

            try
            {
                command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@e", SqlDbType.VarChar).Value = email;
                DataBase.OpenConnection();

                reader = command.ExecuteReader();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка со следующим содержанием:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return mLogin;
        }

        public User GetCurrentUserData(int loginId)
        {
            User user = new();

            string query = "SELECT * FROM Users WHERE LoginId=@Id";

            command = new(query, DataBase.GetConnection());
            command.Parameters.Add("@Id", SqlDbType.Int).Value = loginId;
            DataBase.OpenConnection();

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                user = new User
                {
                    Id = reader.GetInt32(0),
                    SurName = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    Patronymic = reader.GetString(3),
                    BirthDate = reader.GetDateTime(4),
                    LoginId = reader.GetInt32(5)
                };
            }
            reader.Close();

            return user;
        }

        private void AttachNewUserData(string email)
        {
            int loginId = GetCurrentLoginData(email).LoginId;

            string dName = "не указано";
            DateTime dateTime = DateTime.Now;
            string query = $"INSERT INTO Users VALUES ('{dName}', '{dName}', '{dName}', @dt, @loginId)";

            command = new(query, DataBase.GetConnection());
            command.Parameters.Add("@dt", SqlDbType.DateTime).Value = dateTime;
            command.Parameters.Add("loginId", SqlDbType.Int).Value = loginId;

            try
            {
                DataBase.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка со следующим содержанием:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public Employee GetCurrentEmployeeData(int userId)
        {
            Employee employee = new();

            string query = "SELECT * FROM Employees WHERE UserId=@uId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@uId", SqlDbType.Int).Value = userId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employee = new Employee
                    {
                        Id = reader.GetInt32(0),
                        TabNumber = reader.GetInt32(1),
                        UserId = userId,
                        PositionId = reader.GetInt32(3),
                        ColumnId = reader.GetInt32(4)
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить запрос к Базе Данных на получение данных" +
                    $" о сотруднике:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return employee;
        }

        public int GetCurrentRailroadId(int userId)
        {
            int railroadId = 0;
            string query = "SELECT r.Id FROM Employees e "
                            + "INNER JOIN columns c "
                            + "ON c.id = e.columnid "
                            + "INNER JOIN LocomotiveDepots d "
                            + "ON d.id = c.Depot "
                            + "INNER JOIN Railroads r "
                            + "ON r.id = d.Railroad "
                            + "WHERE e.UserId = @uId";

            try
            {
                command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@uId", SqlDbType.Int).Value = userId;
                DataBase.OpenConnection();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    railroadId = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка при попытке получить ID железной дороги:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return railroadId;
        }

        public int GetCurrentDepotId(int userId)
        {
            int depotId = 0;
            string query =  "SELECT d.id "
                            + "FROM Employees e "
                            + "INNER JOIN Columns c "
                            + "ON c.Id = e.ColumnId "
                            + "INNER JOIN LocomotiveDepots d "
                            + "ON d.id = c.Depot "
                            + "WHERE e.UserId = @uId";

            try
            {
                command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@uId", SqlDbType.Int).Value = userId;
                DataBase.OpenConnection();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    depotId = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка при попытке получить ID депо:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return depotId;
        }
    }
}
