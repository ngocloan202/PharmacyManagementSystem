using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
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
            DataGridViewTextBoxColumn commodityIDColumn = new DataGridViewTextBoxColumn();
            commodityIDColumn.Name = "CommodityID";
            commodityIDColumn.Visible = false; 
            dgvCart.Columns.Add(commodityIDColumn);

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
                    amount.ToString("N0") + " VND",
                    cboCommodityName.SelectedValue.ToString()
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove the selected item from the cart?",
                                                      "Confirm Removal",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dgvCart.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
                    lblTotal_TextChanged(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    // Insert into INVOICE
                    string insertInvoiceSql = @"INSERT INTO INVOICE (InvoiceID, CreatedDate, Note, EmployeeID, CustomerID)
                                    VALUES (@InvoiceID, @CreatedDate, @Note, @EmployeeID, @CustomerID)";
                    SqlCommand insertInvoiceCmd = new SqlCommand(insertInvoiceSql);
                    insertInvoiceCmd.Parameters.Add("@InvoiceID", SqlDbType.VarChar, 5).Value = txtInvoiceID.Text;
                    insertInvoiceCmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = dtpDateCreated.Value;
                    insertInvoiceCmd.Parameters.Add("@Note", SqlDbType.NVarChar, 200).Value = txtNote.Text;
                    insertInvoiceCmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 5).Value = employeeID;
                    insertInvoiceCmd.Parameters.Add("@CustomerID", SqlDbType.VarChar, 5).Value = cboCustomerName.SelectedValue.ToString();

                    dataTable.Update(insertInvoiceCmd);

                    // Insert into INVOICEDETAILS
                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string commodityID = row.Cells[5].Value.ToString();
                            int quantity = int.Parse(row.Cells[1].Value.ToString());
                            decimal unitPrice = decimal.Parse(row.Cells[3].Value.ToString().Replace(" VND", "").Replace(",", ""));
                            decimal amount = decimal.Parse(row.Cells[4].Value.ToString().Replace(" VND", "").Replace(",", ""));

                            string insertInvoiceDetailsSql = @"INSERT INTO INVOICEDETAILS (InvoiceID, CommodityID, Quantity, UnitPrice, Amount)
                                                   VALUES (@InvoiceID, @CommodityID, @Quantity, @UnitPrice, @Amount)";
                            SqlCommand insertInvoiceDetailsCmd = new SqlCommand(insertInvoiceDetailsSql);
                            insertInvoiceDetailsCmd.Parameters.Add("@InvoiceID", SqlDbType.VarChar, 5).Value = txtInvoiceID.Text;
                            insertInvoiceDetailsCmd.Parameters.Add("@CommodityID", SqlDbType.VarChar, 5).Value = commodityID;
                            insertInvoiceDetailsCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                            insertInvoiceDetailsCmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = unitPrice;
                            insertInvoiceDetailsCmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amount;

                            dataTable.Update(insertInvoiceDetailsCmd);
                        }
                    }
                    MessageBox.Show("Invoice and details added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    dgvCart.Rows.Clear();
                    NewInvoice_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        #region validating input
        private bool ValidateInput()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.IsBalloon = true;

            toolTip.Hide(txtInvoiceID);
            toolTip.Hide(txtQuantities);

            // Validate Invoice ID
            if (string.IsNullOrWhiteSpace(txtInvoiceID.Text))
            {
                toolTip.Show("Please enter the Invoice ID!", txtInvoiceID,
                    txtInvoiceID.Width - 15, txtInvoiceID.Height - 80, 2000);
                txtInvoiceID.Focus();
                return false;
            }

            // Validate Quantities
            if (string.IsNullOrWhiteSpace(txtQuantities.Text))
            {
                toolTip.Show("Please enter the Quantity!", txtQuantities,
                    txtQuantities.Width - 15, txtQuantities.Height - 80, 2000);
                txtQuantities.Focus();
                return false;
            }


            // Validate Quantity
            if (!int.TryParse(txtQuantities.Text, out _))
            {
                toolTip.Show("Please enter a valid number for Quantity!", txtQuantities,
                    txtQuantities.Width - 15, txtQuantities.Height - 80, 2000);
                txtQuantities.Focus();
                return false;
            }

            return true;
        }
        #endregion

        private void ClearFields()
        {
            txtInvoiceID.Text = "";
            cboCustomerName.SelectedIndex = 0;
            txtQuantities.Text = "1";
            dtpDateCreated.Value = DateTime.Now;
            txtNote.Text = "";
            txtInvoiceID.Select();
        }
    }
}
