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
    public partial class UserDataSettingForm : Form
    {
        StartForm startForm;
        AuthForm authForm;

        public UserDataSettingForm(StartForm stForm, AuthForm authForm)
        {
            InitializeComponent();
            startForm = stForm;
            this.authForm = authForm;

            contactingTheUser.Text = "Добро пожаловать в ТЧ!\n" +
                "Пожалуйста, заполните поля ниже для завершения регистрации";
            contactingTheUser.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 16, true);

            saveUserDataButton.Font = cancelButton.Font = 
                Source.LoadFont(@".\source\fonts\zekton.ttf", 10, true);

            personDataGroupBox.Font = employeeDataGroupBox.Font =
                Source.LoadFont(@".\source\fonts\zekton.ttf", 12, true);

            this.Show();
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            authForm.Close();
        }

        private void UserDataSettingForm_Load(object sender, EventArgs e)
        {
            LoadAvailableRailroads();
        }

        private void LoadAvailableRailroads()
        {
            List<Railroad> railroads = new List<Railroad>();

            string query = "SELECT * FROM Railroads";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    railroads.Add(new Railroad
                    {
                        Id = reader.GetInt32(0),
                        FullTitle = reader.GetString(1),
                        Abbreviation = reader.GetString(2),
                        Code = reader.GetString(3)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список доступных железных дорог:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                for (int i = 0; i < railroads.Count; i++)
                {
                    railRoads.Items.Add(railroads[i].FullTitle);
                }

                railRoads.SelectedItem = railroads[4].FullTitle;
            }
        }
    }
}
