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
        public DateTime loginTime;
        public DateTime logoutTime;
        public frmUser()
        {
            InitializeComponent();
            loginTime = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            logoutTime = DateTime.Now;
            Database.SetWorkTime(loginTime, logoutTime);
            Application.Exit();
        }
    }
}
