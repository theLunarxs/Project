using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Project
{
    public class Database
    {
        public Database()
        {
            SQLiteConnection con = new SQLiteConnection("Data Source = db_users.sqlite3");
            if(!File.Exists("./db_users.sqlite3"))
            {
                SQLiteConnection.CreateFile("db_users.sqlite3");

            }
        }

    }
}
