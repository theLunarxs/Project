using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project
{
    public static class Database
    {
        private static SQLiteConnection con;
        private static SQLiteCommand cmd;
        private static SQLiteDataReader reader;
        private static string LoginUserName;
        private static DateTime LoginTime;
        static Database()
        {
            con = new SQLiteConnection("Data Source = db_users.sqlite3");
            if (!File.Exists("./db_users.sqlite3"))
            {
                SQLiteConnection.CreateFile("db_users.sqlite3");
                OpenConnection();
                new SQLiteCommand("CREATE TABLE tbl_users (UserID INT PRIMARY KEY, Fname varchar(32),Lname varchar(32),Username varchar(32) NOT NULL,Password varchar(32) NOT NULL,Role VARCHAR(32) NOT NULL,PayM int(12),HrsM int(12), HrsW int(12));"
                    + "INSERT INTO tbl_users (Username, Password, Role) ValUES('admin', 'admin', 'admin');", con).ExecuteNonQuery();
                CloseConnection();

            }
        }
        static void OpenConnection() { if (con.State != System.Data.ConnectionState.Open) con.Open(); }
        static void CloseConnection() { if (con.State != System.Data.ConnectionState.Closed) con.Close(); }

        public static void Register(string Fname, string Lname, string Username, string Password, string Role = "user", int PayM = 0, int HrsM = 0, string tbl_name = "tbl_users", int HrsW = 0)
        {
            OpenConnection();
            reader = new SQLiteCommand($"SELECT * FROM {tbl_name} WHERE Username = '{Username}';", con).ExecuteReader();
            if (!reader.Read())
            {
                cmd = new SQLiteCommand($"INSERT INTO {tbl_name} (Fname, Lname, Username, Password, Role, PayM, HrsM, HrsW) VALUES(@Fname, @Lname, @Username, @Password, @Role, @PayM, @HrsM, @HrsW);", con);
                cmd.Parameters.AddWithValue("@Fname", Fname);
                cmd.Parameters.AddWithValue("@Lname", Lname);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Role", Role);
                cmd.Parameters.AddWithValue("@PayM", PayM);
                cmd.Parameters.AddWithValue("@HrsM", HrsM);
                cmd.Parameters.AddWithValue("@HrsW", HrsW);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Register Successfull", "You may now Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("A User Already Exists with your username", "Register Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnection();
        }
        public static string Login(string Username, string Password, string tbl_name = "tbl_users")
        {
            OpenConnection();
            reader = new SQLiteCommand($"SELECT * FROM {tbl_name} WHERE Username = '{Username}' and Password = '{Password}';", con).ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                cmd = new SQLiteCommand($"SELECT Role From {tbl_name} WHERE Username = '{Username}' and Password = '{Password}';", con);
                string role = cmd.ExecuteScalar().ToString();
                CloseConnection();
                LoginUserName = Username;
                LoginTime = DateTime.Now;
                return role == "admin" ? "admin" : "user";
                
            }
            else
            {
                reader.Close();
                CloseConnection();
                return "";
            }
        }

        public static void SetWorkTime(DateTime LogoutTime)
        {
            int HoursWorked = Convert.ToInt32(LogoutTime.Subtract(LogoutTime).TotalHours);
            OpenConnection();
            new SQLiteCommand($"UPDATE tbl_users SET HrsW = HrsW + {HoursWorked} WHERE Username = '{LoginUserName}';", con).ExecuteNonQuery();
            CloseConnection();
        }

        public static void RemoveUser(string Username, string tbl_name = "tbl_users")
        {

            OpenConnection();
            try
            {
                new SQLiteCommand($"DELETE FROM {tbl_name} WHERE Username = '{Username}';", con).ExecuteNonQuery();
                MessageBox.Show($"User {Username} Deleted From Databse Successfully", "Delete Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show($"Username {Username} Not found, Please re-Enter Username", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnection();
        }

        public static void EditUser(string Username, string columnName, object nValue, string tbl_name = "tbl_users")
        {
            OpenConnection();
            var type = Type.GetTypeCode(nValue.GetType());
            try
            {
                switch (type)
                {
                    case TypeCode.Int32:
                        {
                           new SQLiteCommand($"UPDATE {tbl_name} SET {columnName} = {nValue} WHERE Username = '{Username}';", con).ExecuteNonQuery();
                            break;
                        }
                    case TypeCode.String:
                        {
                            new SQLiteCommand($"UPDATE {tbl_name} SET {columnName} = '{nValue}' WHERE Username = '{Username}';", con).ExecuteNonQuery();
                            break;
                        }
                }
                MessageBox.Show($"{columnName} of {Username} changed to {nValue}", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Not Found \nPlease Enter Username Correctly", "Username not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnection();
        }
        public struct UserInfo
        {
            public string Firstname;
            public string Lastname;
            public string Username;
            public string Role;
            public string PayM;
            public string HrsM;
            public string HrsW;
        }
        public static UserInfo GetUserData(string Username)
        {
            UserInfo myUser = new UserInfo();
            OpenConnection();
            reader = new SQLiteCommand($"SELECT Fname, Lname, Username, Role, PayM, HrsM, HrsW FROM tbl_users WHERE Username ='{Username}';", con).ExecuteReader();
            if(reader.Read())
            {
                myUser.Firstname = reader["Fname"].ToString();
                myUser.Lastname = reader["Lname"].ToString();
                myUser.Username = reader["Username"].ToString();
                myUser.Role = reader["Role"].ToString();
                myUser.PayM = reader["PayM"].ToString();
                myUser.HrsM = reader["HrsM"].ToString();
                myUser.HrsW = reader["HrsW"].ToString();
            }
            CloseConnection();
            return myUser;
        }
    }
}
