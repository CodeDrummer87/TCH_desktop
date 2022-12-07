using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCH_desktop.Models;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class NewTripForm : Form
    {
        StartForm startForm;

        private List<Station> stationsList = new();

        public NewTripForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
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

        private void backToStartForm_Click(object sender, EventArgs e)
        {
            startForm.Enabled = true;
            startForm.TopMost = false;
            startForm.Opacity = 100;
           
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
