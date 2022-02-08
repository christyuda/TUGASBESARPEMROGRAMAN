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
    

    public partial class stokin : Form
    {
        //koneksi bung
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        
        public stokin()
        {
            InitializeComponent();
        }
        void munculdatabarang()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select * FROM data_barang;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "data_barang");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data_barang";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }


        private void stokin_Load(object sender, EventArgs e)
        {
            munculdatabarang();
        }

        void cari()
        {
            MySqlConnection conn = konn.GetConn();
            try
            {

                conn.Open();
                cmd = new MySqlCommand("select * from data_barang where id_barang LIKE '%" + textBox1.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "data_barang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "data_barang";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cari();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


    
}
