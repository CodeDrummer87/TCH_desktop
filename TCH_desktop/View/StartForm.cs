﻿using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;
using TCH_desktop.Presenter;
using TCH_desktop.Presenter.interfaces;

namespace TCH_desktop.View
{
    public partial class StartForm : Form
    {
        private User user;

        AuthForm authForm;
        IAccountAction account;

        public StartForm(AuthForm authForm, IAccountAction account, int currentUserLoginId)
        {
            InitializeComponent();

            this.authForm = authForm;
            this.account = account;
            this.authForm.Hide();

            infoAboutCurrentUser.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 11, true);

            user = account.GetCurrentUserData(currentUserLoginId);

            if (!CheckUserData(ref user))
            {
                UserDataSettingForm uDataSettingForm = new(this, authForm);
            }
            else this.Show();
        }

        public int GetCurrentUserId() => user.Id;
        public int GetCurrentUserLoginId() => user.LoginId;

        private void exitButton_Click(object? sender, EventArgs e)
        {
            authForm.Close();
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

        private bool CheckUserData(ref User user)
        {
            return (user.FirstName != "не указано" && user.FirstName != String.Empty)
                && (user.SurName != "не указано" && user.SurName != String.Empty)
                && (user.Patronymic != "не указано" && user.Patronymic != String.Empty);
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            infoAboutCurrentUser.Text = GetInfoAboutEmployee();
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

            return result;
        }
    }
}
