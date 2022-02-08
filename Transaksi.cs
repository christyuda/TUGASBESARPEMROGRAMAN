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
    public partial class Transaksi : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private MySqlCommand cmd2;
        private MySqlCommand delcmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        void munculkodepelanggan()
        {
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from tabel_pelanggan", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                comboBox1.Items.Add(rd[0].ToString());

            }
            rd.Close();
            conn.Close();

        }
        void munculidadmin()
        {
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from tabel_admin", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                comboBox2.Items.Add(rd[0].ToString());

            }
            rd.Close();
            conn.Close();

        }


        void kondisiawal()
        {
            comboBox2.Text = "";
            comboBox1.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label21.Text = "";
            label25.Text = "";
            lbhargabarang.Text = "";
            lbsatuan.Text = "";
            label11.Text = "0";
            textBox1.Text = "";
            textBox2.Text = "";
            label20.Text = "";
            label26.Text = "";
            label15.Text = DateTime.Today.ToString();
            textBox3.Enabled = false;
            this.dataGridView1.Rows.Clear();
        }
        public Transaksi()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            kondisiawal();
            munculkodepelanggan();
            nootomatis();
            munculdatabarang();
            munculidadmin();
            label11.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from tabel_pelanggan where id_pelanggan='" + comboBox1.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                label7.Text = rd[1].ToString();
                label8.Text = rd[2].ToString();
                label9.Text = rd[3].ToString();

            }
        }
        void munculdatabarang()
        {
            dataGridView1.Columns.Add("id_barang", "Kode Barang");
            dataGridView1.Columns.Add("namabarang", "Nama Barang");
            dataGridView1.Columns.Add("harga", "Harga");
            dataGridView1.Columns.Add("jumlahbarang", "Jumlah");
            dataGridView1.Columns.Add("subtotal", "Subtotal");

            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }
        void nootomatis()
        {
            long hitung;
            string urutan;
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select NoJual from tabel_jual where NoJual in(select max(NoJual) from tabel_jual) order by NoJual desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["NoJual"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urutan = "TRN" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "TRN001";
            }
            rd.Close();
            label6.Text = urutan;
            conn.Close();


        }
        void barangdicari()
        {

            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from data_barang where id_barang='" + textBox2.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows)


            {
                label21.Text = rd[1].ToString();
                label25.Text = rd[6].ToString();
                lbsatuan.Text = rd[7].ToString();
                lbstok.Text = rd[5].ToString();
                lbhargabarang.Text = rd[4].ToString();
                textBox3.Enabled = true;

            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            barangdicari();

        }
        void item()
        {
            decimal hitung = 0;

            for (int i = 0; i < Convert.ToInt32(dataGridView1.Rows.Count) - 1; i++)
            {
                hitung = hitung + Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
            }
            label26.Text = hitung.ToString();
        }
        void Rumushitung()
        {
            decimal hitung = 0;

            for (int i = 0; i < Convert.ToInt32(dataGridView1.Rows.Count) - 1; i++)
            {
                hitung = hitung + Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
            }
            label11.Text = hitung.ToString();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" )
            {
                MessageBox.Show("Pastikan Sudah Mengisi kode barang dan jumlah");
            }
            else
            {
                int i;
                int j;
                int subtotal;
                i = Convert.ToInt32(lbhargabarang.Text);
                j = Convert.ToInt32(textBox3.Text);
                subtotal = j * i;
                string[] dataBaru = new string[] { textBox2.Text, label21.Text, lbhargabarang.Text,textBox3.Text ,textBox3.Text = subtotal.ToString() };
                dataGridView1.Rows.Add(dataBaru);
            }
            Rumushitung();
            item();
            kondisiawaljumlah();
            stokjikalebih();


        }
        void kondisiawaljumlah()
        {
            textBox3.Text = "";
        }


        void stokjikalebih()
        {
            
                int stok;
                int stok2;
                stok = Convert.ToInt32(lbstok.Text);
                stok2 = int.Parse(textBox3.Text);
                if (stok < stok2)
                {
                MessageBox.Show("MOHON MAAF STOK TIDAK SAMPAI PERMINTAAN");
                button4.Enabled = false;
                }
                else
            {
                if (stok > stok2)
                {
                    button4.Enabled = true;
                }
            }




        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                int bayar;
                int total;
                int totalakhir;
                
                bayar = Convert.ToInt32(textBox1.Text);
                total = Convert.ToInt32(label11.Text);
                
                totalakhir = bayar - total;
                if (bayar < total)
                {
                    MessageBox.Show("Mohon Maaf untuk Uangnya Kurang");
                }
                else if (bayar == total)
                {
                    label20.Text = "0";
                }
                else if (bayar > total)
                {
                    label20.Text = totalakhir.ToString();
                }

            }
        }
        void deletetransaksi()
        {
            
            
        }
        void masukkelaporankeluar()
        {
            if (label7.Text == "" || label21.Text == "" || label20.Text == "")
            {
                MessageBox.Show("Proses Transaksi Tidak Ada Pastikan anda mengisi dengan benar");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();
                label15.Text = DateTime.Now.ToString("yyyy-MM-dd");
                cmd2 = new MySqlCommand("insert into tabel_detailjual values('" + label6.Text + "','" + textBox2.Text + "','" + label21.Text + "','" + lbhargabarang.Text + "','" + label26.Text + "','" + label11.Text + "','" + label15.Text + "')", conn);
                conn.Open(); cmd2.ExecuteNonQuery();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (label7.Text == "" || label21.Text == "" || label20.Text == "")
            {
                MessageBox.Show("Proses Transaksi Tidak Ada Pastikan anda mengisi dengan benar");
            }
           

            else
            {
                MySqlConnection conn = konn.GetConn();
                label15.Text = DateTime.Now.ToString("yyyy-MM-dd");
                cmd = new MySqlCommand("insert into tabel_jual values('" + label6.Text + "','" + label15.Text + "','" + label26.Text + "','" + label11.Text + "','" + textBox1.Text + "','" + label20.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "')", conn);
                //cmd = new MySqlCommand("UPDATE `data_barang`  SET `jumlahbarang`= jumlahbarang - '" + [4].Value + "' WHERE id_barang='" + r.Cells[0].Value + "'",conn);
                cmd1 = new MySqlCommand("Update data_barang set jumlahbarang = jumlahbarang - '" + label26.Text + "' where id_barang='" + textBox2.Text + "'", conn);

                
                
                
                conn.Open(); cmd1.ExecuteNonQuery(); 
                cmd.ExecuteNonQuery();
                masukkelaporankeluar();
                MessageBox.Show("Transaksi Berhasil Dicetak");
               

            }
            


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kondisiawal();
            nootomatis();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewlist frm = new viewlist();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            deletetransaksi();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                stokjikalebih();
            }
        }
    }

}
