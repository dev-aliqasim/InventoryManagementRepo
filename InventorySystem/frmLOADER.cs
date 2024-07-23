using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmLOADER : Form
    {
        public frmLOADER( string LoginID)
        {
            InitializeComponent();
            loaderLoginID = LoginID;
            
        }
        //loaderLoginID is used to determine the type of login user
        string loaderLoginID ="";
        string type = "";
        //--------------//
        private void frmLOADER_Load(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                string query = "select * from Login where LoginID = " +loaderLoginID.Trim().ToString();
                DataTable dt = new DataTable();
                dt = General.FetchData(query);
                if (dt.Rows.Count > 0)
                {
                    type = dt.Rows[0]["TypeID"].ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
                //lblPercent.Text = progressBar1.Value + "%";
                
            }
            else
            {
                timer1.Stop();
                if (type.Trim().ToString() == "1")
                {
                    mdiMain Main = new mdiMain(loaderLoginID);
                    Main.Show();
                    this.Hide();
                }
                else if(type.Trim().ToString() == "2")
                {
                    mdiCashier Cashier = new mdiCashier(loaderLoginID);
                    Cashier.Show();
                    this.Hide();
                }
                else if (type.Trim().ToString() == "3")
                {
                    mdiCashier Cashier = new mdiCashier(loaderLoginID);
                    Cashier.Show();
                    this.Hide();
                }

            }
        }

        private void lblPercent_Click(object sender, EventArgs e)
        {

        }
    }
}
