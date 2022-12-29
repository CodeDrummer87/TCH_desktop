using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class NewTripForm : Form
    {
        private StartForm startForm;
        private List<Station> stationsList = new();
        private List<TrafficLight> trafficLightsList = new();

        public string locoNumbStr;

        public NewTripForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            Location = new Point(630, 120);
            locoNumbStr = String.Empty;
        }

        private void LoadAvailableStations()
        {
            stationsList.Clear();
            departureStation.Items.Clear();
            arrivalStation.Items.Clear();
            departureStation.ResetText();
            arrivalStation.ResetText();

            string query = "SELECT * FROM Stations ORDER BY Title";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    stationsList.Add(new Station
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Railroad = reader.GetInt32(2),
                        Code = reader.GetString(3)
                    });
                }
                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список доступных станций:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void EnableFields(bool value)
        {
            departureTimePicker.Enabled = value;
            departureTrafficLight.Enabled = value;

            arrivalTimePicker.Enabled = value;
            arrivalTrafficLight.Enabled = value;
        }

        private void LoadAvailableTrafficLights(bool isEvenDirection, int stationId)
        {
            trafficLightsList.Clear();

            string query = "SELECT * FROM TrainModeTrafficLights t "
                            + "INNER JOIN Stations s "
                            + "ON s.id = t.Station "
                            + "WHERE s.id = @stationId AND IsEvenDirection = @isEvenDir";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@stationId", SqlDbType.Int).Value = stationId;
                command.Parameters.Add("@isEvenDir", SqlDbType.Bit).Value = isEvenDirection ? 1 : 0;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    trafficLightsList.Add(new TrafficLight
                    {
                        Id = reader.GetInt32(0),
                        IsEvenDirection = reader.GetByte(1),
                        Title = reader.GetString(2),
                        Station = reader.GetInt32(3),
                    });
                }
                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                string trafficLightDir = isEvenDirection ? "чётных" : "нечётных";

                MessageBox.Show($"Не удалось загрузить список {trafficLightDir} светофоров:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SetTrafficLightsComboBox(ComboBox box)
        {
            if (trafficLightsList.Count > 0)
            {
                box.Items.Clear();
                box.ResetText();

                for (int i = 0; i < trafficLightsList.Count; i++)
                    box.Items.Add(trafficLightsList[i]);

                box.DisplayMember = "Title";
                box.SelectedIndex = 0;
            }
        }

        private void DisplayLocoNumber(bool isDisplay)
        {
            if (isDisplay)
            {
                addLocomotive.Visible = false;
                locoNumber.Text = locoNumbStr;
                locoNumber.Visible = true;
                locoNumber.Location = new Point(700, 57);

                removeLocomotive.Visible = true;
                removeLocomotive.Location = 
                    new Point(locoNumber.Location.X + locoNumber.Width, 59);
            }
            else
            {
                locoNumber.Text = String.Empty;
                locoNumber.Visible = false;
                addLocomotive.Visible = true;

                removeLocomotive.Visible = false;
            }
        }

        private void LoadSuitableBrakeTests()
        {
            brakeTestsSelect.Items.Clear();
            brakeTestsSelect.ResetText();

            int isEven = (Convert.ToInt32(trainNumber.Text) % 2) == 0 ? 1 : 0;
            string query = "SELECT * FROM BrakeTests WHERE IsEvenNumberedDirection = @isEven AND RequiredSpeed != '-'";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@isEven", SqlDbType.Int).Value = isEven;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    brakeTestsSelect.Items.Add(new BrakeTest
                    {
                        Id = reader.GetInt32(0),
                        Depot = reader.GetInt32(1),
                        IsEvenNumberedDirection = reader.GetByte(2),
                        RailwayLine = reader.GetString(3),
                        RequiredSpeed = reader.GetString(4),
                        Point = reader.GetString(5),
                        RequiredSpeedForDoubleTrain = reader.GetString(6),
                        PointForDoubleTrain = reader.GetString(7)
                    });
                }
                reader.Close();
                DataBase.CloseConnection();

                brakeTestsSelect.DisplayMember = "RailwayLine";
                brakeTestsSelect.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                string trafficLightDir = isEven == 1 ? "чётных" : "нечётных";

                MessageBox.Show($"Не удалось загрузить список мест проб тормозов {trafficLightDir}" +
                    $" поездов:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        #region Interactive

        private void NewTripForm_Activated(object sender, EventArgs e)
        {
            Opacity = 80;

            LoadAvailableStations();
            departureStation.Items.Clear();
            departureStation.ResetText();
            arrivalStation.Items.Clear();
            arrivalStation.ResetText();

            if (stationsList.Count > 0)
            {
                for (int i = 0; i < stationsList.Count; i++)
                {
                    departureStation.Items.Add(stationsList[i]);
                    arrivalStation.Items.Add(stationsList[i]);
                }

                departureStation.DisplayMember = arrivalStation.DisplayMember = "Title";
                departureStation.SelectedIndex = arrivalStation.SelectedIndex = 0;
            }

            bool isDisplayLocoNumb = locoNumbStr == String.Empty ? false : true;
            DisplayLocoNumber(isDisplayLocoNumb);
        }

        private void trainNumber_Leave(object sender, EventArgs e)
        {
            if (trainNumber.Text.Trim() != String.Empty)
            {
                EnableFields(true);

                int trainNumb = Convert.ToInt32(trainNumber.Text.Trim());
                LoadAvailableTrafficLights(trainNumb % 2 == 0, ((Station)(departureStation.SelectedItem)).Id);
                SetTrafficLightsComboBox(departureTrafficLight);

                LoadAvailableTrafficLights(trainNumb % 2 == 0, ((Station)(arrivalStation.SelectedItem)).Id);
                SetTrafficLightsComboBox(arrivalTrafficLight);

                if (!addBrakeTest.Enabled)
                    addBrakeTest.Enabled = true;
                LoadSuitableBrakeTests();
            }
            else
            {
                EnableFields(false);
                addBrakeTest.Enabled = false;
            }
        }

        private void departureStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departureTrafficLight.Enabled)
            {
                int trainNumb = Convert.ToInt32(trainNumber.Text.Trim());
                LoadAvailableTrafficLights(trainNumb % 2 == 0, ((Station)(departureStation.SelectedItem)).Id);
                SetTrafficLightsComboBox(departureTrafficLight);
            }
        }

        private void arrivalStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (arrivalTrafficLight.Enabled)
            {
                int trainNumb = Convert.ToInt32(trainNumber.Text.Trim());
                LoadAvailableTrafficLights(trainNumb % 2 == 0, ((Station)(arrivalStation.SelectedItem)).Id);
                SetTrafficLightsComboBox(arrivalTrafficLight);
            }
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
            backToStartForm.ForeColor = Color.YellowGreen;
            backToStartForm.BackColor = SystemColors.InfoText;
        }

        private void saveDataTrip_MouseEnter(object sender, EventArgs e)
        {
            saveDataTrip.ForeColor = Color.Yellow;
            saveDataTrip.BackColor = Color.DimGray;
        }

        private void saveDataTrip_MouseLeave(object sender, EventArgs e)
        {
            saveDataTrip.ForeColor = Color.YellowGreen;
            saveDataTrip.BackColor = SystemColors.InfoText;
        }

        private void addLocomotive_MouseEnter(object sender, EventArgs e)
        {
            addLocomotive.ForeColor = Color.Yellow;
            addLocomotive.BackColor = Color.DimGray;
        }

        private void addLocomotive_MouseLeave(object sender, EventArgs e)
        {
            addLocomotive.ForeColor = Color.YellowGreen;
            addLocomotive.BackColor = SystemColors.InfoText;
        }

        private void addPassedStations_MouseEnter(object sender, EventArgs e)
        {
            addPassedStations.ForeColor = Color.Yellow;
            addPassedStations.BackColor = Color.DimGray;
        }

        private void addPassedStations_MouseLeave(object sender, EventArgs e)
        {
            addPassedStations.ForeColor = Color.YellowGreen;
            addPassedStations.BackColor = SystemColors.InfoText;
        }

        private void addSpeedLimits_MouseEnter(object sender, EventArgs e)
        {
            addSpeedLimits.ForeColor = Color.Yellow;
            addSpeedLimits.BackColor = Color.DimGray;
        }

        private void addSpeedLimits_MouseLeave(object sender, EventArgs e)
        {
            addSpeedLimits.ForeColor = Color.YellowGreen;
            addSpeedLimits.BackColor = SystemColors.InfoText;
        }

        private void addNotes_MouseEnter(object sender, EventArgs e)
        {
            addNotes.ForeColor = Color.Yellow;
            addNotes.BackColor = Color.DimGray;
        }

        private void addNotes_MouseLeave(object sender, EventArgs e)
        {
            addNotes.ForeColor = Color.YellowGreen;
            addNotes.BackColor = SystemColors.InfoText;
        }

        private void addLocomotive_Click(object sender, EventArgs e)
        {
            LocomotivAddForm locoAddForm = new(this);
            TopMost = true;
            Opacity = 60;
            Enabled = false;
            locoAddForm.Show();
        }

        private void addPassedStations_Click(object sender, EventArgs e)
        {
            StationMarksForm stationMarksForm = new(this);
            TopMost = true;
            Opacity = 60;
            Enabled = false;
            stationMarksForm.Show();
        }

        private void addSpeedLimits_Click(object sender, EventArgs e)
        {
            SpeedLimitsForm speedLimitsForm = new(this);
            TopMost = true;
            Opacity = 60;
            Enabled = false;
            speedLimitsForm.Show();
        }

        private void addNotes_Click(object sender, EventArgs e)
        {
            NotesForm notesForm = new(this);
            TopMost = true;
            Opacity = 60;
            Enabled = false;
            notesForm.Show();
        }

        private void removeLocomotive_Click(object sender, EventArgs e)
        {
            locoNumbStr = String.Empty;
            DisplayLocoNumber(false);
        }

        private void removeLocomotive_MouseEnter(object sender, EventArgs e)
        {
            removeLocomotive.ForeColor = Color.LightCoral;
            removeLocomotive.BorderStyle = BorderStyle.FixedSingle;
        }

        private void removeLocomotive_MouseLeave(object sender, EventArgs e)
        {
            removeLocomotive.ForeColor = Color.Red;
            removeLocomotive.BorderStyle = BorderStyle.None;
        }

        private void trainNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void trainMass_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void trainAxles_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void trainSpecificLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void trainTailCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void addBrakeTest_MouseEnter(object sender, EventArgs e)
        {
            addBrakeTest.ForeColor = Color.Yellow;
            addBrakeTest.BackColor = Color.DimGray;
        }

        private void addBrakeTest_MouseLeave(object sender, EventArgs e)
        {
            addBrakeTest.ForeColor = Color.YellowGreen;
            addBrakeTest.BackColor = SystemColors.InfoText;
        }

        private void addBrakeTest_Click(object sender, EventArgs e)
        {
            if (trainNumber.Text != String.Empty)
            {
                brakeTestsSelect.Location = new Point(195, 500);
                brakeTestsSelect.Visible = true;
                addBrakeTestLabel.Visible = false;
                addBrakeTest.Visible = false;
            }
        }

        private void brakeTestsSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            BrakeTest test = (BrakeTest)brakeTestsSelect.SelectedItem;

            if (brakeTestsSelect.Visible)
            {
                brakeTest.Text = $"ПТ(с {test.RequiredSpeed.Trim()} км/ч) " +
                    $"{test.RailwayLine} <{test.Point.Trim()} км.>";
                brakeTest.Location = new Point(150, 500);
                brakeTestsSelect.Visible = false;
                brakeTest.Visible = true;
                //addBrakeTest.Location = new Point(brakeTest.Location.X + brakeTest.Width + 1,500);
                //addBrakeTest.Visible = true;
            }
        }

        private void brakeTest_Click(object sender, EventArgs e)
        {
            brakeTest.Visible = false;
            brakeTestsSelect.Visible = true;
        }

        #endregion
    }
}
