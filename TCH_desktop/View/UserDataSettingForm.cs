using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class UserDataSettingForm : Form
    {
        StartForm startForm;
        AuthForm authForm;

        private List<Railroad> railroads = new ();
        private List<LocomotiveDepot> locoDepots = new ();
        private List<Position> positionsList = new ();
        private List<Column> columnsList = new ();

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
            if (railroads.Count > 0)
            {
                for (int i = 0; i < railroads.Count; i++)
                    railRoads.Items.Add(railroads[i]);

                railRoads.DisplayMember = "FullTitle";
                railRoads.SelectedIndex = 4;
            }

            LoadAvailableLocomotiveDepots();
            if (locoDepots.Count > 0)
            {
                for (int i = 0; i < locoDepots.Count; i++)
                    depot.Items.Add(locoDepots[i]);

                depot.DisplayMember = "ShortTitle";
                depot.SelectedIndex = 0;
            }

            LoadAvailablePositions();
            if (positionsList.Count > 0)
            {
                for (int i = 0; i < positionsList.Count; i++)
                    positions.Items.Add(positionsList[i]);

                positions.DisplayMember = "FullName";
                positions.SelectedIndex = 0;
            }

            LoadAvailableColumns();
            if (columnsList.Count > 0)
            {
                for (int i = 0; i < columnsList.Count; i++)
                    columns.Items.Add(columnsList[i]);

                columns.DisplayMember = "ColumnNumber";
                columns.SelectedIndex = 0;
            }
        }

        private void LoadAvailableRailroads()
        {
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
        }

        private void LoadAvailableLocomotiveDepots()
        {
            locoDepots.Clear();
            depot.Items.Clear();
            depot.ResetText();

            string query = "SELECT * FROM LocomotiveDepots WHERE Railroad=@Id";
            Railroad railroad = (Railroad)railRoads.SelectedItem;

            if (railroad != null)
            {
                try
                {
                    SqlCommand command = new(query, DataBase.GetConnection());
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = railroad?.Id;
                    DataBase.OpenConnection();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        locoDepots.Add(new LocomotiveDepot
                        {
                            Id = reader.GetInt32(0),
                            Railroad = reader.GetInt32(1),
                            ShortTitle = reader.GetString(2),
                            FullTitle = reader.GetString(3),
                            Address = reader.GetString(4),
                            Code = reader.GetString(5)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить список локомотивных депо:\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void railRoads_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadAvailableLocomotiveDepots();
            if (locoDepots.Count > 0)
            {
                for (int i = 0; i < locoDepots.Count; i++)
                    depot.Items.Add(locoDepots[i]);

                depot.DisplayMember = "ShortTitle";
                depot.SelectedIndex = 0;
            }
            else depot.Text = "список пуст";

            AddColumnsItems();
        }

        private void LoadAvailablePositions()
        {
            string query = "SELECT * FROM Positions";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    positionsList.Add(new Position
                    {
                        Id = reader.GetInt32(0),
                        FullName = reader.GetString(1),
                        Abbreviate = reader.GetString(2)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список доступных должностей:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadAvailableColumns()
        {
            columnsList.Clear();
            columns.Items.Clear();
            columns.ResetText();

            string query = "SELECT * FROM Columns WHERE Depot=@Id";
            LocomotiveDepot currentDepot = (LocomotiveDepot)depot.SelectedItem;

            if (currentDepot != null)
            {
                try
                {
                    SqlCommand command = new(query, DataBase.GetConnection());
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = currentDepot?.Id;
                    DataBase.OpenConnection();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        columnsList.Add(new Column
                        {
                            Id = reader.GetInt32(0),
                            ColumnNumber = reader.GetInt32(1),
                            Abbreviation = reader.GetString(2),
                            Specialization = reader.GetInt32(3),
                            Depot = reader.GetInt32(4)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить список доступных колонн:\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void depot_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColumnsItems();
        }

        private void AddColumnsItems()
        {
            LoadAvailableColumns();
            if (columnsList.Count > 0)
            {
                for (int i = 0; i < columnsList.Count; i++)
                    columns.Items.Add(columnsList[i]);

                columns.DisplayMember = "ColumnNumber";
                columns.SelectedIndex = 0;
            }
            else columns.Text = "список пуст";
        }
    }
}
