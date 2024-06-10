using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartlibrary.Insert
{
    public partial class ReturndDetails : Form
    {
        public ReturndDetails()
        {
            InitializeComponent();
        }

        private void ReturndDetails_Load(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            string dat = datetime.ToString("yyyy , MM , dd");
            lblReturnDate.Text = dat.ToString();
            DateTime stdate = Convert.ToDateTime(lblReturnDate.Text);

            DateTime enddate = Convert.ToDateTime(lblBorrowDate.Text);
            //DateTime stdate = new DateTime(2024 , 03 , 22);
            //DateTime enddate = new DateTime(2024 , 05 , 10);
            TimeSpan duration = stdate - enddate;
            double dif = duration.TotalDays;

            lblDifferent.Text = dif.ToString();

            if(dif > 7)
            {
                double difex = dif - 7;
                double pay = difex * 20;
                lblPayment.Text = "Rs: "+pay.ToString();
                
            }
            else
            {
                lblPayment.Text = "Rs: 0";
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MainClass.con.Close();
            MainClass.con.Open();
            String id1 = lblBookID.Text;
            string qry2 = "Delete From borrow where bid = '" + id1 + "' ";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(qry2, MainClass.con);
            sda2.SelectCommand.ExecuteNonQuery();
            MainClass.con.Close();

            guna2MessageDialog1.Show("Payment & Save Successfully");
            this.Close();
        }

        private void lblReturnDate_Click(object sender, EventArgs e)
        {

        }
    }
}
