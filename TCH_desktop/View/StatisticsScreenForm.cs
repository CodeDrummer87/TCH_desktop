﻿using Microsoft.Data.Sqlite;
using TCH_desktop.Models;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class StatisticsScreenForm : Form
    {
        private int tripsCount;

        private SqliteCommand command;
        private SqliteDataReader reader;

        private StartForm startForm;
        private int userId;
        private List<Statistics> tripStat = new();
        private List<TripTime> tripsTime = new();
        private int tStatIndex;

        private bool isOldestLoco;
        private List<string> series = new();
        private int seriesIndex = 0;
        private int seriesCountIndex = 0;
        private bool isFirstTrip;

        public StatisticsScreenForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            Location = new Point(630, 120);

            userId = this.startForm.GetCurrentUserId();
            tripsCount = GetTotalTrips();

            if (tripsCount > 0)
            {    
                tStatIndex = 0;

                isOldestLoco = true;
                series = GetAvailableLocoSeries();
                isFirstTrip = true;
            }
        }

        private int GetTotalTrips()
        {
            int result = 0;
            string query = "SELECT COUNT(Id) FROM Trips WHERE UserID=@uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить общее количество поездок пользователя:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            Console.Write(
result);
            DataBase.CloseConnection();
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
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tripStat.Add(new Statistics
                    {
                        trafficRoute = reader.GetString(0)
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные о маршрутах поездок:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        private void GetTotalTripsByTrafficRoute()
        {
            string query = "SELECT COUNT(TrafficRoute) FROM Trips WHERE UserId=@uId AND TrafficRoute=@tRoute";

            for (int i = 0; i < tripStat.Count(); i++)
            {
                try
                {
                    command = DataBase.GetConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;
                    command.Parameters.Add("@tRoute", SqliteType.Text).Value = tripStat[i].trafficRoute;

                    DataBase.OpenConnection();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Statistics tempStat = tripStat[i] with { totalTrips = reader.GetInt32(0) };
                        tripStat[i] = tempStat;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить данные о количестве поездок по маршруту " +
                        $"\"{tripStat[i].trafficRoute}\":\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                DataBase.CloseConnection();
            }
        }

        private int CheckIndex(int index)
        {
            return index >= tripStat.Count() ? 0 : index < 0 ? tripStat.Count() - 1 : index;
        }

        private void DisplayTrafficRouteCounter()
        {
            if (tripStat.Count > 0)
            {
                int tripsCounter = tripStat[tStatIndex].totalTrips;
                trafficRouteAndCounter.Text = $"★ {tripStat[tStatIndex].trafficRoute} " +
                    $"({tripsCounter} {AllTripsForm.TransformWord(tripsCounter)}) ★";
            }
            else
                trafficRouteAndCounter.Text = "Ни одной поездки не найдено";
        }

        private string GetTravelHours(string start, string end)
        {
            int index = start.IndexOf(':');
            int stHours = Convert.ToInt32(start.Substring(0, index));
            int stMinutes = Convert.ToInt32(start.Substring(index + 1, 2));

            index = end.IndexOf(':');
            int eHours = Convert.ToInt32(end.Substring(0, index));
            int eMinutes = Convert.ToInt32(end.Substring(index + 1, 2));

            int resHours = 0;
            int resMinutes = 0;

            while (eHours != stHours)
            {
                --eHours;
                if (eHours == -1) eHours = 23;
                ++resHours;
            }

            if (stMinutes > 0)
            {
                --resHours;
                resMinutes = 60 - stMinutes;
            }

            resMinutes += eMinutes;
            if (resMinutes > 59)
            {
                ++resHours;
                resMinutes -= 60;
            }

            return $"{resHours}:{resMinutes}";
        }

        private string SumHours(string totalTime, string newTime)
        {
            int index = totalTime.IndexOf(':');
            int totalHours = Convert.ToInt32(totalTime.Substring(0, index));
            int totalMinutes = Convert.ToInt32(totalTime.Substring(index + 1));

            index = newTime.IndexOf(':');
            int newHours = Convert.ToInt32(newTime.Substring(0, index));
            int newMinutes = Convert.ToInt32(newTime.Substring(index + 1));

            int resultHours = totalHours + newHours;
            int resultMinutes = totalMinutes + newMinutes;

            if (resultMinutes > 59)
            {
                ++resultHours;
                resultMinutes -= 60;
            }

            return $"{resultHours}:{(resultMinutes > 9 ? resultMinutes : "0" + resultMinutes)}";
        }

        private void GetTripTime()
        {
            string query = "SELECT Departure, Arrival FROM Trips WHERE UserId=@uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tripsTime.Add(new TripTime
                    {
                        departure = reader.GetString(0),
                        arrival = reader.GetString(1)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить общее количество поездок пользователя:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        private void DisplayTotalTravelTime()
        {
            GetTripTime();

            string sumTravelTime = "0:0";

            for (int i = 0; i < tripsTime.Count; i++)
            {
                string tripTime = GetTravelHours(tripsTime[i].departure, tripsTime[i].arrival);
                sumTravelTime = SumHours(sumTravelTime, tripTime);
            }

            totalTravelTime.Text = sumTravelTime;
        }

        private int GetSumWeight()
        {
            int result = 0;
            string query = "SELECT SUM(t.Weight) FROM Trains t " +
                "INNER JOIN Trips tr " +
                "ON tr.Train=t.Id " +
                "WHERE tr.UserId=@uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить сумму тонн брутто со всех поездок пользователя:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return result;
        }

        private List<string> GetAvailableLocoSeries()
        {
            List<string> series = new();
            string query = "SELECT DISTINCT ls.Series " +
                "FROM Trips t " +
                "INNER JOIN Locomotives l " +
                "ON l.id=t.Locomotive " +
                "INNER JOIN LocoSeries ls " +
                "ON ls.id=l.Series " +
                "WHERE UserId=@uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    series.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить доступные серии локомотивов пользователя:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return series;
        }

        private void SetColonLabel()
        {
            int x = locoSeriesLabel.Location.X + locoSeriesLabel.Width - 5;
            colonLabel.Location = new Point(x, 304);

            x = colonLabel.Location.X + colonLabel.Width;
            locoResultLabel.Location = new Point(x, 304);
        }

        private string GetLocoByCondition(string locoSeries)
        {
            int locoNumber = 0;
            string condition = isOldestLoco ? "MIN" : "MAX";

            string query = $"SELECT {condition}(l.Number) " +
                "FROM Locomotives l " +
                "INNER JOIN LocoSeries ls " +
                "ON l.Series=ls.Id " +
                "INNER JOIN Trips t " +
                "ON t.Locomotive=l.Id " +
                "WHERE t.UserId=@uId AND ls.Series=@locoSeries";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;
                command.Parameters.Add("@locoSeries", SqliteType.Text).Value = locoSeries;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    locoNumber = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить самый {(isOldestLoco ? "старый" : "новый")} " +
                    $"номер локомотива\n\"{ex.Message}\"" +
                    $"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return locoSeries + '-' + TransformLocoNumber(locoNumber);
        }

        private List<LocomotiveTripsCounter> GetLocoCounters()
        {
            List<LocomotiveTripsCounter> locoTripsCounter = new();

            string query = "SELECT (ls.Series || '-' || l.Number), " +
                "COUNT((ls.Series || '-' || l.Number)) " +
                "FROM Trips t " +
                "INNER JOIN Locomotives l " +
                "ON l.Id=t.Locomotive " +
                "INNER JOIN LocoSeries ls " +
                "ON ls.Id=l.Series " +
                "WHERE UserId=@uId " +
                "GROUP BY (ls.Series || '-' || l.Number)";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    locoTripsCounter.Add(new LocomotiveTripsCounter
                    {
                        Locomotive = reader.GetString(0),
                        Count = reader.GetInt32(1)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить самый популярный локомотив.\n\"{ex.Message}\"" +
                    $"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return locoTripsCounter;
        }

        private void GetMostPopularLoco()
        {
            List<LocomotiveTripsCounter> locoCounters = GetLocoCounters();
            int maxValue = 0;

            for (int i = 0; i < locoCounters.Count; i++)
                if (locoCounters[i].Count >= maxValue)
                    maxValue = locoCounters[i].Count;

            if (maxValue > 1)
            {
                int sameMeaning = 0;

                mostPopularLocoResult.Visible = true;
                mostPopularLocoResult.Text = String.Empty;
                foreach (LocomotiveTripsCounter c in locoCounters)
                    if (c.Count == maxValue)
                    {
                        ++sameMeaning;
                        if (mostPopularLocoResult.Text == String.Empty)
                            mostPopularLocoResult.Text += c.Locomotive;
                        else
                            mostPopularLocoResult.Text += ",\n" + c.Locomotive;
                    }


                if (sameMeaning > 1)
                {
                    mostPopularLocoLabel.Text = "Самые популярные локомотивы:";
                    mostPopularLocoResult.Text += $"    (по {maxValue} {TransformWord(maxValue, "поездка")})";
                }
                else
                    mostPopularLocoResult.Text += $"    ({maxValue} {TransformWord(maxValue, "поездка")})";

                int x = mostPopularLocoLabel.Location.X + mostPopularLocoLabel.Width;
                mostPopularLocoResult.Location = new Point(x, mostPopularLocoLabel.Location.Y);
            }
            else
            {
                mostPopularLocoResult.Visible = false;
                mostPopularLocoLabel.Text = "Самый популярный локомотив пока что не выявлен.";
            }
        }

        private string TransformWord(int value, string word)
        {
            return word switch
            {
                "поездка" => value == 1 ? word : (value > 1 && value < 5) ? "поездки" : "поездок",
                "день" => value == 1 ? word : (value > 1 && value < 5) ? "дня" : "дней",
                _ => word
            };
        }

        private void DisplayTotalTripsByLocoSeries()
        {
            totalTripsBySeries.Text = series[seriesCountIndex];

            int y = mostPopularLocoResult.Location.Y + mostPopularLocoResult.Height + 45;
            totalTripsBySeriesLabel.Location = new Point(29, y);

            SetColonLabel2(y);
            int tripsCount = GetTotalTripsBySeriesCount(series[seriesCountIndex]);
            totalTripsBySeriesResult.Text = $"{tripsCount} {TransformWord(tripsCount, "поездка")}";
        }

        private void SetColonLabel2(int y)
        {
            int x = totalTripsBySeriesLabel.Location.X + totalTripsBySeriesLabel.Width;
            totalTripsBySeries.Location = new Point(x, y);

            x += totalTripsBySeries.Width - 5;
            colonLabel2.Location = new Point(x, y);

            x += colonLabel2.Width;
            totalTripsBySeriesResult.Location = new Point(x, y);
        }

        private int GetTotalTripsBySeriesCount(string locoSeries)
        {
            int result = 0;
            string query = "SELECT COUNT(ls.Series) " +
                "FROM Trips t " +
                "INNER JOIN Locomotives l " +
                "ON l.Id=t.Locomotive " +
                "INNER JOIN LocoSeries ls " +
                "ON ls.Id=l.Series " +
                "WHERE UserId=@uId AND ls.Series=@locoSeries";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;
                command.Parameters.Add("@locoSeries", SqliteType.Text).Value = locoSeries;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить количество поездок для серии локомотивов {locoSeries}" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return result;
        }

        private string TransformLocoNumber(int numb)
        {
            return (numb < 10 ? "00" + numb : (numb > 10 && numb < 100) ? "0" + numb : numb.ToString());
        }

        private string GetFirstOrLastTrip()
        {
            string condition = isFirstTrip ? "MIN" : "MAX";
            string query = $"SELECT {condition}(AttendanceTime) FROM Trips WHERE UserId=@uId";
            string result = String.Empty;

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = $"{reader.GetDateTime(0):f}";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить дату {(isFirstTrip ? "первой" : "последней")} поездки" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return result;
        }



        #region Interactive

        private void StatisticsScreenForm_Load(object sender, EventArgs e)
        {
            totalTrips.Text = tripsCount.ToString();

            if (tripsCount > 0)
            {
                GetTripStatistics();
                DisplayTrafficRouteCounter();

                DisplayTotalTravelTime();
                sumWeight.Text = GetSumWeight().ToString();

                locoSeriesLabel.Text = series[seriesIndex];
                locoResultLabel.Text = GetLocoByCondition(locoSeriesLabel.Text);

                GetMostPopularLoco();
                DisplayTotalTripsByLocoSeries();

                int x = label6.Location.X;
                int y = totalTripsBySeriesLabel.Location.Y + 72;

                label6.Location = new Point(x, y);

                x += label6.Width;
                tripStatusLabel.Location = new Point(x, y);

                x += tripStatusLabel.Width;
                tripDateLabel.Location = new Point(x, y);

                x += tripDateLabel.Width;
                tripStatusResult.Location = new Point(x, y);
                tripStatusResult.Text = GetFirstOrLastTrip();
            }
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

        private void locoConditionLabel_Click(object sender, EventArgs e)
        {
            if (tripsCount > 0)
            {
                if (isOldestLoco)
                {
                    isOldestLoco = false;
                    locoConditionLabel.Text = "новый";
                }
                else
                {
                    isOldestLoco = true;
                    locoConditionLabel.Text = "старый";
                }

                locoResultLabel.Text = GetLocoByCondition(locoSeriesLabel.Text);

                int x = locoConditionLabel.Location.X + locoConditionLabel.Width;
                label7.Location = new Point(x, 304);

                x = label7.Location.X + label7.Width;
                locoSeriesLabel.Location = new Point(x, 304);

                SetColonLabel();
            }
        }

        private void locoSeriesLabel_Click(object sender, EventArgs e)
        {
            if (tripsCount > 0)
            {
                ++seriesIndex;
                if (seriesIndex == series.Count)
                    seriesIndex = 0;

                locoSeriesLabel.Text = series[seriesIndex];
                locoResultLabel.Text = GetLocoByCondition(locoSeriesLabel.Text);
                SetColonLabel();
            }
        }

        private void totalTripsBySeries_Click(object sender, EventArgs e)
        {
            if (tripsCount > 0)
            {
                ++seriesCountIndex;
                if (seriesCountIndex == series.Count)
                    seriesCountIndex = 0;

                totalTripsBySeries.Text = series[seriesCountIndex];
                SetColonLabel2(totalTripsBySeries.Location.Y);

                int tripsCount = GetTotalTripsBySeriesCount(series[seriesCountIndex]);
                totalTripsBySeriesResult.Text = $"{tripsCount} {TransformWord(tripsCount, "поездка")}";
            }
        }

        private void tripStatusLabel_Click(object sender, EventArgs e)
        {
            if (tripsCount > 0)
            {
                if (isFirstTrip)
                {
                    isFirstTrip = false;
                    tripStatusLabel.Text = "последней";
                }
                else
                {
                    isFirstTrip = true;
                    tripStatusLabel.Text = "первой";
                }

                int x = tripStatusLabel.Location.X + tripStatusLabel.Width;
                tripDateLabel.Location = new Point(x, tripDateLabel.Location.Y);

                x += tripDateLabel.Width;
                tripStatusResult.Location = new Point(x, tripStatusResult.Location.Y);
                tripStatusResult.Text = GetFirstOrLastTrip();
            }
        }

        #endregion
    }
}
