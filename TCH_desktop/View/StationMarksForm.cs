using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class StationMarksForm : Form
    {
        private int panelCount;
        NewTripForm tripForm;
        private List<Station> stationsList = new();

        public StationMarksForm(NewTripForm tripForm_)
        {
            InitializeComponent();

            this.tripForm = tripForm_;
            panelCount = 1;
        }

        private Panel CreateNewPanel()
        {
            Panel panel = new();
            panel.Size = new(370, 55);

            ComboBox stationSelect = new();
            stationSelect.Name = "select";
            stationSelect.Size = new(225, 24);
            stationSelect.Location = new Point(2, 15);
            stationSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            stationSelect.Cursor = Cursors.Hand;

            for (int i = 0; i < stationsList.Count; i++)
                stationSelect.Items.Add(stationsList[i]);

            stationSelect.DisplayMember = "Title";
            stationSelect.SelectedIndex = 0;

            DateTimePicker timePicker = new();
            timePicker.Name = "picker";
            timePicker.Size = new(100, 27);
            timePicker.Location = new(230, 15);
            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = " HH:MM";
            timePicker.Cursor = Cursors.Hand;

            panel.Controls.Add(stationSelect);
            panel.Controls.Add(timePicker);

            return panel;
        }

        private void LoadAvailableStations()
        {
            stationsList.Clear();

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



        #region Interactive

        private void StationMarksForm_Load(object sender, EventArgs e)
        {
            LoadAvailableStations();
        }

        private void addNewStation_MouseEnter(object sender, EventArgs e)
        {
            addNewStation.ForeColor = Color.GreenYellow;
        }

        private void addNewStation_MouseLeave(object sender, EventArgs e)
        {
            addNewStation.ForeColor = Color.Yellow;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            cancelButton.ForeColor = Color.Yellow;
            cancelButton.BackColor = Color.DimGray;
        }

        private void cancelButton_MouseLeave(object sender, EventArgs e)
        {
            cancelButton.ForeColor = Color.GreenYellow;
            cancelButton.BackColor = SystemColors.InfoText;
        }

        private void addPastStationButton_MouseEnter(object sender, EventArgs e)
        {
            addPastStationButton.ForeColor = Color.Yellow;
            addPastStationButton.BackColor = Color.DimGray;
        }

        private void addPastStationButton_MouseLeave(object sender, EventArgs e)
        {
            addPastStationButton.ForeColor = Color.GreenYellow;
            addPastStationButton.BackColor = SystemColors.InfoText;
        }

        private void addNewStation_Click(object sender, EventArgs e)
        {
            if (panelCount < 11)
            {
                Panel panel = CreateNewPanel();

                int x = addNewStation.Location.X + 5;
                int y = addNewStation.Location.Y - 17;
                panel.Location = new(x, y);

                groupBox.Controls.Add(panel);
                if (panelCount == 5)
                {
                    x = 427;
                    y = -23;
                }
                addNewStation.Location = new(x - 5, y + 75);

                (panel.Controls["select"] as ComboBox).DroppedDown = true;
                panelCount++;
                if (panelCount > 10) addNewStation.Visible = false;
            }
        }

        #endregion
    }
}
