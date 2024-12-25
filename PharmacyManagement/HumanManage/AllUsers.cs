using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.HumanManage
{
    public partial class AllUsers : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public AllUsers()
        {
            dataTable.OpenConnection();
            InitializeComponent();
            txtIdUser.Enabled = false;
        }

        public void GetData()
        {
            string userSql = @"SELECT ac.AccountID, ac.Username, em.EmployeeName, ac.UserRole,
                               em.Sex, em.Contact, em.Birthday, em.EmployeeAddress
                               FROM ACCOUNT as ac, EMPLOYEE as em
                               WHERE ac.EmployeeID = em.EmployeeID";
            SqlCommand userCmd = new SqlCommand(userSql);
            dataTable.Fill(userCmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvAllUsers.DataSource = binding;
            bindingNavigator.BindingSource = binding;

            txtIdUser.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtContact.DataBindings.Clear();
            txtRole.DataBindings.Clear();
            dtpBirthday.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            radMale.DataBindings.Clear();
            radFemale.DataBindings.Clear();

            txtIdUser.DataBindings.Add("Text", binding, "AccountID");
            txtUsername.DataBindings.Add("Text", binding, "Username");
            txtFullName.DataBindings.Add("Text", binding, "EmployeeName");
            txtContact.DataBindings.Add("Text", binding, "Contact");
            txtRole.DataBindings.Add("Text", binding, "UserRole");
            dtpBirthday.DataBindings.Add("Value", binding, "Birthday");
            txtAddress.DataBindings.Add("Text", binding, "EmployeeAddress");

            // Handle rad button gender
            Binding male = new Binding("Checked", dgvAllUsers.DataSource, "Sex");
            male.Format += (s, evt) =>
            {
                evt.Value = Convert.ToString(evt.Value) == "M";
            };
            radMale.DataBindings.Add(male);

            Binding female = new Binding("Checked", dgvAllUsers.DataSource, "Sex");
            female.Format += (s, evt) =>
            {
                evt.Value = Convert.ToString(evt.Value) == "F";
            };
            radFemale.DataBindings.Add(female);
        }

        private void ToggleControls(bool value)
        {
            txtIdUser.Enabled = value;
            txtUsername.Enabled = value;
            txtFullName.Enabled = value;
            txtContact.Enabled = value;
            txtRole.Enabled = value;
            dtpBirthday.Enabled = value;
            txtAddress.Enabled = value;
            radFemale.Enabled = value;
            radMale.Enabled = value;
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            dgvAllUsers.AutoGenerateColumns = false;

            GetData();
            ToggleControls(false);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            AllUsers_Load(sender, e);
            dgvAllUsers.Sort(dgvAllUsers.Columns["AccountID"], ListSortDirection.Ascending);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Are you sure you want to delete this account? ", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string deleteAccountQuery = @"DELETE FROM ACCOUNT WHERE AccountID = @AccountID";
                SqlCommand deleteAccountCmd = new SqlCommand(deleteAccountQuery);
                deleteAccountCmd.Parameters.Add("@AccountID", SqlDbType.VarChar, 50).Value = txtIdUser.Text;
                deleteAccountCmd.ExecuteNonQuery();

                AllUsers_Load(sender, e);
            }
        }

        public void GetData(string keyword)
        {
            string userSql = @"SELECT ac.AccountID, ac.Username, em.EmployeeName, ac.UserRole,
                               em.Sex, em.Contact, em.Birthday, em.EmployeeAddress
                               FROM ACCOUNT as ac, EMPLOYEE as em
                               WHERE ac.EmployeeID = em.EmployeeID
                               AND (ac.AccountID LIKE @Keyword 
                               OR ac.Username LIKE @Keyword
                               OR em.EmployeeName LIKE @Keyword)";
            SqlCommand userCmd = new SqlCommand(userSql);
            userCmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + keyword + "%";
            dataTable.Fill(userCmd);
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvAllUsers.DataSource = null;
                return;
            }
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvAllUsers.DataSource = binding;
            bindingNavigator.BindingSource = binding;

            txtIdUser.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtContact.DataBindings.Clear();
            txtRole.DataBindings.Clear();
            dtpBirthday.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            radMale.DataBindings.Clear();
            radFemale.DataBindings.Clear();

            txtIdUser.DataBindings.Add("Text", binding, "AccountID");
            txtUsername.DataBindings.Add("Text", binding, "Username");
            txtFullName.DataBindings.Add("Text", binding, "EmployeeName");
            txtContact.DataBindings.Add("Text", binding, "Contact");
            txtRole.DataBindings.Add("Text", binding, "UserRole");
            dtpBirthday.DataBindings.Add("Value", binding, "Birthday");
            txtAddress.DataBindings.Add("Text", binding, "EmployeeAddress");

            // Handle rad button gender
            Binding male = new Binding("Checked", dgvAllUsers.DataSource, "Sex");
            male.Format += (s, evt) =>
            {
                evt.Value = Convert.ToString(evt.Value) == "M";
            };
            radMale.DataBindings.Add(male);

            Binding female = new Binding("Checked", dgvAllUsers.DataSource, "Sex");
            female.Format += (s, evt) =>
            {
                evt.Value = Convert.ToString(evt.Value) == "F";
            };
            radFemale.DataBindings.Add(female);
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

        private void dgvAllUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }
    }
}