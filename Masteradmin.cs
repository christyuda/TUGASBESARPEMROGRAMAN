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

namespace AplikasiGudang
{
    
    public partial class Masteradmin : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        
        void Levelmuncul()
        {
            comboBox1.Items.Add("Staff");
            comboBox1.Items.Add("Kasir");
        }
        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";

            Levelmuncul();
            munculdataadmin();
          
        }
        void Kondisireset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            nootomatis();
            munculdataadmin();
        }
        
        
        void munculdataadmin()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT id_admin AS 'KODE ADMIN', username  AS 'USERNAME ADMIN', password AS 'PASSWORD ADMIN', Tanggal  AS 'TANGGAL DAFTAR', level_admin  AS 'LEVEL ADMIN' FROM tabel_admin;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            
            da.Fill(ds, "tabel_admin");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tabel_admin";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
            
            

            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }
        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        void cari()
        {
            MySqlConnection conn = konn.GetConn();
            try
            {
                
                conn.Open();
                cmd = new MySqlCommand("select * from tabel_admin where id_admin LIKE '%" + textBox4.Text + "%' or username LIKE '%" + textBox4.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                
                da.Fill(ds, "tabel_admin");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tabel_admin";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
        }
        void nootomatis()
        {
            long hitung;
            string urutan;
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select id_admin from tabel_admin where id_admin in(select max(id_admin) from tabel_admin) order by id_admin desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["id_admin"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urutan = "USR" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "USR001";
            }
            rd.Close();
            textBox1.Text = urutan;
            conn.Close();


        }

        void idterkunci()
        {
            textBox1.Enabled = false;
        }
        public Masteradmin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //RefreshDataset();
            this.Close();
        }

        private void Masteradmin_Load(object sender, EventArgs e)
        {
            KondisiAwal();
            idterkunci();
            nootomatis();
    
            textBox3.PasswordChar = 'X';


        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
               MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
               MySqlConnection conn = konn.GetConn();
                //string sDate = tanggal.SelectionStart.ToString("yyyy\\/MM\\/dd");
                cmd = new MySqlCommand("insert into tabel_admin values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + comboBox1.Text + "')", conn);
               conn.Open();
               cmd.ExecuteNonQuery();
               MessageBox.Show("Data berhasil ditambah");
               Kondisireset();
               nootomatis();
            }

           
        }

        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == Convert.ToChar(Keys.Enter))
        //    {
        //        MySqlConnection conn = konn.GetConn();
        //        cmd = new MySqlCommand("select * from tabel_admin where id_admin='"+ textBox1.Text +"'", conn);
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        rd = cmd.ExecuteReader();
        //        if (rd.Read())
        //        {
        //            textBox1.Text = rd[0].ToString();
        //            textBox2.Text = rd[1].ToString();
        //            textBox3.Text = rd[2].ToString();
        //            comboBox1.Text = rd[3].ToString();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Data tidak ada");
        //        }
                
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("Update tabel_admin set username='" + textBox2.Text + "',password='" + textBox3.Text + "',level_admin='" + comboBox1.Text + "' where id_admin='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Ganti");
                Kondisireset();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA INI :" +textBox2.Text +"??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = konn.GetConn();

                    cmd = new MySqlCommand("DELETE from tabel_admin where id_admin='" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di Hapus");
                    Kondisireset();
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id_admin"].Value.ToString();
                textBox2.Text = row.Cells["username"].Value.ToString();
                textBox3.Text = row.Cells["password"].Value.ToString();
                
                comboBox1.Text = row.Cells["level_admin"].Value.ToString();

            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kondisireset();
            nootomatis();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cari();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tanggal_DateSelected(object sender, DateRangeEventArgs e)
        {

        }
    }
}
