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
using System.Net.Mail;
using System.Net;
using System.Web;

namespace smartlibrary.view
{
    public partial class warningview : Form
    {
        public warningview()
        {
            InitializeComponent();
        }

        private void warningview_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            string qry = "Select * From warning";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvstuno);
            lb.Items.Add(dgvbookid);
            lb.Items.Add(dgvbname);
            lb.Items.Add(dgvemail);
            lb.Items.Add(dgvContact);
            lb.Items.Add(dgvdate);
            lb.Items.Add(dgvexdate);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvreturn")//Delete
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Are you sure you send email?") == DialogResult.Yes)
                {
                    String em = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvemail"].Value);
                    String Regno = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvstuno"].Value);
                    String Bidn = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvbookid"].Value);
                    String Bname = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvbname"].Value);
                    String exd = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvexdate"].Value);



                    try
                    {
                        

                        DateTime datetime = DateTime.Now;
                        string to, from, pass, mail;
                        to = em;
                        from = "himanthaathukorala@gmail.com";
                        pass = "ivoifqgtxfboqszf";
                        mail = "Date :" + "\t" + datetime + "\n" + "Student Re. No :" + "\t" + Regno + " \n" + "Book ID :" + "\t" + Bidn + " \n" + "Book Name :" + "\t" + Bname + " \n" + " Exrta Date :" + "\t" + exd;
                        MailMessage msg = new MailMessage();
                        msg.To.Add(to);
                        msg.From = new MailAddress(from);
                        msg.Body = mail;
                        msg.Subject = "Library System";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);

                        try
                        {
                            smtp.Send(msg);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in insert Data" + ex);
                    }
                    


                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Send Successfull");
                    GetData();
                }
            }
        }
    }
}
