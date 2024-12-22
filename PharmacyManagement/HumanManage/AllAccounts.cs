using System;
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

        private void AllUsers_Load(object sender, EventArgs e)
        {
            dgvAllAccounts.AutoGenerateColumns = false;
            getData();
        }
    }
}