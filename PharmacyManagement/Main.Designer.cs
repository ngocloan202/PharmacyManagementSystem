namespace PharmacyManagement
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDashboard = new DevExpress.XtraBars.BarButtonItem();
            this.btnProfile = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewCommodity = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllCommodities = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.btnSignOut = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllInvoices = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllUsers = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewAccount = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.pgHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgCommodity = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgHumanManage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgInvoice = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnAllAccounts = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnDashboard,
            this.btnProfile,
            this.btnNewCommodity,
            this.btnAllCommodities,
            this.btnNewInvoice,
            this.btnSignOut,
            this.btnAllInvoices,
            this.btnAbout,
            this.btnNewUser,
            this.btnAllUsers,
            this.barButtonItem1,
            this.btnNewAccount,
            this.btnCustomer,
            this.btnAllAccounts});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btnAbout);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pgHome,
            this.pgCommodity,
            this.pgHumanManage,
            this.pgInvoice});
            this.ribbonControl1.Size = new System.Drawing.Size(1278, 150);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Caption = "Dashboard";
            this.btnDashboard.Id = 1;
            this.btnDashboard.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.dashboard_32;
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnProfile
            // 
            this.btnProfile.Caption = "Profile";
            this.btnProfile.Id = 2;
            this.btnProfile.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.profile_icon_32px;
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnProfile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProfile_ItemClick);
            // 
            // btnNewCommodity
            // 
            this.btnNewCommodity.Caption = "New Commodity";
            this.btnNewCommodity.Id = 3;
            this.btnNewCommodity.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.medicine_32px;
            this.btnNewCommodity.Name = "btnNewCommodity";
            this.btnNewCommodity.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNewCommodity.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewCommodity_ItemClick);
            // 
            // btnAllCommodities
            // 
            this.btnAllCommodities.Caption = "All Commodities";
            this.btnAllCommodities.Id = 4;
            this.btnAllCommodities.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.medical_equipment_32;
            this.btnAllCommodities.Name = "btnAllCommodities";
            this.btnAllCommodities.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAllCommodities.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllCommodities_ItemClick);
            // 
            // btnNewInvoice
            // 
            this.btnNewInvoice.Caption = "New Invoice";
            this.btnNewInvoice.Id = 5;
            this.btnNewInvoice.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.new_invoice;
            this.btnNewInvoice.Name = "btnNewInvoice";
            this.btnNewInvoice.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNewInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewInvoice_ItemClick);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Caption = "Sign Out";
            this.btnSignOut.Id = 6;
            this.btnSignOut.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.logout_32;
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSignOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSignOut_ItemClick);
            // 
            // btnAllInvoices
            // 
            this.btnAllInvoices.Caption = "All Invoices";
            this.btnAllInvoices.Id = 8;
            this.btnAllInvoices.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.all_invoices;
            this.btnAllInvoices.Name = "btnAllInvoices";
            this.btnAllInvoices.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAllInvoices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllInvoices_ItemClick);
            // 
            // btnAbout
            // 
            this.btnAbout.Caption = "About";
            this.btnAbout.Id = 9;
            this.btnAbout.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.information_32px;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Caption = "New User";
            this.btnNewUser.Id = 10;
            this.btnNewUser.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.add_user_32px;
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnAllUsers
            // 
            this.btnAllUsers.Caption = "All Users";
            this.btnAllUsers.Id = 11;
            this.btnAllUsers.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.group_32px;
            this.btnAllUsers.Name = "btnAllUsers";
            this.btnAllUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAllUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllUsers_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnNewAccount
            // 
            this.btnNewAccount.Caption = "New Account";
            this.btnNewAccount.Id = 13;
            this.btnNewAccount.ImageOptions.Image = global::PharmacyManagement.Properties.Resources.new_account;
            this.btnNewAccount.Name = "btnNewAccount";
            this.btnNewAccount.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNewAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewAccount_ItemClick);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Caption = "Customer";
            this.btnCustomer.Id = 14;
            this.btnCustomer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomer.ImageOptions.LargeImage")));
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomer_ItemClick);
            // 
            // pgHome
            // 
            this.pgHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup5});
            this.pgHome.Name = "pgHome";
            this.pgHome.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDashboard);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnProfile, true);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnSignOut, true);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // pgCommodity
            // 
            this.pgCommodity.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.pgCommodity.Name = "pgCommodity";
            this.pgCommodity.Text = "Commodity";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNewCommodity, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAllCommodities, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // pgHumanManage
            // 
            this.pgHumanManage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup6});
            this.pgHumanManage.Name = "pgHumanManage";
            this.pgHumanManage.Text = "Human Manage";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnNewAccount);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnAllAccounts, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnAllUsers);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnCustomer);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // pgInvoice
            // 
            this.pgInvoice.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.pgInvoice.Name = "pgInvoice";
            this.pgInvoice.Text = "Invoice";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnNewInvoice, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnAllInvoices, true);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // btnAllAccounts
            // 
            this.btnAllAccounts.Caption = "All Accounts";
            this.btnAllAccounts.Id = 15;
            this.btnAllAccounts.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAllAccounts.ImageOptions.LargeImage")));
            this.btnAllAccounts.Name = "btnAllAccounts";
            this.btnAllAccounts.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAllAccounts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllAccounts_ItemClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 688);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Image = global::PharmacyManagement.Properties.Resources.Pharmacy_logo_500;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LNQ - Pharmacy Manage System";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnDashboard;
        private DevExpress.XtraBars.BarButtonItem btnProfile;
        private DevExpress.XtraBars.BarButtonItem btnNewCommodity;
        private DevExpress.XtraBars.BarButtonItem btnAllCommodities;
        private DevExpress.XtraBars.BarButtonItem btnNewInvoice;
        private DevExpress.XtraBars.BarButtonItem btnSignOut;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgCommodity;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHumanManage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgInvoice;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnAllInvoices;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
        private DevExpress.XtraBars.BarButtonItem btnNewUser;
        private DevExpress.XtraBars.BarButtonItem btnAllUsers;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnNewAccount;
        private DevExpress.XtraBars.BarButtonItem btnCustomer;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnAllAccounts;
    }
}

