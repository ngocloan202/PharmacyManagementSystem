using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.Commodity
{
    public partial class AllCommodities : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        string commodityName = "";
        public AllCommodities()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }
        private void AllCommodities_Load(object sender, EventArgs e)
        {
            dgvAllCommodities.AutoGenerateColumns = false;
            FetchData();
            ToggleControls(false);
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

        private void ToggleControls(bool value)
        {
            
            txtCommodityID.Enabled = false;
            btnReload.Enabled = true;

            cboCommodityType.Enabled = value;
            txtCommodityName.Enabled = value;
            txtManufacturer.Enabled = value;
            txtQuantity.Enabled = value;
            txtBaseUnit.Enabled = value;
            txtPurchasePrice.Enabled = value;
            txtSellingPrice.Enabled = value;
            dtpMfgDate.Enabled = value;
            dtpExpDate.Enabled = value;

            btnSave.Enabled = value;

            btnEdit.Enabled = !value;
            btnDelete.Enabled = !value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCommodity();
            MessageBox.Show("Updated information successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AllCommodities_Load(sender, e);
        }

        private void UpdateCommodity()
        {
            string updateCommodityQuery = @"UPDATE COMMODITY
                                           SET CommodityName = @CommodityName,
                                               Manufacturer = @Manufacturer,
                                               Quantity = @Quantity,
                                               BaseUnit = @BaseUnit,
                                               PurchasePrice = @PurchasePrice,
                                               SellingPrice = @SellingPrice,
                                               MfgDate = @MfgDate,
                                               ExpDate = @ExpDate,
                                               CategoryID = @CategoryID
                                           WHERE CommodityID = @CommodityID";

            // Handle price string - remove "VND" and comma
            string purchasePrice = txtPurchasePrice.Text.Replace("VND", "").Replace(",", "").Replace(".", "").Trim();
            string sellingPrice = txtSellingPrice.Text.Replace("VND", "").Replace(",", "").Replace(".", "").Trim();

            SqlCommand updateCommodityCmd = new SqlCommand(updateCommodityQuery);
            updateCommodityCmd.Parameters.Add("@CommodityID", SqlDbType.VarChar, 5).Value = txtCommodityID.Text;
            updateCommodityCmd.Parameters.Add("@CommodityName", SqlDbType.VarChar, 200).Value = txtCommodityName.Text.Trim();
            updateCommodityCmd.Parameters.Add("Manufacturer", SqlDbType.NVarChar, 200).Value = txtManufacturer.Text;
            updateCommodityCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = txtQuantity.Text.ToString();
            updateCommodityCmd.Parameters.Add("BaseUnit", SqlDbType.NVarChar, 30).Value = txtBaseUnit.Text.Trim();
            updateCommodityCmd.Parameters.Add("@PurchasePrice", SqlDbType.Money).Value = Convert.ToDecimal(purchasePrice);
            updateCommodityCmd.Parameters.Add("@SellingPrice", SqlDbType.Money).Value = Convert.ToDecimal(sellingPrice);
            updateCommodityCmd.Parameters.Add("@MfgDate", SqlDbType.Date).Value = dtpMfgDate.Value.ToString();
            updateCommodityCmd.Parameters.Add("@ExpDate", SqlDbType.Date).Value = dtpExpDate.Value.ToString();
            updateCommodityCmd.Parameters.Add("@CategoryID", SqlDbType.TinyInt).Value = cboCommodityType.SelectedValue.ToString();
            dataTable.Update(updateCommodityCmd);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            AllCommodities_Load(sender, e);
            dgvAllCommodities.Sort(dgvAllCommodities.Columns["CommodityID"], ListSortDirection.Ascending);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ToggleControls(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Are you sure you want to delete this commodity? ", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string deleteCommodityQuery = @"DELETE FROM COMMODITY WHERE CommodityID = @CommodityID";
                SqlCommand deleteCommodityCmd = new SqlCommand(deleteCommodityQuery);
                deleteCommodityCmd.Parameters.Add("@CommodityID", SqlDbType.NVarChar, 5).Value = txtCommodityID.Text;
                dataTable.Update(deleteCommodityCmd);

                AllCommodities_Load(sender, e);
            }
        }

        public void FetchData(string keyword)
        {
            string commoditySql = @"SELECT C.CommodityID, C.CommodityName, C.Manufacturer, C.Quantity, 
                                    C.BaseUnit, FORMAT(C.PurchasePrice, 'N0') + ' VND' AS PurchasePrice, 
                                    FORMAT(C.SellingPrice, 'N0') + ' VND' AS SellingPrice, A.CategoryName,
                                    C.MfgDate, C.ExpDate, C.CategoryID
                               FROM COMMODITY C, CATEGORIES A
                               WHERE C.CategoryID = A.CategoryID 
                               AND (C.CommodityID LIKE @Keyword 
                                OR C.CommodityName LIKE @Keyword
                                OR C.Manufacturer LIKE @Keyword)";
            SqlCommand dgvCmd = new SqlCommand(commoditySql);
            dgvCmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + keyword + "%";
            dataTable.Fill(dgvCmd);
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvAllCommodities.DataSource = null;
                return;
            }
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

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FetchData(txtFind.Text);
        }

        private void dgvAllCommodities_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }
    }
}