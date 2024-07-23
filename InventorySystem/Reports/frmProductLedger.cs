using PickAndChooseGroceryStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Reports
{
    public partial class frmProductLedger : Form
    {
        public frmProductLedger()
        {
            InitializeComponent();
        }
        //Main dt
        DataTable dt = new DataTable();
        //Product dt
        DataTable dtProduct = new DataTable();
        //
        int soldQuantity = 0;
        float purchaseAmount = 0;
        float saleAmount = 0;
        float profit = 0;
        float currentStock = 0;
        void LoadProducts()
        {
            string query = "select * from ProductInfo";
            dtProduct = General.FetchData(query);
            cmbProduct.DataSource = dtProduct;
            cmbProduct.DisplayMember = dtProduct.Columns["ProductName"].ToString();
            cmbProduct.ValueMember = dtProduct.Columns["ProductID"].ToString();
            cmbProduct.SelectedIndex = -1;
        }
        private void frmProductLedger_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgv.DataSource = "";
            lblCurrentStock.Text = "0.00";
            lblSoldQuantity.Text = "0.00";
            lblPurchaseAmount.Text = "0.00";
            lblSaleAmount.Text = "0.00";
            //lblProfit.Text = "0.00";
            //--------------------------
            dt = new DataTable();
            soldQuantity = 0;
            purchaseAmount = 0;
            saleAmount = 0;
            profit = 0;
            currentStock = 0;
            //
            var fromDate = dtFromDate.Value.ToString();
            var toDate = dtToDate.Value.ToString();
            if (cmbProduct.SelectedIndex <= 0)
            {
                return;
            }
            var productID = cmbProduct.SelectedValue.ToString();
            

            //
            var dtPurchase = new DataTable();
            string queryPurchase = "select Purchases.PurchaseID , Purchases.PurchaseDate ,'PurchaseInvoice' as Flow, Purchases.Qty ," +
                " PrdInfo.PurchasePrice, PrdInfo.PurchasePrice*Purchases.Qty as GrossAmount, PrdInfo.PurchasePrice*Purchases.Qty as NetAmount," +
                " Purchases.ProductID from ProductInfo as PrdInfo inner join 	(select PurInvc.PurchaseID,PurInvc.PurchaseDate ," +
                "PurInvcDet.ProductID,PurInvcDet.Qty from PurchaseInvoice as PurInvc " +
                "inner join PurchaseInvoiceDetail as PurInvcDet on PurInvc.PurchaseID = PurInvcDet.PurchaseID 	where PurInvc.PurchaseDate" +
                " between '" + fromDate + "' and '" + toDate + "') Purchases on Purchases.ProductID = PrdInfo.ProductID " +
                " where Purchases.ProductID = '" + productID + "' order by Purchases.PurchaseDate ";
            dtPurchase = General.FetchData(queryPurchase);
            //
            var dtSales = new DataTable();
            string querySales = "select Sales.BillID, Sales.Date, 'SalesInvoice' as Flow, Sales.Qty, PrdInfo.RetailPrice," +
                " PrdInfo.RetailPrice*Sales.Qty as GrossAmount, Sales.Discount," +
                " Sales.Qty*(PrdInfo.RetailPrice -(PrdInfo.RetailPrice*(Sales.Discount/100)))as NetAmount, Sales.ProductID from ProductInfo as PrdInfo " +
                " inner join (select SI.BillID,SI.Date,SID.ProductID,SID.Qty,SID.Discount from SalesInvoice as SI " +
                "inner join SalesInvoiceDetail as SID on SI.BillID = SID.BillID where Date between '" + fromDate + "' and '" + toDate + "') Sales " +
                "on Sales.ProductID = PrdInfo.ProductID where Sales.ProductID = '" + productID + "' order by Sales.Date ";
            dtSales = General.FetchData(querySales);
            //
            dt.Columns.Add("VoucherNo");
            dt.Columns.Add("Date");
            dt.Columns.Add("Flow");
            dt.Columns.Add("QtyIN");
            dt.Columns.Add("QtyOUT");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("GrossAmount");
            dt.Columns.Add("Discount");
            dt.Columns.Add("NetAmount");
            dt.Columns.Add("TotalQuantity");

            for (int i = 0; i < dtPurchase.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["VoucherNo"] = dtPurchase.Rows[i]["PurchaseID"].ToString();
                dr["Date"] = dtPurchase.Rows[i]["PurchaseDate"].ToString();
                dr["Flow"] = dtPurchase.Rows[i]["Flow"].ToString();
                dr["QtyIN"] = dtPurchase.Rows[i]["Qty"].ToString();
                dr["QtyOUT"] = " --- ";
                dr["UnitPrice"] = dtPurchase.Rows[i]["PurchasePrice"].ToString();
                dr["GrossAmount"] = dtPurchase.Rows[i]["GrossAmount"].ToString();
                dr["Discount"] = " --- ";
                dr["NetAmount"] = dtPurchase.Rows[i]["NetAmount"].ToString();
                dr["TotalQuantity"] = "+ " + dtPurchase.Rows[i]["Qty"].ToString();
                dt.Rows.Add(dr);

            }
            for (int i = 0; i < dtSales.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["VoucherNo"] = dtSales.Rows[i]["BillID"].ToString();
                dr["Date"] = dtSales.Rows[i]["Date"].ToString();
                dr["Flow"] = dtSales.Rows[i]["Flow"].ToString();
                dr["QtyIN"] = " ---";
                dr["QtyOUT"] = dtSales.Rows[i]["Qty"].ToString();
                dr["UnitPrice"] = dtSales.Rows[i]["RetailPrice"].ToString();
                dr["GrossAmount"] = dtSales.Rows[i]["GrossAmount"].ToString();
                dr["Discount"] = dtSales.Rows[i]["Discount"].ToString();
                dr["NetAmount"] = dtSales.Rows[i]["NetAmount"].ToString();
                dr["TotalQuantity"] = "- " + dtSales.Rows[i]["Qty"].ToString();
                dt.Rows.Add(dr);
            }
            dt.DefaultView.Sort = "Date ASC";
            dgv.DataSource = dt;


            if (dtProduct.Rows.Count >0)
            {
                for(int n = 0; n < dtProduct.Rows.Count; n++)
                {
                    if(dtProduct.Rows[n]["ProductID"].ToString() == productID)
                    {
                        currentStock = float.Parse(dtProduct.Rows[n]["AvailableStock"].ToString());
                        break;
                    }
                }
               
            }
            lblCurrentStock.Text = currentStock.ToString();

            //making datetime to date only
            if(dt.Rows.Count >0)
            {
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Date"] = DateTime.Parse(dt.Rows[i]["Date"].ToString()).ToShortDateString();
                }
            }
            
            for (int i = 0; i < dtSales.Rows.Count; i++)
            {
                soldQuantity = soldQuantity + int.Parse(dtSales.Rows[i]["Qty"].ToString());
                saleAmount = saleAmount + float.Parse(dtSales.Rows[i]["NetAmount"].ToString());
            }
            lblSoldQuantity.Text = soldQuantity.ToString();
            lblSaleAmount.Text = saleAmount.ToString();
           
            for (int i = 0; i < dtPurchase.Rows.Count; i++)
            {
                purchaseAmount = purchaseAmount + float.Parse(dtPurchase.Rows[i]["NetAmount"].ToString());
            }
            lblPurchaseAmount.Text = purchaseAmount.ToString();
            profit = (saleAmount - purchaseAmount);
            //lblProfit.Text = (saleAmount - purchaseAmount).ToString();



        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tempProductBarcode = txtBarcode.Text.Trim().ToString();
                string tempProductID = "";
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductBarcode"].ToString() == tempProductBarcode)
                    {
                        tempProductID = dtProduct.Rows[i]["ProductID"].ToString();
                        cmbProduct.SelectedValue = tempProductID;

                    }
                }

               
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex != -1)
            {
                string tempProductID = cmbProduct.SelectedValue.ToString();
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductID"].ToString() == tempProductID)
                    {
                        txtBarcode.Text = dtProduct.Rows[i]["ProductBarcode"].ToString();
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbProduct.SelectedIndex = -1;
            txtBarcode.Text = "";
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            dt.Clear();
            dgv.DataSource = "";
            lblCurrentStock.Text = "0.00";
            lblSoldQuantity.Text = "0.00";
            lblPurchaseAmount.Text = "0.00";
            lblSaleAmount.Text = "0.00";
            //lblProfit.Text = "0.00";

            soldQuantity = 0;
            purchaseAmount = 0;
            saleAmount = 0;
            profit = 0;
            currentStock = 0;


            txtBarcode.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("fromDate", dtFromDate.Value.ToString());
            values.Add("toDate", dtToDate.Value.ToString());
            if(cmbProduct.SelectedIndex == -1)
            {
                values.Add("productID", "-1");
                values.Add("productName", "No Product Selected");
            }
            else 
            {
                values.Add("productID", cmbProduct.SelectedValue.ToString());
                values.Add("productName", cmbProduct.Text.Trim().ToString());
            }            
            
            values.Add("soldQty", soldQuantity.ToString());
            values.Add("purchaseAmount", purchaseAmount.ToString());
            values.Add("saleAmount", saleAmount.ToString());
            values.Add("profit", profit.ToString());
            values.Add("currentStock", currentStock.ToString());





            var crptViewer1 = new CrystalReportsViewers.frmProductLedgerCrptViewer(dt,values);
            crptViewer1.Show();

           
        }
    }
}
