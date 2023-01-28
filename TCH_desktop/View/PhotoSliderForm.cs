﻿using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;
using System.Data.SqlClient;

namespace TCH_desktop.View
{
    public partial class PhotoSliderForm : Form
    {
        private TripInfoForm tripInfoForm;

        private int currentIndex;
        private List<string> files = new();
        private string directoryPath = String.Empty;

        public PhotoSliderForm(TripInfoForm tripInfoForm, string directoryPath)
        {
            InitializeComponent();

            this.tripInfoForm = tripInfoForm;

            if (Directory.Exists(directoryPath))
            {
                this.directoryPath = directoryPath;
                files = new List<string>(Directory.GetFiles(this.directoryPath));
            }

            DisplayLastPhoto();
        }

        private int GetIndex(int index) => 
            index > files.Count() - 1 ? 0 : index < 0 ? files.Count() - 1 : index;

        private bool RemovePhoto(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                if (CheckDefaultPhoto(path))
                {
                    DialogResult result = MessageBox.Show("Данная фотография установлена как заставка." +
                        "\nВсё равно удалить фотографию?", "Внимание!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        UpdateImagePathForLoco(path);
                        file.Delete();
                        return true;
                    }
                }
                else
                {
                    file.Delete();
                    return true;
                }
            }

            return false;
        }

        private void DisplayLastPhoto()
        {
            currentIndex = GetIndex(files.Count() - 1);
            mainSpace.ImageLocation = files[currentIndex];
        }

        private bool CheckDefaultPhoto(string path)
        {
            string query = "SELECT * FROM Locomotives WHERE ImagePath=@imgPath";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@imgPath", SqlDbType.VarChar).Value = path;

                DataTable table = new();
                DataBase.adapter.SelectCommand = command;
                DataBase.adapter.Fill(table);
                DataBase.CloseConnection();

                return table.Rows.Count == 1 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка при попытке проверить фото по умолчанию:" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }
        }

        private void UpdateImagePathForLoco(string path)
        {
            string query = "UPDATE Locomotives SET ImagePath='' WHERE ImagePath=@imgPath";

            try
            { 
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@imgPath", SqlDbType.VarChar).Value = path;
                DataBase.OpenConnection();

                command.ExecuteNonQuery();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось перезаписать путь к файлу для данного локомотива\n\"{ex.Message}" +
                    $"\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        #region Interactive

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close_hover;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            tripInfoForm.Enabled = true;
            tripInfoForm.Opacity = 85;
            Close();
            Dispose();
        }

        private void arrowRight_MouseEnter(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right_hover;
        }

        private void arrowRight_MouseLeave(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right;
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            currentIndex = GetIndex(++currentIndex);
            mainSpace.ImageLocation = files[currentIndex];
        }

        private void arrowLeft_MouseEnter(object sender, EventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left_hover;
        }

        private void arrowLeft_MouseLeave(object sender, EventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left;
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            currentIndex = GetIndex(--currentIndex);
            mainSpace.ImageLocation = files[currentIndex];
        }

        private void addButton_MouseEnter(object sender, EventArgs e)
        {
            addButton.Image = Properties.Resources.add_hover;
        }

        private void addButton_MouseLeave(object sender, EventArgs e)
        {
            addButton.Image = Properties.Resources.add;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new();

            fDialog.Title = "Фотография локомотива";
            fDialog.Filter = "Файлы изображений(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo file = new FileInfo(fDialog.FileName);

                    int index = directoryPath.LastIndexOf(@"\");
                    string loco = directoryPath.Substring(index + 1);

                    string newPhoto = directoryPath + $"\\{loco + '(' + files.Count() + ')'}{file.Extension}";
                    DirectoryInfo dir = new(newPhoto);
                    file.CopyTo(dir.FullName, true);

                    files.Add(newPhoto);
                    DisplayLastPhoto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Невозможно загрузить файл: {ex.Message}",
                        "Ошибка загрузки изображения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void removeButton_MouseEnter(object sender, EventArgs e)
        {
            removeButton.Image = Properties.Resources.remove_hover;
        }

        private void removeButton_MouseLeave(object sender, EventArgs e)
        {
            removeButton.Image = Properties.Resources.remove;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить фотографию?", "Внимание!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (RemovePhoto(files[currentIndex]))
                {
                    files.RemoveAt(currentIndex);

                    if (files.Count() > 0)
                        arrowRight_Click(sender, e);
                    else
                    {
                        tripInfoForm.SetDisplaySlider(false);
                        closeButton_Click(sender, e);
                    }
                }
            }
        }

        private void arrowLeft_MouseDown(object sender, MouseEventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left_click;
        }

        private void arrowLeft_MouseUp(object sender, MouseEventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left_hover;
        }

        private void arrowRight_MouseDown(object sender, MouseEventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right_click;
        }

        private void arrowRight_MouseUp(object sender, MouseEventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right_hover;
        }

        private void setDefaultPhotoButton_MouseEnter(object sender, EventArgs e)
        {
            setDefaultPhotoButton.Image = Properties.Resources.hover_check;
        }

        private void setDefaultPhotoButton_MouseLeave(object sender, EventArgs e)
        {
            setDefaultPhotoButton.Image = Properties.Resources.check;
        }

        private void setDefaultPhotoButton_Click(object sender, EventArgs e)
        {
            
        }

        #endregion
    }
}
