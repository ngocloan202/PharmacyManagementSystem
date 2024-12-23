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
        private string currentRole;
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
    }
}
