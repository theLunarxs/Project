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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblNumTusers.Text = Database.GetUserCount(Total: true);
            lblNumAdmins.Text = Database.GetUserCount(Role: "admin");
            lblNumOnlineUsers.Text = Database.GetUserCount();
        }
    }
}
