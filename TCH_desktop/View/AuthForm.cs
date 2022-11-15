using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCH_desktop.Models;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class AuthForm : Form
    {
        private bool isHiddenPassword = true;

        DataBase db = new();
        SqlDataAdapter adapter = new();

        public AuthForm()
        {
            InitializeComponent();

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
                if (CheckInputedEmail(uEmail))
                {
                    LoginModel loginDb = GetCurrentLoginData(uEmail);

                    if (loginDb != null && (loginDb.Password == GetHashImage(uPswd, loginDb.Salt)))
                    {
                        MessageBox.Show("Welcome!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ClearAuthFormErrorMessage();
        }

        private void pswdInp_Enter(object? sender, EventArgs e)
        {
            ClearAuthFormErrorMessage();
        }

        private void ClearAuthFormErrorMessage()
        {
            if (authFormErrorMessage.Text != String.Empty)
                authFormErrorMessage.Text = String.Empty;
        }


        private bool CheckInputedEmail(string email)
        {
            string query = "SELECT * FROM Logins WHERE Email = @uEmail";
            SqlCommand command = new(query, db.GetConnection());
            command.Parameters.Add("@uEmail", SqlDbType.VarChar).Value = email;

            DataTable table = new();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table.Rows.Count == 1 ? true : false;
        }

        private byte[] GetSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        private string GetHashImage(string pswrd, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pswrd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        //.:: Temporary code :::

        //private void RegisterAdmin()
        //{
        //    string query = "INSERT INTO Logins VALUES ('Admin', @p, @s)";

        //    byte[] salt = GetSalt();
        //    string pswdHashImage = GetHashImage("admin", salt);

        //    SqlCommand command = new(query, db.GetConnection());
        //    command.Parameters.Add("@p", SqlDbType.VarChar).Value = pswdHashImage;
        //    command.Parameters.Add("@s", SqlDbType.VarBinary).Value = salt;

        //    db.OpenConnection();

        //    if (command.ExecuteNonQuery() == 1)
        //    {
        //        MessageBox.Show("Успешная регистрация", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else MessageBox.Show("Ошибка регистрации Админа", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    db.CloseConnection();
        //}

        private LoginModel GetCurrentLoginData(string email)
        {
            LoginModel mLogin = new();

            string query = "SELECT * FROM Logins WHERE Email=@e";

            SqlCommand command = new(query, db.GetConnection());
            command.Parameters.Add("@e", SqlDbType.VarChar).Value = email;
            db.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                mLogin = new LoginModel
                {
                    LoginId = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Password = reader.GetString(2),
                    Salt = (byte[])reader[3]
                };
            }
            reader.Close();

            return mLogin;
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
            RegForm regForm = new RegForm(this);
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
    }
}
