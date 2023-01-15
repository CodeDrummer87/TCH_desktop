using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class AllTripsForm : Form
    {
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
            Location = new Point(630, 120);

            tHeight = tripsTable.Height + 20;
            offset = 0;
        }

        private void GetTrips()
        {
            tripsList.Clear();

            string query = $"SELECT * FROM Trips ORDER BY AttendanceTime DESC OFFSET @offset ROWS FETCH NEXT 8 ROWS ONLY";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@offset", SqlDbType.Int).Value = offset;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tripsList.Add(new Trip
                    {
                        Id = reader.GetInt32(0),
                        AttendanceTime = reader.GetDateTime(1),
                        Locomotive = reader.GetInt32(2),
                        TrafficRoute = reader.GetString(3),
                        ElectricityFactor = reader.IsDBNull(4) ? 0.0f : reader.GetFloat(4),
                        Departure = reader.GetString(5),
                        Arrival = reader.GetString(6),
                        PassedStations = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        SpeedLimits = reader.IsDBNull(8) ? "" : reader.GetString(8),
                        ElectricityAmountRequired = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                        ElectricityRecoveryRequired = reader.IsDBNull(10) ? 0.0f : reader.GetFloat(10),
                        TechnicalSpeed = reader.IsDBNull(11) ? 0.0f : reader.GetFloat(11),
                        Notes = reader.IsDBNull(12) ? "" : reader.GetString(12),
                        Train =reader.GetInt32(13)
                    });
                }
                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список поездок c {offset} по {offset + 5}:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void GetTrainsById()
        {
            trainsList.Clear();

            for (int i = 0; i < tripsList.Count; i++)
            {
                string query = $"SELECT * FROM Trains WHERE Id=@trainId";

                try
                {
                    SqlCommand command = new(query, DataBase.GetConnection());
                    command.Parameters.Add("@trainId", SqlDbType.Int).Value = tripsList[i].Train;
                    DataBase.OpenConnection();

                    SqlDataReader reader = command.ExecuteReader();
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
                    DataBase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить список поездов по ID:" +
                        $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                        "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
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
                    SqlCommand command = new(query, DataBase.GetConnection());
                    command.Parameters.Add("@locoId", SqlDbType.Int).Value = tripsList[i].Locomotive;
                    DataBase.OpenConnection();

                    SqlDataReader reader = command.ExecuteReader();
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
                    DataBase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить список локомотивов по ID:" +
                        $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                        "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private Label AddLabel(string text, int index)
        {
            Label newLabel = new Label();
            newLabel.AutoSize = true;
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.Dock = DockStyle.Fill;
            newLabel.ForeColor = index % 2 == 0 ? Color.Tan : Color.Bisque;
            newLabel.BackColor = Color.Transparent;
            newLabel.Font = new("Lucida Console", 10.0F, FontStyle.Bold, GraphicsUnit.Point);
            newLabel.Text = text;

            return newLabel;
        }

        private void DisplayTripsData()
        {
            for (int i = 0; i < tripsList.Count; i++)
            {
                AddNewTableRow();

                string date = tripsList[0].AttendanceTime.ToString("dd.MM.yy\n(hh:mm)");
                AddNewTableCell(date, i);

                AddNewTableCell(tripsList[i].TrafficRoute, i);

                AddNewTableCell(trainsList[i].Number, i);

                AddNewTableCell(trainsList[i].Weight.ToString(), i);

                string loco = $"{GetLocoSeries(locomotivesList[i].Series)}-{locomotivesList[i].Number}";
                AddNewTableCell(loco, i);
            }
        }

        private void AddNewTableRow()
        {
            ++tripsTable.RowCount;
            tripsTable.Size = new(tripsTable.Width, tripsTable.Height + tHeight);
            tripsTable.RowStyles.Add(new(SizeType.Percent, 45.0F));
        }

        private void AddNewTableCell(string data, int index)
        {
            var trainNumb = AddLabel(data, index);
            tripsTable.Controls.Add(trainNumb);
        }

        private string GetLocoSeries(int seriesId)
        {
            string result = String.Empty;
            string query = $"SELECT Series FROM LocoSeries WHERE Id=@sId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@sId", SqlDbType.Int).Value = seriesId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }
                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить серию локомотива по ID:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return result;
        }



        #region Interactive

        private void AllTripsForm_Load(object sender, EventArgs e)
        {
            GetTrips();
            if (tripsList.Count > 0)
            {
                GetTrainsById();
                GetLocoById();
            }

            if (tripsList.Count > 0)
                DisplayTripsData();
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

        #endregion
    }
}
