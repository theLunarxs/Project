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
        // SQlite Connection To Connect to DB
        private static SQLiteConnection con;
        // SQLite Command to Run Queries
        private static SQLiteCommand cmd;
        // SQlite Reader to Read Data from DB
        private static SQLiteDataReader reader;
        // LoginUsername to show in admin panel and User panel
        public static string LoginUserName;
        // LoginTime to Record and Subtract from LoginTime
        private static DateTime LoginTime;
        static Database()
        {
            con = new SQLiteConnection("Data Source = db_users.sqlite3");
            // Checks If DB file has Already been created If not: Makes it and Adds admin to it
            if (!File.Exists("./db_users.sqlite3"))
            {
                SQLiteConnection.CreateFile("db_users.sqlite3");
                OpenConnection();
                new SQLiteCommand("CREATE TABLE tbl_users (UserID INT PRIMARY KEY, Fname varchar(32),Lname varchar(32),Username varchar(32) NOT NULL,Password varchar(32) NOT NULL,Role VARCHAR(32) NOT NULL,PayM int(12),HrsM int(12), HrsW int(12));"
                    + "INSERT INTO tbl_users (Username, Password, Role) ValUES('admin', 'admin', 'admin');", con).ExecuteNonQuery();
                CloseConnection();
            }
        }
        // 2 functions to Begin and End Communication with DB
        static void OpenConnection() { if (con.State != System.Data.ConnectionState.Open) con.Open();}
        static void CloseConnection() { if (con.State != System.Data.ConnectionState.Closed) con.Close(); if (!reader.IsClosed) reader.Close(); }

        public static void Register(string Fname, string Lname, string Username, string Password, string Role = "user", int PayM = 0, int HrsM = 0, string tbl_name = "tbl_users", int HrsW = 0)
        {
            OpenConnection();
            // Checks if The Username is taken
            try
            {
                reader = new SQLiteCommand($"SELECT * FROM {tbl_name} WHERE Username = '{Username}';", con).ExecuteReader();
                // IF Username Is NOT Taken then adds a user with the following Information:
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
                // If a User Already exists Then It will tell the user
                else
                {
                    MessageBox.Show("A User Already Exists with your username", "Register Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Catches errors and Displays Error Message Details.
            catch (Exception e)
            {
                MessageBox.Show($"DB error \n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnection();
        }
        public static string Login(string Username, string Password, string tbl_name = "tbl_users")
        {
            OpenConnection();

            // Searches DB for Entered Username and Passsowrd.
            reader = new SQLiteCommand($"SELECT * FROM {tbl_name} WHERE Username = '{Username}' and Password = '{Password}';", con).ExecuteReader();
            if (reader.Read())
            {
                // Closes the reader to avoid "DataBase Is locked" Error.
                reader.Close();
                // Fetches Role to determine which form the program should show the user based on their Role
                string role = new SQLiteCommand($"SELECT Role From {tbl_name} WHERE Username = '{Username}' and Password = '{Password}';", con).ExecuteScalar().ToString();
                CloseConnection();
                // Sets the Username to 1- Show in Panel 2- Set the workTime to that specific username (check SetWorkTime() )
                LoginUserName = Username;
                // Starts Login time to Determine Working Hours
                LoginTime = DateTime.Now;
                return role == "admin" ? "admin" : "user";
            }
            else
            {
                CloseConnection();
                return " ";
            }
        }
        //Calculates Work Time by LogoutTime - LoginTime and Converts it to Hours(Int) and sends it to DB
        public static void SetWorkTime(DateTime LogoutTime)
        {
            //Calculates Work Time by LogoutTime - LoginTime and Converts it to Hours(Int)
            int HoursWorked = Convert.ToInt32(LogoutTime.Subtract(LogoutTime).TotalHours);
            // Sending to DB
            OpenConnection();
            new SQLiteCommand($"UPDATE tbl_users SET HrsW = HrsW + {HoursWorked} WHERE Username = '{LoginUserName}';", con).ExecuteNonQuery(); // Detects Current HoursWorked and adds to it
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
            catch (Exception e)
            {
                MessageBox.Show($"Username {Username} Not found, Please re-Enter Username\nError Details:{e.Message}", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnection();
        }
        // Edits UserData based On Given Information
        public static void EditUser(string Username, string columnName, object nValue, string tbl_name = "tbl_users")
        {
            //Takes nValue as Object Because I don't know Whether It's going to be an Int or a String
            OpenConnection();
            //Determines the Type of nValue ( new Value) that was Passed to Function and decides based on it
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
                // Succession MessageBox.
                MessageBox.Show($"{columnName} of {Username} changed to {nValue}", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                // Failure MessageBox.
                MessageBox.Show($"Error \nPlease Enter Username Or Value Correctly \n{e.Message}", "Username not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnection();
        }
        // Define a Struct with same variables as DB Columns to store Users in it.
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
        
        public static UserInfo GetUserData(string Username) // Returns a Brief of UserData Based on Given Username.
        {
            UserInfo myUser = new UserInfo();
            OpenConnection();
            try
            {
                reader = new SQLiteCommand($"SELECT Fname, Lname, Username, Role, PayM, HrsM, HrsW FROM tbl_users WHERE Username ='{Username}';", con).ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show($"DB error\nError Details :{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (reader.Read())
            {
                // puts Each Data from Query Result in the right struct Variable.
                myUser.Firstname = reader["Fname"].ToString().Trim();
                myUser.Lastname = reader["Lname"].ToString().Trim();
                myUser.Username = reader["Username"].ToString().Trim();
                myUser.Role = reader["Role"].ToString().Trim();
                myUser.PayM = reader["PayM"].ToString().Trim();
                myUser.HrsM = reader["HrsM"].ToString().Trim();
                myUser.HrsW = reader["HrsW"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Error, User Does not Exist","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseConnection();
            return myUser;
        }
        // Gets UserCount of Company for Dashboard
        public static string GetUserCount(string Role = "user", bool Total = false, string tableName = "tbl_users")
        {
            OpenConnection();
            string x;
            if (!Total)
                x = new SQLiteCommand($"SELECT COUNT(*) FROM {tableName} WHERE Role = '{Role}';", con).ExecuteScalar().ToString();
            else
                x = new SQLiteCommand($"SELECT COUNT(*) FROM {tableName};", con).ExecuteScalar().ToString();
            CloseConnection();
            return x;
        }
    }
}
