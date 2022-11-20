using TCH_desktop.Presenter;
using TCH_desktop.Presenter.interfaces;

namespace TCH_desktop.View
{
    public partial class RegForm : Form
    {
        AuthForm authForm;
        IAccountAction account;

        public RegForm(AuthForm authForm, IAccountAction account)
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
            if (pswdInp.Text == confirmPswdInp.Text && !regButton.Enabled)
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

            string email = loginInp.Text.Trim();
            string password = pswdInp.Text.Trim();
            string confirmedPassword = confirmPswdInp.Text.Trim();

            if (email != String.Empty && email != null)
            {
                message = account.CreateNewAccount(email, password, confirmedPassword);
            }
            else message = "Укажите свой email";

            currentMessage.Text = message;
        }
    }
}
