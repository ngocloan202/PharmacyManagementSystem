using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.View
{
    public partial class Profile : XtraForm
    {
        private string username;
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();

        public string Username
        {
            get => username;
            set => username = value;
        }

        public Profile()
        {
            InitializeComponent();
            dataTable.OpenConnection();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                FetchData(Username);
            }
        }

        public void FetchData(string username)
        {
            string profileSql = @"SELECT Ac.AccountID, Ac.Username, Em.EmployeeName, Em.Sex, 
                                        Em.Contact, Em.Birthday, Em.EmployeeAddress
                                 FROM ACCOUNT as Ac
                                 INNER JOIN EMPLOYEE as Em ON Ac.EmployeeID = Em.EmployeeID 
                                 WHERE Ac.Username = @Username";

            using (SqlCommand cmd = new SqlCommand(profileSql))
            {
                try
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                    dataTable.Fill(cmd);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        txtIdProfile.Text = row["AccountID"].ToString();
                        txtUsername.Text = row["Username"].ToString();
                        txtFullName.Text = row["EmployeeName"].ToString();
                        txtContact.Text = row["Contact"].ToString();
                        txtAddress.Text = row["EmployeeAddress"].ToString();

                        if (row["Sex"].ToString() == "M")
                        {
                            radMale.Checked = true;
                        }
                        else if (row["Sex"].ToString() == "F")
                        {
                            radFemale.Checked = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in FetchData: {ex.Message}");
                }
            }
        }
    }
}