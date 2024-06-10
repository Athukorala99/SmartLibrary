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

namespace smartlibrary
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        MySqlDataAdapter da;
        MySqlCommand cmd;
        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUName.Clear();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                cmd = new MySqlCommand("SELECT * FROM mem_login WHERE uname = '" + txtUName.Text + "' AND password = '" + txtPassword.Text + "'", MainClass.con);
                da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    MainClass.con.Close();
                    Main fmain = new Main();
                    fmain.Show();
                    this.Hide();
                }
                else
                {
                    guna2MessageDialog1.Show("Invalid Username or Password");
                    return;
                }

               
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Error in ligin process" + ex);
                return;
            }
            finally
            {
                MainClass.con.Close();
            }
        }
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked == false)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}