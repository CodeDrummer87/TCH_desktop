using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TCH_desktop.Presenter
{
    public class DbCreator
    {
        public DbCreator()
        {
            if (CheckDbForExist("tchDb"))
            {
                //.:: temporary code
                MessageBox.Show(".:: База данных создана");
            }
            else
            {
                string currentDir = Environment.CurrentDirectory;
                int index = currentDir.IndexOf("Desktop") + 20;

                string root = (currentDir.Remove(index)) + "Database";
                DeployDatabase(root);
            }    
        }

        public bool CheckDbForExist(string dbName)
        {
            int result = 0;

            string query = "USE master GO SELECT COUNT(*) FROM sysdatabases WHERE NAME='@dbName'";
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

        public async void DeployDatabase(string root)
        {
            DirectoryInfo dir = new(root);
            int number = dir.GetDirectories().Count();

            string query = String.Empty;
            DirectoryInfo[] subDirFirst;
            DirectoryInfo[] subDirSecond;
            FileInfo[] sqlFile;

            for (int i = 1; i < number + 1; i++)
            {
                subDirFirst = dir.GetDirectories((i.ToString() + ".*"));
                subDirSecond = subDirFirst[0].GetDirectories("SQL");
                sqlFile = subDirSecond[0].GetFiles("*.sql");
                string path = sqlFile[0].FullName;

                using (FileStream fstream = File.OpenRead(path))
                {
                    byte[] buffer = new byte[fstream.Length];

                    await fstream.ReadAsync(buffer, 0, buffer.Length);
                    query = Encoding.Default.GetString(buffer);

                    RunScript(query, i);
                }
            }

            DataBase.SetSqlConnection("tchDb");
        }

        public void RunScript(string query, int number)
        {
            query = query.Replace("GO", "");

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                DataBase.OpenConnection();

                command.ExecuteNonQuery();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить {number}-й скрипт при развёртывании Базы Данных приложения." +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(query);
            }
        }
    }
}
