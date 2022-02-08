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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        koneksidb konn = new koneksidb();
        private string url = "server=localhost;userid=root;password=;database=gudang";

        private void btnlogin_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            MySqlConnection conn = konn.GetConn();
            {
                conn.Open();
                
                cmd = new MySqlCommand("SELECT * from tabel_superadmin where username='" + tbusername.Text + "' and password='" + tbpassword.Text + "'", conn);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    FormMenuUtama.MENU.menulogin.Enabled = false;
                    FormMenuUtama.MENU.menuexit.Enabled = true;
                    FormMenuUtama.MENU.menumaster.Enabled = true;
                    FormMenuUtama.MENU.menutransaksi.Enabled = true;
                    FormMenuUtama.MENU.menudatapelanggan.Enabled = true;
                    FormMenuUtama.MENU.transaksi.Enabled = true;
                    FormMenuUtama.MENU.menuhelp.Enabled = true;
                    FormMenuUtama.MENU.menutransaksilaporan.Enabled = true;

                    //string welcome;
                    //tbusername.Text = rd[1].ToString();
                    //FormMenuUtama menuutama = new FormMenuUtama();
                    //menuutama.Show();
                    this.Close();
                    MessageBox.Show("SELAMAT DATANG " + tbusername.Text +"");
                }
                else
                {
                    MessageBox.Show("Salah username atau password");
                }
            }
        }



        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            tbpassword.PasswordChar = '*';
            tbusername.Text = "admin";
            tbpassword.Text = "admin";
            
        }



        //if (tbusername.Text == "YUDA" && tbpassword.Text == "admin")
        //{
        //    FormMenuUtama menuutama = new FormMenuUtama();
        //    menuutama.Show();
        //    this.Hide();
        //}
        //else
        //{
        //    MessageBox.Show("Salah username atau password");
        //}

    }
}
