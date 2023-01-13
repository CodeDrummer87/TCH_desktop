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

            }
            else
            {
                if (MessageBox.Show(".:: Для корректной работы приложения необходимо развернуть и " +
                    "подключить Базу Данных. В программу заложена возможность развернуть Базу Данных для сервера " +
                    "MS SQL 2018 и выше. Развернуть?", "База данных отсутствует",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string currentDir = Environment.CurrentDirectory;
                    int index = currentDir.IndexOf("Desktop") + 20;

                    string root = (currentDir.Remove(index)) + "Database";
                    DeployDatabase(root);
                }
            }
        }

        public bool CheckDbForExist(string dbName)
        {
            int result = 0;

            string query = "USE master SELECT COUNT(*) FROM sysdatabases WHERE NAME=@dbName";

            try
            {
                SqlCommand command = new(query, DataBase.GetMasterConnection());
                command.Parameters.Add("@dbName", SqlDbType.VarChar).Value = dbName;
                DataBase.OpenMasterConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                reader.Close();
                DataBase.CloseMasterConnection();

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

            MessageBox.Show(".:: Приложение готово к работе", "База Данных развёрнута",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RunScript(string query, int number)
        {
            query = query.Replace("GO", "");

            int index = query.IndexOf("USE");
            if (index != 0) query = query.Substring(index);

            try
            {
                SqlCommand command = new(@query, DataBase.GetMasterConnection());
                DataBase.OpenMasterConnection();

                command.ExecuteNonQuery();
                DataBase.CloseMasterConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить {number}-й скрипт при развёртывании Базы Данных приложения." +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
