﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class RegForm : Form
    {
        AuthForm authForm;

        public RegForm(AuthForm authForm)
        {
            InitializeComponent();

            this.authForm = authForm;
            this.Show();
            this.authForm.Hide();

            title.Text = "ТЧЭ-2\nЗСЖД";
            title.Font = Source.LoadFont(Source.dockerFont, 50, true);

            developerEmail.Font = Source.LoadFont(Source.zektonFont, 11, true);

            loginInp.Font = pswdInp.Font = confirmPswdInp.Font = currentMessage.Font =
                Source.LoadFont(Source.zektonFont, 12, true);

             codeForReg.Font = confirmEmailButton.Font = regButton.Font =
                Source.LoadFont(Source.zektonFont, 10, true);
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
            backToAuthForm.Text = "<<";
            backToAuthForm.ForeColor = Color.LightGreen;
        }

        private void backToAuthForm_Click(object? sender, EventArgs e)
        {
            this.Close();
            authForm.Show();
        }

        private void backToAuthForm_MouseLeave(object? sender, EventArgs e)
        {
            backToAuthForm.Text = "<";
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
            regButton.BackColor = Color.LightSkyBlue;
        }

        private void regButton_MouseLeave(object sender, EventArgs e)
        {
            regButton.BackColor = Color.LightBlue;
        }
    }
}
