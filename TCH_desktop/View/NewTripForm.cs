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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список доступных станций:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
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
            }
            catch (Exception ex)
            {
                string trafficLightDir = isEvenDirection ? "чётных" : "нечётных";

                MessageBox.Show($"Не удалось загрузить список {trafficLightDir} светофоров:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
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

        private int GetLocoId(string loco)
        {
            if (loco != String.Empty)
            {
                int index = loco.IndexOf('-');
                string series = loco.Substring(0, index);
                int seriesId = GetSeriesId(series);

                index++;
                string numberStr = loco.Substring(index);
                int number = Convert.ToInt32(numberStr);

                int locoId = 0;
                string query = "SELECT Id FROM Locomotives WHERE Series=@sId and Number=@number";

                try
                {
                    SqlCommand command = new(query, DataBase.GetConnection());
                    command.Parameters.Add("@sId", SqlDbType.Int).Value = seriesId;
                    command.Parameters.Add("@number", SqlDbType.Int).Value = number;
                    DataBase.OpenConnection();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        locoId = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось получить Id локомотива:\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                DataBase.CloseConnection();
                return locoId;
            }
            else
            {
                MessageBox.Show($"Не указан локомотив, на котором совершена поездка", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return 0;
            }
        }

        private int GetSeriesId(string series)
        {
            int seriesId = 0;
            string query = "SELECT Id FROM LocoSeries WHERE Series=@s";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@s", SqlDbType.NVarChar).Value = series;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    seriesId = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить Id серии локомотива:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return seriesId;
        }

        private int SaveTrainData(int brakeHolders)
        {
            string query = "INSERT Trains VALUES(@numb, @weight, @axles, @length, @tail, @fixation)";

            string fixation = String.Empty;
            float weight = 0;
            float axles = 0;

            if (!singleLoco.Checked && trainMass.Text != String.Empty && trainAxles.Text != String.Empty)
            { 
                weight = Convert.ToInt32(trainMass.Text);
                axles = Convert.ToInt32(trainAxles.Text);

                int k = (int)(weight / axles);
                float value = k < 7 ? (weight / 400) : (weight * 0.8f / 400);
                int trainFixation = GetRequiredTrainFixation(value);

                if (trainFixation > brakeHolders)
                    fixation = $"{brakeHolders}ТБ и {trainFixation - brakeHolders}РТ";
                else
                    fixation = $"{trainFixation}ТБ";
            }

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@numb", SqlDbType.NChar).Value = trainNumber.Text;
                command.Parameters.Add("@weight", SqlDbType.NChar).Value = weight;
                command.Parameters.Add("@axles", SqlDbType.NChar).Value = axles;
                command.Parameters.Add("@length", SqlDbType.NChar).Value = !singleLoco.Checked ? 
                    trainSpecificLength.Text : 0;
                command.Parameters.Add("@tail", SqlDbType.NChar).Value = !singleLoco.Checked ? 
                    trainTailCar.Text : 0;
                command.Parameters.Add("@fixation", SqlDbType.NVarChar).Value = !singleLoco.Checked ?
                    fixation : 0;

                DataBase.OpenConnection();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить данные поезда в Базу Данных:\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return GetLastId("Trains");
        }

        private int GetRequiredTrainFixation(double value)
        {
            string valStr = value.ToString();
            int index = valStr.IndexOf(',');    
            float tenths = Convert.ToSingle(value.ToString().Substring(0, index + 2));

            float remainder = tenths - (int)value;
            return remainder > 0.0F ? (int)++value : (int)value; 
        }

        private int GetLastId(string table)
        {
            int Id = 0;

            string query = $"SELECT MAX(Id) FROM {table}";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Id = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить ID последней записи в таблице \"Поезда\":\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return Id;
        }

        private int GetBrakeHolders(int locoId)
        {
            int brakeHolders = 0;

            string query = "SELECT NumberOfBrakeHolders FROM Locomotives WHERE Id=@locoId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@locoId", SqlDbType.Int).Value = locoId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    brakeHolders = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить значение количества тормозных башмаков на " +
                    $"локомотиве:\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return brakeHolders;
        }

        private void SaveBrakeTests(int tripId)
        {
            if (brakeTests.Count > 0)
            {
                string query = "INSERT TripsBrakeTests VALUES(@tripId, @brakeTest)";

                for (int i = 0; i < brakeTests.Count; i++)
                {
                    try
                    {
                        SqlCommand command = new(query, DataBase.GetConnection());
                        command.Parameters.Add("@tripId", SqlDbType.Int).Value = tripId;
                        command.Parameters.Add("@brakeTest", SqlDbType.NVarChar).Value = brakeTests[i];
                        DataBase.OpenConnection();

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось сохранить пробы тормозов текущей поездки в Базу Данных:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для устранения ошибки.",
                                "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    DataBase.CloseConnection();
                }
            }
        }

        private string CheckData(string data) => data == String.Empty ? "н/у" : data;

        private bool CheckValuesForCalc(string condition)
        {
            return condition switch
            {
                "elAmount" => (distanceTextBox.Text != String.Empty && trainMass.Text != String.Empty &&
                electricityFactorTextBox.Text != String.Empty),

                _ => (distanceTextBox.Text != String.Empty && trainMass.Text != String.Empty &&
                elRecoveryFactorTextBox.Text != String.Empty)
            };
        }

        private float GetTechSpeed(string notes_)
        {
            this.TopMost = startForm.TopMost = false;

            string departureTime = departureTimePicker.Value.Hour.ToString() + ':'
                + departureTimePicker.Value.Minute;
            string arrivalTime = arrivalTimePicker.Value.Hour.ToString() + ':'
                + arrivalTimePicker.Value.Minute;

            if (arrivalTime != departureTime)
            {
                int tripTimeInMinutes = GetMinutes(departureTime, arrivalTime);

                if ((notes_.Contains("стоянки") || notes_.Contains("остановки")) && notes_.Contains("||"))
                {
                    int index = notes_.IndexOf("||");
                    string newNotes = notes_.Substring(index - 6);

                    string addDepTime = String.Empty;
                    string addArrivalTime = String.Empty;

                    while (newNotes.Contains("||"))
                    {
                        index = newNotes.IndexOf("||");
                        addDepTime = newNotes.Substring(index - 6, 5);
                        addArrivalTime = newNotes.Substring(index + 3, 5);

                        tripTimeInMinutes -= GetMinutes(addDepTime, addArrivalTime);

                        newNotes = newNotes.Substring(index + 3);
                    }
                }

                float tripTimeInHours = (float)tripTimeInMinutes / 60;
                float distance = distanceTextBox.Text != String.Empty ? Convert.ToSingle(distanceTextBox.Text) : 0.0F;

                return distance / tripTimeInHours;
            }

            return 0.0F;
        }

        private int GetMinutes(string from, string to)
        {
            int fHour;
            int fMin;
            ParseTimeString(from, out fHour, out fMin);

            int tHour;
            int tMin;
            ParseTimeString(to, out tHour, out tMin);

            int totalHours = 0;
            int totalMinutes;

            if (tHour != fHour)
            {
                while (tHour != fHour)
                {
                    tHour = SubtractAnHour(tHour);
                    ++totalHours;
                }

                totalMinutes = totalHours * 60 - fMin + tMin;
            }
            else
                totalMinutes = tMin - fMin;

            return totalMinutes;
        }

        private void ParseTimeString(string time, out int hours, out int minutes)
        {
            int length = time.Length;
            int index = time.IndexOf(":");
            hours = Convert.ToInt32(time.Substring(0, index));
            minutes = Convert.ToInt32(time.Substring(++index, length - index));
        }

        private int SubtractAnHour(int hour) => --hour == -1 ? 23 : hour;



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

            trainMass.Focus();
        }

        private void departureStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departureTrafficLight.Enabled)
            {
                int trainNumb = Convert.ToInt32(trainNumber.Text.Trim());
                LoadAvailableTrafficLights(trainNumb % 2 == 0, ((Station)(departureStation.SelectedItem)).Id);
                SetTrafficLightsComboBox(departureTrafficLight);
            }

            distanceTextBox.Focus();
        }

        private void arrivalStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (arrivalTrafficLight.Enabled)
            {
                int trainNumb = Convert.ToInt32(trainNumber.Text.Trim());
                LoadAvailableTrafficLights(trainNumb % 2 == 0, ((Station)(arrivalStation.SelectedItem)).Id);
                SetTrafficLightsComboBox(arrivalTrafficLight);
            }
            distanceTextBox.Focus();
        }

        private void backToStartForm_Click(object sender, EventArgs e)
        {
            startForm.Enabled = true;
            this.Close();
        }

        private void labelMouseEnter(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.Yellow;
            label_.BackColor = Color.DimGray;
        }

        private void labelMouseLeave(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.YellowGreen;
            label_.BackColor = SystemColors.InfoText;
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

        private void anotherLabelMouseEnter(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.LightCoral;
            label_.BorderStyle = BorderStyle.FixedSingle;
        }

        private void anotherLabelMouseLeave(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.Red;
            label_.BorderStyle = BorderStyle.None;
        }

        private void checkKeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)   // ASCII: 8 = Backspace
                e.Handled = true;
        }

        private void checkKeyPressForFactor(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            TextBox field = sender as TextBox;
            if (ch == ',' && field.Text.IndexOf(',') != -1)
                e.Handled = true;

            if (ch == ',' && field.Text.Length < 1)
                e.Handled = true;

            if (!Char.IsDigit(ch) && ch != 8 && ch != ',')
                e.Handled = true;
        }

        private void addBrakeTest_Click(object sender, EventArgs e)
        {
            BrakeTestForm brakeTestForm = new(this, Convert.ToInt32(trainNumber.Text));
            TopMost = true;
            Opacity = 60;
            Enabled = false;
            brakeTestForm.Show();
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

        private void saveDataTrip_Click(object sender, EventArgs e)
        {
            this.TopMost = startForm.TopMost = false;

            if (trainNumber.Text != String.Empty && locoNumbStr != String.Empty 
                && distanceTextBox.Text != String.Empty)
            {
                int locoId = GetLocoId(locoNumbStr);
                DateTime attendaceTime = attendanceTimePicker.Value;
                string trafficRoute = departureStation.Text + " - " + arrivalStation.Text;

                string departure = departureTimePicker.Value.Hour.ToString() + ':' + departureTimePicker.Value.Minute
                    + "\n(" + CheckData(departureTrafficLight.Text) + ')';
                string arrival = arrivalTimePicker.Value.Hour.ToString() + ':' + arrivalTimePicker.Value.Minute
                    + "\n(" + CheckData(arrivalTrafficLight.Text) + ')';

                string pStations = String.Empty;
                if (pastStations.Count > 0)
                    foreach (string s in pastStations)
                        pStations += s + ';';

                int brakeHolders = GetBrakeHolders(locoId);
                int trainId = SaveTrainData(brakeHolders);

                string elFactor = electricityFactorTextBox.Text != String.Empty ?
                    electricityFactorTextBox.Text.Replace('.', ',') : "0.0";
                string elAmountReq = elAmountRequiredValue.Text != String.Empty ? 
                    elAmountRequiredValue.Text : "0";
                string elRecoveryReq = elRecoveryRequiredValue.Text != String.Empty ?
                    elRecoveryRequiredValue.Text : "0.0";

                if (elRecoveryReq != "0.0")
                {
                    int ind = elRecoveryReq.IndexOf(',');
                    elRecoveryReq = elRecoveryReq.Substring(0, ind + 2);
                }

                string techSpeed = GetTechSpeed(notes).ToString();
                int index = techSpeed.IndexOf(',');
                int length = techSpeed.Length;
                techSpeed = index + 2 <= length ? techSpeed.Substring(0, index + 2) : techSpeed;

                string query = "INSERT INTO Trips (AttendanceTime, Locomotive, TrafficRoute, " +
                    "ElectricityFactor, Departure, Arrival, PassedStations, SpeedLimits, " +
                    "ElectricityAmountRequired, ElectricityRecoveryRequired, TechnicalSpeed, Notes, Train, UserId) " +
                    "VALUES (@atTime, @locoId, @route, @eF, @dep, @arr, @pasSt, @spLim, " +
                    "@elAmountRequired, @elRecoveryRequired, @techSp, @notes, @trainId, @userId)";

                try
                {
                    SqlCommand command = new(query, DataBase.GetConnection());
                    command.Parameters.Add("@atTime", SqlDbType.DateTime).Value = attendaceTime;
                    command.Parameters.Add("@locoId", SqlDbType.Int).Value = locoId;
                    command.Parameters.Add("@route", SqlDbType.NVarChar).Value = trafficRoute;
                    command.Parameters.Add("@eF", SqlDbType.Float).Value = elFactor;
                    command.Parameters.Add("@dep", SqlDbType.NVarChar).Value = departure;
                    command.Parameters.Add("@arr", SqlDbType.NVarChar).Value = arrival;
                    command.Parameters.Add("@pasSt", SqlDbType.NVarChar).Value = pStations;
                    command.Parameters.Add("@spLim", SqlDbType.NVarChar).Value = limits;
                    command.Parameters.Add("@elAmountRequired", SqlDbType.Int).Value = elAmountReq;
                    command.Parameters.Add("@elRecoveryRequired", SqlDbType.Float).Value = elRecoveryReq;
                    command.Parameters.Add("@techSp", SqlDbType.Float).Value = techSpeed;
                    command.Parameters.Add("@notes", SqlDbType.NVarChar).Value = notes;
                    command.Parameters.Add("@trainId", SqlDbType.Int).Value = trainId;
                    command.Parameters.Add("@userId", SqlDbType.Int).Value = startForm.GetCurrentUserId();
                    DataBase.OpenConnection();

                    command.ExecuteNonQuery();

                    int tripId = GetLastId("Trips");
                    SaveBrakeTests(tripId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось сохранить данные поездки в Базу Данных:\n\"{ex.Message}\"\n" +
                            $"Обратитесь к системному администратору для устранения ошибки.",
                            "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                DataBase.CloseConnection();
                startForm.Enabled = true;
                startForm.wasSavedTrip = true;
                this.Close();
            }
            else
            {
                string message = "Невозможно сохранить данные о поездке";
                if (trainNumber.Text == String.Empty && locoNumbStr != String.Empty && distanceTextBox.Text != String.Empty)
                    message += ": не указан номер поезда.";
                else if (trainNumber.Text != String.Empty && locoNumbStr == String.Empty && distanceTextBox.Text != String.Empty)
                    message += ": не указан локомотив.";
                else if (trainNumber.Text != String.Empty && locoNumbStr != String.Empty && distanceTextBox.Text == String.Empty)
                    message += ": не указана длина обслуживаемого участка";
                else message += ": не указаны номер поезда и локомотив, а также длина обслуживаемого участка";
                MessageBox.Show(message, "Не указаны важные сведения о поездке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void radioButton_CheckedChanged(object? sender, EventArgs e)
        {
            RadioButton rButton = (RadioButton)sender;
            if (rButton.Checked)
            {
                if (rButton.Text == "Следование резервом")
                {
                    trainMass.Enabled = trainAxles.Enabled = trainSpecificLength.Enabled =
                        trainTailCar.Enabled = false;

                    trainMass.BackColor = trainAxles.BackColor = trainSpecificLength.BackColor = 
                        trainTailCar.BackColor = SystemColors.InactiveCaption;

                    label8.ForeColor = label9.ForeColor = label10.ForeColor = label11.ForeColor = Color.Gray;
                }
                else
                {
                    trainMass.Enabled = trainAxles.Enabled = trainSpecificLength.Enabled =
                        trainTailCar.Enabled = true;

                    trainMass.BackColor = trainAxles.BackColor = trainSpecificLength.BackColor =
                        trainTailCar.BackColor = SystemColors.Window;

                    label8.ForeColor = label9.ForeColor = label10.ForeColor = label11.ForeColor = Color.GreenYellow;
                }
            }
        }

        private void CalcElectricityAmount(object sender, EventArgs e)
        {
            if (CheckValuesForCalc("elAmount"))
            {
                float k = Convert.ToSingle(electricityFactorTextBox.Text.Replace('.', ','));
                float weight = Convert.ToSingle(trainMass.Text);
                float distance = Convert.ToSingle(distanceTextBox.Text);

                float value = (k * weight * distance / 1000000);
                float remainder = value - (int)value;

                remainder = Convert.ToSingle(remainder.ToString().Substring(0, 3));
                elAmountRequiredValue.Text = (remainder > 0.0 ? (int)(++value) : (int)value).ToString();
            }
        }

        private void distanceTextBox_Leave(object sender, EventArgs e)
        {
            trainNumber.Focus();
        }

        private void trainTailCar_Leave(object sender, EventArgs e)
        {
            electricityFactorTextBox.Focus();
        }

        private void ClearTextBox(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            tBox.Text = String.Empty;
        }

        private void CalcElectricityRecoveryRequired(object sender, EventArgs e)
        {
            if (CheckValuesForCalc("elRecovery"))
            {
                float k = Convert.ToSingle(elRecoveryFactorTextBox.Text.Replace('.', ','));
                float weight = Convert.ToSingle(trainMass.Text);
                float distance = Convert.ToSingle(distanceTextBox.Text);

                float value = (k * weight * distance / 1000000);
                int index = value.ToString().IndexOf(',');

                float hundredths = Convert.ToSingle(value.ToString().Substring(0, index + 3));
                float tenths = Convert.ToSingle(value.ToString().Substring(0, index + 2));

                float remainder = hundredths - tenths;
                float tenRemainder = tenths - (int)value;

                elRecoveryRequiredValue.Text = ((remainder > 0.00F && tenRemainder > 0.0F) ?
                    tenths += 0.1F : tenths).ToString();
            }
        }

        private void CalcElectricityIndicators(object sender, EventArgs e)
        {
            CalcElectricityAmount(sender, e);
            CalcElectricityRecoveryRequired(sender, e);
        }

        #endregion
    }
}
