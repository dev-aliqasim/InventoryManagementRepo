
namespace PickAndChooseGroceryStore
{
    partial class mdiMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeSalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeSalaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productStockReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productLedgerReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseInvoiceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.purchasesToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(866, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.categoryToolStripMenuItem,
            this.productInToolStripMenuItem,
            this.productInToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dashboardToolStripMenuItem.Image")));
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("categoryToolStripMenuItem.Image")));
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.categoryToolStripMenuItem.Text = "Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // productInToolStripMenuItem
            // 
            this.productInToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("productInToolStripMenuItem.Image")));
            this.productInToolStripMenuItem.Name = "productInToolStripMenuItem";
            this.productInToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.productInToolStripMenuItem.Text = "Product Information";
            this.productInToolStripMenuItem.Click += new System.EventHandler(this.productInToolStripMenuItem_Click);
            // 
            // productInToolStripMenuItem1
            // 
            this.productInToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("productInToolStripMenuItem1.Image")));
            this.productInToolStripMenuItem1.Name = "productInToolStripMenuItem1";
            this.productInToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.productInToolStripMenuItem1.Text = "Supplier";
            this.productInToolStripMenuItem1.Click += new System.EventHandler(this.productInToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem1.Text = "Customer";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeSalaryToolStripMenuItem});
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // employeeSalaryToolStripMenuItem
            // 
            this.employeeSalaryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("employeeSalaryToolStripMenuItem.Image")));
            this.employeeSalaryToolStripMenuItem.Name = "employeeSalaryToolStripMenuItem";
            this.employeeSalaryToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.employeeSalaryToolStripMenuItem.Text = "Employee Salaries";
            this.employeeSalaryToolStripMenuItem.Click += new System.EventHandler(this.employeeSalaryToolStripMenuItem_Click);
            // 
            // purchasesToolStripMenuItem
            // 
            this.purchasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseInvoiceToolStripMenuItem});
            this.purchasesToolStripMenuItem.Name = "purchasesToolStripMenuItem";
            this.purchasesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.purchasesToolStripMenuItem.Text = "Purchases";
            // 
            // purchaseInvoiceToolStripMenuItem
            // 
            this.purchaseInvoiceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("purchaseInvoiceToolStripMenuItem.Image")));
            this.purchaseInvoiceToolStripMenuItem.Name = "purchaseInvoiceToolStripMenuItem";
            this.purchaseInvoiceToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.purchaseInvoiceToolStripMenuItem.Text = "Purchase Invoice";
            this.purchaseInvoiceToolStripMenuItem.Click += new System.EventHandler(this.purchaseInvoiceToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesInvoiceToolStripMenuItem});
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // salesInvoiceToolStripMenuItem
            // 
            this.salesInvoiceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salesInvoiceToolStripMenuItem.Image")));
            this.salesInvoiceToolStripMenuItem.Name = "salesInvoiceToolStripMenuItem";
            this.salesInvoiceToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.salesInvoiceToolStripMenuItem.Text = "Sales Invoice";
            this.salesInvoiceToolStripMenuItem.Click += new System.EventHandler(this.salesInvoiceToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attendanceReportToolStripMenuItem,
            this.employeeSalaryReportToolStripMenuItem,
            this.productStockReportToolStripMenuItem,
            this.productLedgerReportToolStripMenuItem,
            this.purchaseInvoiceReportToolStripMenuItem,
            this.sToolStripMenuItem,
            this.salesReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // attendanceReportToolStripMenuItem
            // 
            this.attendanceReportToolStripMenuItem.Name = "attendanceReportToolStripMenuItem";
            this.attendanceReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.attendanceReportToolStripMenuItem.Text = "Attendance Report";
            this.attendanceReportToolStripMenuItem.Click += new System.EventHandler(this.attendanceReportToolStripMenuItem_Click);
            // 
            // employeeSalaryReportToolStripMenuItem
            // 
            this.employeeSalaryReportToolStripMenuItem.Name = "employeeSalaryReportToolStripMenuItem";
            this.employeeSalaryReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.employeeSalaryReportToolStripMenuItem.Text = "Employee Salary Report";
            this.employeeSalaryReportToolStripMenuItem.Click += new System.EventHandler(this.employeeSalaryReportToolStripMenuItem_Click);
            // 
            // productStockReportToolStripMenuItem
            // 
            this.productStockReportToolStripMenuItem.Name = "productStockReportToolStripMenuItem";
            this.productStockReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.productStockReportToolStripMenuItem.Text = "Product Stock Report";
            this.productStockReportToolStripMenuItem.Click += new System.EventHandler(this.productStockReportToolStripMenuItem_Click);
            // 
            // productLedgerReportToolStripMenuItem
            // 
            this.productLedgerReportToolStripMenuItem.Name = "productLedgerReportToolStripMenuItem";
            this.productLedgerReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.productLedgerReportToolStripMenuItem.Text = "Product Ledger Report";
            this.productLedgerReportToolStripMenuItem.Click += new System.EventHandler(this.productLedgerReportToolStripMenuItem_Click);
            // 
            // purchaseInvoiceReportToolStripMenuItem
            // 
            this.purchaseInvoiceReportToolStripMenuItem.Name = "purchaseInvoiceReportToolStripMenuItem";
            this.purchaseInvoiceReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.purchaseInvoiceReportToolStripMenuItem.Text = "Purchase Invoice Report";
            this.purchaseInvoiceReportToolStripMenuItem.Click += new System.EventHandler(this.purchaseInvoiceReportToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.sToolStripMenuItem.Text = "Sales Invoice Report";
            this.sToolStripMenuItem.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // salesReportToolStripMenuItem
            // 
            this.salesReportToolStripMenuItem.Name = "salesReportToolStripMenuItem";
            this.salesReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.salesReportToolStripMenuItem.Text = "Sales Report";
            this.salesReportToolStripMenuItem.Click += new System.EventHandler(this.salesReportToolStripMenuItem_Click);
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(866, 525);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "mdiMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grocery Store APP - ADMIN ONLY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mdiMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productInToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeSalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productStockReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseInvoiceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeSalaryReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productLedgerReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}



