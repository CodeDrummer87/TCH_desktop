using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class StationMarksForm : Form
    {
        private int panelCount;
        NewTripForm tripForm;
        private List<Station> stationsList = new();
        private bool isEdit;
        private string editNumb;

        public StationMarksForm(NewTripForm tripForm_)
        {
            InitializeComponent();

            this.tripForm = tripForm_;
            panelCount = 0;
            isEdit = false;
            editNumb = String.Empty;
        }

        private Panel CreateNewPanel()
        {
            Panel panel = new();
            panel.Name = "panel" + ++panelCount;
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
            timePicker.CustomFormat = "HH:mm";
            timePicker.Cursor = Cursors.Hand;
            timePicker.Leave += new System.EventHandler(CreateEntry);
            timePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeyPress);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список доступных станций:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }



        #region Interactive

        private void StationMarksForm_Load(object sender, EventArgs e)
        {
            tripForm.pastStations.Clear();
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
            tripForm.pastStations.Clear();

            tripForm.Enabled = true;
            Close();
            Dispose();
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

            label_.ForeColor = Color.GreenYellow;
            label_.BackColor = SystemColors.InfoText;
        }

        private void addNewStation_Click(object sender, EventArgs e)
        {
            removeEntry.Visible = false;

            if (panelCount < 10)
            {
                addNewStation.Visible = false;
                Panel panel = CreateNewPanel();

                int x = addNewStation.Location.X + 5;
                int y = addNewStation.Location.Y - 17;
                panel.Location = new(x, y);

                groupBox.Controls.Add(panel);

                tabTip.Visible = true;
                tabTip.Location = new(x, y + 45);

                if (panelCount == 5)
                {
                    x = 427;
                    y = -23;
                }

                if (panelCount < 10)
                    addNewStation.Location = new(x - 5, y + 75);
                else if (panelCount >= 10)
                    addNewStation.Visible = false;

                (panel.Controls["select"] as ComboBox).DroppedDown = true;
            }
        }

        private void CreateEntry(object? sender, EventArgs e)
        {
            if (!isEdit)
            {
                addNewStation.Visible = true;
                removeEntry.Visible = true;
                tabTip.Visible = false;

                Label entry = new();
                entry.Name = "entry" + (panelCount);
                entry.Size = new(387, 25);
                entry.TextAlign = ContentAlignment.MiddleCenter;
                entry.ForeColor = Color.Gold;

                Panel panel = groupBox.Controls["panel" + (panelCount)] as Panel;
                ComboBox station = panel.Controls["select"] as ComboBox;
                DateTimePicker time = panel.Controls["picker"] as DateTimePicker;

                string hour = time.Value.Hour < 10 ? "0" + time.Value.Hour : (time.Value.Hour).ToString();
                string minute = time.Value.Minute < 10 ? "0" + time.Value.Minute : (time.Value.Minute).ToString();
                string text = $"ст.{((Station)station.SelectedItem).Title} в {hour}:{minute}";
                entry.Text = text;
                tripForm.pastStations.Add(text);
                
                entry.Location = new(panel.Location.X - 7, panel.Location.Y + 17);
                entry.Cursor = Cursors.Hand;
                entry.Click += new System.EventHandler(ChangeEntry);

                panel.Visible = false;
                groupBox.Controls.Add(entry);

                int x = panelCount > 5 ? 800 : 400;
                removeEntry.Location = new(x, entry.Location.Y + 4);
                if (!removeEntry.Visible) removeEntry.Visible = true;
            }
            else
            {
                Label entry = groupBox.Controls["entry" + editNumb] as Label;
                Panel panel = groupBox.Controls["panel" + editNumb] as Panel;
                ComboBox station = panel.Controls["select"] as ComboBox;
                DateTimePicker time = panel.Controls["picker"] as DateTimePicker;

                string hour = time.Value.Hour < 10 ? "0" + time.Value.Hour : (time.Value.Hour).ToString();
                string minute = time.Value.Minute < 10 ? "0" + time.Value.Minute : (time.Value.Minute).ToString();
                string text = $"ст.{((Station)station.SelectedItem).Title} в {hour}:{minute}";
                entry.Text = text;
                int index = Convert.ToInt32(editNumb) - 1;
                tripForm.pastStations[index] = text;

                panel.Visible = false;
                entry.Visible = true;
                isEdit = false;
                editNumb = String.Empty;
                removeEntry.Visible = true;
            }

            if (panelCount >= 10) addNewStation.Visible = false;
            else addNewStation.Visible = true;
        }

        private void ChangeEntry(object? sender, EventArgs e)
        {
            isEdit = true;
            addNewStation.Visible = false;
            removeEntry.Visible = false;

            Label entry = sender as Label;
            string number = entry.Name.Remove(0, 5);
            entry.Visible = false;
            editNumb = number;

            Panel panel = groupBox.Controls["panel" + number] as Panel;
            panel.Visible = true;
        }

        private void removeEntry_MouseEnter(object sender, EventArgs e)
        {
            removeEntry.ForeColor = Color.LightCoral;
            removeEntry.BorderStyle = BorderStyle.FixedSingle;
        }

        private void removeEntry_MouseLeave(object sender, EventArgs e)
        {
            removeEntry.ForeColor = Color.Red;
            removeEntry.BorderStyle = BorderStyle.None;
        }

        private void removeEntry_Click(object sender, EventArgs e)
        {
            Label entry = groupBox.Controls["entry" + panelCount] as Label;
            Panel panel = groupBox.Controls["panel" + panelCount] as Panel;

            groupBox.Controls.Remove(panel);
            groupBox.Controls.Remove(entry);

            tripForm.pastStations.RemoveAt(--panelCount);

            Label prevEntry = groupBox.Controls["entry" + panelCount] as Label;
            int x = 19;
            int y = addNewStation.Location.Y;
            if (panelCount == 9)
            {
                x = 427;
                y += 58;
                addNewStation.Visible = true;
            }
            else if (panelCount >= 5 && panelCount < 9)
                x = 427;
            else if (panelCount == 4)
                y = 342;

            addNewStation.Location = new(x, y - 58);

            if (panelCount > 0)
                removeEntry.Location = new(prevEntry.Location.X + prevEntry.Width - 10, prevEntry.Location.Y + 4);
            else removeEntry.Visible = false;
        }

        private void CheckKeyPress(object? sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (number == 13)
                CreateEntry(sender, e);

        }

        private void addPastStationButton_Click(object sender, EventArgs e)
        {
            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        #endregion
    }
}
