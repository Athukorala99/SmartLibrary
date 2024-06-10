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
    public partial class Studentview : Form
    {
        public Studentview()
        {
            InitializeComponent();
        }
        public int id = 0;
        public void GetData()
        {
            string qry = "Select * From user_form where regno like '%" + txtSearch.Text + "%'    ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvstunum);
            lb.Items.Add(dgvname);
            lb.Items.Add(dgvclass);
            lb.Items.Add(dgvgender);
            lb.Items.Add(dgvcontact);
            lb.Items.Add(dgvemail);
            lb.Items.Add(dgvpass);
            lb.Items.Add(dgvimage);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }
        private void Studentview_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new StudentInsert());
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new StudentInsert());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")//Update
            {

                StudentInsert frm = new StudentInsert();
                String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvstunum"].Value);

                frm.txtStuNo.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvstunum"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvname"].Value);
                frm.txtClass.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvclass"].Value);
                frm.txtContact.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvcontact"].Value);
                frm.txtEmail.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvemail"].Value);

                if((guna2DataGridView1.CurrentRow.Cells["dgvgender"].Value).ToString() == "Male")
                {
                    frm.rbMale.Checked = true;
                }
                else if ((guna2DataGridView1.CurrentRow.Cells["dgvgender"].Value).ToString() == "Female")
                {
                    frm.rbFemale.Checked = true;
                }


                string qry = "Delete From user_form where regno = '" + id1 + "' ";
                Hashtable ht = new Hashtable();
                MainClass.SQl(qry, ht);
                MainClass.BlurBackground(frm);
                GetData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")//Delete
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvstunum"].Value);
                    string qry = "Delete From user_form where regno = '" + id1 + "' ";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Detete Successfull");
                    GetData();
                }
            }
        }
    }
}
