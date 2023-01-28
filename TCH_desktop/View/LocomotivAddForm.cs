using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;
using System.IO;

namespace TCH_desktop.View
{
    public partial class LocomotivAddForm : Form
    {
        private bool isReadyReader;
        private NewTripForm tripForm;
        private string tempImageFullName;
        private bool isExistLoco;

        public LocomotivAddForm(NewTripForm tripForm)
        {
            InitializeComponent();

            this.tripForm = tripForm;
            isReadyReader = false;
            tempImageFullName = String.Empty;
            isExistLoco = false;
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
                locoSeriesSelect.SelectedIndex = 1;

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

            string query =  "SELECT	CONCAT(d.ShortTitle, ', ', r.Abbreviation) 'allocation'"  
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
                ImagePath = SaveLocomotivePhoto()
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

        private string SaveLocomotivePhoto()
        {
            string currentDir = Environment.CurrentDirectory;
            string photoFullName = String.Empty;

            DirectoryInfo dir = new(currentDir);
            if (!Directory.Exists(currentDir + @"\Фотографии"))
                dir.CreateSubdirectory("Фотографии");

            dir = new(currentDir + @"\Фотографии");

            string locoType = ((LocomotiveType)(locoTypeSelect.SelectedItem)).LocoType;
            if (!Directory.Exists(dir + @"\" + locoType + 'ы'))
                dir.CreateSubdirectory(locoType + 'ы');

            dir = new(dir + @"\" + locoType + 'ы');

            string locoSeries = ((LocomotiveSeries)(locoSeriesSelect.SelectedItem)).Series;
            if (!Directory.Exists(dir + @"\" + locoSeries))
                dir.CreateSubdirectory(locoSeries);

            dir = new(dir + @"\" + locoSeries);

            string seriesNumber = $"{locoSeries}-{locoNumberInp.Text}";
            if (!Directory.Exists(dir + @"\" + seriesNumber))
                dir.CreateSubdirectory(seriesNumber);

            dir = new(dir + @"\" + seriesNumber);

            if (tempImageFullName != String.Empty)
            {
                FileInfo locoPhoto = new(tempImageFullName);

                dir = new(dir + $"\\{locoSeries}-{locoNumberInp.Text}{locoPhoto.Extension}");
                locoPhoto.CopyTo(dir.FullName, true);

                locoPhoto = new(dir.FullName);
                locoImageBox.Image = new Bitmap(locoPhoto.FullName);
                photoFullName = dir.FullName;
            }

            return photoFullName;
        }

        private string TransformLocoNumber(string numb)
        {
            int n = Convert.ToInt32(numb);
            string number = n < 10 ? "00" + n : (n >= 10 && n < 100) ? "0" + n : n.ToString();

            return number;
        }

        private bool CheckLocoForExist()
        {
            int typeId = ((LocomotiveType)locoTypeSelect.SelectedItem).Id;
            int seriesId = ((LocomotiveSeries)locoSeriesSelect.SelectedItem).Id;
            int number = Convert.ToInt32(locoNumberInp.Text);

            string query = "SELECT * FROM Locomotives WHERE LocoType =@lT AND Series = @lS AND Number = @lN";

            try
            {
                isReadyReader = false;
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@lT", SqlDbType.Int).Value = typeId;
                command.Parameters.Add("@lS", SqlDbType.Int).Value = seriesId;
                command.Parameters.Add("@lN", SqlDbType.Int).Value = number;

                DataTable table = new();
                DataBase.adapter.SelectCommand = command;
                DataBase.adapter.Fill(table);
                DataBase.CloseConnection();

                isReadyReader = true;
                return table.Rows.Count == 1 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при попытке проверить наличие локомотива в Базе Данных:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }
        }

        private void ApplyLocoPhoto()
        {
            string type = ((LocomotiveType)locoTypeSelect.SelectedItem).LocoType;
            string series = ((LocomotiveSeries)locoSeriesSelect.SelectedItem).Series;
            int number = Convert.ToInt32(locoNumberInp.Text);

            string path = Environment.CurrentDirectory + @$"\Фотографии\{type}ы\{series}";
            FileInfo image = new(path + $@"\{series}-{number}.jpg");

            if (image.Exists)
            {
                locoImageBox.Image = new Bitmap(path + $@"\{series}-{number}.jpg");
            }
            else
                locoImageBox.Image = Properties.Resources.addLocoImg;
        }

        private void SetDefaultControl(bool flag)
        {
            if (flag)
            {
                addNewLocoButton.Text = "Выбрать";
                allocationSelect.Enabled = false;
                brakeHoldersTrackBar.Enabled = false;
            }
            else
            {
                addNewLocoButton.Text = "Добавить";
                allocationSelect.Enabled = true;
                brakeHoldersTrackBar.Enabled = true;
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
                    tempImageFullName = fDialog.FileName;
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
            if (!isExistLoco) SaveLocomotiveData(locomotive);

            string number = TransformLocoNumber(locoNumberInp.Text);
            tripForm.locoNumbStr = ((LocomotiveSeries)locoSeriesSelect.SelectedItem).Series + '-' + number;
            tripForm.Enabled = true;
            this.Close();
        }

        private void locoNumberInp_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void locoNumberInp_TextChanged(object sender, EventArgs e)
        {
            int locoNumber = locoNumberInp.Text == String.Empty ? 0 : Convert.ToInt32(locoNumberInp.Text);

            if (locoNumber > 0)
            {
                locoImageBox.Enabled = true;
                locoImageBox.BorderStyle = BorderStyle.FixedSingle;
                addNewLocoButton.Enabled = true;

                isExistLoco = CheckLocoForExist();
                SetDefaultControl(isExistLoco);
                
                ApplyLocoPhoto();
            }
            else
            {
                locoImageBox.Enabled = false;
                locoImageBox.BorderStyle = BorderStyle.None;
                addNewLocoButton.Enabled = false;

                SetDefaultControl(false);
            }
        }

        #endregion
    }
}
