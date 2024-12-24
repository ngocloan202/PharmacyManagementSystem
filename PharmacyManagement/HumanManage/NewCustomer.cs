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

namespace PharmacyManagement.HumanManage
{
    public partial class NewCustomer : XtraForm
    {
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        string customerName = "";
        public NewCustomer()
        {
            dataTable.OpenConnection();
            InitializeComponent();
        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {
            dgvCustomer.AutoGenerateColumns = false;

        }

        public void FetchData()
        {
            string customerSql = @"SELECT * FROM Customer";
            SqlCommand customerCmd = new SqlCommand(customerSql);
            dataTable.Fill(customerCmd);
            BindingSource binding = new BindingSource();
            binding.DataSource = dataTable;

            dgvCustomer.DataSource = binding;
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
    }
}