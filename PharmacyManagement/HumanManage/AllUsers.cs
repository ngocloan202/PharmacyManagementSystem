using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.HumanManage
{
    public partial class AllUsers : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public AllUsers()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        public void getData()
        {
            string userSql = @"SELECT ac.AccountID, ac.Username, em.EmployeeName, ac.UserRole,
                               em.Sex, em.Contact, em.Birthday, em.EmployeeAddress
                               FROM ACCOUNT as ac, EMPLOYEE as em
                               WHERE ac.EmployeeID = em.EmployeeID";
            SqlCommand userCmd = new SqlCommand(userSql);
            dataTable.Fill(userCmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvAllUsers.DataSource = binding;
            bindingNavigator.BindingSource = binding;
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            dgvAllUsers.AutoGenerateColumns = false;
            getData();
        }
    }
}