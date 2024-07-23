using InventorySystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class mdiCashier : Form
    {
        private int childFormNumber = 0;

        public mdiCashier()
        {
            InitializeComponent();
        }
        // depricated
        // overloaded constructor of mdiCashier used for Cashier Login
        public mdiCashier(string LoginIDfromLoaderfromLogin)
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

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
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
                // This is used to open frmCategory in the current MDI Container
                frmCategory frm = new frmCategory();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void productInformationToolStripMenuItem_Click(object sender, EventArgs e)
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
                // This is used to open frmProductInfo in the current MDI Container
                frmProductInfo frm = new frmProductInfo();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
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
                // This is used to open frmSupplier in the current MDI Container
                frmSupplier frm = new frmSupplier();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This will redirect to Login Form
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
           
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
                // This is used to open frmPurchaseInvoice in the current MDI Container
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
                // This is used to open frmSalesInvoice in the current MDI Container
                frmSalesInvoice frm = new frmSalesInvoice();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void mdiCashier_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    string query = "select * from Login where LoginID = " + LoginID.Trim().ToString();
            //    DataTable dt = new DataTable();
            //    dt = General.FetchData(query);
            //    if (dt.Rows.Count > 0)
            //    {
            //        lblUserName.Text = dt.Rows[0]["UserName"].ToString();
            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
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
