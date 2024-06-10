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
    public partial class BorrowInsert : Form
    {
        public BorrowInsert()
        {
            InitializeComponent();
        }
        /*DateTime datetime = DateTime.Now;
        txtBookID.Text = datetime.ToString("dd/MM/yyyy");*/
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbId.Clear();
            txtStuNo.Clear();
            lblsName.Text = "Name";
            lblEmail.Text = "E-Mail";
            lblContact.Text = "Contact No.";
            lblCategory.Text = "Category";
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sta = "Borrowed";
            DateTime datetime = DateTime.Now;
            string dat = datetime.ToString("yyyy , MM , dd");
            try
            {
                MainClass.con.Open();
                string qry = "INSERT INTO borrow (sregno,bid,bname,email,contact,category,date) Values('" + txtStuNo.Text + "','" + txtbId.Text + "','" + lblBookName.Text + "','" + lblEmail.Text + "','" + lblContact.Text + "','" + lblCategory.Text + "','" + dat + "')";
                MySqlDataAdapter sda = new MySqlDataAdapter(qry, MainClass.con);
                sda.SelectCommand.ExecuteNonQuery();

                string qry1 = "UPDATE book set status = '" + sta + "' WHERE bid = '" + txtbId.Text + "' ";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(qry1, MainClass.con);
                sda1.SelectCommand.ExecuteNonQuery();

                guna2MessageDialog1.Show("Registation Successfully");
                return;
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Error in registering" + ex);
            }
            finally
            {
                MainClass.con.Close();
            }
            //
            
            try
            {
                MainClass.con.Open();
                string qry1 = "UPDATE book set status = '"+sta+"' WHERE bid = '"+txtbId.Text+"' ";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(qry1, MainClass.con);
                sda1.SelectCommand.ExecuteNonQuery();
                guna2MessageDialog1.Show(" Successfully");
                return;
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Error in registering" + ex);
            }
            finally
            {
                MainClass.con.Close();
            }
        }

        private void txtStuNo_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = MainClass.con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            try
            {
                MainClass.con.Open();
                String qry = "Select * From user_form where regno = '" + txtStuNo.Text + "'";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(qry, MainClass.con);
                da.Fill(dt);
                da.SelectCommand.ExecuteNonQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    lblsName.Text = dr["name"].ToString();
                    lblContact.Text = dr["contact"].ToString();
                    lblEmail.Text = dr["email"].ToString();
                }

                return;
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Error insert data" + ex);
            }
            finally
            {
                MainClass.con.Close();
            }
        }

        private void txtbId_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = MainClass.con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            try
            {
                MainClass.con.Open();
                String qry = "Select * From book where bid = '" + txtbId.Text + "'";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(qry, MainClass.con);
                da.Fill(dt);
                da.SelectCommand.ExecuteNonQuery();

                foreach (DataRow dr in dt.Rows)
                {
                    lblBookName.Text = dr["bname"].ToString();
                    lblCategory.Text = dr["category"].ToString();
                }

                return;
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Error insert data" + ex);
            }
            finally
            {
                MainClass.con.Close();
            }
        }
    }
}
