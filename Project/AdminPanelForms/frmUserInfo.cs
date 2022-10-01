using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.AdminPanelForms
{
    public partial class frmUserInfo : Form
    {
        public frmUserInfo()
        {
            InitializeComponent();
            pnl1.Visible = false;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = false;
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            pnl1.Visible = true;
            pnl2.Visible = true;
            pnl3.Visible = true;
            pnl4.Visible = true;
            pnl5.Visible = true;
            pnl6.Visible = true;
            Database.UserInfo user = Database.GetUserData(txtUsername.Text);
            lblFullname.Text = user.Firstname + user.Lastname;
            lblRole.Text = user.Role;
            lblHrsM.Text = user.HrsM;
            lblHrsW.Text = user.HrsW;
            lblPayM.Text = user.PayM;
            lblUsername.Text = user.Username;
            txtUsername.Text = "";
        }
    }
}
