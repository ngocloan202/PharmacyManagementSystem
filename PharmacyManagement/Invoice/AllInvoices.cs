using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.Invoice
{
    public partial class AllInvoices : DevExpress.XtraEditors.XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public AllInvoices()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        private void AllInvoices_Load(object sender, EventArgs e)
        {
            dgvAllInvoices.AutoGenerateColumns = false;
            GetData();
        }

        private void GetData()
        {
            string selectAllInvoicesQuery = @"SELECT ivd.InvoiceID, cus.CustomerName, cus.Contact,
                                                     iv.CreatedDate, iv.Note, em.EmployeeName, ivd.Amount
                                              FROM INVOICE as iv, INVOICEDETAILS as ivd, EMPLOYEE as em, CUSTOMER as cus
                                              WHERE iv.InvoiceID = ivd.InvoiceID and iv.EmployeeID = em.EmployeeID
		                                      and iv.CustomerID = cus.CustomerID";
            SqlCommand userCmd = new SqlCommand(selectAllInvoicesQuery);
            dataTable.Fill(userCmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvAllInvoices.DataSource = binding;
            bindingNavigator.BindingSource = binding;
        }

        private void dgvAllInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAllInvoices.Columns[e.ColumnIndex].Name == "Amount" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = $"{amount.ToString("N0")} VND";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}