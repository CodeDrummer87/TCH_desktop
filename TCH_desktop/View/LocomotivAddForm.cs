using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class LocomotivAddForm : Form
    {
        private NewTripForm tripForm;

        public LocomotivAddForm(NewTripForm tripForm)
        {
            InitializeComponent();

            this.tripForm = tripForm;
        }

        private void LoadLocoTypeData()
        {
            locoTypeSelect.Items.Clear();
            locoTypeSelect.ResetText();

            string query = "SELECT * FROM LocomotiveTypes ORDER BY LocoType DESC";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    locoTypeSelect.Items.Add(new LocomotiveType
                    {
                        Id = reader.GetInt32(0),
                        LocoType = reader.GetString(1)
                    });
                }
                locoTypeSelect.DisplayMember = "LocoType";
                locoTypeSelect.SelectedIndex = 0;

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить типы локомотивов:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadLocoSeriesData()
        {
            locoSeriesSelect.Items.Clear();
            locoSeriesSelect.ResetText();

            string query = "SELECT * FROM LocoSeries WHERE LocoType=@locType ORDER BY SeriesFirst";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                LocomotiveType locType = (LocomotiveType)locoTypeSelect.SelectedItem;
                command.Parameters.Add("@locType", SqlDbType.Int).Value = locType?.Id;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    locoSeriesSelect.Items.Add(new LocomotiveSeries
                    {
                        Id = reader.GetInt32(0),
                        SeriesFirst = reader.GetString(1),
                        lIndex = reader.GetString(2),
                        isUpperIndex = reader.GetByte(3),
                        SeriesSecond = reader.GetString(4),
                        LocoType = reader.GetInt32(5)
                    });
                }
                locoSeriesSelect.DisplayMember = "SeriesFirst";
                locoSeriesSelect.SelectedIndex = 0;

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить серии локомотивов:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        #region Interactive

        private void LocomotivAddForm_Activated(object sender, EventArgs e)
        {
            LoadLocoTypeData();
            LoadLocoSeriesData();
        }

        private void locoTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadLocoSeriesData();
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
            cancelButton.ForeColor = Color.YellowGreen;
            cancelButton.BackColor = SystemColors.InfoText;
        }

        private void addNewLocoButton_MouseEnter(object sender, EventArgs e)
        {
            addNewLocoButton.ForeColor = Color.Yellow;
            addNewLocoButton.BackColor = Color.DimGray;
        }

        private void addNewLocoButton_MouseLeave(object sender, EventArgs e)
        {
            addNewLocoButton.ForeColor = Color.YellowGreen;
            addNewLocoButton.BackColor = SystemColors.InfoText;
        }

        private void brakeHoldersTrackBar_Scroll(object sender, EventArgs e)
        {
            brakeHoldersValue.Text = brakeHoldersTrackBar.Value.ToString();
        }

        private void locoImageBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new();

            fDialog.Title = "Фотография локомотива";
            fDialog.Filter = "Файлы изображений(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    locoImageBox.Image = new Bitmap(fDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Невозможно загрузить файл: {ex.Message}",
                        "Ошибка загрузки изображения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion
    }
}
