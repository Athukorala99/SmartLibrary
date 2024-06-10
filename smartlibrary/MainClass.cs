using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using MySql.Data.MySqlClient;

namespace smartlibrary
{
    class MainClass
    {
        public static readonly string con_string = "server=127.0.0.1;user=root;database=librarysystem;password=";
        public static MySqlConnection con = new MySqlConnection(con_string);

        public static void BlurBackground(Form Model)
        {
            Form Backgroung = new Form();
            using (Model)
            {
                Backgroung.StartPosition = FormStartPosition.Manual;
                Backgroung.FormBorderStyle = FormBorderStyle.None;
                Backgroung.Opacity = 0.5d;
                Backgroung.BackColor = Color.Black;
                Backgroung.Size = Main.Instance.Size;
                Backgroung.Location = Main.Instance.Location;
                Backgroung.ShowInTaskbar = false;
                Backgroung.Show();
                Model.Owner = Backgroung;
                Model.ShowDialog(Backgroung);
                Backgroung.Dispose();
            }
        }
        public static int SQl(string qry, Hashtable ht)
        {
            int res = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }
                res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
            return res;
        }
        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {
            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);
            try
            {
                MySqlCommand cmd = new MySqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string ColNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[ColNam1].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }
        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }
        public static void CBFill(string qry, ComboBox cb)
        {
            MySqlCommand cmd = new MySqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }
    }
}
