using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmDashboard_Dashboard : Form
    {
        public frmDashboard_Dashboard()
        {
            InitializeComponent();
        }
        DataTable dtItemPurchased = new DataTable();
        DataTable dtItemSold = new DataTable();
        public void LoadItemSold()
        {
            try
            {
                var StartOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                string query = "select * from SalesInvoice SI inner join SalesInvoiceDetail SD on SI.BillID = SD.BillID inner join ProductInfo on SD.ProductID = ProductInfo.ProductID where SI.Date between '" + StartOfMonth + "' and '" + DateTime.Now + "' ";
                dtItemSold = General.FetchData(query);
                float count = 0;
                for (int i = 0; i < dtItemSold.Rows.Count; i++)
                {
                    count = count + float.Parse(dtItemSold.Rows[i]["Qty"].ToString());
                }
                lblSold.Text = count.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void LoadItemPurchased()
        {
            try
            {
                var StartOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                string query = "select * from PurchaseInvoice PI inner join PurchaseInvoiceDetail PD on PI.PurchaseID = PD.PurchaseID inner join ProductInfo on PD.ProductID = ProductInfo.ProductID inner join Category on ProductInfo.CategoryID = Category.CategoryID where PI.PurchaseDate between '" + StartOfMonth + "' and '" + DateTime.Now + "' ";
                dtItemPurchased = General.FetchData(query);
                float count = 0;
                for (int i = 0; i < dtItemPurchased.Rows.Count; i++)
                {
                    count = count + float.Parse(dtItemPurchased.Rows[i]["Qty"].ToString());
                }
                lblPurchase.Text = count.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void OrderColumnOfSoldItems()
        {
            dgvSoldItem.Columns["Date"].DisplayIndex = 0;
            dgvSoldItem.Columns["ProductName"].DisplayIndex = 1;
            dgvSoldItem.Columns["Qty"].DisplayIndex = 2;
            dgvSoldItem.Columns["Discount"].DisplayIndex = 3;
        }
        public void LoadRecentlySoldItems()
        {
            DataTable dtRecentlySoldItems = new DataTable();
            DateTime DT;
            dtRecentlySoldItems = dtItemSold.Clone();
            for (int i = 0; i < dtItemSold.Rows.Count; i++)
            {
                DT = DateTime.Parse(dtItemSold.Rows[i]["Date"].ToString());
                if ( DT.Date == DateTime.Now.Date)
                {
                    dtRecentlySoldItems.Rows.Add(dtItemSold.Rows[i].ItemArray);
                }
            }
            dgvSoldItem.DataSource = dtRecentlySoldItems;
            OrderColumnOfSoldItems();

        }
        public void OrderColumnOfPurchaseItems()
        {
            dgvPurchaseItems.Columns["CategoryName"].DisplayIndex = 0;
            dgvPurchaseItems.Columns["ProductName"].DisplayIndex = 1;
            dgvPurchaseItems.Columns["Qty"].DisplayIndex = 2;
            dgvPurchaseItems.Columns["AvailableStock"].DisplayIndex = 3;
        }
        public void LoadRecentlyPurchasedItems()
        {
            DataTable dtRecentlyPurchaseItems = new DataTable();
            DateTime DT;
            dtRecentlyPurchaseItems = dtItemPurchased.Clone();
            for (int i = 0; i < dtItemPurchased.Rows.Count; i++)
            {
                DT = DateTime.Parse(dtItemPurchased.Rows[i]["PurchaseDate"].ToString());
                if (DT.Date == DateTime.Now.Date)
                {
                    dtRecentlyPurchaseItems.Rows.Add(dtItemPurchased.Rows[i].ItemArray);
                }
            }
            dgvPurchaseItems.DataSource = dtRecentlyPurchaseItems;
            OrderColumnOfPurchaseItems();
        }

        public void LoadProfit()
        {
            float retailPrice = 0;
            float purchasePrice = 0;
            float discount = 0;
            float items = 0;
            float totalprice = 0;
            float profit = 0;
            float TotalProfit = 0;
            for (int i = 0; i < dtItemSold.Rows.Count; i++)
            {
                retailPrice = float.Parse(dtItemSold.Rows[i]["RetailPrice"].ToString());
                purchasePrice = float.Parse(dtItemSold.Rows[i]["PurchasePrice"].ToString());
                discount = float.Parse(dtItemSold.Rows[i]["Discount"].ToString());
                items = float.Parse(dtItemSold.Rows[i]["Qty"].ToString());
                //
                totalprice = (retailPrice*items) - (( (retailPrice*items )*discount)/100);
                profit = totalprice - (purchasePrice * items) ;
                TotalProfit = TotalProfit + profit;
            }
            lblProfit.Text = TotalProfit.ToString() + " Rs";
        }

        public void LoadCategories()
        {
            string query = "select count(*) as  Count from Category ";
            DataTable Category = General.FetchData(query);
            lblCategory.Text = Category.Rows[0]["Count"].ToString();
        }
        public void LoadEmployees()
        {
            string query = "select count(*) as  Count from Employee ";
            DataTable Employees = General.FetchData(query);
            lblEmployee.Text = Employees.Rows[0]["Count"].ToString();
        }
        private void frmDashboard_Dashboard_Load(object sender, EventArgs e)
        {
            LoadItemSold();
            LoadItemPurchased();
            LoadProfit();
            LoadCategories();
            LoadEmployees();

            LoadRecentlySoldItems();
            LoadRecentlyPurchasedItems();
              
        }

        private void dgvSoldItem_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.ToString().Trim().ToLower() == "date")
            {
                e.Column.HeaderText = "Date";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "productname")
            {
                e.Column.HeaderText = "Product Name";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "qty")
            {
                e.Column.HeaderText = "Quantity";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "discount")
            {
                e.Column.HeaderText = "Discount";
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void dgvPurchaseItems_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.ToString().Trim().ToLower() == "productname")
            {
                e.Column.HeaderText = "Product Name";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "qty")
            {
                e.Column.HeaderText = "Quantity";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "categoryname")
            {
                e.Column.HeaderText = "Category";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "availablestock")
            {
                e.Column.HeaderText = "Available Stock";
            }
            else
            {
                e.Column.Visible = false;
            }
        }
    }
}
