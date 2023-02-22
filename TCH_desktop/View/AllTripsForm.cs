using Microsoft.Data.Sqlite;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class AllTripsForm : Form
    {
        private SqliteCommand command;
        private SqliteDataReader reader;

        private int userId;
        private StartForm startForm;
        private List<Trip> tripsList = new();
        private List<Train> trainsList = new();
        private List<Locomotive> locomotivesList = new();

        private int tHeight;
        private int offset;

        public AllTripsForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            userId = this.startForm.GetCurrentUserId();
            Location = new Point(630, 120);

            tHeight = tripsTable.Height + 20;
            offset = 0;
        }

        private void GetTrips()
        {
            tripsList.Clear();

            string query = $"SELECT * FROM Trips WHERE UserId=@uId " +
                $"ORDER BY AttendanceTime DESC LIMIT 8 OFFSET @offset";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;
                command.Parameters.Add("@offset", SqliteType.Integer).Value = offset * 8;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tripsList.Add(new Trip
                    {
                        Id = reader.GetInt32(0),
                        AttendanceTime = reader.GetDateTime(1),
                        Locomotive = reader.GetInt32(2),
                        TrafficRoute = reader.GetString(3),
                        ElectricityFactor = reader.IsDBNull(4) ? 0.0f : Convert.ToSingle(reader.GetDouble(4)),
                        Departure = reader.GetString(5),
                        Arrival = reader.GetString(6),
                        PassedStations = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        SpeedLimits = reader.IsDBNull(8) ? "" : reader.GetString(8),
                        ElectricityAmountRequired = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                        ElectricityRecoveryRequired = reader.IsDBNull(10) ? 0.0f :
                            Convert.ToSingle(reader.GetDouble(10)),
                        TechnicalSpeed = reader.IsDBNull(11) ? 0.0f : Convert.ToSingle(reader.GetDouble(11)),
                        Notes = reader.IsDBNull(12) ? "" : reader.GetString(12),
                        Train = reader.GetInt32(13)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список поездок c {offset} по {offset + 8}:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        private void GetTrainsById()
        {
            trainsList.Clear();

            for (int i = 0; i < tripsList.Count; i++)
            {
                string query = $"SELECT * FROM Trains WHERE Id=@trainId";

                try
                {
                    command = DataBase.GetConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.Add("@trainId", SqliteType.Integer).Value = tripsList[i].Train;

                    DataBase.OpenConnection();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        trainsList.Add(new Train
                        {
                            Id = reader.GetInt32(0),
                            Number = reader.GetString(1),
                            Weight = reader.GetInt32(2),
                            Axles = reader.GetInt32(3),
                            SpecificLength = reader.GetInt32(4),
                            TailCar = reader.GetString(5),
                            TrainFixation = reader.GetString(6)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить список поездов по ID:" +
                        $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                        "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                DataBase.CloseConnection();
            }
        }

        private void GetLocoById()
        {
            locomotivesList.Clear();

            for (int i = 0; i < tripsList.Count; i++)
            {
                string query = $"SELECT * FROM Locomotives WHERE Id=@locoId";

                try
                {
                    command = DataBase.GetConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.Add("@locoId", SqliteType.Integer).Value = tripsList[i].Locomotive;

                    DataBase.OpenConnection();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        locomotivesList.Add(new Locomotive
                        {
                            Id = reader.GetInt32(0),
                            LocoType = reader.GetInt32(1),
                            Series = reader.GetInt32(2),
                            Number = reader.GetInt32(3),
                            Allocation = reader.GetString(4),
                            NumberOfBrakeHolders = reader.GetInt32(5),
                            ImagePath = reader.GetString(6)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить список локомотивов по ID:" +
                        $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                        "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                DataBase.CloseConnection();
            }
        }

        private Label AddLabel(string text, int index, int tripId)
        {
            Label newLabel = new Label();
            newLabel.Name = $"{index}_{tripId}";
            newLabel.AutoSize = true;
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.Dock = DockStyle.Fill;
            newLabel.ForeColor = index % 2 == 0 ? Color.Tan : Color.Bisque;
            newLabel.BackColor = Color.Transparent;
            newLabel.Font = new("Lucida Console", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            newLabel.Text = text;
            newLabel.Cursor = Cursors.Hand;

            newLabel.MouseEnter += HoverLabel;
            newLabel.MouseLeave += LeaveLabel;
            newLabel.MouseDoubleClick += ClickTripRow;

            return newLabel;
        }

        private void DisplayTripsData()
        {
            for (int i = 0; i < tripsList.Count; i++)
            {
                AddNewTableRow();

                int tripId = tripsList[i].Id;
                string date = tripsList[i].AttendanceTime.ToString("dd.MM.yy\n(hh:mm)");
                AddNewTableCell(date, i, tripId);

                AddNewTableCell(tripsList[i].TrafficRoute, i, tripId);

                AddNewTableCell(trainsList[i].Number, i, tripId);

                AddNewTableCell(trainsList[i].Weight.ToString(), i, tripId);

                string loco = $"{GetLocoSeries(locomotivesList[i].Series)}-" +
                    $"{GetThreeDigitNumber(locomotivesList[i].Number)}";
                AddNewTableCell(loco, i, tripId);
            }

            int totalCount = GetTotalTripsCount();
            string total = offset == 0 ? String.Empty : $"({offset * 8 + tripsList.Count})";
            currentMessage.Text = $"Показано {tripsList.Count}{total} {TransformWord(tripsList.Count)} " +
                $"из {totalCount}";

            if (totalCount - (tripsList.Count + offset * 8) > 0)
                arrowRight.Visible = true;
            else
                arrowRight.Visible = false;
        }

        private void AddNewTableRow()
        {
            ++tripsTable.RowCount;
            tripsTable.Size = new(tripsTable.Width, tripsTable.Height + tHeight);
            tripsTable.RowStyles.Add(new(SizeType.Percent, 45.0F));
        }

        private void AddNewTableCell(string data, int index, int tripId)
        {
            var label = AddLabel(data, index, tripId);
            tripsTable.Controls.Add(label);
        }

        private string GetLocoSeries(int seriesId)
        {
            string result = String.Empty;
            string query = $"SELECT Series FROM LocoSeries WHERE Id=@sId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@sId", SqliteType.Integer).Value = seriesId;

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
                MessageBox.Show($"Не удалось загрузить серию локомотива по ID:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return result;
        }

        private void DisplayDataTable()
        {
            if (searchByLoco.Text == String.Empty)
                GetTrips();
            else GetTripsByLoco();

            if (tripsList.Count > 0)
            {
                GetTrainsById();
                GetLocoById();

                DisplayTripsData();
            }
        }

        private void ClearTable()
        {
            this.SuspendLayout();

            int numberOfControls = tripsTable.Controls.Count;
            while (numberOfControls > 5)
                tripsTable.Controls.RemoveAt(--numberOfControls);
            tripsTable.RowCount = 1;
            tripsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 32.8F));
            tripsTable.Size = new Size(832, 40);
            tHeight = tripsTable.Height + 20;

            this.ResumeLayout();
        }

        private int GetTotalTripsCount()
        {
            int result = 0;
            string query = $"SELECT COUNT(Id) FROM Trips WHERE UserId=@uId";

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
                MessageBox.Show($"Не удалось загрузить список поездов по ID:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return result;
        }

        public static string TransformWord(int count)
        {
            return count == 1 ? "поездка" :
                count > 1 && count < 5 ? "поездки" : "поездок";
        }

        private void HoverLabel(object? sender, EventArgs e)
        {
            string index = (((Label)sender)?.Name).Substring(0, 1);
            for (int i = 0; i < tripsTable.Controls.Count; i++)
            {
                if ((tripsTable.Controls[i].Name).StartsWith(index))
                {
                    tripsTable.Controls[i].ForeColor = Color.Lime;
                    tripsTable.Controls[i].BackColor = Color.DarkOliveGreen;
                }
            }
        }

        private void LeaveLabel(object? sender, EventArgs e)
        {
            string index = (((Label)sender)?.Name).Substring(0, 1);
            for (int i = 0; i < tripsTable.Controls.Count; i++)
            {
                if ((tripsTable.Controls[i].Name).StartsWith(index))
                {
                    tripsTable.Controls[i].ForeColor = Convert.ToInt32(index) % 2 == 0 ?
                        Color.Tan : Color.Bisque;
                    tripsTable.Controls[i].BackColor = Color.Transparent;
                }
            }
        }

        private void ClickTripRow(object? sender, EventArgs e)
        {
            string name = ((Label)sender)?.Name;
            int tripId = Convert.ToInt32(name.Substring(2));

            TripInfoForm tripInfoForm = new(this, tripId);
            TopMost = true;
            startForm.TopMost = true;
            startForm.Enabled = false;
            Opacity = 60;
            Enabled = false;
            tripInfoForm.Show();

        }

        public string GetThreeDigitNumber(int numb)
        {
            return (numb > 0 && numb < 10) ? "00" + numb :
                (numb > 9 && numb < 100) ? "0" + numb : numb.ToString();
        }

        private void GetTripsByLoco()
        {
            tripsList.Clear();
            string condition = $"'%{searchByLoco.Text}%'";

            string query = $"SELECT t.Id, t.AttendanceTime, t.Locomotive, t.TrafficRoute, " +
                $" t.ElectricityFactor, t.Departure, t.Arrival, t.PassedStations, " +
                $"t.SpeedLimits, t.ElectricityAmountRequired, t.ElectricityRecoveryRequired, " +
                $"t.TechnicalSpeed, t.Notes, t.Train, t.UserId " +
                $"FROM Trips t " +
                $"INNER JOIN Locomotives l " +
                $"ON l.id=t.Locomotive " +
                $"INNER JOIN LocoSeries ls " +
                $"ON ls.id=l.Series " +
                $"WHERE UserId=@uId AND CONCAT(ls.Series, '-', l.Number) LIKE {condition} " +
                $"ORDER BY AttendanceTime DESC LIMIT 8 OFFSET @offset";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = userId;
                command.Parameters.Add("@offset", SqliteType.Integer).Value = offset * 8;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tripsList.Add(new Trip
                    {
                        Id = reader.GetInt32(0),
                        AttendanceTime = reader.GetDateTime(1),
                        Locomotive = reader.GetInt32(2),
                        TrafficRoute = reader.GetString(3),
                        ElectricityFactor = reader.IsDBNull(4) ? 0.0f : Convert.ToSingle(reader.GetDouble(4)),
                        Departure = reader.GetString(5),
                        Arrival = reader.GetString(6),
                        PassedStations = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        SpeedLimits = reader.IsDBNull(8) ? "" : reader.GetString(8),
                        ElectricityAmountRequired = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                        ElectricityRecoveryRequired = reader.IsDBNull(10) ? 0.0f :
                            Convert.ToSingle(reader.GetDouble(10)),
                        TechnicalSpeed = reader.IsDBNull(11) ? 0.0f : Convert.ToSingle(reader.GetDouble(11)),
                        Notes = reader.IsDBNull(12) ? "" : reader.GetString(12),
                        Train = reader.GetInt32(13),
                        UserId = reader.GetInt32(14)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список поездок по номеру локомотива c {offset} " +
                    $"по {offset + 8}:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }



        #region Interactive

        private void AllTripsForm_Load(object sender, EventArgs e)
        {
            DisplayDataTable();
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.clicked_right_arrow;
            ++offset;

            if (!arrowLeft.Visible)
                arrowLeft.Visible = true;

            ClearTable();
            DisplayDataTable();
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            tripsTable.SuspendLayout();

            arrowLeft.Image = Properties.Resources.clicked_left_arrow;
            --offset;

            if (offset <= 0)
            {
                offset = 0;
                arrowLeft.Visible = false;
            }

            ClearTable();
            DisplayDataTable();

            tripsTable.ResumeLayout();
        }

        private void backToStartForm_Click(object sender, EventArgs e)
        {
            startForm.Enabled = true;
            this.Close();
        }

        private void backToStartForm_MouseEnter(object sender, EventArgs e)
        {
            backToStartForm.ForeColor = Color.Yellow;
            backToStartForm.BackColor = Color.DimGray;
        }

        private void backToStartForm_MouseLeave(object sender, EventArgs e)
        {
            backToStartForm.ForeColor = Color.GreenYellow;
            backToStartForm.BackColor = SystemColors.InfoText;
        }

        private void arrowRight_MouseEnter(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.hover_right_arrow;
        }

        private void arrowRight_MouseLeave(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.right_arrow;
        }

        private void arrowLeft_MouseEnter(object sender, EventArgs e)
        {
            arrowLeft.Image = Properties.Resources.hover_left_arrow;
        }

        private void arrowLeft_MouseLeave(object sender, EventArgs e)
        {
            arrowLeft.Image = Properties.Resources.left_arrow;
        }

        private void searchByLoco_TextChanged(object sender, EventArgs e)
        {
            GetTripsByLoco();
            ClearTable();
            DisplayDataTable();
        }

        #endregion

    }
}
