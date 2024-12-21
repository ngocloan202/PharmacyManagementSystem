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
            ToolTip toolTip = new ToolTip();
            toolTip.IsBalloon = true;

            if (txtUsername.Text.Trim() == "")
            {
                toolTip.Show("Please fill your username", txtUsername,
                    txtUsername.Width - 15, txtUsername.Height - 80, 2000);
                txtUsername.Focus();
            }
            else if (txtPassword.Text.Trim() == "")
            {
                toolTip.Show("Please fill your password", txtPassword,
                    txtPassword.Width - 15, txtPassword.Height - 80, 2000);
                txtPassword.Focus();
            }
            else if (txtConfirmPass.Text.Trim() == "")
            {
                toolTip.Show("Please fill your password", txtConfirmPass,
                    txtConfirmPass.Width - 15, txtConfirmPass.Height - 80, 2000);
                txtConfirmPass.Focus();
            }
        }
    }
}