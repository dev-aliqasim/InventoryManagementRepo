using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.CrystalReportsViewers
{
    public partial class frmProductLedgerCrptViewer : Form
    {
        public frmProductLedgerCrptViewer()
        {
            InitializeComponent();
        }

        public frmProductLedgerCrptViewer(DataTable dt, Dictionary<string, string> values)
        {
            InitializeComponent();
            sourceDT = dt;
            this.values = values;
        }

        DataTable sourceDT = new DataTable();
        Dictionary<string, string> values;

        private void frmProductLedgerCrptViewer_Load(object sender, EventArgs e)
        {
            var crptProductLedger = new CrystalReports.crptProductLedger();
            crptProductLedger.SetDataSource(sourceDT);

            var fromDate = DateTime.Parse(values["fromDate"]);
            var toDate = DateTime.Parse(values["toDate"]);
            var productID = values["productID"];
            var productName = values["productName"];
            var soldQty = values["soldQty"];
            var purchaseAmount = values["purchaseAmount"];
            var saleAmount = values["saleAmount"];
            var profit = values["profit"];
            var currentStock = values["currentStock"];






            crptProductLedger.SetParameterValue("fromDate", fromDate.ToString("dd MMM yyyy"));
            crptProductLedger.SetParameterValue("toDate", toDate.ToString("dd MMM yyyy"));
            crptProductLedger.SetParameterValue("productID", productID);
            crptProductLedger.SetParameterValue("productName", productName);
            crptProductLedger.SetParameterValue("soldQty", soldQty);
            crptProductLedger.SetParameterValue("purchaseAmount", purchaseAmount);
            crptProductLedger.SetParameterValue("saleAmount", saleAmount);
            crptProductLedger.SetParameterValue("profit", profit);
            crptProductLedger.SetParameterValue("currentStock", currentStock);








            crptViewer.ReportSource = null;
            crptViewer.ReportSource = crptProductLedger;
        }
    }
}
