using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public class Database
    {
        public SQLiteConnection con;
        public SQLiteCommand cmd;
        public Database()
        {
            con = new SQLiteConnection("Data Source = db_users.sqlite3");
            if(!File.Exists("./db_users.sqlite3"))
            {
                SQLiteConnection.CreateFile("db_users.sqlite3");
                OpenConnection();
                cmd = new SQLiteCommand("CREATE TABLE tbl_users (UserID INT AUTO_INCREMENT PRIMARY KEY, Fname varchar(32),Lname varchar(32),Username varchar(32) NOT NULL,Password varchar(32) NOT NULL,Role VARCHAR(32) NOT NULL,PayM int(12),HrsM int(12));"
                    + "INSERT INTO tbl_users (Username, Password, Role) ValUES('admin', 'admin', 'admin');", con);
                cmd.ExecuteNonQuery();
                CloseConnection();

            }
        }
        public void OpenConnection() { if (con.State != System.Data.ConnectionState.Open) con.Open(); }
        public void CloseConnection() { if (con.State != System.Data.ConnectionState.Closed) con.Close(); }

        public void InsertData(string Fname, string Lname, string Username, string Password, string Role="user", int PayM=0, int HrsM = 0, string tbl_name ="tbl_users")
        {
            OpenConnection();
            cmd = new SQLiteCommand($"SELECT * FROM {tbl_name} WHERE Username = '{Username}';", con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if(!reader.Read())
            {
                cmd = new SQLiteCommand($"INSERT INTO {tbl_name} (Fname, Lname, Username, Password, Role, PayM, HrsM) VALUES(@Fname, @Lname, @Username, @Password, @Role, @PayM, @HrsM);", con);
                cmd.Parameters.AddWithValue("@Fname", Fname);
                cmd.Parameters.AddWithValue("@Lname", Lname);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Role", Role);
                cmd.Parameters.AddWithValue("@PayM", PayM);
                cmd.Parameters.AddWithValue("@HrsM", HrsM);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Register Successfull", "You may now Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("A User Already Exists with your username", "Register Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnection();
        }
        public SQLiteDataReader Login(string Username, string Password, string tbl_name = "tbl_users")
        {
            OpenConnection();
            cmd = new SQLiteCommand($"SELECT * FROM {tbl_name} WHERE Username = '{Username}' and Password = '{Password}';", con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
