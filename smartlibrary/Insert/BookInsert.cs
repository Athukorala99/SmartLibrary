using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartlibrary.Insert
{
    public partial class BookInsert : Form
    {
        public BookInsert()
        {
            InitializeComponent();
        }
        public int rID = 0;
        public int id = 0;

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookID.Clear();
            txtBookName.Clear();
            txtWriter.Clear();
        }

        private void BookInsert_Load(object sender, EventArgs e)
        {
            string qry1 = "Select rackno name from rack";
            MainClass.CBFill(qry1, cmbCategory);
            if (rID > 0)
            {
                cmbCategory.SelectedValue = rID;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = MainClass.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            lblCategory.Text = "Category";
            try
            {
                MainClass.con.Open();
                String qry = "Select * From rack where rackno = '" + cmbCategory.Text + "'";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(qry, MainClass.con);
                da.Fill(dt);
                da.SelectCommand.ExecuteNonQuery();

                foreach (DataRow dr in dt.Rows)
                {
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Image temp = new Bitmap(imgbook.Image);
            //MemoryStream ms = new MemoryStream();
            //temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //byte[] imageByteArray = ms.ToArray();
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //string imagePath = openFileDialog.FileName;



            //byte[] imagebyte;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //imgbook.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //imagebyte = ms.ToArray();
            //}
            MemoryStream ms = new MemoryStream();
            imgbook.Image.Save(ms, imgbook.Image.RawFormat);
            byte[] img = ms.ToArray();

                string status = "Available";

            string qry = "INSERT INTO book (bid,bpic,bname,writer,rack,category,discription,status) VALUES (@id,@img,@name,@writer,@rack,@cat,@dis,@status)";
            MySqlCommand cmd = new MySqlCommand(qry, MainClass.con);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = txtBookID.Text;
            cmd.Parameters.Add("@img", MySqlDbType.Blob).Value = img;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = txtBookName.Text;
            cmd.Parameters.Add("@writer", MySqlDbType.VarChar).Value = txtWriter.Text;
            cmd.Parameters.Add("@rack", MySqlDbType.VarChar).Value = cmbCategory.Text;
            cmd.Parameters.Add("@cat", MySqlDbType.VarChar).Value = lblCategory.Text;
            cmd.Parameters.Add("@dis", MySqlDbType.VarChar).Value = txtDescription.Text;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

            ExecMyQuery(cmd, "Data Insert Successfully");
            /*try
            {
                MainClass.con.Open();
                string qry = "INSERT INTO book (bid,bpic,bname,writer,rack,category,discription,status) Values('" + txtBookID.Text + "','"+ img + "','" + txtBookName.Text + "','" + txtWriter.Text + "','" + cmbCategory.Text + "','" + lblCategory.Text + "','"+txtDescription.Text+"','" + status + "')";
                MySqlDataAdapter sda = new MySqlDataAdapter(qry, MainClass.con);
                sda.SelectCommand.ExecuteNonQuery();
                guna2MessageDialog1.Show("Registation Successfully");
                return;
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Error in insert book" + ex);
            }
            finally
            {
                MainClass.con.Close();
            }*/

        }

        public void ExecMyQuery(MySqlCommand mcomd,string mymsg)
        {
            MainClass.con.Open();
            if(mcomd.ExecuteNonQuery() == 1)
            {
                guna2MessageDialog1.Show(mymsg);
            }
            else
            {
                guna2MessageDialog1.Show("Query not Executed");
            }
            MainClass.con.Close();
        }

        string filepath;
        Byte[] imageByteArray;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                imgbook.Image = new Bitmap(filepath);
                
            }
        }
    }
}
