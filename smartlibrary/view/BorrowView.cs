using MySql.Data.MySqlClient;
using smartlibrary.Insert;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartlibrary.view
{
    public partial class BorrowView : Form
    {
        public BorrowView()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new BorrowInsert());
            GetData();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new BorrowInsert());
            GetData();
        }

        private void BorrowView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            string qry = "Select * From borrow where bid like '%" + txtSearch.Text + "%'    ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvstuno);
            lb.Items.Add(dgvbookid);
            lb.Items.Add(dgvbname);
            lb.Items.Add(dgvemail);
            lb.Items.Add(dgvContact);
            lb.Items.Add(dgvcategory);
            lb.Items.Add(dgvdate);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvreturn")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Are you sure you want to return?") == DialogResult.Yes)
                {
                    string status = "Available";

                    try
                    {
                        MainClass.con.Open();
                        
                        String id3 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvbookid"].Value);
                        string qry3 = "UPDATE book set status = '" + status + "' WHERE bid = '" + id3 + "' ";
                        MySqlDataAdapter sda3 = new MySqlDataAdapter(qry3, MainClass.con);
                        sda3.SelectCommand.ExecuteNonQuery();


                        /*String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                        string qry2 = "Delete From borrow where id = '" + id1 + "' ";
                        MySqlDataAdapter sda2 = new MySqlDataAdapter(qry2, MainClass.con);*/
                        

                        //guna2MessageDialog1.Show("Return Successfully");

                        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                        guna2MessageDialog1.Show("Return Successfull");
                        GetData();


                        ReturndDetails frm = new ReturndDetails();
                        
                        frm.lblBookID.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvbookid"].Value);
                        frm.lblStuNo.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvstuno"].Value);
                        frm.lblBorrowDate.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvdate"].Value);

                        //sda2.SelectCommand.ExecuteNonQuery();

                        MainClass.BlurBackground(frm);
                        GetData();

                        

                        return;
                    }
                    catch (Exception ex)
                    {
                        guna2MessageDialog1.Show("Error in return" + ex);
                    }
                    finally
                    {
                        MainClass.con.Close();
                    }
                }
            }
        }
        private void btnWornning_Click(object sender, EventArgs e)
        {
            MainClass.con.Open();

            string qry5 = "DELETE FROM warning";
            MySqlDataAdapter sda5 = new MySqlDataAdapter(qry5, MainClass.con);
            sda5.SelectCommand.ExecuteNonQuery();

            string qry = "SELECT Count(*)  FROM borrow";
            
            MySqlCommand cmdb = new MySqlCommand(qry, MainClass.con);
            var countb = cmdb.ExecuteScalar();
            string countlist = countb.ToString();
            int cnt = Convert.ToInt32(countlist);
           
            for(int x = 1; x <= cnt ; x++)
            {
                string qry2 = "SELECT * FROM (SELECT id,ROW_NUMBER() OVER(ORDER BY id) AS ROWNUM FROM borrow) AS SubQueryAlias WHERE ROWNUM = '"+x+"'";
                MySqlCommand cmdbt = new MySqlCommand(qry2, MainClass.con);
                var countbt = cmdbt.ExecuteScalar(); ;
                string countid = countbt.ToString();
                //guna2MessageDialog1.Show(countid);

                string qry3 = "SELECT * FROM borrow WHERE id = '"+countid+"'";
                MySqlCommand cmdnn = new MySqlCommand(qry3, MainClass.con);
                MySqlDataReader dr = cmdnn.ExecuteReader();
                dr.Read();
                string datenn = dr["date"].ToString();
                //guna2MessageDialog1.Show(datenn);
                dr.Close();
                
                DateTime datetime = DateTime.Now;
                string dat = datetime.ToString("yyyy , MM , dd");
                DateTime stdate = Convert.ToDateTime(dat);

                DateTime enddate = Convert.ToDateTime(datenn);
                
                //string enddatetable = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvdate"].Value);
                //DateTime enddate = Convert.ToDateTime(enddatetable);

                TimeSpan duration = stdate - enddate;
                double dif = duration.TotalDays;
                int difint = Convert.ToInt32(dif);
                if (difint > 7)
                {
                    string bookid = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvbookid"].Value);
                    string stuno = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvstuno"].Value);
                    string email = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvemail"].Value);
                    string bookname = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvbname"].Value);
                    string cont = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvContact"].Value);

                    string qry4 = "INSERT INTO warning (stuno,bid,bname,email,contact,bdate,extradate) VALUES ('" + stuno + "','" + bookid + "','" + bookname + "','" + email + "','" + cont + "','" + datenn + "','" + dif + "')";
                    MySqlDataAdapter sda4 = new MySqlDataAdapter(qry4, MainClass.con);
                    sda4.SelectCommand.ExecuteNonQuery();
                }
            }
            MainClass.BlurBackground(new warningview());
            GetData();
            MainClass.con.Close();
        }
    }
}
