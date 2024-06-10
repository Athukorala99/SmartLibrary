using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace smartlibrary.view
{
    public partial class Dashboaed : Form
    {
        //MySqlConnection con = new DBConnection().getConnection();
        public Dashboaed()
        {
            InitializeComponent();
        }

        private void Dashboaed_Load(object sender, EventArgs e)
        {
            //MainClass.con.Close();
             MainClass.con.Open();

           // con.Open();
            string qry = "SELECT Count(*)  FROM user_form";

            MySqlCommand cmdb = new MySqlCommand(qry, MainClass.con);
            var countb = cmdb.ExecuteScalar();
            string countlist = countb.ToString();
            int cnt = Convert.ToInt32(countlist);
            txtReader.Text = cnt.ToString();
            
            MySqlCommand cmdr = new MySqlCommand("Select Count(*) From book", MainClass.con);
            var countr = cmdr.ExecuteScalar();
            txtBooks.Text = countr.ToString();
            
            MySqlCommand cmdw = new MySqlCommand("Select Count(*) From book where status = 'Available' ", MainClass.con);
            var countw = cmdw.ExecuteScalar();
            txtAvailable.Text = countw.ToString();

            MySqlCommand cmdbr = new MySqlCommand("Select Count(*) From book where status = 'Borrowed' ", MainClass.con);
            var countbr = cmdbr.ExecuteScalar();
            txtBorrowed.Text = countbr.ToString();

              MainClass.con.Close();
            //con.Close();
        }
       
    }
}
