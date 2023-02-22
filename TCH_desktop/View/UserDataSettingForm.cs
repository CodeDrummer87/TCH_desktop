using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class UserDataSettingForm : Form
    {
        private SqliteCommand command;
        private SqliteDataReader reader;

        private bool isEdit = true;
        StartForm startForm;
        AuthForm authForm;

        private List<Railroad> railroads = new();
        private List<LocomotiveDepot> locoDepots = new();
        private List<Position> positionsList = new();
        private List<Column> columnsList = new();

        public UserDataSettingForm(StartForm stForm, AuthForm authForm, bool isEdit_)
        {
            InitializeComponent();

            isEdit = isEdit_;
            startForm = stForm;
            this.authForm = authForm;

            contactingTheUser.Text = isEdit ? "Редактирование личных и профессиональных\nданных пользователя"
                : "Добро пожаловать в ТЧ!\nПожалуйста, заполните поля ниже для завершения регистрации";

            cancelButton.Text = isEdit ? "Оставить всё как есть" : "Займусь этим в другой раз";

            if (isEdit) DisplayCurrentPersonData();

            this.Show();
        }

        private void UserDataSettingForm_Activated(object sender, EventArgs e)
        {
            LoadAvailableRailroads();
            if (railroads.Count > 0)
            {
                for (int i = 0; i < railroads.Count; i++)
                    railRoads.Items.Add(railroads[i]);

                railRoads.DisplayMember = "FullTitle";
                railRoads.SelectedIndex = isEdit ? startForm.GetSelectedRailroadId() - 1 : 4;
            }

            LoadAvailableLocomotiveDepots();
            if (locoDepots.Count > 0)
            {
                for (int i = 0; i < locoDepots.Count; i++)
                    depot.Items.Add(locoDepots[i]);

                depot.DisplayMember = "ShortTitle";
                depot.SelectedIndex = isEdit ? startForm.GetSelectedDepotId() - 1 : 0;
            }

            LoadAvailablePositions();
            if (positionsList.Count > 0)
            {
                for (int i = 0; i < positionsList.Count; i++)
                    positions.Items.Add(positionsList[i]);

                positions.DisplayMember = "FullName";
                positions.SelectedIndex = isEdit ? startForm.GetSelectedPositionId() - 1 : 0;
            }

            LoadAvailableColumns();
            if (columnsList.Count > 0)
            {
                for (int i = 0; i < columnsList.Count; i++)
                    columns.Items.Add(columnsList[i]);

                columns.DisplayMember = "ColumnNumber";
                columns.SelectedIndex = isEdit ? startForm.GetSelectedColumnId() - 1 : 0;
            }
        }

        private void LoadAvailableRailroads()
        {
            railroads.Clear();
            railRoads.Items.Clear();
            railRoads.ResetText();

            string query = "SELECT * FROM Railroads";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                DataBase.OpenConnection();

                reader = command.ExecuteReader();
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

            DataBase.CloseConnection();
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
                    command = DataBase.GetConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.Add("@Id", SqliteType.Integer).Value = railroad?.Id;
                    
                    DataBase.OpenConnection();
                    reader = command.ExecuteReader();
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

                DataBase.CloseConnection();
            }
        }

        private void LoadAvailablePositions()
        {
            string query = "SELECT * FROM Positions";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                    
                DataBase.OpenConnection();
                reader = command.ExecuteReader();
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

            DataBase.CloseConnection();
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
                    command = DataBase.GetConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.Add("@Id", SqliteType.Integer).Value = currentDepot?.Id;
                    
                    DataBase.OpenConnection();
                    reader = command.ExecuteReader();
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

                DataBase.CloseConnection();
            }
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

        private bool ValidateUserData()
        {
            return surNameInp.Text != String.Empty && firstNameInp.Text != String.Empty
                && patronymicInp.Text != String.Empty && tabNumberInp.Text != String.Empty;
        }

        private void SaveUserData()
        {
            string query = "UPDATE Users SET SurName=@sN, FirstName=@fN, Patronymic=@p, BirthDate=@bD" +
                " WHERE LoginId=@loginId";

            string surname = surNameInp.Text;
            string firstname = firstNameInp.Text;
            string patronymic = patronymicInp.Text;
            DateTime bDate = birthDatePicker.Value;

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@sN", SqliteType.Text).Value = surname;
                command.Parameters.Add("@fN", SqliteType.Text).Value = firstname;
                command.Parameters.Add("@p", SqliteType.Text).Value = patronymic;
                command.Parameters.Add("@bD", SqliteType.Text).Value = bDate;
                command.Parameters.Add("@loginId", SqliteType.Integer).Value = startForm.GetCurrentUserLoginId();
                
                DataBase.OpenConnection();
                command.ExecuteNonQuery();
                startForm.SetUserData(surname, firstname, patronymic, bDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить данные пользователя:\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        private void SaveEmployeeData()
        {
            bool isExist = CheckEmployeeForExist(startForm.GetCurrentUserId());

            string query = isExist ? "UPDATE Employees SET TabNumber=@tN, PositionId=@pId, ColumnId=@cId " +
                "WHERE UserId=@uId"
                : "INSERT INTO Employees(TabNumber, UserId, PositionId, ColumnId) VALUES (@tN, @uId, @pId, @cId)";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@tN", SqliteType.Integer).Value = tabNumberInp.Text;
                command.Parameters.Add("@uId", SqliteType.Integer).Value = startForm.GetCurrentUserId();
                command.Parameters.Add("@pId", SqliteType.Integer).Value = ((Position)positions.SelectedItem).Id;
                command.Parameters.Add("@cId", SqliteType.Integer).Value = ((Column)columns.SelectedItem).Id;
                
                DataBase.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить данные сотрудника:\n\"{ex.Message}\"\n" +
                        $"Обратитесь к системному администратору для устранения ошибки.",
                        "Ошибка в работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        private bool CheckEmployeeForExist(int userId)
        {
            string query = "SELECT * FROM Employees WHERE UserId = @uId";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@uId", SqliteType.Text).Value = userId;
               
                DataBase.OpenConnection();
                reader = command.ExecuteReader();

                return reader.HasRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получена ошибка со следующим содержанием:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для её устранения.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return false;
        }

        private void DisplayCurrentPersonData()
        {
            User user = startForm.GetUserData();
            Employee employee = startForm.GetEmployeeData();

            surNameInp.Text = user.SurName;
            firstNameInp.Text = user.FirstName;
            patronymicInp.Text = user.Patronymic;
            birthDatePicker.Value = user.BirthDate;

            tabNumberInp.Text = (employee.TabNumber).ToString();
        }



        #region Interactive

        private void saveUserDataButton_Click(object sender, EventArgs e)
        {
            SaveUserData();
            SaveEmployeeData();

            startForm.wasSavedUserData = true;
            this.Hide();
            startForm.Show();
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            if (isEdit)
            {
                this.Hide();
                startForm.Show();
            }
            else authForm.Close();
        }

        private void saveUserDataButton_MouseEnter(object sender, EventArgs e)
        {
            saveUserDataButton.BackColor = Color.Khaki;
        }

        private void saveUserDataButton_MouseLeave(object sender, EventArgs e)
        {
            saveUserDataButton.BackColor = Color.YellowGreen;
        }

        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            cancelButton.BackColor = Color.PaleTurquoise;
        }

        private void cancelButton_MouseLeave(object sender, EventArgs e)
        {
            cancelButton.BackColor = Color.LightBlue;
        }

        private void textBoxTextChanged(object sender, EventArgs e)
        {
            saveUserDataButton.Enabled = ValidateUserData();
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

        private void saveUserDataButton_EnabledChanged(object sender, EventArgs e)
        {
            saveUserDataButton.BackColor = saveUserDataButton.BackColor
                == Color.YellowGreen ? Color.LightGray : Color.YellowGreen;
        }

        private void depot_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddColumnsItems();
        }

        #endregion
    }
}
