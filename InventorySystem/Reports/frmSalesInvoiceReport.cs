using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InventorySystem.CrystalReports;
using InventorySystem.CrystalReportsViewers;

namespace PickAndChooseGroceryStore.Reports
{
    public partial class frmSalesInvoiceReport : Form
    {
        public frmSalesInvoiceReport()
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
            string query = "select * from SalesInvoice as SalInvo inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID inner join Customer as C on SalInvo.CustomerID = C.CustomerID inner join Category as Cat on PI.CategoryID = cat.CategoryID Where  SalInvo.Date between   '" + DateTime.Now.Date + "'   and  '" + DateTime.Now + "'   ";
            dt = General.FetchData(query);
            dgvSalesInvoiceReport.DataSource = dt;
            DataLoadedMode = "dt";
            SortDGVColumns();
        }
        public void SortDGVColumns()
        {
            dgvSalesInvoiceReport.Columns["SrNo"].DisplayIndex = 0;
            dgvSalesInvoiceReport.Columns["CustomerName"].DisplayIndex = 1;
            dgvSalesInvoiceReport.Columns["CategoryName"].DisplayIndex = 2;
            dgvSalesInvoiceReport.Columns["ProductName"].DisplayIndex = 3;
            dgvSalesInvoiceReport.Columns["ProductBarcode"].DisplayIndex = 4;
            dgvSalesInvoiceReport.Columns["RetailPrice"].DisplayIndex = 5;
            dgvSalesInvoiceReport.Columns["Discount"].DisplayIndex = 6;
            dgvSalesInvoiceReport.Columns["Qty"].DisplayIndex = 7;
            dgvSalesInvoiceReport.Columns["PaymentStatus"].DisplayIndex = 8;
            dgvSalesInvoiceReport.Columns["Date"].DisplayIndex = 9;
        }
        public void LoadCustomer()
        {
            string query = "select * from customer ";
            DataTable customer = new DataTable();
            customer = General.FetchData(query);
            cmbCustomer.DataSource = customer;
            cmbCustomer.DisplayMember = customer.Columns["CustomerName"].ToString();
            cmbCustomer.ValueMember = customer.Columns["CustomerID"].ToString();
            cmbCustomer.SelectedIndex = -1;
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
        private void frmSalesInvoiceReport_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCustomer();
            LoadCategory();
            LoadProduct();
        }

        private void lblTodaysReport_Click(object sender, EventArgs e)
        {
            dgvSalesInvoiceReport.DataSource = dt;
            DataLoadedMode = "dt";
            SortDGVColumns();
        }

        public void SearchData()
        {
            string query = "select * from SalesInvoice as SalInvo inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID inner join Customer as C on SalInvo.CustomerID = C.CustomerID inner join Category as Cat on PI.CategoryID = cat.CategoryID  Where  SalInvo.Date between   '" + dtFromDate.Value.ToString().Trim() + "'   and  '" + dtToDate.Value.ToString().Trim() + "'   ";
            tempDT = General.FetchData(query);
            dgvSalesInvoiceReport.DataSource = tempDT;
            DataLoadedMode = "tempDT";
            SortDGVColumns();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
            cmbCustomer.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            //
            chkBoxSuccess.Checked = false;
            chkBoxPending.Checked = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //
            dgvSalesInvoiceReport.DataSource = dt;
            DataLoadedMode = "dt";
            SortDGVColumns();
            //
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            //
            chkBoxSuccess.Checked = false;
            chkBoxPending.Checked = false;
            //
            cmbCustomer.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
        }

