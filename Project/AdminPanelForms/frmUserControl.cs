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
            if(!(txtUsername.Text == "" || txtPassword.Text == "" || txtFname.Text =="" || txtLname.Text == ""))
            {
                if(!(txtHrsM.Text == "" && txtPayM.Text == ""))
                {
                    if (!(txttblname.Text == ""))
                    {
                        db.InsertData(txtFname.Text, txtLname.Text, txtUsername.Text, txtPassword.Text,Role:cboxRole.ToString() ,HrsM: int.Parse(txtHrsM.Text), 
                          PayM: int.Parse(txtPayM.Text), tbl_name:txttblname.Text);
                    }
                    else
                    {
                        db.InsertData(txtFname.Text, txtLname.Text, txtUsername.Text, txtPassword.Text, Role: cboxRole.ToString(), HrsM:int.Parse(txtHrsM.Text), PayM: int.Parse(txtPayM.Text));
                    }
                    
                }
                else
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
}
