using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.Invoice;
using PharmacyManagement.View;

namespace PharmacyManagement
{
    public partial class Main : XtraForm
    {
        #region Global variable
        Profile profile = null;
        NewInvoice newInvoice = null;
        AllInvoices allInvoice = null;
        private string currentRole;
        private string currentUsername;
        private string currentEmployeeID;
        #endregion
        public Main()
        {
            Flash flash = new Flash();
            flash.ShowDialog();
            while (true)
            {
                if (!IsSignInSuccessful())
                {
                    Application.Exit();
                    return;
                }
                break;
            }
            InitializeComponent();
            this.Show();
            this.IsMdiContainer = true;
            ConfigureBasedOnRole();
        }

        #region Handle Sign In
        private bool IsSignInSuccessful()
        {
            SignIn signIn = new SignIn();
            DialogResult result = signIn.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentRole = signIn.currentRoleUser;
                currentUsername = signIn.currentUsername;
                currentEmployeeID = signIn.currentEmployeeID;
                return true;
            }
            else if (result == DialogResult.Cancel)
            {
                return false;
            }
            return IsSignInSuccessful();
        }

        private void ConfigureBasedOnRole()
        {
            switch (currentRole)
            {
                case "admin":
                    admin();
                    break;

                case "user":
                    user();
                    break;

                default:
                    MessageBox.Show("Invalid user role", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    break;
            }
        }
        #endregion
        #region Close And Show New Form
        private void CloseAllMdiForms()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            profile = null;
            newInvoice = null;
        }
        #endregion

        #region configureAdmin
        public void admin()
        {
            btnProfile.Enabled = true;
            btnAllUsers.Enabled = true;
            btnAllCommodities.Enabled = true;
            btnNewUser.Enabled = true;
            btnAllUsers.Enabled = true;
            btnAllInvoices.Enabled = true;
            btnDashboard.Enabled = true;

            btnNewCommodity.Enabled = false;
            btnNewInvoice.Enabled = false;

        }
        #endregion

        #region configureUser
        public void user()
        {
            btnProfile.Enabled = true;
            btnAllUsers.Enabled = true;
            btnAllCommodities.Enabled = true;
            btnAllInvoices.Enabled = true;
            btnDashboard.Enabled = true;
            btnNewCommodity.Enabled = true;
            btnNewInvoice.Enabled = true;

            btnNewUser.Enabled = false;
            btnAllUsers.Enabled = false;

        }
        #endregion

        #region Handle Profile
        private void btnProfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllMdiForms();
            if (profile == null || profile.IsDisposed)
            {
                if (!string.IsNullOrEmpty(currentUsername))
                {
                    profile = new Profile();
                    profile.Username = currentUsername;
                    profile.MdiParent = this;
                    profile.Show();
                }
                else
                {
                    MessageBox.Show("Error: Username not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Handle Sign Out
        private void btnSignOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                SignIn signInForm = new SignIn();
                if (signInForm.ShowDialog() == DialogResult.OK)
                {
                    currentRole = signInForm.currentRoleUser;
                    currentUsername = signInForm.currentUsername;
                    ConfigureBasedOnRole();
                    this.Show(); 
                }
                else
                {
                    Application.Exit(); 
                }
            }
        }
        #endregion

        #region New Invoice
        private void btnNewInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllMdiForms();
            if (newInvoice == null || newInvoice.IsDisposed)
            {
                if (!string.IsNullOrEmpty(currentEmployeeID))
                {
                    newInvoice = new NewInvoice();
                    newInvoice.EmployeeID = currentEmployeeID;
                    newInvoice.MdiParent = this;
                    newInvoice.Show();
                }
                else
                {
                    MessageBox.Show("Error: EmployeeID not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void btnAllInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllMdiForms();
            if (allInvoice == null || allInvoice.IsDisposed)
            {
                if (!string.IsNullOrEmpty(currentEmployeeID))
                {
                    allInvoice = new AllInvoices();
                    allInvoice.EmployeeID = currentEmployeeID;
                    allInvoice.Role = currentRole;
                    allInvoice.MdiParent = this;
                    allInvoice.Show();
                }
                else
                {
                    MessageBox.Show("Error: EmployeeID not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
