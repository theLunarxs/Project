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
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
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
