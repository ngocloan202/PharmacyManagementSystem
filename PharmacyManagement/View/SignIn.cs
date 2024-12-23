using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class SignIn : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public string currentRoleUser { get; private set; }
        public string Username { get; private set; }

        public SignIn()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            DialogResult result = signUp.ShowDialog();
            if (result == DialogResult.Retry)
                {
                    txtUsername.Clear();
                    txtPassword.Clear();
                    this.Show();
                }
            else
            {
                this.Close(); 
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                return;
            }
            else
            {
                String accountSQL = @"SELECT * FROM Account WHERE Username = @Username and UserPassword = @UserPassword";
                SqlCommand cmd = new SqlCommand(accountSQL);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = txtUsername.Text;
                cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar, 50).Value = txtPassword.Text;
                dataTable.Fill(cmd);
                if (dataTable.Rows.Count > 0)
                {
                    currentRoleUser = dataTable.Rows[0]["UserRole"].ToString();
                    Username = dataTable.Rows[0]["Username"].ToString(); // Store username
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                }
            }
        }

        public Boolean validateInput()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.IsBalloon = true;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                toolTip.Show("Please fill your username", txtUsername,
                    txtUsername.Width - 15, txtUsername.Height - 80, 2000);
                txtUsername.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                toolTip.Show("Please fill your password", txtPassword,
                    txtPassword.Width - 15, txtPassword.Height - 80, 2000);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        #region Show Password
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.PasswordChar = '•';
            }
        }
        #endregion
    }

}