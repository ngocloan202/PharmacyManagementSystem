﻿using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.Invoice
{
    public partial class AllInvoices : XtraForm
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
            ToggleControls(false);
        }

        private void GetData()
        {
            string selectAllInvoicesQuery = @"SELECT ivd.InvoiceID, cus.CustomerName, cus.Contact,
                                                     iv.CreatedDate, iv.Note, em.EmployeeName, 
                                                     FORMAT(ivd.Amount, 'N0') + ' VND' AS Amount
                                              FROM INVOICE as iv, INVOICEDETAILS as ivd, EMPLOYEE as em, CUSTOMER as cus
                                              WHERE iv.InvoiceID = ivd.InvoiceID 
                                                    AND iv.EmployeeID = em.EmployeeID
                                                    AND iv.CustomerID = cus.CustomerID
                                             ";
            SqlCommand userCmd = new SqlCommand(selectAllInvoicesQuery);
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
    }
}