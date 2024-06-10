using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace smartlibrary
{
    class DBConnection
    {
       // public string con_string = "server=127.0.0.1;user=root;database=librarysystem;password=";
        public MySqlConnection con = new MySqlConnection("server=127.0.0.1;user=root;database=librarysystem;password=");

        public MySqlConnection getConnection() {
            return con;
        }



    }
}
