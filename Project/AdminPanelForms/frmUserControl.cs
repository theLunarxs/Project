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
    public partial class frmUserControl : Form
    {
        Database db;
        public frmUserControl()
        {
            InitializeComponent();
            db = new Database();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "" & txtFname.Text != "" && txtLname.Text != "")
            {
                db.InsertData(txtFname.Text, txtLname.Text, txtUsername.Text, txtPassword.Text);
            }
                
                
                



                txtUsername.Text = "";
                txtPassword.Text = "";
                txtLname.Text = "";
                txtFname.Text = "";
                
            
        }
    }
}
