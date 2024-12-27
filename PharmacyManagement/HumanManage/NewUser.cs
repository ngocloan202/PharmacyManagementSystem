using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.HumanManage
{
    public partial class NewUser : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public NewUser()
        {
            dataTable.OpenConnection();
            InitializeComponent();
            cboUserRole.SelectedIndex = 0;
            dtpBirthday.Value = DateTime.Now;
        }

        private void NewAccount_Load(object sender, EventArgs e)
        {
            ClearAllField();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    string employeeSql = @"INSERT INTO EMPLOYEE VALUES(@EmployeeID, @EmployeeName, @Sex, 
                                                @Contact, @Birthday, @EmployeeAddress)";
                SqlCommand employeeCmd = new SqlCommand(employeeSql);

                employeeCmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 5).Value = txtEmployeeID.Text;
                employeeCmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar, 200).Value = txtEmployeeName.Text;
                employeeCmd.Parameters.Add("@Sex", SqlDbType.Char, 1).Value = radFemale.Checked ? "F" : "M";
                employeeCmd.Parameters.Add("@Contact", SqlDbType.VarChar, 10).Value = txtContact.Text;
                employeeCmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = dtpBirthday.Value;
                employeeCmd.Parameters.Add("@EmployeeAddress", SqlDbType.NVarChar, 200).Value = txtAddress.Text;
                dataTable.Update(employeeCmd);

                string accountSql = @"INSERT INTO ACCOUNT (Username, UserPassword, UserRole, EmployeeID) 
                       VALUES(@Username, @UserPassword, @UserRole, @EmployeeID)";
                SqlCommand accountCmd = new SqlCommand(accountSql);

                accountCmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = txtUsername.Text;
                accountCmd.Parameters.Add("@UserPassword", SqlDbType.VarChar, 50).Value = txtUserPassword.Text;
                accountCmd.Parameters.Add("@UserRole", SqlDbType.VarChar, 5).Value = cboUserRole.SelectedItem.ToString();
                accountCmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 5).Value = txtEmployeeID.Text;

                dataTable.Update(accountCmd);
                MessageBox.Show("Account added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewAccount_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                toolTip.Show("Please enter the Employee ID!", txtEmployeeID,
                    txtEmployeeID.Width - 15, txtEmployeeID.Height - 80, 2000);
                txtEmployeeID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                toolTip.Show("Please enter the Employee ID!", txtEmployeeName,
                    txtEmployeeName.Width - 15, txtEmployeeName.Height - 80, 2000);
                txtEmployeeName.Focus();
                return false;
            }
            return true;
        }
        private void ClearAllField()
        {
            txtEmployeeID.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtUserPassword.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            radFemale.Checked = true;
            dtpBirthday.Value = DateTime.Now;
            cboUserRole.Items.IndexOf(0);
            txtEmployeeID.Focus();
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