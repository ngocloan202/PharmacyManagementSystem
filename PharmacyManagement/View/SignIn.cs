using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class SignIn : XtraForm
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.IsBalloon = true;

            if (txtUsername.Text.Trim() == "")
            {
                toolTip.Show("Please fill your username", txtUsername,
                    txtUsername.Width - 15, txtUsername.Height - 80, 2000);
                txtUsername.Focus();
            }
            else if(txtPassword.Text.Trim() == "")
            {
                toolTip.Show("Please fill your password", txtPassword, 
                    txtPassword.Width - 15, txtPassword.Height - 80, 2000);
                txtPassword.Focus();
            }
        }
    }
}