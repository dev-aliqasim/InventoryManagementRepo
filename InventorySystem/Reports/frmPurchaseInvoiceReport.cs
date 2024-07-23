using InventorySystem.CrystalReportsViewers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore.Reports
{
    public partial class frmPurchaseInvoiceReport : Form
    {
        public frmPurchaseInvoiceReport()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DataTable tempDT = new DataTable();
        //
        string DataLoadedMode = "";
        //
        public void LoadData()
        {
            string query = "Select   * from PurchaseInvoice as PI  Inner Join PurchaseInvoiceDetail as PID  on Pi.PurchaseID = PID.PurchaseID  Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID inner join Category C on ProductInfo.CategoryID =  C.CategoryID inner join Supplier on PI.SupplierID = Supplier.SupplierID where pI.PurchaseDate between  '" + DateTime.Now.Date + "'   and  '" + DateTime.Now + "'   ";
            dt = General.FetchData(query);
            dgvPurchaseInvoiceReport.DataSource = dt;
            DataLoadedMode = "dt";
            SortDGVColumns();
        }
        public void LoadSupplier()
        {
            string query = "select * from supplier ";
            DataTable supplier = new DataTable();
            supplier = General.FetchData(query);
            cmbSupplier.DataSource = supplier;
            cmbSupplier.DisplayMember = supplier.Columns["SupplierName"].ToString();
            cmbSupplier.ValueMember = supplier.Columns["SupplierID"].ToString();
            cmbSupplier.SelectedIndex = -1;
        }
        public void LoadCategory()
        {
            string query = "select * from Category ";
            DataTable category = new DataTable();
            category = General.FetchData(query);
            cmbCategory.DataSource = category;
            cmbCategory.DisplayMember = category.Columns["CategoryName"].ToString();
            cmbCategory.ValueMember = category.Columns["CategoryID"].ToString();
            cmbCategory.SelectedIndex = -1;

        }
        public void LoadProduct()
        {
            string query = "select * from ProductInfo ";
            DataTable product = new DataTable();
            product = General.FetchData(query);
            cmbProduct.DataSource = product;
            cmbProduct.DisplayMember = product.Columns["ProductName"].ToString();
            cmbProduct.ValueMember = product.Columns["ProductID"].ToString();
            cmbProduct.SelectedIndex = -1;
        }
        public void SortDGVColumns()
        {
            dgvPurchaseInvoiceReport.Columns["SrNo"].DisplayIndex = 0;
            dgvPurchaseInvoiceReport.Columns["SupplierName"].DisplayIndex = 1;
            dgvPurchaseInvoiceReport.Columns["CategoryName"].DisplayIndex = 2;
            dgvPurchaseInvoiceReport.Columns["ProductName"].DisplayIndex = 3;
            dgvPurchaseInvoiceReport.Columns["ProductBarcode"].DisplayIndex = 4;
            dgvPurchaseInvoiceReport.Columns["PurchasePrice"].DisplayIndex = 5;
            dgvPurchaseInvoiceReport.Columns["RetailPrice"].DisplayIndex = 6;
            dgvPurchaseInvoiceReport.Columns["Qty"].DisplayIndex = 7;
            dgvPurchaseInvoiceReport.Columns["PurchaseStatus"].DisplayIndex = 8;
            dgvPurchaseInvoiceReport.Columns["PurchaseDate"].DisplayIndex = 9;
        }
        private void frmPurchaseInvoiceReport_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadSupplier();
            LoadCategory();
            LoadProduct();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
           
        }

        public void SearchData()
        {
            string query = "Select   * from PurchaseInvoice as PI  Inner Join PurchaseInvoiceDetail as PID  on Pi.PurchaseID = PID.PurchaseID  Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID inner join Category C on ProductInfo.CategoryID =  C.CategoryID inner join Supplier on PI.SupplierID = Supplier.SupplierID where pI.PurchaseDate between  '" + dtFromDate.Text.ToString().Trim() + "'   and  '" + dtToDate.Text.ToString().Trim() + "'   ";
            tempDT = General.FetchData(query);
            dgvPurchaseInvoiceReport.DataSource = tempDT;
            DataLoadedMode = "tempDT";
            SortDGVColumns();
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SearchData();
            cmbSupplier.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            //
            chkBoxPurchased.Checked = false;
            chkBoxPending.Checked = false;

        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            //
            dgvPurchaseInvoiceReport.DataSource = dt;
            DataLoadedMode = "dt";
            SortDGVColumns();
            //
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            //
            chkBoxPurchased.Checked = false;
            chkBoxPending.Checked = false;
            //
            cmbSupplier.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
        }

        private void chkBoxPurchased_Click(object sender, EventArgs e)
        {
            chkBoxPurchased.Checked = true;
            chkBoxPending.Checked = false;
            DataTable purchasedDT = new DataTable();

            if (DataLoadedMode == "dt")
            {
                purchasedDT = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PurchaseStatus"].ToString().Trim().ToLower() =="purchased")
                    {
                        purchasedDT.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (DataLoadedMode == "tempDT")
            {
                purchasedDT = tempDT.Clone();
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["PurchaseStatus"].ToString().Trim().ToLower() == "purchased")
                    {
                        purchasedDT.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
            }
            dgvPurchaseInvoiceReport.DataSource = "";
            dgvPurchaseInvoiceReport.DataSource = purchasedDT;
            SortDGVColumns();


        }

        private void chkBoxPending_Click(object sender, EventArgs e)
        {
            chkBoxPurchased.Checked = false;
            chkBoxPending.Checked = true;
            DataTable pendingDT = new DataTable();


            if (DataLoadedMode == "dt")
            {
                pendingDT = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PurchaseStatus"].ToString().Trim().ToLower() == "pending")
                    {
                        pendingDT.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (DataLoadedMode == "tempDT")
            {
                pendingDT = tempDT.Clone();
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["PurchaseStatus"].ToString().Trim().ToLower() == "pending")
                    {
                        pendingDT.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
            }
            dgvPurchaseInvoiceReport.DataSource = "";
            dgvPurchaseInvoiceReport.DataSource = pendingDT;
            SortDGVColumns();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            chkBoxPurchased.Checked = false;
            chkBoxPending.Checked = false;
            if (DataLoadedMode == "dt")
            {
                dgvPurchaseInvoiceReport.DataSource = dt;
                DataLoadedMode = "dt";
                SortDGVColumns();
            }
            else if (DataLoadedMode == "tempDT")
            {
                SearchData();
            }
        }

        private void lblTodaysReport_Click(object sender, EventArgs e)
        {
            dgvPurchaseInvoiceReport.DataSource = dt;
            DataLoadedMode = "dt";
            SortDGVColumns();
        }

        private void cmbSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;

            DataTable filterSupplier = new DataTable();
            if (DataLoadedMode == "dt")
            {
                filterSupplier = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SupplierID"].ToString().Trim() == cmbSupplier.SelectedValue.ToString().Trim())
                    {
                        filterSupplier.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (DataLoadedMode == "tempDT")
            {
                filterSupplier = tempDT.Clone();
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["SupplierID"].ToString().Trim() == cmbSupplier.SelectedValue.ToString().Trim())
                    {
                        filterSupplier.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
            }
            dgvPurchaseInvoiceReport.DataSource = filterSupplier;
            SortDGVColumns();
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbSupplier.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;

            DataTable filterCategory = new DataTable();
            if (DataLoadedMode == "dt")
            {
                filterCategory = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["CategoryID"].ToString().Trim() == cmbCategory.SelectedValue.ToString().Trim())
                    {
                        filterCategory.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (DataLoadedMode == "tempDT")
            {
                filterCategory = tempDT.Clone();
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["CategoryID"].ToString().Trim() == cmbCategory.SelectedValue.ToString().Trim())
                    {
                        filterCategory.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
            }
            dgvPurchaseInvoiceReport.DataSource = filterCategory;
            SortDGVColumns();
        }

        private void cmbProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbSupplier.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;

            DataTable filterProduct = new DataTable();
            if (DataLoadedMode == "dt")
            {
                filterProduct = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ProductID"].ToString().Trim() == cmbProduct.SelectedValue.ToString().Trim())
                    {
                        filterProduct.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (DataLoadedMode == "tempDT")
            {
                filterProduct = tempDT.Clone();
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["ProductID"].ToString().Trim() == cmbProduct.SelectedValue.ToString().Trim())
                    {
                        filterProduct.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
            }
            dgvPurchaseInvoiceReport.DataSource = filterProduct;
            SortDGVColumns();
        }

        private void dgvAttendence_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.ToString().Trim().ToLower() == "srno")
            {
                e.Column.HeaderText = "Sr.No";
                e.Column.DisplayIndex = 0;
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "suppliername")
            {
                e.Column.HeaderText = "Supplier Name";

            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "categoryname")
            {
                e.Column.HeaderText = "Category Name";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "productname")
            {
                e.Column.HeaderText = "Product Name";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "productbarcode")
            {
                e.Column.HeaderText = "Product Barcode";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "purchaseprice")
            {
                e.Column.HeaderText = "Purchase Price";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "retailprice")
            {
                e.Column.HeaderText = "Retail Price";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "qty")
            {
                e.Column.HeaderText = "Qty";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "purchasestatus")
            {
                e.Column.HeaderText = "Status";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "purchasedate")
            {
                e.Column.HeaderText = "Purchase Date";
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dates = new Dictionary<string, string>();
            dates.Add("fromDate", dtFromDate.Value.ToString());
            dates.Add("toDate", dtToDate.Value.ToString());



            if (DataLoadedMode == "dt")
            {
                frmPurchaseCrptViewer frmPurchaseRegister = new frmPurchaseCrptViewer(dt, dates);
                frmPurchaseRegister.Show();

            }
            else if (DataLoadedMode == "tempDT")
            {
                frmPurchaseCrptViewer frmSalesRegister2 = new frmPurchaseCrptViewer(tempDT, dates);
                frmSalesRegister2.Show();

            }
        }
    }
}
