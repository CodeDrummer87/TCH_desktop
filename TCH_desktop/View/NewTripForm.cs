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
        public List<string> brakeTests = new();
        public List<string> pastStations = new();
        public string limits;
        public string notes;

        public NewTripForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            Location = new Point(630, 120);
            locoNumbStr = String.Empty;
            limits = String.Empty;
            notes = String.Empty;   
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

        private void DisplayBrakeTest()
        {
            if (brakeTests.Count == 0)
            {
                doubleTrain.Enabled = true;
                ResetBrakeTestInfo();
            }
            else
            {
                doubleTrain.Enabled = false;

                addBrakeTestLabel.Text = "Проба тормозов: ";
                addBrakeTestLabel.Location = new(261, addBrakeTestLabel.Location.Y);
                brakeTestInfo.Text = "Основная проба";
                if (brakeTests.Count > 1)
                {
                    int testsNumber = brakeTests.Count - 1;
                    brakeTestInfo.Text += $" + {testsNumber} доп. {AdaptTheWord(testsNumber)}";
                }
                brakeTestInfo.Location = new(428, brakeTestInfo.Location.Y);
                brakeTestInfo.Visible = true;
                addBrakeTest.Visible = false;
                int x = brakeTestInfo.Location.X + brakeTestInfo.Width + 2;
                removeBrakeTest.Location = new(x, brakeTestInfo.Location.Y + 3);
                removeBrakeTest.Visible = true;              
            }
        }

        private string AdaptTheWord(int number)
        {
            return number == 1 ? "проба" :
                (number > 1 && number < 5) ? "пробы" : "проб";
        }

        private void ResetBrakeTestInfo()
        {
            addBrakeTestLabel.Text = "Добавить пробу тормозов: ";
            addBrakeTestLabel.Location = new(171, addBrakeTestLabel.Location.Y);
            brakeTestInfo.Visible = false;
            addBrakeTest.Visible = true;
            removeBrakeTest.Visible = false;
        }

        private void DisplayPastStations()
        {
            if (pastStations.Count == 0)
            {
                addPassedStations.Visible = true;
                pastStationsInfo.Visible = false;
                removePastStations.Visible = false;
            }
            else
            {
                addPassedStations.Visible = false;

                int number = pastStations.Count;
                string word = number == 1 ? " станция" :
                    (number > 1 && number < 5) ? " станции" : " станций";

                pastStationsInfo.Text = pastStations.Count + word;
                pastStationsInfo.Location = new(428, label14.Location.Y + 2);
                pastStationsInfo.Visible = true;

                int x = pastStationsInfo.Location.X + pastStationsInfo.Width + 2;
                int y = pastStationsInfo.Location.Y + 3;
                removePastStations.Location = new(x, y);
                removePastStations.Visible = true;
            }
        }

        private void DisplayLimits()
        {
            if (limits.Length == 0)
            {
                addSpeedLimits.Visible = true;
                speedLimitsInfo.Visible = false;
                removeSpeedLimits.Visible = false;
            }
            else
            {
                addSpeedLimits.Visible = false;
                speedLimitsInfo.Text = "имеются";
                speedLimitsInfo.Location = new(428, label15.Location.Y + 2);
                speedLimitsInfo.Visible = true;

                int x = speedLimitsInfo.Location.X + speedLimitsInfo.Width + 2;
                int y = speedLimitsInfo.Location.Y + 3;
                removeSpeedLimits.Location = new(x, y);
                removeSpeedLimits.Visible = true;
            }
        }

        private void DisplayNotes()
        {
            if (notes.Length == 0)
            {
                addNotes.Visible = true;
                notesInfo.Visible = false;
                removeNotes.Visible = false;
            }
            else
            {
                addNotes.Visible = false;
                notesInfo.Text = "имеются";
                notesInfo.Location = new(428, label16.Location.Y + 2);
                notesInfo.Visible = true;

                int x = notesInfo.Location.X + notesInfo.Width + 2;
                int y = notesInfo.Location.Y + 3;
                removeNotes.Location = new(x, y);
                removeNotes.Visible = true;
            }
        }


        #region Interactive

        private void NewTripForm_Activated(object sender, EventArgs e)
        {
            bool isDisplayLocoNumb = locoNumbStr == String.Empty ? false : true;
            DisplayLocoNumber(isDisplayLocoNumb);

            DisplayBrakeTest();
            DisplayPastStations();
            DisplayLimits();
            DisplayNotes();
        }

        private void NewTripForm_Load(object sender, EventArgs e)
        {
            Opacity = 80;
            departureStation.Items.Clear();
            departureStation.ResetText();
            arrivalStation.Items.Clear();
            arrivalStation.ResetText();

            LoadAvailableStations();
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

            trainNumber.Focus();

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
            BrakeTestForm brakeTestForm = new(this, Convert.ToInt32(trainNumber.Text));
            TopMost = true;
            Opacity = 60;
            Enabled = false;
            brakeTestForm.Show();
        }

        private void removeBrakeTest_MouseEnter(object sender, EventArgs e)
        {
            removeBrakeTest.ForeColor = Color.LightCoral;
            removeBrakeTest.BorderStyle = BorderStyle.FixedSingle;
        }

        private void removeBrakeTest_MouseLeave(object sender, EventArgs e)
        {
            removeBrakeTest.ForeColor = Color.Red;
            removeBrakeTest.BorderStyle = BorderStyle.None;
        }

        private void removeBrakeTest_Click(object sender, EventArgs e)
        {
            doubleTrain.Enabled = true;
            ResetBrakeTestInfo();
        }

        private void removePastStations_Click(object sender, EventArgs e)
        {
            pastStations.Clear();

            removePastStations.Visible = false;
            pastStationsInfo.Visible = false;
            addPassedStations.Visible = true;
        }

        private void removeSpeedLimits_Click(object sender, EventArgs e)
        {
            limits = String.Empty;

            removeSpeedLimits.Visible = false;
            speedLimitsInfo.Visible = false;
            addSpeedLimits.Visible = true;
        }

        private void removeNotes_Click(object sender, EventArgs e)
        {
            notes = String.Empty;

            removeNotes.Visible = false;
            notesInfo.Visible = false;
            addNotes.Visible = true;
        }

        #endregion

    }
}
