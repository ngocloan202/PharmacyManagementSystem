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

namespace PharmacyManagement.Commodity
{
    public partial class AllCommodities : DevExpress.XtraEditors.XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        string commodityName = "";
        public AllCommodities()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }
        public void getData()
        {
            string typeSql = "SELECT * FROM CATEGORIES";
            SqlCommand typeCmd = new SqlCommand(typeSql);
            dataTable.Fill(typeCmd);
            cboCommodityType.DataSource = dataTable;
            cboCommodityType.DisplayMember = "CategoryName";
            cboCommodityType.ValueMember = "CategoryID";

            string commoditySql = @"SELECT C.*, A.CategoryName
                               FROM COMMODITY C, CATEGORIES A
                               WHERE C.CategoryID = A.CategoryID";
            SqlCommand dgvCmd = new SqlCommand(commoditySql);
            dataTable.Fill(dgvCmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvAllCommodities.DataSource = binding;
            bindingNavigator.BindingSource = binding;

            txtCommodityID.DataBindings.Clear();
            cboCommodityType.DataBindings.Clear();
            txtCommodityName.DataBindings.Clear();
            txtManufacturer.DataBindings.Clear();
            txtPurchasePrice.DataBindings.Clear();
            txtSellingPrice.DataBindings.Clear();
            dtpMfgDate.DataBindings.Clear();
            dtpExpDate.DataBindings.Clear();

            txtCommodityID.DataBindings.Add("Text", binding, "AccountID");
            txtCommodityName.DataBindings.Add("Text", binding, "Username");
            txtManufacturer.DataBindings.Add("Text", binding, "UserPassword");
            txtPurchasePrice.DataBindings.Add("Text", binding, "UserRole");
            txtFullName.DataBindings.Add("Text", binding, "EmployeeName");
        }
    }
}