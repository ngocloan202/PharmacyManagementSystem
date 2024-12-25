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
using PharmacyManagement.HumanManage;
using PharmacyManagement.View;

namespace PharmacyManagement
{
    public partial class Main : XtraForm
    {
        #region Global variable
        private Profile profile = null;
        private NewInvoice newInvoice = null;
        private NewAccount newAccount = null;
        private string currentRole;
        private string currentUsername;
        private string currentEmployeeID;
        #endregion

        public Main()
        {
            InitializeComponent();
            ShowFlashScreen();
            HandleInitialSignIn();
            ConfigureForm();
        }

        private void ShowFlashScreen()
        {
            using (Flash flash = new Flash())
            {
                flash.ShowDialog();
            }
        }

        private void HandleInitialSignIn()
        {
            if (!IsSignInSuccessful())
            {
                Application.Exit();
            }
        }

        private void ConfigureForm()
        {
            this.IsMdiContainer = true;
            ConfigureBasedOnRole();
            OpenProfile();
        }

        #region Handle Sign In
        private bool IsSignInSuccessful()
        {
            using (SignIn signIn = new SignIn())
            {
                DialogResult result = signIn.ShowDialog();
                if (result == DialogResult.OK)
                {
                    currentRole = signIn.currentRoleUser;
                    currentUsername = signIn.currentUsername;
                    currentEmployeeID = signIn.currentEmployeeID;
                    return true;
                }
                return result != DialogResult.Cancel && IsSignInSuccessful();
            }
        }

        private void ConfigureBasedOnRole()
        {
            if (string.IsNullOrEmpty(currentRole))
            {
                ShowErrorAndExit("User role not found");
                return;
            }

            switch (currentRole.ToLower())
            {
                case "admin":
                    ConfigureAdminRole();
                    break;

                case "user":
                    ConfigureUserRole();
                    break;

                default:
                    ShowErrorAndExit("Invalid user role");
                    break;
            }
        }

        private void ShowErrorAndExit(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private void OpenProfile()
        {
            CloseAllMdiForms();
            if (string.IsNullOrEmpty(currentUsername))
            {
                MessageBox.Show("Error: Username not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            profile = new Profile
            {
                Username = currentUsername,
                MdiParent = this
            };
            profile.Show();
        }
        #endregion

        #region Close And Show New Form
        private void CloseAllMdiForms()
        {
            foreach (Form form in this.MdiChildren)
            {
                form?.Close();
            }
            profile = null;
            newInvoice = null;
            newAccount = null;
        }
        #endregion

        #region Configure Roles
        private void ConfigureAdminRole()
        {
            btnProfile.Enabled = true;
            btnAllUsers.Enabled = true;
            btnAllCommodities.Enabled = true;
            btnNewUser.Enabled = true;
            btnAllInvoices.Enabled = true;
            btnDashboard.Enabled = true;
            btnNewAccount.Enabled = true;

            btnNewCommodity.Enabled = false;
            btnNewInvoice.Enabled = false;
        }

        private void ConfigureUserRole()
        {
            btnProfile.Enabled = true;
            btnAllCommodities.Enabled = true;
            btnAllInvoices.Enabled = true;
            btnDashboard.Enabled = true;
            btnNewCommodity.Enabled = true;
            btnNewInvoice.Enabled = true;

            btnNewUser.Enabled = false;
            btnAllUsers.Enabled = false;
            btnNewAccount.Enabled = false;
        }
        #endregion

        #region Event Handlers
        private void btnProfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenProfile();
        }

        private void btnSignOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            this.Hide();
            using (SignIn signInForm = new SignIn())
            {
                if (signInForm.ShowDialog() == DialogResult.OK)
                {
                    currentRole = signInForm.currentRoleUser;
                    currentUsername = signInForm.currentUsername;
                    currentEmployeeID = signInForm.currentEmployeeID;
                    ConfigureBasedOnRole();
                    OpenProfile();
                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void btnNewInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllMdiForms();
            if (string.IsNullOrEmpty(currentEmployeeID))
            {
                MessageBox.Show("Error: EmployeeID not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            newInvoice = new NewInvoice
            {
                EmployeeID = currentEmployeeID,
                MdiParent = this
            };
            newInvoice.Show();
        }

        private void btnNewAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllMdiForms();
            newAccount = new NewAccount
            {
                MdiParent = this
            };
            newAccount.Show();
        }
        #endregion
    }
}