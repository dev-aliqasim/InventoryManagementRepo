using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmProductStockReport : Form
    {
        public frmProductStockReport()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DataTable dtMax = new DataTable();
        DataTable dtMin = new DataTable();
        DataTable dtOutOfStock = new DataTable();
        int stock = 0;
        public void LoadData()
        {
            stock = 0;
            try
            {
                string Query = "select * from ProductInfo  inner join Category on ProductInfo.CategoryID = Category.CategoryID";
                dt = General.FetchData(Query);
                dgvStockReport.DataSource = dt;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                  stock = stock + int.Parse(dt.Rows[i]["AvailableStock"].ToString());
                }

                lblTotalAmount.Text = stock.ToString();
                lblStatus.Text = "Overall report";
                AdjustColumnIndex();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        }
        public void AdjustColumnIndex()
        {
            dgvStockReport.Columns["ProductBarcode"].DisplayIndex = 0;
            dgvStockReport.Columns["ProductName"].DisplayIndex = 1;
            dgvStockReport.Columns["CategoryName"].DisplayIndex = 2;
            dgvStockReport.Columns["PurchasePrice"].DisplayIndex = 3;
            dgvStockReport.Columns["RetailPrice"].DisplayIndex = 4;
            dgvStockReport.Columns["AvailableStock"].DisplayIndex = 5;
        }

        public void LoadCategory()
        {
            string query = "select * from Category";
            DataTable tempCategory = new DataTable();
            tempCategory = General.FetchData(query);
            cmbCategory.DataSource = tempCategory;
            cmbCategory.DisplayMember = tempCategory.Columns["CategoryName"].ToString();
            cmbCategory.ValueMember = tempCategory.Columns["CategoryID"].ToString();
            cmbCategory.SelectedIndex = -1;
        }
        private void frmProductStockReport_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCategory();
        }
       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //
            txtBarcode.Text = "";
            txtProductName.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbFilterBy.SelectedIndex = -1;
            //
            stock = 0;
            dgvStockReport.DataSource = "";
            dgvStockReport.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                stock = stock + int.Parse(dt.Rows[i]["AvailableStock"].ToString());
            }

            lblTotalAmount.Text = stock.ToString();
            lblStatus.Text = "Overall report";
            AdjustColumnIndex();
            
            cmbFilterBy.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
        }

        private void dgvStockReport_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.Trim().ToString().ToLower() == "productbarcode")
            {
                e.Column.HeaderText = "Barcode";

            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "productname")
            {
                e.Column.HeaderText = "Product";
                
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "categoryname")
            {
                e.Column.HeaderText = "Category";
                
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "purchaseprice")
            {
                e.Column.HeaderText = "Purchased Price";
                
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "retailprice")
            {
                e.Column.HeaderText = "Retail Price";
                
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "availablestock")
            {
                e.Column.HeaderText = "AvailableStock";
                
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbFilterBy.SelectedIndex = -1;
            txtBarcode.Text = "";
            txtProductName.Text = "";
            /////
            DataTable filterCategory = new DataTable();
            filterCategory = dt.Clone();
            if (cmbCategory.SelectedIndex != -1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["CategoryID"].ToString().Trim() == cmbCategory.SelectedValue.ToString().Trim())
                    {
                        filterCategory.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                dgvStockReport.DataSource = filterCategory;
                //status of report
                stock = 0;
                for (int i = 0; i < filterCategory.Rows.Count; i++)
                {
                    stock = stock + int.Parse(filterCategory.Rows[i]["AvailableStock"].ToString());
                }

                lblTotalAmount.Text = stock.ToString();
                lblStatus.Text = "CategoryWise";
                AdjustColumnIndex();
                
            }
            
        }

        private void cmbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cmbCategory.SelectedIndex = -1;
            txtBarcode.Text = "";
            txtProductName.Text = "";
            ////
            if (cmbFilterBy.SelectedIndex == 0)//{0:Max Stock}
            {
                try
                {
                    string query = "select * from ProductInfo  inner join Category on ProductInfo.CategoryID = Category.CategoryID where Category.CategoryID = '"+cmbCategory.SelectedValue+"' order by AvailableStock desc";
                    dtMax = General.FetchData(query);
                    dgvStockReport.DataSource = "";
                    dgvStockReport.DataSource = dtMax;
                    // calculate stock
                    int stock = 0;
                    for (int i = 0; i < dtMax.Rows.Count; i++)
                    {
                        stock = stock + int.Parse(dtMax.Rows[i]["AvailableStock"].ToString());
                    }
                    lblTotalAmount.Text = stock.ToString();
                    lblStatus.Text = "...By MAX stock";
                    //
                    AdjustColumnIndex();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else if (cmbFilterBy.SelectedIndex == 1)//{1:Min Stock}
            {
                try
                {
                    string query = "select * from ProductInfo  inner join Category on ProductInfo.CategoryID = Category.CategoryID where Category.CategoryID = '" + cmbCategory.SelectedValue + "' order by AvailableStock asc";
                    dtMin = General.FetchData(query);
                    dgvStockReport.DataSource = "";
                    dgvStockReport.DataSource = dtMin;
                    // calculate stock
                    int stock = 0;
                    for (int i = 0; i < dtMin.Rows.Count; i++)
                    {
                        stock = stock + int.Parse(dtMin.Rows[i]["AvailableStock"].ToString());
                    }
                    lblTotalAmount.Text = stock.ToString();
                    lblStatus.Text = "...By MIN stock";
                    //
                    AdjustColumnIndex();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmbFilterBy.SelectedIndex == 2)//{2:Out of Stock}
            {
                try
                {
                    string query = "select * from ProductInfo  inner join Category on ProductInfo.CategoryID = Category.CategoryID where  Category.CategoryID = '" + cmbCategory.SelectedValue + "' AND ProductInfo.AvailableStock = 0 ";
                    dtOutOfStock = General.FetchData(query);
                    dgvStockReport.DataSource = "";
                    dgvStockReport.DataSource = dtOutOfStock;
                    // calculate stock
                    int stock = 0;
                    for (int i = 0; i < dtOutOfStock.Rows.Count; i++)
                    {
                        stock = stock + int.Parse(dtOutOfStock.Rows[i]["AvailableStock"].ToString());
                    }
                    lblTotalAmount.Text = stock.ToString();
                    lblStatus.Text = "...Out of Stock";
                    //
                    AdjustColumnIndex();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbFilterBy.SelectedIndex = -1;
            //
            if (txtBarcode.Text.Length > 0)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("productbarcode like '%{0}%' ",txtBarcode.Text.Trim());
                DataTable dtTemp = dv.ToTable();
                dgvStockReport.DataSource = dtTemp;
                //status of report
                stock = 0;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    stock = stock + int.Parse(dtTemp.Rows[i]["AvailableStock"].ToString());
                }

                lblTotalAmount.Text = stock.ToString();
                lblStatus.Text = "..By Barcode";
                AdjustColumnIndex();
            }
            else if (txtBarcode.Text.Length <= 0)
            {
                LoadData();
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbFilterBy.SelectedIndex = -1;
            //
            if (txtProductName.Text.Length > 0)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("productname like '%{0}%' ", txtProductName.Text.Trim());
                DataTable dtTemp = dv.ToTable();
                dgvStockReport.DataSource = dtTemp;
                //status of report
                stock = 0;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    stock = stock + int.Parse(dtTemp.Rows[i]["AvailableStock"].ToString());
                }

                lblTotalAmount.Text = stock.ToString();
                lblStatus.Text = "..Product Name";
                AdjustColumnIndex();
            }
            else if (txtProductName.Text.Length <= 0)
            {
                LoadData();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
