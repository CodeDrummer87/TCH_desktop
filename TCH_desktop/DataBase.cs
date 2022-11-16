using System.Data.SqlClient;

namespace TCH_desktop
{
    internal static class DataBase
    {
        static SqlConnection sqlConnection = new
            (@"Data Source=LANCELOT\SQLEXPRESS;Initial Catalog=tchDb;Integrated Security=True;");

        public static SqlDataAdapter adapter = new();

        public static void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public static SqlConnection GetConnection() => sqlConnection;
    }
}
