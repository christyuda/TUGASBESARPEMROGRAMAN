using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AplikasiGudang
{
    public partial class DataBarang : Form
    {
        //koneksi bung
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        Decimal rupiah;
        
        //function time



        //function bung

        void Levelmuncul()
        {
            comboBox1.Items.Add("Bintang 1");
            comboBox1.Items.Add("Bintang 2");
            comboBox1.Items.Add("Bintang 3");
            comboBox1.Items.Add("Bintang 4");
            comboBox1.Items.Add("Bintang 5");
            comboBox1.Items.Add("Bintang 6");
        }

        void satuanmuncul()
        {
            comboBox2.Items.Add("pcs");
            comboBox2.Items.Add("box");
            
        }
        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            Levelmuncul();
            munculdatabarang();
            satuanmuncul();


        }
        void Kondisireset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = ""; 
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            
            munculdatabarang();
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
                cmd = new MySqlCommand("select * from data_barang where id_barang LIKE '%" + textBox6.Text + "%' or namabarang LIKE '%" + textBox6.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "data_barang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "data_barang";
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
            cmd = new MySqlCommand("select id_barang from data_barang where id_barang in(select max(id_barang) from data_barang) order by id_barang desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["id_barang"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urutan = "DTR" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "DTR001";
            }
            rd.Close();
            textBox1.Text = urutan;
            conn.Close();


        }
        void idterkunci()
        {
            textBox1.Enabled = false;
        }
        void munculdatabarang()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT id_barang AS 'KODE BARANG', namabarang  AS 'NAMA BARANG',jumlahbarang AS 'JUMLAH BARANG', level_barang  AS 'LEVEL BARANG', harga AS 'Harga jual' ,hargabeli AS 'Harga Beli', satuan  AS 'SATUAN', pemasok AS 'Nama Pemasok' FROM data_barang;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "data_barang");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data_barang";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }
        public DataBarang()
        {
            InitializeComponent();
        }
        void kalauhargajuallebihmurah()
        {
            if (Convert.ToInt32(textBox4.Text) < Convert.ToInt32(textBox5.Text))
            {
                MessageBox.Show("PASTIKAN HARGA JUAL LEBIH MAHAL SUPAYA TIDAK RUGI");
                textBox3.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(textBox4.Text) > Convert.ToInt32(textBox5.Text))
                textBox3.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
            }
        }
        private void DataBarang_Load(object sender, EventArgs e)
        {
            KondisiAwal();
            //menuterkunci();
            nootomatis();
            idterkunci();
            munculdatapemasok();
            


        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();
                //string sDate = Tgl.SelectionStart.ToString("yyyy\\/MM\\/dd");
                cmd = new MySqlCommand("insert into data_barang values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')", conn);
               
                //cmd = new MySqlCommand("insert into data_barang values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + sDate + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "')", conn);
                //cmd = new MySqlCommand("INSERT INTO  `data_barang` (`id_barang`, `namabarang`,`jumlahbarang`, `Tgl`, `hargabeli`,`hargajual`, `level_barang`,`id_pemasok` )" + " VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + textBox5.Text + "' ,'" + textBox4.Text + "','" + comboBox1.Text + "')",  conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                


                MessageBox.Show("Data berhasil ditambah");
                Kondisireset();
                //konn.update_Autonumber(comboBox1.Text);
                nootomatis();
                tambahtabelstokin();
                
            }
        }

        void tambahtabelstokin()
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                
            }
            else
            {
                MySqlConnection conn = konn.GetConn();
                cmd1 = new MySqlCommand("insert into stokin values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')", conn);
                cmd1.ExecuteNonQuery();
                nootomatis();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("Update data_barang set namabarang='" + textBox2.Text + "',pemasok='" + comboBox3.Text + "',hargabeli='" + textBox5.Text + "',harga='" + textBox4.Text + "',jumlahbarang='" + textBox3.Text + "',level_barang='" + comboBox1.Text + "',satuan='" + comboBox2.Text + "' where id_barang='" + textBox1.Text + "'", conn);
                //cmd1 = new MySqlCommand("Update stokin set namabarang='" + textBox2.Text + "',pemasok='" + comboBox3.Text + "',hargabeli='" + textBox5.Text + "',jumlahbarang='" + textBox3.Text + "',level_barang='" + comboBox1.Text + "',satuan='" + comboBox2.Text + "',tanggal='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where idbarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                //cmd1.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Ganti");
                Kondisireset();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA BARANG INI :" + textBox2.Text + "??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = konn.GetConn();

                    cmd = new MySqlCommand("DELETE from data_barang where id_barang='" + textBox1.Text + "'", conn);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id_barang"].Value.ToString();
                textBox2.Text = row.Cells["namabarang"].Value.ToString();
                comboBox3.Text = row.Cells["pemasok"].Value.ToString();
                textBox5.Text = row.Cells["hargabeli"].Value.ToString();
                textBox4.Text = row.Cells["harga"].Value.ToString();
                textBox3.Text = row.Cells["jumlahbarang"].Value.ToString();
                comboBox1.Text = row.Cells["level_barang"].Value.ToString();
                comboBox2.Text = row.Cells["satuan"].Value.ToString();
                

            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }
        void munculdatapemasok()
        {
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from tabel_pemasok", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                comboBox3.Items.Add(rd[1].ToString());

            }
            rd.Close();
            conn.Close();
        }

      

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                kalauhargajuallebihmurah();
            }
        }
    }
}
