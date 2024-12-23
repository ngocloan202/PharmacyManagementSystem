using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;
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

namespace PharmacyManagement.Commodity
{
    public partial class NewCommodity : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        string commodityName = "";
        public NewCommodity()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        private void NewCommodity_Load(object sender, EventArgs e)
        {

        }

        public void FetchData()
        {
            PharmacyMgtDatabase categogyTable = new PharmacyMgtDatabase();
            categogyTable.OpenConnection();
            string typeSql = "SELECT * FROM CATEGORIES";
            SqlCommand typeCmd = new SqlCommand(typeSql);
            categogyTable.Fill(typeCmd);
            cboCommodityType.DataSource = categogyTable;
            cboCommodityType.DisplayMember = "CategoryName";
            cboCommodityType.ValueMember = "CategoryID";

            string commoditySql = @"SELECT C.CommodityID, C.CommodityName, C.Manufacturer, C.Quantity, 
                                    C.BaseUnit, FORMAT(C.PurchasePrice, 'N0') + ' VND' AS PurchasePrice, 
                                    FORMAT(C.SellingPrice, 'N0') + ' VND' AS SellingPrice, A.CategoryName,
                                    C.MfgDate, C.ExpDate, C.CategoryID
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
            txtQuantity.DataBindings.Clear();
            txtBaseUnit.DataBindings.Clear();
            txtPurchasePrice.DataBindings.Clear();
            txtSellingPrice.DataBindings.Clear();
            dtpMfgDate.DataBindings.Clear();
            dtpExpDate.DataBindings.Clear();

            txtCommodityID.DataBindings.Add("Text", binding, "CommodityID");
            cboCommodityType.DataBindings.Add("SelectedValue", binding, "CategoryID");
            txtCommodityName.DataBindings.Add("Text", binding, "CommodityName");
            txtManufacturer.DataBindings.Add("Text", binding, "Manufacturer");
            txtQuantity.DataBindings.Add("Text", binding, "Quantity");
            txtBaseUnit.DataBindings.Add("Text", binding, "BaseUnit");
            txtPurchasePrice.DataBindings.Add("Text", binding, "PurchasePrice");
            txtSellingPrice.DataBindings.Add("Text", binding, "SellingPrice");
            dtpMfgDate.DataBindings.Add("Value", binding, "MfgDate");
            dtpExpDate.DataBindings.Add("Value", binding, "ExpDate");
        }
    }
}