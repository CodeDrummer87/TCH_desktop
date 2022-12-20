using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class LocomotivAddForm : Form
    {
        private bool isReadyReader;
        private NewTripForm tripForm;

        public LocomotivAddForm(NewTripForm tripForm)
        {
            InitializeComponent();

            this.tripForm = tripForm;
            isReadyReader = false;
        }

        private void LoadLocoTypeData()
        {
            locoTypeSelect.Items.Clear();
            locoTypeSelect.ResetText();

            string query = "SELECT * FROM LocomotiveTypes ORDER BY LocoType DESC";

            try
            {
                isReadyReader = false;
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
                isReadyReader = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить типы локомотивов:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadLocoSeriesData()
        {
            locoSeriesSelect.Items.Clear();
            locoSeriesSelect.ResetText();

            string query = "SELECT * FROM LocoSeries WHERE LocoType=@locType ORDER BY Series";

            try
            {
                isReadyReader = false;
                SqlCommand command = new(query, DataBase.GetConnection());
                LocomotiveType locType = (LocomotiveType)locoTypeSelect.SelectedItem;
                command.Parameters.Add("@locType", SqlDbType.Int).Value = locType.Id;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    locoSeriesSelect.Items.Add(new LocomotiveSeries
                    {
                        Id = reader.GetInt32(0),
                        Series = reader.GetString(1),
                        LocoType = reader.GetInt32(2)
                    });
                }
                locoSeriesSelect.DisplayMember = "Series";
                locoSeriesSelect.SelectedIndex = 0;

                reader.Close();
                DataBase.CloseConnection();
                isReadyReader = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить серии локомотивов:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadAllocationData()
        {
            allocationSelect.Items.Clear();
            allocationSelect.ResetText();

            string query =  "SELECT	CONCAT(d.ShortTitle, ' (', r.Abbreviation, ')') 'allocation'"  
                            + "FROM LocomotiveDepots d "
                            + "INNER JOIN Railroads r "
                            + "ON r.Id = d.Railroad";

            try
            {
                isReadyReader = false;
                SqlCommand command = new(query, DataBase.GetConnection());
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    allocationSelect.Items.Add(reader.GetString(0));
                }
                allocationSelect.DisplayMember = "allocation";
                allocationSelect.SelectedIndex = 0;

                reader.Close();
                DataBase.CloseConnection();
                isReadyReader = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить серии локомотивов:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private Locomotive GetDataFromFields()
        {
            return new Locomotive
            {
                LocoType = ((LocomotiveType)locoTypeSelect.SelectedItem).Id,
                Series = ((LocomotiveSeries)locoSeriesSelect.SelectedItem).Id,
                Number = Convert.ToInt32(locoNumberInp.Text.Trim()),
                Allocation = allocationSelect.Text,
                NumberOfBrakeHolders = brakeHoldersTrackBar.Value,
                ImagePath = String.Empty //.:: temporary code
            };
        }

        private void SaveLocomotiveData(Locomotive loco)
        {
            string query = "INSERT Locomotives VALUES(@locType, @series, @numb, @alloc, @brakeHolders, @iPath)";

            try
            {
                isReadyReader = false;
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@locType", SqlDbType.Int).Value = loco.LocoType;
                command.Parameters.Add("@series", SqlDbType.Int).Value = loco.Series;
                command.Parameters.Add("@numb", SqlDbType.Int).Value = loco.Number;
                command.Parameters.Add("@alloc", SqlDbType.NVarChar).Value = loco.Allocation;
                command.Parameters.Add("@brakeHolders", SqlDbType.Int).Value = loco.NumberOfBrakeHolders;
                command.Parameters.Add("@iPath", SqlDbType.NVarChar).Value = loco.ImagePath;
                DataBase.OpenConnection();

                command.ExecuteNonQuery();
                DataBase.CloseConnection();
                isReadyReader = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить данные по локомотиву:\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        #region Interactive

        private void LocomotivAddForm_Load(object sender, EventArgs e)
        {
            LoadLocoTypeData();
            LoadLocoSeriesData();
            LoadAllocationData();
        }

        private void locoTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isReadyReader) LoadLocoSeriesData();
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

        private void addNewLocoButton_Click(object sender, EventArgs e)
        {
            Locomotive locomotive = GetDataFromFields();
            SaveLocomotiveData(locomotive);

            tripForm.Enabled = true;
            this.Close();
        }

        #endregion
    }
}
