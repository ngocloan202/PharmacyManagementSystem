using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.HumanManage
{
    public partial class NewAccount : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public NewAccount()
        {
            dataTable.OpenConnection();
            InitializeComponent();
            cboUserRole.SelectedIndex = 0;
        }

        private void NewAccount_Load(object sender, EventArgs e)
        {
            txtAccountID.Enabled = false;
            ClearAllField();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string sql = @"INSERT INTO ACCOUNT (Username, UserPassword, UserRole) 
                       VALUES(@Username, @UserPassword, @UserRole)";
                SqlCommand cmd = new SqlCommand(sql);

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = txtUsername.Text;
                cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar, 50).Value = txtUserPassword.Text;
                cmd.Parameters.Add("@UserRole", SqlDbType.VarChar, 5).Value = cboUserRole.SelectedItem.ToString();

                dataTable.Update(cmd);
                MessageBox.Show("Account added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewAccount_Load(sender, e);
            }
        }

        private bool ValidateInput()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.IsBalloon = true;

            toolTip.Hide(txtUsername);
            toolTip.Hide(txtUserPassword);

            // Validate Username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                toolTip.Show("Please enter the Username!", txtUsername,
                    txtUsername.Width - 15, txtUsername.Height - 80, 2000);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUserPassword.Text))
            {
                toolTip.Show("Please enter the Password!", txtUserPassword,
                    txtUserPassword.Width - 15, txtUserPassword.Height - 80, 2000);
                txtUserPassword.Focus();
                return false;
            }

            return true;
        }
        private void ClearAllField()
        {
            txtUsername.Text = string.Empty;
            txtUserPassword.Text = string.Empty;
            cboUserRole.Items.IndexOf(0);
            txtUsername.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the changes?",
                "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                NewAccount_Load(sender, e);
            }
        }
    }
}