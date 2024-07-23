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
    public partial class frmPurchaseCrptViewer : Form
    {
        public frmPurchaseCrptViewer()
        {
            InitializeComponent();
        }
        public frmPurchaseCrptViewer(DataTable dt, Dictionary<string, string> dates)
        {
            InitializeComponent();
            sourceDT = dt;
            sourceDates = dates;
        }

        DataTable sourceDT = new DataTable();
        Dictionary<string, string> sourceDates;

        private void frmPurchaseCrptViewer_Load(object sender, EventArgs e)
        {
            var crptPurchaseRegister = new CrystalReports.crptPurchaseRegister();
            crptPurchaseRegister.SetDataSource(sourceDT);

            var fromDate = DateTime.Parse(sourceDates["fromDate"]);
            var toDate = DateTime.Parse(sourceDates["toDate"]);


            crptPurchaseRegister.SetParameterValue("fromDate", fromDate.ToString("dd MMM yyyy"));
            crptPurchaseRegister.SetParameterValue("toDate", toDate.ToString("dd MMM yyyy"));


            crptViewer.ReportSource = null;
            crptViewer.ReportSource = crptPurchaseRegister;
        }
    }
}
