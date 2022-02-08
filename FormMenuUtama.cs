using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace AplikasiGudang
{
    public partial class FormMenuUtama : Form
    {
        
        public static FormMenuUtama MENU;
        MenuStrip mnstrip;
        FormLogin frmlogin;
        Masteradmin frmdataadmin;
        DataPemasok frmdatapemasok;
        DataBarang frmdatabarang;
        About frmabout;
        Stokout frmstokout;
        stokin frmstokin;
        DataPelanggan frmpelanggan;
        Transaksi frmtransaksi;
        

        void frmlogin_fromClosed(object sender, FormClosedEventArgs e)
        {
            frmlogin = null;
        }
        void frmtransaksi_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmtransaksi = null;
        }
        void frmdataadmin_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmdataadmin = null;
        }
        void frmpelanggan_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmpelanggan = null;
        }

        void frmdatapemasok_fromClosed(object sender, FormClosedEventArgs e)
        {
            frmdatapemasok = null;
        }
        void frmstokin_fromClosed(object sender, FormClosedEventArgs e)
        {
            frmstokin = null;
        }
        void frmdatabarang_fromClosed(object sender, FormClosedEventArgs e)
        {
            frmdatabarang = null;
        }
        void frmabout_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmabout = null;
        }
        void frmstokout_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmstokout = null;
        }
        void MenuTerkunci()
        {
            
            menulogin.Enabled = true;
            menuexit.Enabled = false;
            menumaster.Enabled = false;
            menutransaksi.Enabled = false;
            menudatapelanggan.Enabled = false;
            menutransaksilaporan.Enabled = false;
            menuhelp.Enabled = false;
            transaksi.Enabled = false;
            MENU = this;
          
        }
        public FormMenuUtama()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMenuUtama_Load(object sender, EventArgs e)
        {
            MenuTerkunci();
            STLabel10.Text = DateTime.Today.ToString();
        }

        private void menulogin_Click(object sender, EventArgs e)
        {
            if (frmlogin == null)
            {
                frmlogin = new FormLogin();
                frmlogin.FormClosed += new FormClosedEventHandler(frmlogin_fromClosed);
                frmlogin.ShowDialog();
            }
            else
            {
                frmlogin.Activate();
            }
            //frmlogin = new FormLogin();
            //frmlogin.Show();
        }

        private void menudataadmin_Click(object sender, EventArgs e)
        {
            if (frmdataadmin == null)
            {
                frmdataadmin = new Masteradmin();
                frmdataadmin.FormClosed += new FormClosedEventHandler(frmdataadmin_fromClosed);
                frmdataadmin.ShowDialog();
            }
            else
            {
                frmdataadmin.Activate();
            }
        }

        private void menudatapemasok_Click(object sender, EventArgs e)
        {
            if (frmdatapemasok == null)
            {
                frmdatapemasok = new DataPemasok();
                frmdatapemasok.FormClosed += new FormClosedEventHandler(frmdatapemasok_fromClosed);
                frmdatapemasok.ShowDialog();
            }
            else
            {
                frmdatapemasok.Activate();
            }
        }

        private void menudatabarang_Click(object sender, EventArgs e)
        {
            if (frmdatabarang == null)
            {
                frmdatabarang = new DataBarang();
                frmdatabarang.FormClosed += new FormClosedEventHandler(frmdatabarang_fromClosed);
                frmdatabarang.ShowDialog();
            }
            else
            {
                frmdatabarang.Activate();
            }
        }

        private void menuabout_Click(object sender, EventArgs e)
        {
            if (frmabout == null)
            {
                frmabout = new About();
                frmabout.FormClosed += new FormClosedEventHandler(frmabout_fromClosed);
                frmabout.ShowDialog();
            }
            else
            {
                frmabout.Activate();
            }
        }

        private void laporanDataKeluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menudatapelanggan_Click(object sender, EventArgs e)
        {
            
                 if (frmpelanggan == null)
            {
                frmpelanggan = new DataPelanggan();
                frmpelanggan.FormClosed += new FormClosedEventHandler(frmpelanggan_fromClosed);
                frmpelanggan.ShowDialog();
            }
            else
            {
                frmpelanggan.Activate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            STLabel8.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmtransaksi == null)
            {
                frmtransaksi = new Transaksi();
                frmtransaksi.FormClosed += new FormClosedEventHandler(frmtransaksi_fromClosed);
                frmtransaksi.ShowDialog();
            }
            else
            {
                frmtransaksi.Activate();
            }
        }

        private void detailTransaksiMasukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmstokout == null)
            {
                frmstokout = new Stokout();
                frmstokout.FormClosed += new FormClosedEventHandler(frmstokout_fromClosed);
                frmstokout.ShowDialog();
            }
            else
            {
                frmstokin.Activate();
            }
        }

        private void detailtransaksi_Click(object sender, EventArgs e)
        {
            if (frmstokin == null)
            {
                frmstokin = new stokin();
                frmstokin.FormClosed += new FormClosedEventHandler(frmstokin_fromClosed);
                frmstokin.ShowDialog();
            }
            else
            {
                frmstokin.Activate();
            }
        }
    }
}
