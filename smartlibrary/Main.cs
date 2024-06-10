using smartlibrary.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartlibrary
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        static Main _obj;
        public static Main Instance
        {
            get { if (_obj == null) { _obj = new Main(); } return _obj; }
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AddControls(new Dashboaed());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            AddControls(new Dashboaed());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AddControls(new Studentview());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            AddControls(new Rackview());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddControls(new BookView());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddControls(new BorrowView());
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Login flog = new Login();
            flog.Show();
            this.Hide();
        }

        private void CenterPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
