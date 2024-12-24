using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement
{
    public partial class NewInvoice : XtraForm
    {
        private string employeeID;
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public NewInvoice()
        {
            InitializeComponent();
            dataTable.OpenConnection();
        }

        public string EmployeeID { get => employeeID; set => employeeID = value; }

        private void NewInvoice_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EmployeeID))
            {
                FetchData(EmployeeID);
            }
        }

        #region Fetch Data
        private void FetchDataCustomer()
        {
            PharmacyMgtDatabase customerTable = new PharmacyMgtDatabase();
            customerTable.OpenConnection();
            string customerSql = "SELECT * FROM CUSTOMER";
            SqlCommand customerCmd = new SqlCommand(customerSql);
            customerTable.Fill(customerCmd);
            cboCustomerName.DataSource = customerTable;
            cboCustomerName.DisplayMember = "CustomerName";
            cboCustomerName.ValueMember = "CustomerID";
        }
        private void FetchDataCommodities()
        {
            PharmacyMgtDatabase commoditiesTable = new PharmacyMgtDatabase();
            commoditiesTable.OpenConnection();
            string commoditiesSql = "SELECT * FROM COMMODITY";
            SqlCommand commoditiesCmd = new SqlCommand(commoditiesSql);
            commoditiesTable.Fill(commoditiesCmd);
            cboCommodityName.DataSource = commoditiesTable;
            cboCommodityName.DisplayMember = "CommodityName";
            cboCommodityName.ValueMember = "CommodityID";
        }
        private void FetchDataEmployeeName()
        {
            string employeeSql = @"SELECT Em.EmployeeName
                                 FROM ACCOUNT as Ac, EMPLOYEE as Em
                                 WHERE Ac.EmployeeID = @EmployeeID 
                                       AND Ac.EmployeeID = Em.EmployeeID"
            ;
            using (SqlCommand cmd = new SqlCommand(employeeSql))
            {
                try
                {
                    cmd.Parameters.Add("@employeeID", SqlDbType.NVarChar, 5).Value = employeeID;
                    dataTable.Fill(cmd);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        txtEmployeeName.Text = row["EmployeeName"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in FetchData: {ex.Message}");
                }
            }
        }
        private void FetchData(string employeeID)
        {
            FetchDataCustomer();
            FetchDataCommodities();
            FetchDataEmployeeName();
        }
        #endregion
    }
}