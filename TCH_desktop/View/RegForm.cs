﻿using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class RegForm : Form
    {
        AuthForm authForm;
        AccountAction account;

        private System.Windows.Forms.Timer timer;
        private int timePeriod;

        public RegForm(AuthForm authForm, AccountAction account)
        {
            InitializeComponent();

            this.authForm = authForm;
            this.Show();
            this.authForm.Hide();

            this.account = account;

            title.Text = "ТЧЭ-2\nЗСЖД";
            title.Font = Source.LoadFont(Source.dockerFont, 50, true);

            developerEmail.Font = Source.LoadFont(Source.zektonFont, 11, true);

            loginInp.Font = pswdInp.Font = confirmPswdInp.Font = currentMessage.Font =
                Source.LoadFont(Source.zektonFont, 12, true);

            codeForReg.Font = confirmEmailButton.Font = regButton.Font =
               Source.LoadFont(Source.zektonFont, 10, true);

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timePeriod = 3;
            timer.Tick += TimerTick;
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
            exitButton.ForeColor = Color.White;
        }

        private void backToAuthForm_MouseEnter(object? sender, EventArgs e)
        {
            backToAuthForm.ForeColor = Color.LightGreen;
        }

        private void backToAuthForm_Click(object? sender, EventArgs e)
        {
            this.Close();
            authForm.Show();
            this.Dispose();
        }

        private void backToAuthForm_MouseLeave(object? sender, EventArgs e)
        {
            backToAuthForm.ForeColor = Color.White;
        }

        private void confirmEmailButton_MouseEnter(object sender, EventArgs e)
        {
            confirmEmailButton.BackColor = Color.LightSkyBlue;
        }

        private void confirmEmailButton_MouseLeave(object sender, EventArgs e)
        {
            confirmEmailButton.BackColor = Color.LightBlue;
        }

        private void regButton_MouseEnter(object sender, EventArgs e)
        {
            regButton.BackColor = Color.GreenYellow;
        }

        private void regButton_MouseLeave(object sender, EventArgs e)
        {
            regButton.BackColor = Color.PaleGreen;
        }

        private void confirmPswdInp_TextChanged(object sender, EventArgs e)
        {
            if (pswdInp.Text.ToLower() == confirmPswdInp.Text.ToLower() && !regButton.Enabled)
            {
                regButton.Enabled = true;
                regButton.BackColor = Color.PaleGreen;
            }
            else
            {
                regButton.Enabled = false;
                regButton.BackColor = Color.PaleGoldenrod;
            }
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            string message = String.Empty;

            string email = loginInp.Text.ToLower().Trim();
            string password = pswdInp.Text.ToLower().Trim();
            string confirmedPassword = confirmPswdInp.Text.ToLower().Trim();

            if (email != String.Empty && email != null)
            {
                message = account.CreateNewAccount(email, password, confirmedPassword);
                timer.Start();
            }
            else message = "Укажите свой email";

            currentMessage.Text = message;
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            timePeriod--;

            if (timePeriod <= 0)
            {
                timer.Stop();
                timePeriod = 3;
                currentMessage.Text = String.Empty;

                this.Close();
                this.Dispose();
                authForm.Show();
            }
        }
    }
}
