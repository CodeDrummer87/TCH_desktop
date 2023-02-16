using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class StartForm : Form
    {
        private User user;

        AuthForm authForm;
        AccountAction account;

        private System.Windows.Forms.Timer timer;
        int timePeriod;

        public bool wasSavedTrip;
        public bool wasSavedUserData;

        public StartForm(AuthForm authForm, AccountAction account, int currentUserLoginId)
        {
            InitializeComponent();

            this.authForm = authForm;
            this.account = account;
            this.authForm.Hide();

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timePeriod = 3;
            timer.Tick += TimerTick;

            user = account.GetCurrentUserData(currentUserLoginId);

            if (!CheckUserData(ref user))
            {
                UserDataSettingForm uDataSettingForm = new(this, authForm, false);
            }
            else this.Show();

            wasSavedTrip = false;
            wasSavedUserData = false;
        }

        public int GetCurrentUserId() => user.Id;
        public int GetCurrentUserLoginId() => user.LoginId;

        public User GetUserData() => account.GetCurrentUserData(user.LoginId);
        public Employee GetEmployeeData() => account.GetCurrentEmployeeData(user.Id);
        public int GetSelectedRailroadId() => account.GetCurrentRailroadId(user.Id);
        public int GetSelectedDepotId() => account.GetCurrentDepotId(user.Id);
        public int GetSelectedPositionId() => account.GetCurrentPositionId(user.Id);
        public int GetSelectedColumnId() => account.GetCurrentColumnId(user.Id);



        private bool CheckUserData(ref User user)
        {
            return (user.FirstName != "не указано" && user.FirstName != String.Empty)
                && (user.SurName != "не указано" && user.SurName != String.Empty)
                && (user.Patronymic != "не указано" && user.Patronymic != String.Empty);
        }

        public void SetUserData(string sName, string fName, string patronymic, DateTime bDate)
        {
            user.SurName = sName;
            user.FirstName = fName;
            user.Patronymic = patronymic;
            user.BirthDate = bDate;
        }

        private string GetInfoAboutEmployee()
        {
            string result = String.Empty;
            string query = "SELECT	concat(p.Abbreviate, ' ', u.Surname, ' ', u.FirstName, ' ', " +
                " u.Patronymic, ' (таб.N', CHAR(0176), ' ', e.TabNumber, ', колонна N', " +
                "CHAR(0176), ' ', c.ColumnNumber, ') ',  d.ShortTitle) " +
                "FROM Employees e " +
                "INNER JOIN Users u " +
                "ON u.Id = e.UserId " +
                "INNER JOIN Positions p " +
                "ON p.Id = e.PositionId " +
                "INNER JOIN Columns c " +
                "ON c.Id = e.ColumnId " +
                "INNER JOIN LocomotiveDepots d " +
                "ON d.Id = c.Depot " +
                "WHERE e.UserId = @uId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@uId", SqlDbType.Int).Value = GetCurrentUserId();
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить запрос к Базе Данных на получение данных" +
                    $" о сотруднике:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return result;
        }



        #region Interactive

        private void personDataMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDataSettingForm uDataSettingForm = new(this, authForm, true);
        }

        private void StartForm_Activated(object sender, EventArgs e)
        {
            infoAboutCurrentUser.Text = GetInfoAboutEmployee();
            TopMost = false;
            Opacity = 100;
            Enabled = true;

            if (wasSavedTrip)
            {
                wasSavedTrip = false;
                currentMessage.Text = "Данные о поездке успешно сохранены";
                timer.Start();
            }

            if (wasSavedUserData)
            {
                wasSavedUserData = false;
                currentMessage.Text = "Личные данные пользователя сохранены";
                timer.Start();
            }
        }

        private void exitButton_Click(object? sender, EventArgs e)
        {
            authForm.Close();
        }

        private void newTripMenu_Click(object sender, EventArgs e)
        {
            NewTripForm newTripForm = new(this);
            TopMost = true;
            Opacity = 60;
            Enabled = false;
            newTripForm.Show();
        }

        private void allTripsMenu_Click(object sender, EventArgs e)
        {
            AllTripsForm allTripsForm = new(this);
            TopMost = true;
            Opacity = 60;
            this.Enabled = false;
            allTripsForm.Show();
        }

        private void exitButton_MouseEnter(object? sender, EventArgs e)
        {
            exitButton.Text = "x";
            exitButton.ForeColor = Color.Red;
        }

        private void exitButton_MouseLeave(object? sender, EventArgs e)
        {
            exitButton.Text = "-";
            exitButton.ForeColor = SystemColors.ButtonHighlight;
        }

        private void labelMouseEnter(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.GreenYellow;
            label_.BackColor = Color.DimGray;
        }

        private void labelMouseLeave(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = SystemColors.Control;
            label_.BackColor = Color.Transparent;
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            timePeriod--;

            if (timePeriod <= 0)
            {
                timer.Stop();
                timePeriod = 3;
                currentMessage.Text = String.Empty;
            }
        }

        private void statisticsScreenMenu_Click(object sender, EventArgs e)
        {
            StatisticsScreenForm statScreen = new(this);
            TopMost = true;
            Opacity = 60;
            this.Enabled = false;
            statScreen.Show();
        }

        #endregion

    }
}
