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
    public partial class frmLogin : Form
    {
        Database db;
        public frmLogin()
        {
            InitializeComponent();
            db = new Database();
        }

        private void chckbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxShowPassword.Checked) txtPassword.PasswordChar = '\0';
            else  txtPassword.PasswordChar = '•';
        }

        private void lblAlreadyHaveAccount_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!(txtUsername.Text == "" && txtPassword.Text == ""))
            {
                if(db.Login(txtUsername.Text, txtPassword.Text).Read() == true)
                {
                    new frmAdmin().Show();
                    this.Hide();
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Username Or Password is Incorrect", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
        }
    }
}
