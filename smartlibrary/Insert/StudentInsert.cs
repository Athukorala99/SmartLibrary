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
    public partial class StudentInsert : Form
    {
        public StudentInsert()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStuNo.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            txtClass.Clear();
            rbMale.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string pass = "123";
            if (rbFemale.Checked)
            {
                try
                {
                    
                    MainClass.con.Open();

                    string qry = "INSERT INTO user_form (regno,name,class,gender,contact,email,password) VALUES ('" + txtStuNo.Text + "','" + txtName.Text + "','" + txtClass.Text + "','" + rbFemale.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "', '"+pass+"')";
                    MySqlDataAdapter sda = new MySqlDataAdapter(qry, MainClass.con);
                    sda.SelectCommand.ExecuteNonQuery();

                    /*string qry1 = "INSERT INTO user_form (name,email,password) VALUES ('" + txtName.Text+"','"+txtEmail.Text+"', '"+ pass +"' )";
                    MySqlDataAdapter sda1 = new MySqlDataAdapter(qry1, MainClass.con);
                    sda1.SelectCommand.ExecuteNonQuery();*/

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
            }
            if (rbMale.Checked)
            {
                try
                {
                    MainClass.con.Open();
                    string qry = "INSERT INTO user_form (regno,name,class,gender,contact,email,password) VALUES ('" + txtStuNo.Text + "','" + txtName.Text + "','" + txtClass.Text + "','" + rbMale.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "', '"+pass+"')";
                    MySqlDataAdapter sda = new MySqlDataAdapter(qry, MainClass.con);
                    sda.SelectCommand.ExecuteNonQuery();
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
            }
            txtStuNo.Clear();
            txtName.Clear();
            txtClass.Clear();
            rbMale.Checked = true;
            txtEmail.Clear();
            txtContact.Clear();
        }
    }
}
