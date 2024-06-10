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

namespace smartlibrary.Insert
{
    public partial class RackInsert : Form
    {
        public RackInsert()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)//Insert
            {
                qry = "INSERT INTO rack (rackno,category) Values('" + txtRackNo.Text + "','" + txtCatName.Text + "')";
            }
            else//Update
            {
                qry = "Update rack Set category = (@Name where rackno = @id)";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", txtRackNo.Text);
            ht.Add("@Name", txtCatName.Text);

            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Saved Successfully...");
                id = 0;
                txtCatName.Text = "";
                txtRackNo.Text = "";
                txtRackNo.Focus();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RackInsert_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCatName.Clear();
            txtRackNo.Clear();
        }
    }
}
