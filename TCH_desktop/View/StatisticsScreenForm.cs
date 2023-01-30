using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class StatisticsScreenForm : Form
    {
        private StartForm startForm;
        private int userId;
        private List<Statistics> tripStat = new();
        int tStatIndex;

        public StatisticsScreenForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            Location = new Point(630, 120);

            userId = this.startForm.GetCurrentUserId();
            tStatIndex = 0;
        }

        /*
        1) Всего поездок - количество (done)
        2) Времени в пути - сумма
        3) Тонн брутто перевезено
        4) Плечи на которых пришлось поработать (в скобках количество поездок) (done)
        5) Самый популярный локомотив в поездках
        6) Самая старая Синара
        7) Самая новая Синара
        */

        private int GetTotalTrips()
        {
            int result = 0;
            string query = "SELECT COUNT(Id) FROM Trips WHERE UserID=@uId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@uId", SqlDbType.Int).Value = userId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить общее количество поездок пользователя:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return result;
        }

        private void GetTripStatistics()
        {
            GetTrafficRoutes();
            GetTotalTripsByTrafficRoute();
        }

        public void GetTrafficRoutes()
        {
            string query = "SELECT DISTINCT TrafficRoute FROM Trips WHERE UserId=@uId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@uId", SqlDbType.Int).Value = userId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tripStat.Add(new Statistics
                    {
                        trafficRoute = reader.GetString(0)
                    });
                }

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные о маршрутах поездок:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void GetTotalTripsByTrafficRoute()
        {
            string query = "SELECT COUNT(TrafficRoute) FROM Trips WHERE UserId=@uId AND TrafficRoute=@tRoute";

            for (int i = 0; i < tripStat.Count(); i++)
            {
                try
                {
                    SqlCommand command = new(query, DataBase.GetConnection());
                    command.Parameters.Add("@uId", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@tRoute", SqlDbType.NVarChar).Value = tripStat[i].trafficRoute;
                    DataBase.OpenConnection();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Statistics tempStat = tripStat[i] with { totalTrips = reader.GetInt32(0) };  
                        tripStat[i] = tempStat;
                    }
                    DataBase.CloseConnection();

                    reader.Close();                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить данные о количестве поездок по маршруту " +
                        $"\"{tripStat[i].trafficRoute}\":\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }     
        }

        private int CheckIndex(int index)
        {
            return index >= tripStat.Count() ? 0 : index < 0 ? tripStat.Count() - 1 : index;
        }

        private void DisplayTrafficRouteCounter()
        {
            int tripsCounter = tripStat[tStatIndex].totalTrips;
            trafficRouteAndCounter.Text = $"★ {tripStat[tStatIndex].trafficRoute} " +
                $"({tripsCounter} {AllTripsForm.TransformWord(tripsCounter)}) ★";
        }



        #region Interactive

        private void StatisticsScreenForm_Load(object sender, EventArgs e)
        {
            totalTrips.Text = GetTotalTrips().ToString();

            GetTripStatistics();
            DisplayTrafficRouteCounter();        
        }

        private void closeScreen_MouseEnter(object sender, EventArgs e)
        {
            closeScreen.ForeColor = Color.Yellow;
            closeScreen.BackColor = Color.DimGray;
        }

        private void closeScreen_MouseLeave(object sender, EventArgs e)
        {
            closeScreen.ForeColor = Color.YellowGreen;
            closeScreen.BackColor = SystemColors.InfoText;
        }

        private void closeScreen_Click(object sender, EventArgs e)
        {
            startForm.Enabled = true;
            this.Close();
        }

        private void arrowLeft_MouseEnter(object sender, EventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left_hover;
        }

        private void arrowLeft_MouseLeave(object sender, EventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left;
        }

        private void arrowRight_MouseEnter(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right_hover;
        }

        private void arrowRight_MouseLeave(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right;
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            tStatIndex = CheckIndex(--tStatIndex);
            DisplayTrafficRouteCounter();
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            tStatIndex = CheckIndex(++tStatIndex);
            DisplayTrafficRouteCounter();
        }

        private void arrowRight_MouseDown(object sender, MouseEventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right_click;
        }

        private void arrowRight_MouseUp(object sender, MouseEventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right_hover;
        }

        private void arrowLeft_MouseDown(object sender, MouseEventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left_click;
        }

        private void arrowLeft_MouseUp(object sender, MouseEventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left_hover;
        }

        #endregion
    }
}
