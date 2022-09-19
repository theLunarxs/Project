using Project.AdminPanelForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmAdmin : Form
    {


        public frmAdmin()
        {
            InitializeComponent();
            lblPageInfo.Text = "Dashboard";
            this.pnlContent.Controls.Clear();
            frmDashboard frmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlContent.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            lblPageInfo.Text = "Dashboard";
            this.pnlContent.Controls.Clear();
            frmDashboard frmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlContent.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void btnUserControl_Click(object sender, EventArgs e)
        {
            lblPageInfo.Text = "User Control";
            this.pnlContent.Controls.Clear();
            frmUserControl frmUserControl_Vrb = new frmUserControl(){ Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmUserControl_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlContent.Controls.Add(frmUserControl_Vrb);
            frmUserControl_Vrb.Show();
        }
    }
}
