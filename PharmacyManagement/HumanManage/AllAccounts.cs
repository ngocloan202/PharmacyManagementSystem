using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.HumanManage
{
    public partial class AllAccounts : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public AllAccounts()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        public void getData()
        {
            string userSql = @"SELECT ac.AccountID, ac.Username, ac.UserRole, 
                                      ac.UserPassword ,em.EmployeeName
                               FROM ACCOUNT as ac, EMPLOYEE as em
                               WHERE ac.EmployeeID = em.EmployeeID";
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

        private void toggleControls(bool value)
        {
            txtIdUser.Enabled = false;
            txtFullName.Enabled = false;

            txtUsername.Enabled = value;
            txtPass.Enabled = value;
            txtRole.Enabled = value;
            btnSave.Enabled = value;
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            dgvAllAccounts.AutoGenerateColumns = false;
            getData();
            toggleControls(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            toggleControls(true);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            AllUsers_Load(sender, e);
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
    }
}