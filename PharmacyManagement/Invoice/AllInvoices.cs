using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.Invoice
{
    public partial class AllInvoices : XtraForm
    {
        private string employeeID;
        private string role;
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public string EmployeeID{get => employeeID; set => employeeID = value;}

        public string Role{get => role; set => role = value;}

        public AllInvoices()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        private void AllInvoices_Load(object sender, EventArgs e)
        {
            dgvAllInvoices.AutoGenerateColumns = false;
            GetData();
            ToggleControls(false);
        }

        private void GetData()
        {
            string selectAllInvoicesQuery;

            if (role == "admin")
            {
                selectAllInvoicesQuery = @"SELECT ivd.InvoiceID, cus.CustomerName, cus.Contact,
                                                  iv.CreatedDate, iv.Note, em.EmployeeName, 
                                               FORMAT(Sum(ivd.Amount), 'N0') + ' VND' AS Amount
                                           FROM INVOICE iv, INVOICEDETAILS ivd, EMPLOYEE em, CUSTOMER cus
                                           WHERE iv.InvoiceID = ivd.InvoiceID 
                                                 AND iv.EmployeeID = em.EmployeeID
                                                 AND iv.CustomerID = cus.CustomerID
                                           Group by ivd.InvoiceID, cus.CustomerName, cus.Contact,
                                                    iv.CreatedDate, iv.Note, em.EmployeeName";
            }
            else
            {
                selectAllInvoicesQuery = @"SELECT ivd.InvoiceID, cus.CustomerName, cus.Contact,
                                                  FORMAT(iv.CreatedDate, 'MM/dd/yyyy'), iv.Note, em.EmployeeName, 
                                                  FORMAT(Sum(ivd.Amount), 'N0') + ' VND' AS Amount
                                           FROM INVOICE iv, INVOICEDETAILS ivd, EMPLOYEE em, CUSTOMER cus
                                           WHERE iv.InvoiceID = ivd.InvoiceID 
                                                  AND iv.EmployeeID = em.EmployeeID
                                                  AND iv.CustomerID = cus.CustomerID
	                                              AND em.EmployeeID = 'E002'
                                           Group by ivd.InvoiceID, cus.CustomerName, cus.Contact,
		                                            iv.CreatedDate, iv.Note, em.EmployeeName";
            }

            SqlCommand userCmd = new SqlCommand(selectAllInvoicesQuery);
            if (role != "admin")
            {
                userCmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 5).Value = employeeID;
            }

            dataTable.Fill(userCmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvAllInvoices.DataSource = binding;
            bindingNavigator.BindingSource = binding;

            txtIdInvoice.DataBindings.Clear();
            txtCustomerName.DataBindings.Clear();
            txtCustomerContact.DataBindings.Clear();
            txtCreateBy.DataBindings.Clear();
            txtNote.DataBindings.Clear();
            dtpDateCreated.DataBindings.Clear();
            txtTotal.DataBindings.Clear();

            txtIdInvoice.DataBindings.Add("Text", binding, "InvoiceID");
            txtCustomerName.DataBindings.Add("Text", binding, "CustomerName");
            txtCustomerContact.DataBindings.Add("Text", binding, "Contact");
            txtCreateBy.DataBindings.Add("Text", binding, "EmployeeName");
            txtNote.DataBindings.Add("Text", binding, "Note");
            dtpDateCreated.DataBindings.Add("Value", binding, "CreatedDate");
            txtTotal.DataBindings.Add("Text", binding, "Amount");
        }

        private void ToggleControls(bool value)
        {
            txtIdInvoice.Enabled = value;
            txtCustomerName.Enabled = value;
            txtCustomerContact.Enabled = value;
            txtCreateBy.Enabled = value;
            txtNote.Enabled = value;
            dtpDateCreated.Enabled = value;
            txtTotal.Enabled = value;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            AllInvoices_Load(sender, e);
            dgvAllInvoices.Sort(dgvAllInvoices.Columns["InvoiceID"], ListSortDirection.Ascending);
        }
        private void GetData(string keyword)
        {
            string selectAllInvoicesQuery;

            if (role == "admin")
            {
                selectAllInvoicesQuery = @"SELECT ivd.InvoiceID, cus.CustomerName, cus.Contact,
                                     iv.CreatedDate, iv.Note, em.EmployeeName, 
                                     FORMAT(ivd.Amount, 'N0') + ' VND' AS Amount
                              FROM INVOICE iv, INVOICEDETAILS ivd, EMPLOYEE em, CUSTOMER cus
                              WHERE iv.InvoiceID = ivd.InvoiceID 
                                    AND iv.EmployeeID = em.EmployeeID
                                    AND iv.CustomerID = cus.CustomerID 
                                    AND (ivd.InvoiceID LIKE @Keyword 
                                    OR em.EmployeeName LIKE @Keyword 
                                    OR cus.CustomerName LIKE @Keyword)";
            }
            else
            {
                selectAllInvoicesQuery = @"SELECT ivd.InvoiceID, cus.CustomerName, cus.Contact,
                                     iv.CreatedDate, iv.Note, em.EmployeeName, 
                                     FORMAT(ivd.Amount, 'N0') + ' VND' AS Amount
                              FROM INVOICE iv, INVOICEDETAILS ivd, EMPLOYEE em, CUSTOMER cus
                              WHERE iv.InvoiceID = ivd.InvoiceID 
                                    AND iv.EmployeeID = em.EmployeeID
                                    AND iv.CustomerID = cus.CustomerID
                                    AND iv.EmployeeID = @EmployeeID
                                    AND (ivd.InvoiceID LIKE @Keyword 
                                    OR cus.CustomerName LIKE @Keyword)";
            }

                SqlCommand cmd = new SqlCommand(selectAllInvoicesQuery);
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + keyword + "%";
                if (role != "admin")
                {
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 5).Value = employeeID;
                }

                try
                {
                    dataTable.Fill(cmd);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvAllInvoices.DataSource = null;
                        return;
                    }

                    BindingSource binding = new BindingSource();
                    binding.DataSource = dataTable;

                    dgvAllInvoices.DataSource = binding;
                    bindingNavigator.BindingSource = binding;

                    txtIdInvoice.DataBindings.Clear();
                    txtCustomerName.DataBindings.Clear();
                    txtCustomerContact.DataBindings.Clear();
                    txtCreateBy.DataBindings.Clear();
                    txtNote.DataBindings.Clear();
                    dtpDateCreated.DataBindings.Clear();
                    txtTotal.DataBindings.Clear();

                    txtIdInvoice.DataBindings.Add("Text", binding, "InvoiceID");
                    txtCustomerName.DataBindings.Add("Text", binding, "CustomerName");
                    txtCustomerContact.DataBindings.Add("Text", binding, "Contact");
                    txtCreateBy.DataBindings.Add("Text", binding, "EmployeeName");
                    txtNote.DataBindings.Add("Text", binding, "Note");
                    dtpDateCreated.DataBindings.Add("Value", binding, "CreatedDate");
                    txtTotal.DataBindings.Add("Text", binding, "Amount");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error performing search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            GetData(txtFind.Text);
        }

        private void dgvAllInvoices_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }
    }
}