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
    public partial class DataPelanggan : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public DataPelanggan()
        {
            InitializeComponent();
        }

        void Levelmuncul()
        {
            cbkelaspelanggan.Items.Add("Bintang 1");
            cbkelaspelanggan.Items.Add("Bintang 2");
            cbkelaspelanggan.Items.Add("Bintang 3");
            cbkelaspelanggan.Items.Add("Bintang 4");
            cbkelaspelanggan.Items.Add("Bintang 5");
            cbkelaspelanggan.Items.Add("Bintang 6");
        }
        void KondisiAwal()
        {
            tbkode.Text = "";
            tbnama.Text = "";
            tbalamat.Text = "";
            tbnohp.Text = "";
            cbkelaspelanggan.Text = "";

            Levelmuncul();
            munculdatapelanggan();
        }

        void Kondisireset()
        {
            tbkode.Text = "";
            tbnama.Text = "";
            tbalamat.Text = "";
            tbnohp.Text = "";
            cbkelaspelanggan.Text = "";
            munculdatapelanggan();
        }

        void menuterkunci()
        {
            tbkode.Enabled = false;
        }
        void cari()
        {
            MySqlConnection conn = konn.GetConn();
            try
            {

                conn.Open();
                cmd = new MySqlCommand("select * from tabel_pelanggan where id_pelanggan LIKE '%" + textBox5.Text + "%' or namapelanggan LIKE '%" + textBox5.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "tabel_pelanggan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tabel_pelanggan";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
        }

        void munculdatapelanggan()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM tabel_pelanggan;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "tabel_pelanggan");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tabel_pelanggan";
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
            cmd = new MySqlCommand("select id_pelanggan from tabel_pelanggan where id_pelanggan in(select max(id_pelanggan) from tabel_pelanggan) order by id_pelanggan desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["id_pelanggan"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urutan = "PLG" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "PLG001";
            }
            rd.Close();
            tbkode.Text = urutan;
            conn.Close();


        }

        private void DataPelanggan_Load(object sender, EventArgs e)
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
            if (tbkode.Text.Trim() == "" || tbnama.Text.Trim() == "" || tbalamat.Text.Trim() == "" || tbnohp.Text.Trim() == "" || cbkelaspelanggan.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();
                //string sDate = tanggal.SelectionStart.ToString("yyyy\\/MM\\/dd");
                cmd = new MySqlCommand("insert into tabel_pelanggan values('" + tbkode.Text + "','" + tbnama.Text + "','" + tbalamat.Text + "','" + tbnohp.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + cbkelaspelanggan.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambah");
                Kondisireset();
                nootomatis();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbkode.Text.Trim() == "" || tbnama.Text.Trim() == "" || tbalamat.Text.Trim() == "" || tbnohp.Text.Trim() == "" || cbkelaspelanggan.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("Update tabel_pelanggan set namapelanggan='" + tbnama.Text + "',alamat='" + tbalamat.Text + "',nohp='" + tbnohp.Text + "',kelaspelanggan='" + cbkelaspelanggan.Text + "' where id_pelanggan='" + tbkode.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Ganti");
                Kondisireset();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cari();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                tbkode.Text = row.Cells["id_pelanggan"].Value.ToString();
                tbnama.Text = row.Cells["namapelanggan"].Value.ToString();
                tbalamat.Text = row.Cells["alamat"].Value.ToString();
                tbnohp.Text = row.Cells["nohp"].Value.ToString();

                cbkelaspelanggan.Text = row.Cells["kelaspelanggan"].Value.ToString();

            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbkode.Text.Trim() == "" || tbnama.Text.Trim() == "" || tbalamat.Text.Trim() == "" || tbnohp.Text.Trim() == "" || cbkelaspelanggan.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA INI :" + tbnama.Text + "??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = konn.GetConn();

                    cmd = new MySqlCommand("DELETE from tabel_pelanggan where id_pelanggan='" + tbkode.Text + "'", conn);
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

        private void tbnohp_KeyPress(object sender, KeyPressEventArgs e)
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
