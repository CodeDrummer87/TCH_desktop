using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCH_desktop.Models;
using TCH_desktop.Presenter.interfaces;

namespace TCH_desktop.View
{
    public partial class StartForm : Form
    {
        private int currentUserLoginId;

        AuthForm authForm;
        IAccountAction account;

        public StartForm(AuthForm authForm, IAccountAction account, int currentUserLoginId)
        {
            InitializeComponent();

            this.authForm = authForm;
            this.account = account;
            this.currentUserLoginId = currentUserLoginId;
            this.authForm.Hide();

            User user = account.GetCurrentUserData(currentUserLoginId);

            if (user.FirstName == "не указано" || user.SurName == "не указано")
            {
                UserDataSettingForm uDataSettingForm = new(this, authForm);
            }
            else this.Show();
        }

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
    }
}
