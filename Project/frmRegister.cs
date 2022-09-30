using Project;
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
    public partial class frmRegister : Form
    {
        
        public frmRegister()
        {
            InitializeComponent();
            //db = new Database();
        }
        private void lblAlreadyHaveAccount_MouseHover(object sender, EventArgs e)
        {
            lblAlreadyHaveAccount.ForeColor = Color.FromArgb(159, 168, 218);
        }

        private void lblAlreadyHaveAccount_MouseLeave(object sender, EventArgs e)
        {
            lblAlreadyHaveAccount.ForeColor= Color.White;
        }

        private void chckbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chckbxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfPass.PasswordChar = '•';
            }
        }

        private void lblAlreadyHaveAccount_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtConfPass.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registeration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtPassword.Text == txtConfPass.Text)
            {
                Database.Register(txtFname.Text, txtLname.Text, txtUsername.Text, txtPassword.Text);
                

                

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtLname.Text = "";
                txtFname.Text = "";
                txtConfPass.Text = "";

                new frmLogin().Show();
                this.Hide();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
