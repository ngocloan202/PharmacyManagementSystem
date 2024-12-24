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
        private bool isUpdating = false;
        private PharmacyMgtDatabase customerTable;
        public string EmployeeID { get => employeeID; set => employeeID = value; }
        public NewInvoice()
        {
            InitializeComponent();
            dataTable.OpenConnection();
        }
        private void NewInvoice_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EmployeeID))
            {
                FetchData(EmployeeID);
                SetCustomerContact();
            }
            ToggleControls();
        }

        #region Fetch Data
        private void FetchDataCustomer()
        {
            customerTable = new PharmacyMgtDatabase();
            customerTable.OpenConnection();

            string customerSql = @"SELECT * FROM CUSTOMER";
            SqlCommand customerCmd = new SqlCommand(customerSql);
            customerTable.Fill(customerCmd);

            cboCustomerName.DataSource = customerTable;
            cboCustomerName.DisplayMember = "CustomerName";
            cboCustomerName.ValueMember = "CustomerID";

            cboCustomerName.SelectedIndexChanged += (sender, e) =>
            {
                SetCustomerContact();
            };
        }
        private void SetCustomerContact()
        {
            string selectedCustomerName = cboCustomerName.Text.Trim();

            if (customerTable.Rows.Count > 0)
            {
                DataRow[] customerRows = customerTable.Select($"CustomerName = '{selectedCustomerName}'");

                if (customerRows.Length > 0)
                {
                    string contact = customerRows[0]["Contact"].ToString();
                    txtCustomerContact.Text = contact;
                }
                else
                {
                    MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void FetchDataCommodities()
        {
            PharmacyMgtDatabase commoditiesTable = new PharmacyMgtDatabase();
            commoditiesTable.OpenConnection();
            string commoditiesSql = @"SELECT * FROM COMMODITY";
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
        #region Toggle Controls
        private void ToggleControls()
        {
            txtEmployeeName.Enabled = false;
            txtCustomerContact.Enabled = false;
        }
        #endregion
        #region Handle Event Add To Cart
        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            double price = double.Parse(txtPrice.Text);
            double quantity = double.Parse(txtQuantities.Text);
            double amount = price * quantity;
            string formattedPrice = price.ToString("N0") + " VND";
            string formattedAmount = amount.ToString("N0") + " VND";

            dgvCart.Rows.Add(
                cboCommodityName.Text,
                txtQuantities.Text,
                txtBaseUnit.Text,
                formattedPrice,
                formattedAmount
            );

            MessageBox.Show("Commodity added to cart successfully!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblTotal_TextChanged(sender, e);
            ClearAllFieldOfCommodities();
        }
        private void ClearAllFieldOfCommodities()
        {
            cboCommodityName.SelectedIndex = 0;
            txtQuantities.Text = "1";
            txtBaseUnit.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
        #endregion
        #region Total Amount
        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            isUpdating = true;
            decimal total = 0;
            for (int i = 0; i < dgvCart.Rows.Count; i++)
            {
                if (dgvCart.Rows[i].Cells[4].Value != null)
                {
                    string amountStr = dgvCart.Rows[i].Cells[4].Value.ToString()
                                        .Replace(" VND", "")
                                        .Replace(",", "");

                    decimal amount;
                    if (decimal.TryParse(amountStr, out amount))
                    {
                        total += amount;
                    }
                }
            }
            lblTotal.Text = total.ToString("N0") + " VND";
            isUpdating = false;
        }
        #endregion
    }
}