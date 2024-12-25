using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PharmacyManagement.HumanManage
{
    public partial class AllAccounts : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        string username = "";
        public AllAccounts()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        public void FetchData()
        {
            string userSql = @"SELECT ac.AccountID, ac.Username, ac.UserRole, 
                                      ac.UserPassword, em.EmployeeName,
                                 CASE 
                                      WHEN ac.EmployeeID IS NULL THEN 1
                                      ELSE 0
                                 END AS IsEmployeeNull
                               FROM ACCOUNT AS ac
                               LEFT JOIN EMPLOYEE AS em
                               ON ac.EmployeeID = em.EmployeeID";
            SqlCommand userCmd = new SqlCommand(userSql);
            dataTable.Fill(userCmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvAllAccounts.DataSource = binding;
            bindingNavigator.BindingSource = binding;

            txtIdUser.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtPass.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtRole.DataBindings.Clear();

            txtIdUser.DataBindings.Add("Text", binding, "AccountID");
            txtUsername.DataBindings.Add("Text", binding, "Username");
            txtPass.DataBindings.Add("Text", binding, "UserPassword");
            txtRole.DataBindings.Add("Text", binding, "UserRole");
            txtFullName.DataBindings.Add("Text", binding, "EmployeeName");
        }

        private void ToggleControls(bool value)
        {
            txtIdUser.Enabled = false;
            txtFullName.Enabled = false;

            txtUsername.Enabled = value;
            txtPass.Enabled = value;
            txtRole.Enabled = value;
            btnSave.Enabled = value;

            btnEdit.Enabled = !value;
            btnDelete.Enabled = !value;
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            dgvAllAccounts.AutoGenerateColumns = false;
            FetchData();
            ToggleControls(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            ToggleControls(true);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            AllUsers_Load(sender, e);
            dgvAllAccounts.Sort(dgvAllAccounts.Columns["AccountID"], ListSortDirection.Ascending);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Are you sure you want to delete this account? ", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string deleteAccountQuery = @"DELETE FROM ACCOUNT WHERE AccountID = @AccountID";
                SqlCommand deleteAccountCmd = new SqlCommand(deleteAccountQuery);
                deleteAccountCmd.Parameters.Add("@AccountID", SqlDbType.TinyInt).Value = txtIdUser.Text;
                dataTable.Update(deleteAccountCmd);

                AllUsers_Load(sender, e);
            }
        }

        private void UpdateAccount()
        {
            string updateAccountQuery = @"UPDATE ACCOUNT
                                   SET Username = @newUsername,
                                       UserPassword = @UserPassword,
                                       Userrole = @Userrole
                                   WHERE Username = @oldUsername";
            SqlCommand updateAccountCmd = new SqlCommand(updateAccountQuery);
            updateAccountCmd.Parameters.Add("@newUsername", SqlDbType.VarChar, 50).Value = txtUsername.Text.Trim();
            updateAccountCmd.Parameters.Add("@oldUsername", SqlDbType.VarChar, 50).Value = username;
            updateAccountCmd.Parameters.Add("@UserPassword", SqlDbType.VarChar, 50).Value = txtPass.Text.Trim();
            updateAccountCmd.Parameters.Add("@Userrole", SqlDbType.VarChar, 5).Value = txtRole.Text.Trim();
            dataTable.Update(updateAccountCmd);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateAccount();
            MessageBox.Show("Updated information successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AllUsers_Load(sender, e);
        }

        private void dgvAllAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAllAccounts.Columns[e.ColumnIndex].Name == "UserPassword")
            {
                e.Value = "••••••••••";
            }
        }

        public void FetchData(string keyword)
        {
            string userSql = @"SELECT ac.AccountID, ac.Username, ac.UserRole, 
                                      ac.UserPassword, em.EmployeeName,
                                 CASE 
                                      WHEN ac.EmployeeID IS NULL THEN 1
                                      ELSE 0
                                 END AS IsEmployeeNull
                               FROM ACCOUNT AS ac
                               LEFT JOIN EMPLOYEE AS em
                               ON ac.EmployeeID = em.EmployeeID
                               WHERE ac.Username LIKE @Keyword 
                                OR em.EmployeeName LIKE @Keyword";
            SqlCommand userCmd = new SqlCommand(userSql);
            userCmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + keyword + "%";
            dataTable.Fill(userCmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvAllAccounts.DataSource = binding;
            bindingNavigator.BindingSource = binding;

            txtIdUser.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtPass.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtRole.DataBindings.Clear();

            txtIdUser.DataBindings.Add("Text", binding, "AccountID");
            txtUsername.DataBindings.Add("Text", binding, "Username");
            txtPass.DataBindings.Add("Text", binding, "UserPassword");
            txtRole.DataBindings.Add("Text", binding, "UserRole");
            txtFullName.DataBindings.Add("Text", binding, "EmployeeName");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FetchData(txtFind.Text);
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
            }
        }
    }
}