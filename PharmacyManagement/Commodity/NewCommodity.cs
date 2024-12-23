using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using PharmacyManagement.DB_query;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        private void NewCommodity_Load(object sender, EventArgs e)
        {
            FetchData();
            txtCommodityID.Select();
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


        private void CreateNewCommodity()
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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                CreateNewCommodity();
            }
        }

        #region validating input

        DXErrorProvider errorProviderID = new DXErrorProvider();
        private void txtCommodityID_Validating(object sender, CancelEventArgs e)
        {
            var edit = sender as TextEdit;
            if (string.IsNullOrWhiteSpace(txtCommodityID.Text))
            {
                errorProviderID.SetError(edit, "Please enter the Commodity ID!", ErrorType.Critical);
                txtCommodityID.Focus();
                e.Cancel = true;
            }
        }

        DXErrorProvider errorProviderName = new DXErrorProvider();
        private void txtCommodityName_Validating(object sender, CancelEventArgs e)
        {
            var edit = sender as TextEdit;
            if (string.IsNullOrWhiteSpace(txtCommodityName.Text))
            {
                errorProviderName.SetError(edit, "Please enter the Commodity Name!", ErrorType.Critical);
                txtCommodityName.Focus();
                e.Cancel = true;
            }
        }


        DXErrorProvider errorProviderMGF = new DXErrorProvider();
        private void txtManufacturer_Validating(object sender, CancelEventArgs e)
        {
            var edit = sender as TextEdit;
            if (string.IsNullOrWhiteSpace(txtManufacturer.Text))
            {
                errorProviderMGF.SetError(edit, "Please enter the Manufacturer!", ErrorType.Critical);
                txtManufacturer.Focus();
                e.Cancel = true;
            }
        }

        DXErrorProvider errorProviderUnit = new DXErrorProvider();
        private void txtBaseUnit_Validating(object sender, CancelEventArgs e)
        {
            var edit = sender as TextEdit;
            if (string.IsNullOrWhiteSpace(txtBaseUnit.Text))
            {
                errorProviderUnit.SetError(edit, "Please enter the Base Unit!", ErrorType.Critical);
                txtBaseUnit.Focus();
                e.Cancel = true;
            }
        }

        DXErrorProvider errorProviderQuantity = new DXErrorProvider();
        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            var edit = sender as TextEdit;
            if (!int.TryParse(txtQuantity.Text, out _))
            {
                errorProviderQuantity.SetError(edit, "Please enter a valid number!", ErrorType.Critical);
                e.Cancel = true;
            }
        }

        DXErrorProvider errorProviderExpDate = new DXErrorProvider();
        private void dtpExpDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpExpDate.Value <= dtpMfgDate.Value)
            {
                errorProviderExpDate.SetError(dtpExpDate, "Expiry date must be after manufacturing date!", ErrorType.Critical);
                e.Cancel = true;
            }
            else
            {
                errorProviderExpDate.SetError(dtpExpDate, "");
            }
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