using System;
using System.ComponentModel;
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
        private PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        private PharmacyMgtDatabase customerTable;
        private PharmacyMgtDatabase commoditiesTable;
        private bool isUpdating = false;

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
                SetBaseUnit();
                SetSellingPrice();
            }
            ToggleControls();
            dgvCart.Sort(dgvCart.Columns["CommodityName"], ListSortDirection.Ascending);
        }

        #region Fetch Data Customer
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

            if (cboCustomerName.Items.Count > 0)
            {
                cboCustomerName.SelectedIndex = 0;
                SetCustomerContact();
            }
        }

        private void SetCustomerContact()
        {
            string selectedCustomerName = cboCustomerName.Text.Trim();

            if (customerTable.Rows.Count > 0)
            {
                DataRow[] customerRows = customerTable.Select($"CustomerName = '{selectedCustomerName}'");
                if (customerRows.Length > 0)
                {
                    txtCustomerContact.Text = customerRows[0]["Contact"].ToString();
                }
                else
                {
                    txtCustomerContact.Text = string.Empty;
                }
            }
        }
        #endregion

        #region Fetch Data Commodities
        private void FetchDataCommodities()
        {
            commoditiesTable = new PharmacyMgtDatabase();
            commoditiesTable.OpenConnection();

            string commoditiesSql = @"SELECT * FROM COMMODITY";
            SqlCommand commoditiesCmd = new SqlCommand(commoditiesSql);
            commoditiesTable.Fill(commoditiesCmd);

            cboCommodityName.DataSource = commoditiesTable;
            cboCommodityName.DisplayMember = "CommodityName";
            cboCommodityName.ValueMember = "CommodityID";

            cboCommodityName.SelectedIndexChanged += (sender, e) =>
            {
                SetBaseUnit();
                SetSellingPrice();
            };

            if (cboCommodityName.Items.Count > 0)
            {
                cboCommodityName.SelectedIndex = 0;
                SetBaseUnit();
                SetSellingPrice();
            }
        }

        private void SetBaseUnit()
        {
            string selectedCommodityName = cboCommodityName.Text.Trim();

            if (commoditiesTable.Rows.Count > 0)
            {
                DataRow[] baseUnitRows = commoditiesTable.Select($"CommodityName = '{selectedCommodityName}'");
                if (baseUnitRows.Length > 0)
                {
                    txtBaseUnit.Text = baseUnitRows[0]["BaseUnit"].ToString();
                }
                else
                {
                    txtBaseUnit.Text = string.Empty;
                }
            }
        }

        private void SetSellingPrice()
        {
            string selectedCommodityName = cboCommodityName.Text.Trim();

            if (commoditiesTable.Rows.Count > 0)
            {
                DataRow[] sellingPriceRows = commoditiesTable.Select($"CommodityName = '{selectedCommodityName}'");
                if (sellingPriceRows.Length > 0)
                {
                    decimal sellingPrice = Convert.ToDecimal(sellingPriceRows[0]["SellingPrice"]);
                    txtSellingPrice.Text = sellingPrice.ToString("N0") + " VND";
                }
                else
                {
                    txtSellingPrice.Text = string.Empty;
                }
            }
        }
        #endregion

        #region Fetch Data Employee Name
        private void FetchDataEmployeeName()
        {
            string employeeSql = @"SELECT Em.EmployeeName
                                 FROM ACCOUNT as Ac, EMPLOYEE as Em
                                 WHERE Ac.EmployeeID = @EmployeeID 
                                       AND Ac.EmployeeID = Em.EmployeeID";
            using (SqlCommand cmd = new SqlCommand(employeeSql))
            {
                try
                {
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 5).Value = employeeID;
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
        #endregion

        private void FetchData(string employeeID)
        {
            FetchDataCustomer();
            FetchDataCommodities();
            FetchDataEmployeeName();
        }

        #region Toggle Controls
        private void ToggleControls()
        {
            txtEmployeeName.Enabled = false;
            txtCustomerContact.Enabled = false;
            txtBaseUnit.Enabled = false;
            txtSellingPrice.Enabled = false;
        }
        #endregion

        #region Handle Event Add To Cart
        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtSellingPrice.Text.Replace(" VND", "").Replace(",", ""), out double price) &&
                double.TryParse(txtQuantities.Text, out double quantity))
            {
                double amount = price * quantity;
                dgvCart.Rows.Add(
                    cboCommodityName.Text,
                    txtQuantities.Text,
                    txtBaseUnit.Text,
                    price.ToString("N0") + " VND",
                    amount.ToString("N0") + " VND"
                );

                MessageBox.Show("Commodity added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTotal_TextChanged(sender, e);
                ClearAllFieldOfCommodities();
            }
            else
            {
                MessageBox.Show("Invalid price or quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAllFieldOfCommodities()
        {
            cboCommodityName.SelectedIndex = 0;
            txtQuantities.Text = "1";
            FetchDataCommodities();
        }
        #endregion

        #region Total Amount
        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            isUpdating = true;
            decimal total = 0;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    string amountStr = row.Cells[4].Value.ToString().Replace(" VND", "").Replace(",", "");
                    if (decimal.TryParse(amountStr, out decimal amount))
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
