using smartlibrary.Insert;
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

namespace smartlibrary.view
{
    public partial class BookView : Form
    {
        public BookView()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new BookInsert());
            GetData();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new BookInsert());
            GetData();
        }

        private void BookView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            string qry = "Select * From book where bid like '%" + txtSearch.Text + "%'    ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvpic);
            lb.Items.Add(dgvname);
            lb.Items.Add(dgvwriter);
            lb.Items.Add(dgvrack);
            lb.Items.Add(dgvcategory);
            lb.Items.Add(dgvdis);
            lb.Items.Add(dgvstatus);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")//Update
            {

                BookInsert frm = new BookInsert();
                String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                frm.txtBookID.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtBookName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvname"].Value);
                frm.txtWriter.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvwriter"].Value);
                frm.txtDescription.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvdis"].Value);
                frm.cmbCategory.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvrack"].Value);
                Byte[] img = (Byte[])guna2DataGridView1.CurrentRow.Cells["dgvpic"].Value;

                MemoryStream ms = new MemoryStream(img);
                frm.imgbook.Image = Image.FromStream(ms);

                string qry = "Delete From book where bid = '" + id1 + "' ";
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
                    String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete From book where bid = '" + id1 + "' ";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Detete Successfull");
                    GetData();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
