using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class SignUp : XtraForm
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            if (!signUp.IsDisposed)
            {
                this.Hide();
                SignIn signIn = new SignIn();
                signIn.ShowDialog();
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                return;
            }
            SignUp signUp = new SignUp();
            if (!signUp.IsDisposed)
            {
                this.Hide();
                SignIn signIn = new SignIn();
                signIn.ShowDialog();
            }
        }

        public Boolean validateInput()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.IsBalloon = true;

            if (txtUsername.Text.Trim() == "")
            {
                toolTip.Show("Please fill your username", txtUsername,
                    txtUsername.Width - 15, txtUsername.Height - 80, 2000);
                txtUsername.Focus();
                return false;
            }
            else if (txtPassword.Text.Trim() == "")
            {
                toolTip.Show("Please fill your password", txtPassword,
                    txtPassword.Width - 15, txtPassword.Height - 80, 2000);
                txtPassword.Focus();
                return false;
            }
            else if (txtConfirmPass.Text.Trim() == "")
            {
                toolTip.Show("Please fill your confirm password", txtConfirmPass,
                    txtConfirmPass.Width - 15, txtConfirmPass.Height - 80, 2000);
                txtConfirmPass.Focus();
                return false;
            }
            else if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim() == true)
            {
                toolTip.Show("Confirm password is incorrect!", txtConfirmPass,
                    txtConfirmPass.Width - 15, txtConfirmPass.Height - 80, 2000);
                txtConfirmPass.Focus();
                return false;
            }
            return true;
        }
    }
}