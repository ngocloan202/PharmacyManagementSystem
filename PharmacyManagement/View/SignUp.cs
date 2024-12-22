using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class SignUp : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public SignUp()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                return;
            }
            if (CreateNewAccount())
            {
                MessageBox.Show("Account created successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Retry;
                this.Close();
            }
        }

        private bool CreateNewAccount()
        {
            try
            {
                string checkUsernameSQL = @"SELECT COUNT(*) FROM ACCOUNT WHERE Username = @Username";
                SqlCommand checkCmd = new SqlCommand(checkUsernameSQL);
                checkCmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = txtUsername.Text;
                dataTable.Fill(checkCmd);

                if (Convert.ToInt32(dataTable.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Username already exists!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return false;
                }

                string insertAccountSQL = @"INSERT INTO ACCOUNT (Username, UserPassword, UserRole)
                                          VALUES (@Username, @UserPassword, @UserRole)";
                SqlCommand insertCmd = new SqlCommand(insertAccountSQL);
                insertCmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = txtUsername.Text;
                insertCmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar, 50).Value = txtPassword.Text;
                insertCmd.Parameters.Add("@UserRole", SqlDbType.NVarChar, 5).Value = "user";

                dataTable.Update(insertCmd);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
            else if (string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                toolTip.Show("Please fill your confirm password", txtConfirmPass,
                    txtConfirmPass.Width - 15, txtConfirmPass.Height - 80, 2000);
                txtConfirmPass.Focus();
                return false;
            }
            else if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())
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