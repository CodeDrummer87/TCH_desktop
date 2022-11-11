using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCH_desktop
{
    internal class DataBase
    {
        SqlConnection sqlConnection = new
            (@"Data Source=LANCELOT\SQLEXPRESS;Initial Catalog=tchDb;Integrated Security=True;");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }    
        }

        public SqlConnection GetConnection() => sqlConnection;
    }
}
