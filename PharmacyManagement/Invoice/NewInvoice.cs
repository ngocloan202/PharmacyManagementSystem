using System;
using System.Data.SqlClient;
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

        private void FetchData(string employeeID)
        {
            FetchDataCustomer();
            FetchDataCommodities();
        }
    }
}