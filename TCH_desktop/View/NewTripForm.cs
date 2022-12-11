using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class NewTripForm : Form
    {
        StartForm startForm;

        private List<Station> stationsList = new();
        private List<TrafficLight> trafficLightsList = new();

        public NewTripForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            this.startForm.Enabled = false;
            this.startForm.TopMost = true;
            this.startForm.Opacity = 60;
            Location = new Point(630, 120);

            backToStartForm.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 11, true);
            saveDataTrip.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 11, true);
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

        #region Interactive

        private void NewTripForm_Activated(object sender, EventArgs e)
        {
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
            }
            else
            {
                EnableFields(false);
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
            startForm.Opacity = 100;
            startForm.TopMost = false;
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

        #endregion
    }
}
