using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography;
using TCH_desktop.Models;

namespace TCH_desktop.Presenter
{
    public class AccountAction
    {
        private SqliteCommand command;
        private SqliteDataReader reader;

        public string CreateNewAccount(string email, string password, string confirmedPassword)
        {
            string message = String.Empty;

            if (!CheckInputedEmail(email) && (password == confirmedPassword))
            {
                string query = "INSERT INTO Logins(Email, Password, Salt) VALUES (@login, @password, @salt)";

                try
                {
                    byte[] salt = GetSalt();
                    string pswdHashImage = GetHashImage(password, salt);

                    command = DataBase.GetConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.Add("@login", SqliteType.Text).Value = email;
                    command.Parameters.Add("@password", SqliteType.Text).Value = pswdHashImage;
                    command.Parameters.Add("@salt", SqliteType.Blob).Value = salt;

                    DataBase.OpenConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        message = $"Аккаунт для {email} успешно зарегистрирован";
                        AttachNewUserData(email);
                    }
                    else message = "Ошибка регистрации";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Получена ошибка со следующим содержанием:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

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
            string query = "SELECT * FROM Logins WHERE Email=@uEmail";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uEmail", SqliteType.Text).Value = email;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();

                return reader.HasRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка со следующим содержанием:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return false;
        }

        public LoginModel GetCurrentLoginData(string email)
        {
            LoginModel mLogin = new();
            string query = "SELECT * FROM Logins WHERE Email=@e";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@e", SqliteType.Text).Value = email;

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

            DataBase.CloseConnection();
            return mLogin;
        }

        public User GetCurrentUserData(int loginId)
        {
            User user = new();
            string query = "SELECT * FROM Users WHERE LoginId=@Id";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@Id", SqliteType.Integer).Value = loginId;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить данные текущего пользователя:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return user;
        }

        private void AttachNewUserData(string email)
        {
            int loginId = GetCurrentLoginData(email).LoginId;

            string dName = "не указано";
            DateTime dateTime = DateTime.Now;
            string query = $"INSERT INTO Users(SurName, FirstName, Patronymic, BirthDate, LoginId) " +
                $"VALUES ('{dName}', '{dName}', '{dName}', @dt, @loginId)";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@dt", SqliteType.Text).Value = dateTime;
                command.Parameters.Add("loginId", SqliteType.Integer).Value = loginId;

                DataBase.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка со следующим содержанием:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        public Employee GetCurrentEmployeeData(int userId)
        {
            Employee employee = new();
            string query = "SELECT * FROM Employees WHERE UserId=@uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
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
                MessageBox.Show($"Не удалось получить данные текущего сотрудника:" +
                    $" о сотруднике:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
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
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

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

            DataBase.CloseConnection();
            return railroadId;
        }

        public int GetCurrentDepotId(int userId)
        {
            int depotId = 0;
            string query = "SELECT d.id "
                            + "FROM Employees e "
                            + "INNER JOIN Columns c "
                            + "ON c.Id = e.ColumnId "
                            + "INNER JOIN LocomotiveDepots d "
                            + "ON d.id = c.Depot "
                            + "WHERE e.UserId = @uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

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

            DataBase.CloseConnection();
            return depotId;
        }

        public int GetCurrentPositionId(int userId)
        {
            int positionId = 0;
            string query = "SELECT PositionId FROM Employees e WHERE e.UserId = @uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    positionId = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка при попытке получить ID должности сотрудника:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return positionId;
        }

        public int GetCurrentColumnId(int userId)
        {
            int columnId = 0;
            string query = "SELECT ColumnId FROM Employees e WHERE e.UserId = @uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    columnId = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка при попытке получить ID колонны сотрудника:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return columnId;
        }

        public string GetInfoAboutEmployee(int userId)
        {
            string result = String.Empty;
            string query = "SELECT	(p.Abbreviate || ' ' || u.Surname || ' ' || u.FirstName || ' ' || " +
                " u.Patronymic || ' (таб.N' || CHAR(0176) || ' ' || e.TabNumber || ', колонна N' || " +
                "CHAR(0176) || ' ' || c.ColumnNumber || ') ' ||  d.ShortTitle) " +
                "FROM Employees e " +
                "INNER JOIN Users u " +
                "ON u.Id = e.UserId " +
                "INNER JOIN Positions p " +
                "ON p.Id = e.PositionId " +
                "INNER JOIN Columns c " +
                "ON c.Id = e.ColumnId " +
                "INNER JOIN LocomotiveDepots d " +
                "ON d.Id = c.Depot " +
                "WHERE e.UserId = @uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
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

            DataBase.CloseConnection();
            return result;
        }
    }
}
