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
    public partial class Stokout : Form
    {
        //koneksi bung
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        public Stokout()
        {
            InitializeComponent();
        }

        void munculdatabarang()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM tabel_detailjual;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "tabel_detailjual");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tabel_detailjual";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        void cari()
        {
            MySqlConnection conn = konn.GetConn();
            try
            {

                conn.Open();
                cmd = new MySqlCommand("select * from tabel_detailjual where nojual LIKE '%" + textBox1.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "tabel_detailjual");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tabel_detailjual";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
        }

        private void Stokout_Load(object sender, EventArgs e)
        {
            munculdatabarang();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cari();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = konn.GetConn();
            MySqlCommand com = new MySqlCommand(" Select * from tabel_detailjual", conn);
            MySqlDataAdapter d = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("TRANSAKSI dihapus?", "APAKAH DATA INGIN DIHAPUS", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["NoJual"].FormattedValue.ToString();
                MySqlConnection conn = konn.GetConn();
                conn.Open();
                MySqlCommand com = new MySqlCommand("Delete from tabel_detailjual where NoJual='" + id + "'", conn);
                com.ExecuteNonQuery();
                MessageBox.Show("DATA SUKSES DIHAPUS");
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