        private void chkBoxSuccess_Click(object sender, EventArgs e)
        {
            chkBoxSuccess.Checked = true;
            chkBoxPending.Checked = false;
            DataTable successDT = new DataTable();

            if (DataLoadedMode == "dt")
            {
                successDT = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PaymentStatus"].ToString().Trim().ToLower() == "success")
                    {
                        successDT.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (DataLoadedMode == "tempDT")
            {
                successDT = tempDT.Clone();
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["PaymentStatus"].ToString().Trim().ToLower() == "success")
                    {
                        successDT.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
            }
            dgvSalesInvoiceReport.DataSource = "";
            dgvSalesInvoiceReport.DataSource = successDT;
            SortDGVColumns();
        }

        private void cmbCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            txtSrNo.Text = "";

            DataTable filterCustomer = new DataTable();
            if (DataLoadedMode == "dt")
            {
                filterCustomer = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["CustomerID"].ToString().Trim() == cmbCustomer.SelectedValue.ToString().Trim())
                    {
                        filterCustomer.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (DataLoadedMode == "tempDT")
            {
                filterCustomer = tempDT.Clone();
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["CustomerID"].ToString().Trim() == cmbCustomer.SelectedValue.ToString().Trim())
                    {
                        filterCustomer.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
            }
            dgvSalesInvoiceReport.DataSource = filterCustomer;
            SortDGVColumns();
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            txtSrNo.Text = "";

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
            dgvSalesInvoiceReport.DataSource = filterCategory;
            SortDGVColumns();
        }

        private void cmbProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            txtSrNo.Text = "";

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
            dgvSalesInvoiceReport.DataSource = filterProduct;
            SortDGVColumns();
        }

        private void chkBoxPending_Click(object sender, EventArgs e)
        {
            chkBoxSuccess.Checked = false;
            chkBoxPending.Checked = true;
            DataTable pendingDT = new DataTable();


            if (DataLoadedMode == "dt")
            {
                pendingDT = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PaymentStatus"].ToString().Trim().ToLower() == "pending")
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
                    if (tempDT.Rows[i]["PaymentStatus"].ToString().Trim().ToLower() == "pending")
                    {
                        pendingDT.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
            }
            dgvSalesInvoiceReport.DataSource = "";
            dgvSalesInvoiceReport.DataSource = pendingDT;
            SortDGVColumns();
        
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            chkBoxSuccess.Checked = false;
            chkBoxPending.Checked = false;
            if (DataLoadedMode == "dt")
            {
                dgvSalesInvoiceReport.DataSource = dt;
                DataLoadedMode = "dt";
                SortDGVColumns();
            }
            else if (DataLoadedMode == "tempDT")
            {
                SearchData();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtSrNo_TextChanged(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;

            if (txtSrNo.Text.Length > 0)
            {
                if (DataLoadedMode == "dt")
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = string.Format("srno like '{0}' ", txtSrNo.Text.ToString().Trim());
                    dgvSalesInvoiceReport.DataSource = dv.ToTable();

                }
                else if (DataLoadedMode == "tempDT")
                {
                    DataView dv = tempDT.DefaultView;
                    dv.RowFilter = string.Format("srno like '{0}' ", txtSrNo.Text.ToString().Trim());
                    dgvSalesInvoiceReport.DataSource = dv.ToTable();
                }
                SortDGVColumns();
            }
            else
            {
                if (DataLoadedMode == "dt")
                {
                    LoadData();

                }
                else if (DataLoadedMode == "tempDT")
                {
                    SearchData();
                }
            }
            
        }

        private void dgvSalesInvoiceReport_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.ToString().Trim().ToLower() == "srno")
            {
                e.Column.HeaderText = "Sr.No";
                e.Column.DisplayIndex = 0;
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "customername")
            {
                e.Column.HeaderText = "Customer Name";

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
            else if (e.Column.Name.ToString().Trim().ToLower() == "retailprice")
            {
                e.Column.HeaderText = "Retail Price";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "discount")
            {
                e.Column.HeaderText = "Discount";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "qty")
            {
                e.Column.HeaderText = "Qty";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "paymentstatus")
            {
                e.Column.HeaderText = "Status";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "date")
            {
                e.Column.HeaderText = "Date";
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Dictionary<string,string> dates = new Dictionary<string,string>();
            dates.Add("fromDate",dtFromDate.Value.ToString());
            dates.Add("toDate", dtToDate.Value.ToString());



            if (DataLoadedMode == "dt")
            {
                frmSalesCrptViewer frmSalesRegister = new frmSalesCrptViewer(dt,dates);
                frmSalesRegister.Show();

            }
            else if (DataLoadedMode == "tempDT")
            {
                frmSalesCrptViewer frmSalesRegister2 = new frmSalesCrptViewer(tempDT,dates);
                frmSalesRegister2.Show();

            }

            

        }
    }
}
