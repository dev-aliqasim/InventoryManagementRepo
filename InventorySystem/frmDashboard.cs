using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        public void LoadForm(object Form)
        {
            if (this.panelBody.Controls.Count > 0)
            {
                this.panelBody.Controls.RemoveAt(0);
            }
                Form f = Form as Form;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                this.panelBody.Controls.Add(f);
                this.panelBody.Tag = f;
                f.Show();

            
        }
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadForm(new frmDashboard_Dashboard());
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadForm(new frmDashboard_Reports());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new frmDashboard_Dashboard());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LoadForm(new frmDashboard_Setting());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.MdiParent.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new frmEmployeesAttendence());
        }
    }
}
