namespace PharmacyManagement.Invoice
{
    partial class AllInvoices
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllInvoices));
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReload = new Guna.UI2.WinForms.Guna2Button();
            this.dgvAllInvoices = new System.Windows.Forms.DataGridView();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtFind = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpDateCreated = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCreateBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomerContact = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtIdInvoice = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoices)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.btnReload);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 195);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(813, 45);
            this.guna2Panel3.TabIndex = 1;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReload.BorderRadius = 15;
            this.btnReload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(165)))), ((int)(((byte)(80)))));
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(709, 7);
            this.btnReload.Name = "btnReload";
            this.btnReload.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(80)))));
            this.btnReload.Size = new System.Drawing.Size(85, 30);
            this.btnReload.TabIndex = 13;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // dgvAllInvoices
            // 
            this.dgvAllInvoices.AllowUserToAddRows = false;
            this.dgvAllInvoices.AllowUserToDeleteRows = false;
            this.dgvAllInvoices.AllowUserToOrderColumns = true;
            this.dgvAllInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllInvoices.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.CustomerName,
            this.Contact,
            this.CreatedDate,
            this.Note,
            this.EmployeeName,
            this.Amount});
            this.dgvAllInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllInvoices.Location = new System.Drawing.Point(0, 0);
            this.dgvAllInvoices.MultiSelect = false;
            this.dgvAllInvoices.Name = "dgvAllInvoices";
            this.dgvAllInvoices.ReadOnly = true;
            this.dgvAllInvoices.RowHeadersWidth = 51;
            this.dgvAllInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllInvoices.Size = new System.Drawing.Size(813, 240);
            this.dgvAllInvoices.TabIndex = 0;
            // 
            // InvoiceID
            // 
            this.InvoiceID.DataPropertyName = "InvoiceID";
            this.InvoiceID.HeaderText = "ID";
            this.InvoiceID.MinimumWidth = 6;
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.MinimumWidth = 6;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "Contact";
            this.Contact.HeaderText = "Customer Contact";
            this.Contact.MinimumWidth = 6;
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "Date Created";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // Note
            // 
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Note";
            this.Note.MinimumWidth = 6;
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "Create By";
            this.EmployeeName.MinimumWidth = 6;
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Total";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.dgvAllInvoices);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 256);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(813, 240);
            this.guna2Panel1.TabIndex = 4;
            // 
            // txtFind
            // 
            this.txtFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(120, 27);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnFind,
            this.txtFind});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 229);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(813, 27);
            this.bindingNavigator.TabIndex = 0;
            this.bindingNavigator.Text = "bindingNavigator";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFind.Image = global::PharmacyManagement.Properties.Resources.find_24px;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(24, 24);
            this.btnFind.Text = "toolStripButton1";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.guna2Panel4);
            this.guna2Panel2.Controls.Add(this.bindingNavigator);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(813, 256);
            this.guna2Panel2.TabIndex = 3;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.dtpDateCreated);
            this.guna2Panel4.Controls.Add(this.txtTotal);
            this.guna2Panel4.Controls.Add(this.labelControl8);
            this.guna2Panel4.Controls.Add(this.txtCustomerName);
            this.guna2Panel4.Controls.Add(this.labelControl4);
            this.guna2Panel4.Controls.Add(this.labelControl5);
            this.guna2Panel4.Controls.Add(this.txtCreateBy);
            this.guna2Panel4.Controls.Add(this.txtNote);
            this.guna2Panel4.Controls.Add(this.labelControl7);
            this.guna2Panel4.Controls.Add(this.txtCustomerContact);
            this.guna2Panel4.Controls.Add(this.labelControl6);
            this.guna2Panel4.Controls.Add(this.labelControl2);
            this.guna2Panel4.Controls.Add(this.txtIdInvoice);
            this.guna2Panel4.Controls.Add(this.labelControl3);
            this.guna2Panel4.Controls.Add(this.guna2Panel5);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(813, 229);
            this.guna2Panel4.TabIndex = 1;
            // 
            // dtpDateCreated
            // 
            this.dtpDateCreated.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDateCreated.BackColor = System.Drawing.Color.Transparent;
            this.dtpDateCreated.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(85)))), ((int)(((byte)(143)))));
            this.dtpDateCreated.BorderRadius = 13;
            this.dtpDateCreated.BorderThickness = 1;
            this.dtpDateCreated.Checked = true;
            this.dtpDateCreated.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(228)))), ((int)(((byte)(255)))));
            this.dtpDateCreated.FocusedColor = System.Drawing.Color.Transparent;
            this.dtpDateCreated.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateCreated.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDateCreated.Location = new System.Drawing.Point(556, 98);
            this.dtpDateCreated.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateCreated.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateCreated.Name = "dtpDateCreated";
            this.dtpDateCreated.Size = new System.Drawing.Size(214, 36);
            this.dtpDateCreated.TabIndex = 16;
            this.dtpDateCreated.Value = new System.DateTime(2024, 12, 19, 10, 4, 31, 434);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTotal.BorderColor = System.Drawing.Color.Black;
            this.txtTotal.BorderRadius = 14;
            this.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotal.DefaultText = "";
            this.txtTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtTotal.Location = new System.Drawing.Point(200, 183);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.PasswordChar = '\0';
            this.txtTotal.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtTotal.PlaceholderText = "";
            this.txtTotal.SelectedText = "";
            this.txtTotal.Size = new System.Drawing.Size(186, 31);
            this.txtTotal.TabIndex = 9;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(142, 188);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(41, 21);
            this.labelControl8.TabIndex = 8;
            this.labelControl8.Text = "Total:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCustomerName.BorderColor = System.Drawing.Color.Black;
            this.txtCustomerName.BorderRadius = 14;
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerName.DefaultText = "";
            this.txtCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerName.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtCustomerName.Location = new System.Drawing.Point(556, 58);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtCustomerName.PlaceholderText = "";
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.Size = new System.Drawing.Size(214, 31);
            this.txtCustomerName.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(411, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(122, 21);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Customer Name:";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(436, 105);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(100, 21);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Date Created:";
            // 
            // txtCreateBy
            // 
            this.txtCreateBy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCreateBy.BorderColor = System.Drawing.Color.Black;
            this.txtCreateBy.BorderRadius = 14;
            this.txtCreateBy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCreateBy.DefaultText = "";
            this.txtCreateBy.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCreateBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCreateBy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCreateBy.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCreateBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtCreateBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCreateBy.ForeColor = System.Drawing.Color.Black;
            this.txtCreateBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtCreateBy.Location = new System.Drawing.Point(556, 141);
            this.txtCreateBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCreateBy.Name = "txtCreateBy";
            this.txtCreateBy.PasswordChar = '\0';
            this.txtCreateBy.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtCreateBy.PlaceholderText = "";
            this.txtCreateBy.SelectedText = "";
            this.txtCreateBy.Size = new System.Drawing.Size(214, 31);
            this.txtCreateBy.TabIndex = 9;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNote.BorderColor = System.Drawing.Color.Black;
            this.txtNote.BorderRadius = 14;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.DefaultText = "";
            this.txtNote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNote.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtNote.Location = new System.Drawing.Point(200, 141);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNote.Name = "txtNote";
            this.txtNote.PasswordChar = '\0';
            this.txtNote.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtNote.PlaceholderText = "";
            this.txtNote.SelectedText = "";
            this.txtNote.Size = new System.Drawing.Size(186, 31);
            this.txtNote.TabIndex = 9;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(464, 145);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(74, 21);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "Create By:";
            // 
            // txtCustomerContact
            // 
            this.txtCustomerContact.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCustomerContact.BorderColor = System.Drawing.Color.Black;
            this.txtCustomerContact.BorderRadius = 14;
            this.txtCustomerContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerContact.DefaultText = "";
            this.txtCustomerContact.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerContact.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerContact.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerContact.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerContact.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtCustomerContact.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerContact.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerContact.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtCustomerContact.Location = new System.Drawing.Point(200, 100);
            this.txtCustomerContact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerContact.Name = "txtCustomerContact";
            this.txtCustomerContact.PasswordChar = '\0';
            this.txtCustomerContact.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtCustomerContact.PlaceholderText = "";
            this.txtCustomerContact.SelectedText = "";
            this.txtCustomerContact.Size = new System.Drawing.Size(186, 31);
            this.txtCustomerContact.TabIndex = 9;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(142, 145);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 21);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Note:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(42, 105);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(136, 21);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Customer Contact:";
            // 
            // txtIdInvoice
            // 
            this.txtIdInvoice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIdInvoice.BorderColor = System.Drawing.Color.Black;
            this.txtIdInvoice.BorderRadius = 14;
            this.txtIdInvoice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdInvoice.DefaultText = "";
            this.txtIdInvoice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIdInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIdInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdInvoice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdInvoice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtIdInvoice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdInvoice.ForeColor = System.Drawing.Color.Black;
            this.txtIdInvoice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(132)))), ((int)(((byte)(252)))));
            this.txtIdInvoice.Location = new System.Drawing.Point(200, 58);
            this.txtIdInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdInvoice.Name = "txtIdInvoice";
            this.txtIdInvoice.PasswordChar = '\0';
            this.txtIdInvoice.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtIdInvoice.PlaceholderText = "";
            this.txtIdInvoice.SelectedText = "";
            this.txtIdInvoice.Size = new System.Drawing.Size(77, 31);
            this.txtIdInvoice.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(164, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(20, 21);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "ID:";
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Controls.Add(this.labelControl1);
            this.guna2Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(228)))), ((int)(((byte)(255)))));
            this.guna2Panel5.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(813, 37);
            this.guna2Panel5.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(363, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 21);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Information";
            // 
            // AllInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 496);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::PharmacyManagement.Properties.Resources.Pharmacy_logo_500;
            this.Name = "AllInvoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Invoices";
            this.Load += new System.EventHandler(this.AllInvoices_Load);
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoices)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button btnReload;
        private System.Windows.Forms.DataGridView dgvAllInvoices;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.ToolStripTextBox txtFind;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Guna.UI2.WinForms.Guna2TextBox txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private Guna.UI2.WinForms.Guna2TextBox txtCreateBy;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerContact;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Guna.UI2.WinForms.Guna2TextBox txtIdInvoice;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}