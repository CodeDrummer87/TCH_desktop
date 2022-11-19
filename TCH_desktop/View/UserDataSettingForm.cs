using System;
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
    }
}
