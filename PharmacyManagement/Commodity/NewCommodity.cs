using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PharmacyManagement.Commodity
{
    public partial class NewCommodity : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public NewCommodity()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        private void NewCommodity_Load(object sender, EventArgs e)
        {
            FetchData();
            txtCommodityID.Select();
            btnCancel.Enabled = false;
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
        }



        private void CreateNewCommodity(object sender, EventArgs e)
        {
            try
            {
                string sql = @"INSERT INTO COMMODITY VALUES(@CommodityID, @CommodityName, @Manufacturer, 
                      @Quantity, @BaseUnit, @PurchasePrice, @SellingPrice, @MfgDate, @ExpDate, @CategoryID)";
                SqlCommand cmd = new SqlCommand(sql);

                if (!int.TryParse(txtQuantity.Text, out int quantity) ||
                    !decimal.TryParse(txtPurchasePrice.Text, out decimal purchasePrice) ||
                    !decimal.TryParse(txtSellingPrice.Text, out decimal sellingPrice))
                {
                    MessageBox.Show("Invalid numeric values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmd.Parameters.Add("@CommodityID", SqlDbType.NVarChar, 5).Value = txtCommodityID.Text;
                cmd.Parameters.Add("@CommodityName", SqlDbType.NVarChar, 200).Value = txtCommodityName.Text;
                cmd.Parameters.Add("@Manufacturer", SqlDbType.NVarChar, 200).Value = txtManufacturer.Text;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@BaseUnit", SqlDbType.NVarChar, 30).Value = txtBaseUnit.Text;
                cmd.Parameters.Add("@PurchasePrice", SqlDbType.Money).Value = purchasePrice;
                cmd.Parameters.Add("@SellingPrice", SqlDbType.Money).Value = sellingPrice;
                cmd.Parameters.Add("@MfgDate", SqlDbType.Date).Value = dtpMfgDate.Value;
                cmd.Parameters.Add("@ExpDate", SqlDbType.Date).Value = dtpExpDate.Value;
                cmd.Parameters.Add("@CategoryID", SqlDbType.TinyInt).Value = Convert.ToByte(cboCommodityType.SelectedValue);

                dataTable.Update(cmd);
                MessageBox.Show("Commodity added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllFields();
                NewCommodity_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAllFields()
        {
            txtCommodityID.Text = string.Empty;
            txtCommodityName.Text = string.Empty;
            txtManufacturer.Text = string.Empty;
            txtQuantity.Text = "1";
            txtBaseUnit.Text = string.Empty;
            txtPurchasePrice.Text = "0";
            txtSellingPrice.Text = "0";
            dtpMfgDate.Value = DateTime.Now;
            dtpExpDate.Value = DateTime.Now;
            cboCommodityType.SelectedIndex = 0; 

            txtCommodityID.Select();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            if (ValidateInput())
            {
                CreateNewCommodity(sender, e);
            }
        }

        #region validating input
        private bool ValidateInput()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.IsBalloon = true;

            toolTip.Hide(txtCommodityID);
            toolTip.Hide(txtCommodityName);
            toolTip.Hide(txtManufacturer);
            toolTip.Hide(txtBaseUnit);
            toolTip.Hide(txtQuantity);

            // Validate Commodity ID
            if (string.IsNullOrWhiteSpace(txtCommodityID.Text))
            {
                toolTip.Show("Please enter the Commodity ID!", txtCommodityID,
                    txtCommodityID.Width - 15, txtCommodityID.Height - 80, 2000);
                txtCommodityID.Focus();
                return false;
            }

            string commodityIdPattern = @"^(MD|IN)\d{3}$";
            if (!Regex.IsMatch(txtCommodityID.Text, commodityIdPattern))
            {
                toolTip.Show("Commodity ID must start with 'MD' or 'IN' followed by 3 digits (e.g., MD123 or IN456)!", txtCommodityID,
                    txtCommodityID.Width - 15, txtCommodityID.Height - 80, 2000);
                txtCommodityID.Focus();
                return false;
            }

            // Validate Commodity Name
            if (string.IsNullOrWhiteSpace(txtCommodityName.Text))
            {
                toolTip.Show("Please enter the Commodity Name!", txtCommodityName,
                    txtCommodityName.Width - 15, txtCommodityName.Height - 80, 2000);
                txtCommodityName.Focus();
                return false;
            }

            // Validate Manufacturer
            if (string.IsNullOrWhiteSpace(txtManufacturer.Text))
            {
                toolTip.Show("Please enter the Manufacturer!", txtManufacturer,
                    txtManufacturer.Width - 15, txtManufacturer.Height - 80, 2000);
                txtManufacturer.Focus();
                return false;
            }

            // Validate Base Unit
            if (string.IsNullOrWhiteSpace(txtBaseUnit.Text))
            {
                toolTip.Show("Please enter the Base Unit!", txtBaseUnit,
                    txtBaseUnit.Width - 15, txtBaseUnit.Height - 80, 2000);
                txtBaseUnit.Focus();
                return false;
            }

            // Validate Quantity
            if (!int.TryParse(txtQuantity.Text, out _))
            {
                toolTip.Show("Please enter a valid number for Quantity!", txtQuantity,
                    txtQuantity.Width - 15, txtQuantity.Height - 80, 2000);
                txtQuantity.Focus();
                return false;
            }

            // Validate Expiry Date
            if (dtpExpDate.Value <= dtpMfgDate.Value)
            {
                toolTip.Show("Expiry date must be after manufacturing date!", dtpExpDate,
                    dtpExpDate.Width - 15, dtpExpDate.Height - 80, 2000);
                dtpExpDate.Focus();
                return false;
            }

            return true;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the changes?",
                "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                NewCommodity_Load(sender, e);
            }
        }


    }
}