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
    public partial class DataPemasok : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        void Levelmuncul()
        {
            comboBox1.Items.Add("Bintang 1");
            comboBox1.Items.Add("Bintang 2");
            comboBox1.Items.Add("Bintang 3");
            comboBox1.Items.Add("Bintang 4");
            comboBox1.Items.Add("Bintang 5");
            comboBox1.Items.Add("Bintang 6");
        }
        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";

            Levelmuncul();
            munculdatapemasok();
        }

        void Kondisireset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            munculdatapemasok();
        }

        void menuterkunci()
        {
            textBox1.Enabled = false;
        }
        void cari()
        {
            MySqlConnection conn = konn.GetConn();
            try
            {

                conn.Open();
                cmd = new MySqlCommand("select * from tabel_pemasok where id_pemasok LIKE '%" + textBox5.Text + "%' or pemasok LIKE '%" + textBox5.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "tabel_pemasok");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tabel_pemasok";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
        }
        void munculdatapemasok()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT `id_pemasok` as 'Pemasok Id', `pemasok` as 'Nama Pemasok', `alamat` as 'Alamat', `no_hp` as 'No HP', `tanggal` as 'Tanggal', `level_pemasok` as 'Level Pemasok'   FROM tabel_pemasok;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "tabel_pemasok");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tabel_pemasok";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }
        void nootomatis()
        {
            long hitung;
            string urutan;
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select id_pemasok from tabel_pemasok where id_pemasok in(select max(id_pemasok) from tabel_pemasok) order by id_pemasok desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["id_pemasok"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urutan = "PMS" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "PMS001";
            }
            rd.Close();
            textBox1.Text = urutan;
            conn.Close();


        }

        public DataPemasok()
        {
            InitializeComponent();
        }

        private void DataPemasok_Load(object sender, EventArgs e)
        {
            KondisiAwal();
            menuterkunci();
            nootomatis();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();
                //string sDate = tanggal.SelectionStart.ToString("yyyy\\/MM\\/dd");
                cmd = new MySqlCommand("insert into tabel_pemasok values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambah");
                Kondisireset();
                nootomatis();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MySqlConnection conn = konn.GetConn();
                cmd = new MySqlCommand("select * from tabel_pemasok where id_pemasok='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    textBox4.Text = rd[3].ToString();
                    comboBox1.Text = rd[4].ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ada");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("Update tabel_pemasok set pemasok='" + textBox2.Text + "',alamat='" + textBox3.Text + "',no_hp='" + textBox4.Text + "',level_pemasok='" + comboBox1.Text + "' where id_pemasok='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Ganti");
                Kondisireset();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA INI :" + textBox2.Text + "??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = konn.GetConn();

                    cmd = new MySqlCommand("DELETE from tabel_pemasok where id_pemasok='" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di Hapus");
                    Kondisireset();
                    nootomatis();
                }
            }
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id_pemasok"].Value.ToString();
                textBox2.Text = row.Cells["pemasok"].Value.ToString();
                textBox3.Text = row.Cells["alamat"].Value.ToString();
                textBox4.Text = row.Cells["no_hp"].Value.ToString();

                comboBox1.Text = row.Cells["level_pemasok"].Value.ToString();

            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataPemasok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
