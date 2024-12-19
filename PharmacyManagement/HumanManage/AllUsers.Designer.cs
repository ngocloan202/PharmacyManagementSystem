namespace PharmacyManagement.HumanManage
{
    partial class AllUsers
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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.gdvAllUsers = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Username = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Role = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Birthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAllUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.gdvAllUsers);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(762, 395);
            this.guna2Panel2.TabIndex = 1;
            // 
            // gdvAllUsers
            // 
            this.gdvAllUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvAllUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdvAllUsers.Location = new System.Drawing.Point(0, 0);
            this.gdvAllUsers.MainView = this.gridView1;
            this.gdvAllUsers.Name = "gdvAllUsers";
            this.gdvAllUsers.Size = new System.Drawing.Size(762, 395);
            this.gdvAllUsers.TabIndex = 0;
            this.gdvAllUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.layoutView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Username,
            this.FullName,
            this.Role,
            this.Sex,
            this.Contact,
            this.Birthday,
            this.Address});
            this.gridView1.GridControl = this.gdvAllUsers;
            this.gridView1.Name = "gridView1";
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            // 
            // Username
            // 
            this.Username.Caption = "Username";
            this.Username.Name = "Username";
            this.Username.Visible = true;
            this.Username.VisibleIndex = 1;
            // 
            // FullName
            // 
            this.FullName.Caption = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 2;
            // 
            // Role
            // 
            this.Role.Caption = "Role";
            this.Role.Name = "Role";
            this.Role.Visible = true;
            this.Role.VisibleIndex = 3;
            // 
            // Sex
            // 
            this.Sex.Caption = "Sex";
            this.Sex.Name = "Sex";
            this.Sex.Visible = true;
            this.Sex.VisibleIndex = 4;
            // 
            // Contact
            // 
            this.Contact.Caption = "Contact";
            this.Contact.Name = "Contact";
            this.Contact.Visible = true;
            this.Contact.VisibleIndex = 5;
            // 
            // Birthday
            // 
            this.Birthday.Caption = "Birthday";
            this.Birthday.Name = "Birthday";
            this.Birthday.Visible = true;
            this.Birthday.VisibleIndex = 6;
            // 
            // Address
            // 
            this.Address.Caption = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = true;
            this.Address.VisibleIndex = 7;
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.gdvAllUsers;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = null;
            // 
            // AllUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 395);
            this.Controls.Add(this.guna2Panel2);
            this.IconOptions.Image = global::PharmacyManagement.Properties.Resources.Pharmacy_logo_500;
            this.Name = "AllUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Users";
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvAllUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private DevExpress.XtraGrid.GridControl gdvAllUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Username;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn Role;
        private DevExpress.XtraGrid.Columns.GridColumn Sex;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.GridColumn Contact;
        private DevExpress.XtraGrid.Columns.GridColumn Birthday;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
    }
}