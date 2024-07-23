using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmSalesReport : Form
    {
        public frmSalesReport()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();

        public void LoadData()
        {
            string Query = "select * from SalesInvoice as SalInvo  inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID  inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID inner join Category as C on PI.CategoryID = C.CategoryID";
            dt = General.FetchData(Query);
            //calculating amount
            float price = 0;
            float quantity = 0;
            float discount = 0;
            float amount = 0;
            float totalamount = 0;
            dt.Columns.Add("Amount");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                price = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                quantity = float.Parse(dt.Rows[i]["Qty"].ToString());
                discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                amount = quantity * price;
                totalamount = amount - ((amount * discount) / 100);
                dt.Rows[i]["Amount"] = totalamount.ToString();
            }
            //
            dgvSalesReport.DataSource = "";
            dgvSalesReport.DataSource = dt;

            AdjustColumnIndex();
        }

        public void AdjustColumnIndex()
        {
            dgvSalesReport.Columns["Date"].DisplayIndex = 0;
            dgvSalesReport.Columns["ProductBarcode"].DisplayIndex = 1;
            dgvSalesReport.Columns["ProductName"].DisplayIndex = 2;
            dgvSalesReport.Columns["CategoryName"].DisplayIndex = 3;
            dgvSalesReport.Columns["Qty"].DisplayIndex = 4;
            dgvSalesReport.Columns["Amount"].DisplayIndex = 5;
        }
        public float TotalAmountCalculated()
        {
            float amount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                amount = amount + float.Parse(dt.Rows[i]["Amount"].ToString());
            }
            return amount;
        }
        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            LoadData();
            lblTotalAmount.Text = TotalAmountCalculated().ToString();
            lblStatus.Text = "Normal Report";
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Query = "select * from SalesInvoice as SalInvo  inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID  inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID inner join Category as C on PI.CategoryID = C.CategoryID where SalInvo.Date between '"+dtFromDate.Text.Trim().ToString()+ "' AND '" + dtToDate.Text.Trim().ToString() + "'";
            dt = General.FetchData(Query);
            //calculating amount
            float price = 0;
            float quantity = 0;
            float discount = 0;
            float amount = 0;
            float totalamount = 0;
            dt.Columns.Add("Amount");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                price = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                quantity = float.Parse(dt.Rows[i]["Qty"].ToString());
                discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                amount = quantity * price;
                totalamount = amount - ((amount * discount) / 100);
                dt.Rows[i]["Amount"] = totalamount.ToString();
            }
            //
            dgvSalesReport.DataSource = "";
            dgvSalesReport.DataSource = dt;

            AdjustColumnIndex();
            lblTotalAmount.Text = TotalAmountCalculated().ToString();
            lblStatus.Text = "Special Report";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            LoadData();
            lblTotalAmount.Text =  TotalAmountCalculated().ToString();
            lblStatus.Text = "Normal Report";
        }

        private void dgvSalesReport_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.Trim().ToString().ToLower() == "date")
            {
                e.Column.HeaderText = "Date";
                e.Column.DisplayIndex = 0;
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "productbarcode")
            {
                e.Column.HeaderText = "Barcode";
                e.Column.DisplayIndex = 1;
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "productname")
            {
                e.Column.HeaderText = "Product";
                e.Column.DisplayIndex = 2;
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "categoryname")
            {
                e.Column.HeaderText = "Category";
                e.Column.DisplayIndex = 3;
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "qty")
            {
                e.Column.HeaderText = "Quantity";
                e.Column.DisplayIndex = 4;
            }
            else if (e.Column.Name.Trim().ToString().ToLower() == "amount")
            {
                e.Column.HeaderText = "Amount";
                e.Column.DisplayIndex = 5;
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void btnTodayReport_Click(object sender, EventArgs e)
        {
            string Query = "select * from SalesInvoice as SalInvo  inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID  inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID inner join Category as C on PI.CategoryID = C.CategoryID where SalInvo.Date = '"+DateTime.Now.Date+"'";
            dt = General.FetchData(Query);
            //calculating amount
            float price = 0;
            float quantity = 0;
            float discount = 0;
            float amount = 0;
            float totalamount = 0;
            dt.Columns.Add("Amount");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                price = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                quantity = float.Parse(dt.Rows[i]["Qty"].ToString());
                discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                amount = quantity * price;
                totalamount = amount - ((amount * discount) / 100);
                dt.Rows[i]["Amount"] = totalamount.ToString();
            }
            //
            dgvSalesReport.DataSource = "";
            dgvSalesReport.DataSource = dt;

            AdjustColumnIndex();
            lblTotalAmount.Text = TotalAmountCalculated().ToString();
            lblStatus.Text = "Today's Report";
        }
    }
}
