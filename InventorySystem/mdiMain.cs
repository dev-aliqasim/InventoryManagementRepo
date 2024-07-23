using InventorySystem;
using InventorySystem.Reports;
using PickAndChooseGroceryStore.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class mdiMain : Form
    {
        private int childFormNumber = 0;
        public mdiMain()
        {
            InitializeComponent();
        }

        //depricated
        //overloaded constructor of mdiMain used for Administrator login
        public mdiMain(string LoginIDfromLoaderfromLogin)
        {
            InitializeComponent();
            LoginID = LoginIDfromLoaderfromLogin;
        }
        
        string LoginID = "";
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmCategory")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmcategory in the current MDI container
                frmCategory frm = new frmCategory();
                frm.MdiParent = this;
                frm.Show();
            }
            

        }

        private void productInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProductInfo")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
            // This will open the frmProductInfo in the current MDI container
            frmProductInfo frm = new frmProductInfo();
            frm.MdiParent = this;
            frm.Show();
            }
        }

        private void productInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmSupplier")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmSupplier in the current MDI container
                frmSupplier frm = new frmSupplier();
                frm.MdiParent = this;
                frm.Show();
            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This will navigate back to Login Form
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }

        private void attendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeesAttendence frm = new frmEmployeesAttendence();
            frm.MdiParent = this;
            frm.Show();
        }

        private void employeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployees frm = new frmEmployees();
            frm.MdiParent = this;
            frm.Show();
        }

        private void employeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmEmployeesSalary")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmEmployeesSalary in the current MDI container
                frmEmployeesSalary frm = new frmEmployeesSalary();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void purchaseInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmPurchaseInvoice")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmPurchaseInvoice in the current MDI container
                frmPurchaseInvoice frm = new frmPurchaseInvoice();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmSalesInvoice")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmSalesInvoice in the current MDI container
                frmSalesInvoice frm = new frmSalesInvoice();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        

        private void mdiMain_Load(object sender, EventArgs e)
        {
            
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmDashboard")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
            
                // This will open the dashboard in the current MDI Container.
                frmDashboard frmDashboard = new frmDashboard();
                frmDashboard.MdiParent = this;
                frmDashboard.TopLevel = false;
                frmDashboard.Dock = DockStyle.Fill;
                frmDashboard.Show();
            }


            
        }

        private void attendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmAttendenceReport")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmAttendenceReport in the current MDI container
                frmAttendenceReport frm = new frmAttendenceReport();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void employeeSalaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmEmployeeSalaryReport")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmEmployeeSalaryReport in the current MDI container
                frmEmployeeSalaryReport frm = new frmEmployeeSalaryReport();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void expiredProductReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmExpiredProductReport")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmExpiredProductReport in the current MDI container
                frmExpiredProductReport frm = new frmExpiredProductReport();
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void productStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProductStockReport")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmProductStockReport in the current MDI container
                frmProductStockReport frm = new frmProductStockReport();
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void productLedgerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProductLedger")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmProductLedger in the current MDI container
                frmProductLedger frm = new frmProductLedger();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void purchaseInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmPurchaseInvoiceReport")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmProductLedger in the current MDI container
                frmPurchaseInvoiceReport frm = new frmPurchaseInvoiceReport();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmSalesInvoiceReport")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmProductLedger in the current MDI container
                frmSalesInvoiceReport frm = new frmSalesInvoiceReport();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmSalesReport")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmProductLedger in the current MDI container
                frmSalesReport frm = new frmSalesReport();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmCustomer")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                // This will open the frmCustomer in the current MDI container
                frmCustomer frm = new frmCustomer();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}

