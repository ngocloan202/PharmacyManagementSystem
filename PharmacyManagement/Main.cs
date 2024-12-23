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
using PharmacyManagement.View;

namespace PharmacyManagement
{
    public partial class Main : XtraForm
    {
        #region Global variable
        SignIn signIn = new SignIn();
        Profile profile = null;
        private string currentRole;
        private string currentUsername;
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
                currentUsername = signIn.Username;
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
            else
                profile.Show();
        }
        #endregion
    }
}
