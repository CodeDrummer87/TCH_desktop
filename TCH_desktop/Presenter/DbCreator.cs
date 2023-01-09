using System.Data;
using System.Data.SqlClient;

namespace TCH_desktop.Presenter
{
    public class DbCreator
    {
        public DbCreator()
        {
            string message = String.Empty;
            if (CheckDbForExist("tchDb"))
            {
                message = "The database \"tchDb\" is exist";
            }
            else message = "\"tchDb\" database will be created";
            MessageBox.Show(message);
        }

        public bool CheckDbForExist(string dbName)
        {
            int result = 0;

            string query = "USE master GO SELECT COUNT(*) FROM sysdatabases WHERE NAME=@dbName";
            string updatedQuery = query.Replace("GO", "");

            try
            {
                SqlCommand command = new(updatedQuery, DataBase.GetConnection());
                command.Parameters.Add("@dbName", SqlDbType.VarChar).Value = dbName;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                reader.Close();
                DataBase.CloseConnection();

                return result == 1 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"При попытке проверить наличие Базы Данных приложения \"ТЧЭ-2\" произошла ошибка:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return false;
        }
    }
}
