using TCH_desktop.Models;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class AuthForm : Form
    {
        private  AccountAction account;
        private bool isHiddenPassword;

        public AuthForm()
        {
            InitializeComponent();

            account = new AccountAction();
            isHiddenPassword = true;

            title.Text = "ТЧЭ-2\nЗСЖД";
            title.Font = Source.LoadFont(@".\source\fonts\docker.ttf", 50, true);
            developerEmail.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 11, true);
            loginInp.Font = pswdInp.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 12, true);
            authButton.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 10, true);
            authFormErrorMessage.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 11, true);
        }

        private void exitButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void exitButton_MouseEnter(object? sender, EventArgs e)
        {
            exitButton.Text = "x";
            exitButton.ForeColor = Color.Red;
        }

        private void exitButton_MouseLeave(object? sender, EventArgs e)
        {
            exitButton.Text = "-";
            exitButton.ForeColor = Color.Black;
        }

        private void authButton_MouseEnter(object? sender, EventArgs e)
        {
            authButton.BackColor = Color.LightSkyBlue;
        }

        private void authButton_MouseLeave(object? sender, EventArgs e)
        {
            authButton.BackColor = Color.LightBlue;
        }

        private void authButton_Click(object? sender, EventArgs e)
        {
            string uEmail = loginInp.Text.Trim();
            string uPswd = pswdInp.Text.Trim();

            if (CheckInput(uEmail, false) && CheckInput(uPswd, true))
            {
                if (account.CheckInputedEmail(uEmail))
                {
                    LoginModel loginDb = account.GetCurrentLoginData(uEmail);

                    if (loginDb != null && (loginDb.Password == account.GetHashImage(uPswd, loginDb.Salt)))
                    {
                        StartForm startForm = new StartForm(this, account, loginDb.LoginId);
                    }
                    else
                    {
                        authFormErrorMessage.Text = "Неверный пароль. Попробуйте ещё раз.";
                        pswdInp.Text = String.Empty;
                    }
                }
                else
                {
                    authFormErrorMessage.Text = $"аккаунта с почтой {uEmail} не существует";
                    loginInp.Text = String.Empty;
                    pswdInp.Text = String.Empty;
                }
            }
        }

        private bool CheckInput(string value, bool isPassword)
        {
            if (value != null && value != String.Empty)
                return true;

            authFormErrorMessage.Text = isPassword ?
                "Введите пароль" : "Укажите Ваш email";

            if (isPassword) pswdInp.Text = String.Empty;
            else loginInp.Text = String.Empty;

            return false;
        }

        private void loginInp_Enter(object? sender, EventArgs e)
        {
            loginInp.Text = String.Empty;
            ClearAuthFormErrorMessage();
        }

        private void pswdInp_Enter(object? sender, EventArgs e)
        {
            pswdInp.Text = String.Empty;
            ClearAuthFormErrorMessage();
        }

        private void ClearAuthFormErrorMessage()
        {
            if (authFormErrorMessage.Text != String.Empty)
                authFormErrorMessage.Text = String.Empty;
        }

        private void addAccountPicture_MouseEnter(object? sender, EventArgs e)
        {
            addAccountPicture.BackColor = Color.LightGreen;
        }

        private void addAccountPicture_MouseLeave(object? sender, EventArgs e)
        {
            addAccountPicture.BackColor = SystemColors.InactiveCaption;
        }

        private void addAccountPicture_Click(object? sender, EventArgs e)
        {
            RegForm regForm = new RegForm(this, account);
        }

        private void showHidePasswordPicture_MouseEnter(object? sender, EventArgs e)
        {
            showHidePasswordPicture.BackColor = Color.LightGreen;
        }

        private void showHidePasswordPicture_MouseLeave(object? sender, EventArgs e)
        {
            showHidePasswordPicture.BackColor = SystemColors.InactiveCaption;
        }

        private void showHidePasswordPicture_Click(object? sender, EventArgs e)
        {
            if (isHiddenPassword)
            {
                isHiddenPassword = false;
                showHidePasswordPicture.Image = Properties.Resources.open_eye_icon;
                pswdInp.PasswordChar = '\0';
            }
            else
            {
                isHiddenPassword = true;
                showHidePasswordPicture.Image = Properties.Resources.closed_eye_icon;
                pswdInp.PasswordChar = '★';
            }
        }

        private void pswdInp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                authButton_Click(sender, e);
        }
    }
}
