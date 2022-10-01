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
    public partial class frmUser : Form
    {
        
        public DateTime LogoutTime;
        public frmUser()
        {
            InitializeComponent();
            lblLogin.Text = $"You're now Logged in as {Database.LoginUserName}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            LogoutTime = DateTime.Now;
            Database.SetWorkTime(LogoutTime);
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogoutTime = DateTime.Now;
            Database.SetWorkTime(LogoutTime);
            new frmLogin().Show();
            this.Close();
        }
    }
}
