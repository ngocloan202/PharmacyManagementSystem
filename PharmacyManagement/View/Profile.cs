﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Security;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement.View
{
    public partial class Profile : XtraForm
    {
        private string username;
        private string currentRole;
        string oldUsername = "";
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();

        public string Username
        {
            get => username;
            set => username = value;
        }
        public string Role 
        { 
            get => currentRole; 
            set => currentRole = value; 
        }

        public Profile()
        {
            InitializeComponent();
            dataTable.OpenConnection();
            txtUsername.MouseClick += Guna2TextBox_MouseClick;
            txtFullName.MouseClick += Guna2TextBox_MouseClick;
            txtContact.MouseClick += Guna2TextBox_MouseClick;
            txtAddress.MouseClick += Guna2TextBox_MouseClick;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                if (Role?.ToLower() == "guest")
                {
                    HandleGuestProfile();
                    ToggleControlsOfGuest();
                }
                else
                {
                    FetchData(Username);
                    ToggleControls(false);
                }
            }
        }

        private void HandleGuestProfile()
        {
            txtIdProfile.Text = string.Empty;
            txtUsername.Text = Username;
            txtFullName.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            dtpBirthday.Value = DateTime.Today;
            radMale.Checked = false;
            radFemale.Checked = false;

            btnEdit.Enabled = false;
        }

        private void FetchData(string username)
        {
            string profileSql = @"SELECT Ac.EmployeeID, Ac.Username, Em.EmployeeName, Em.Sex, 
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
                        txtIdProfile.Text = row["EmployeeID"].ToString();
                        txtUsername.Text = row["Username"].ToString();
                        txtFullName.Text = row["EmployeeName"].ToString();
                        txtContact.Text = row["Contact"].ToString();
                        txtAddress.Text = row["EmployeeAddress"].ToString();
                        dtpBirthday.Value = Convert.ToDateTime(row["Birthday"]);

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

        private void Guna2TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2TextBox guna2TextBox && guna2TextBox.Enabled)
            {
                Point clickPoint = e.Location;

                int index = GetCharIndexFromPosition(guna2TextBox, clickPoint);

                guna2TextBox.SelectionStart = index;
                guna2TextBox.Focus();
            }
        }

        private int GetCharIndexFromPosition(Guna.UI2.WinForms.Guna2TextBox textBox, Point point)
        {
            Graphics g = textBox.CreateGraphics();
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    SizeF size = g.MeasureString(textBox.Text.Substring(0, i), textBox.Font);
                    if (size.Width > point.X)
                    {
                        return i; 
                    }
                }
            return textBox.Text.Length;
        }
        private void ToggleControls(bool value)
        {
            txtIdProfile.Enabled = false;

            txtFullName.Enabled = value;
            txtUsername.Enabled = value;
            txtContact.Enabled = value;
            txtAddress.Enabled = value;
            radFemale.Enabled = value;
            radMale.Enabled = value;
            dtpBirthday.Enabled = value;
            btnSave.Enabled = value;
            btnCancel.Enabled = value;

            btnEdit.Enabled = !value;
        }
        private void ToggleControlsOfGuest()
        {
            txtUsername.ReadOnly = true;
            txtUsername.TabStop = false;

            txtIdProfile.Enabled = false;
            txtFullName.Enabled = false;
            txtContact.Enabled = false;
            txtAddress.Enabled = false;
            radFemale.Enabled = false;
            radMale.Enabled = false;
            dtpBirthday.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            oldUsername = txtUsername.Text;
            ToggleControls(true);
            txtUsername.Focus();
        }

        private void UpdateUsername()
        {
            string updateAccountQuery = @"UPDATE ACCOUNT
                                   SET Username = @newUsername
                                   WHERE Username = @oldUsername";
            SqlCommand updateAccountCmd = new SqlCommand(updateAccountQuery);
            updateAccountCmd.Parameters.Add("@newUsername", SqlDbType.VarChar, 50).Value = txtUsername.Text.Trim();
            updateAccountCmd.Parameters.Add("@oldUsername", SqlDbType.VarChar, 50).Value = oldUsername;
            dataTable.Update(updateAccountCmd);
        }
        private void UpdateInfor()
        {
            string updateInforQuery = @"UPDATE EMPLOYEE
                                        SET EmployeeName = @EmployeeName,
                                            Sex = @Sex,
                                            Contact = @Contact,
                                            Birthday = @Birthday,
                                            EmployeeAddress = @EmployeeAddress
                                        WHERE EmployeeID = @EmployeeID";
            SqlCommand updateInforCmd = new SqlCommand(updateInforQuery);
            updateInforCmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50).Value = txtIdProfile.Text.Trim();
            updateInforCmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar, 200).Value = txtFullName.Text.Trim();
            updateInforCmd.Parameters.Add("@Sex", SqlDbType.VarChar, 1).Value = radFemale.Checked ? "F" : "M";
            updateInforCmd.Parameters.Add("@Contact", SqlDbType.NVarChar, 200).Value = txtContact.Text.Trim();
            updateInforCmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = dtpBirthday.Value;
            updateInforCmd.Parameters.Add("@EmployeeAddress", SqlDbType.NVarChar, 200).Value = txtAddress.Text.Trim();
            dataTable.Update(updateInforCmd);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateUsername();
            UpdateInfor();
            MessageBox.Show("Updated information successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Profile_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the changes?", 
                "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(Username))
                {
                    FetchData(Username);
                }
                ToggleControls(false);
            }
        }
    }
}