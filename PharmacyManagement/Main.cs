using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.Invoice;
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
        private AllInvoices allInvoice = null;
        private NewCustomer customer = null;
        private string currentRole;
        private string currentUsername;
        private string currentEmployeeID;
        #endregion

        public Main()
        {
            InitializeComponent();

            using (Flash flash = new Flash())
            {
                flash.ShowDialog();
            }

            if (!HandleInitialSignIn())
            {
                this.Close();
                return;
            }

            ConfigureForm();
        }

        private bool HandleInitialSignIn()
        {
            using (SignIn signIn = new SignIn())
            {
                DialogResult result = signIn.ShowDialog();

                if (result == DialogResult.OK &&
                    !string.IsNullOrEmpty(signIn.currentRoleUser) &&
                    !string.IsNullOrEmpty(signIn.currentUsername))
                {
                    currentRole = signIn.currentRoleUser;
                    currentUsername = signIn.currentUsername;
                    currentEmployeeID = signIn.currentEmployeeID;
                    return true;
                }

                Program.ForceApplicationExit();
                return false;
            }
        }

        private void ConfigureForm()
        {
            this.IsMdiContainer = true;
            ConfigureBasedOnRole();
            OpenProfile();
        }

        #region Handle Sign In
        private void ConfigureBasedOnRole()
        {
            if (string.IsNullOrEmpty(currentRole))
            {
                MessageBox.Show("User role not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.ForceApplicationExit();
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
                    MessageBox.Show("Invalid user role", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.ForceApplicationExit();
                    break;
            }
        }

        private void OpenProfile()
        {
            CloseAllMdiForms();

            if (string.IsNullOrEmpty(currentUsername))
            {
                MessageBox.Show("Error: Username not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.ForceApplicationExit();
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
            btnCustomer.Enabled = true;

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

            btnCustomer.Enabled = false;
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
            if (!HandleInitialSignIn())
            {
                this.Close();
                return;
            }

            ConfigureBasedOnRole();
            OpenProfile();
            this.Show();
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

        private void btnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllMdiForms();
            customer = new NewCustomer
            {
                MdiParent = this
            };
            customer.Show();
        }

        #endregion

    }

}