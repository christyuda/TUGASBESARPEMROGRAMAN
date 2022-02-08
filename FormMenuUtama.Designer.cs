namespace AplikasiGudang
{
    partial class FormMenuUtama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menufile = new System.Windows.Forms.ToolStripMenuItem();
            this.menulogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuexit = new System.Windows.Forms.ToolStripMenuItem();
            this.menumaster = new System.Windows.Forms.ToolStripMenuItem();
            this.menudataadmin = new System.Windows.Forms.ToolStripMenuItem();
            this.menudatapemasok = new System.Windows.Forms.ToolStripMenuItem();
            this.menudatapelanggan = new System.Windows.Forms.ToolStripMenuItem();
            this.menudatabarang = new System.Windows.Forms.ToolStripMenuItem();
            this.menutransaksi = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksi = new System.Windows.Forms.ToolStripMenuItem();
            this.menutransaksilaporan = new System.Windows.Forms.ToolStripMenuItem();
            this.detailtransaksi = new System.Windows.Forms.ToolStripMenuItem();
            this.detailTransaksiMasukToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuhelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuabout = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.STLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.STLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.STLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.STLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.STLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.STLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.STLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::AplikasiGudang.Properties.Resources.ice_cream_feature_scaled_e1630664958334;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menufile,
            this.menumaster,
            this.menutransaksi,
            this.menutransaksilaporan,
            this.menuhelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(668, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menufile
            // 
            this.menufile.BackColor = System.Drawing.Color.LightSeaGreen;
            this.menufile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menulogin,
            this.menuexit});
            this.menufile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.menufile.Name = "menufile";
            this.menufile.Size = new System.Drawing.Size(37, 20);
            this.menufile.Text = "&File";
            // 
            // menulogin
            // 
            this.menulogin.Name = "menulogin";
            this.menulogin.Size = new System.Drawing.Size(152, 22);
            this.menulogin.Text = "&Login";
            this.menulogin.Click += new System.EventHandler(this.menulogin_Click);
            // 
            // menuexit
            // 
            this.menuexit.Name = "menuexit";
            this.menuexit.Size = new System.Drawing.Size(152, 22);
            this.menuexit.Text = "&Exit";
            this.menuexit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menumaster
            // 
            this.menumaster.BackColor = System.Drawing.Color.LightSeaGreen;
            this.menumaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menudataadmin,
            this.menudatapemasok,
            this.menudatapelanggan,
            this.menudatabarang});
            this.menumaster.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.menumaster.Name = "menumaster";
            this.menumaster.Size = new System.Drawing.Size(55, 20);
            this.menumaster.Text = "&Master";
            // 
            // menudataadmin
            // 
            this.menudataadmin.Name = "menudataadmin";
            this.menudataadmin.Size = new System.Drawing.Size(157, 22);
            this.menudataadmin.Text = "&Data Karyawan";
            this.menudataadmin.Click += new System.EventHandler(this.menudataadmin_Click);
            // 
            // menudatapemasok
            // 
            this.menudatapemasok.Name = "menudatapemasok";
            this.menudatapemasok.Size = new System.Drawing.Size(157, 22);
            this.menudatapemasok.Text = "&Data Pemasok";
            this.menudatapemasok.Click += new System.EventHandler(this.menudatapemasok_Click);
            // 
            // menudatapelanggan
            // 
            this.menudatapelanggan.Name = "menudatapelanggan";
            this.menudatapelanggan.Size = new System.Drawing.Size(157, 22);
            this.menudatapelanggan.Text = "Data Pelanggan";
            this.menudatapelanggan.Click += new System.EventHandler(this.menudatapelanggan_Click);
            // 
            // menudatabarang
            // 
            this.menudatabarang.Name = "menudatabarang";
            this.menudatabarang.Size = new System.Drawing.Size(157, 22);
            this.menudatabarang.Text = "&Data Barang";
            this.menudatabarang.Click += new System.EventHandler(this.menudatabarang_Click);
            // 
            // menutransaksi
            // 
            this.menutransaksi.BackColor = System.Drawing.Color.LightSeaGreen;
            this.menutransaksi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transaksi});
            this.menutransaksi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.menutransaksi.Name = "menutransaksi";
            this.menutransaksi.Size = new System.Drawing.Size(66, 20);
            this.menutransaksi.Text = "&Transaksi";
            // 
            // transaksi
            // 
            this.transaksi.Name = "transaksi";
            this.transaksi.Size = new System.Drawing.Size(180, 22);
            this.transaksi.Text = "Transaksi Pelanggan";
            this.transaksi.Click += new System.EventHandler(this.transaksiToolStripMenuItem_Click);
            // 
            // menutransaksilaporan
            // 
            this.menutransaksilaporan.BackColor = System.Drawing.Color.LightSeaGreen;
            this.menutransaksilaporan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailtransaksi,
            this.detailTransaksiMasukToolStripMenuItem});
            this.menutransaksilaporan.ForeColor = System.Drawing.SystemColors.Control;
            this.menutransaksilaporan.Name = "menutransaksilaporan";
            this.menutransaksilaporan.Size = new System.Drawing.Size(62, 20);
            this.menutransaksilaporan.Text = "&Laporan";
            // 
            // detailtransaksi
            // 
            this.detailtransaksi.Name = "detailtransaksi";
            this.detailtransaksi.Size = new System.Drawing.Size(159, 22);
            this.detailtransaksi.Text = "&Transaksi Masuk";
            this.detailtransaksi.Click += new System.EventHandler(this.detailtransaksi_Click);
            // 
            // detailTransaksiMasukToolStripMenuItem
            // 
            this.detailTransaksiMasukToolStripMenuItem.Name = "detailTransaksiMasukToolStripMenuItem";
            this.detailTransaksiMasukToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.detailTransaksiMasukToolStripMenuItem.Text = "&Transaksi Keluar";
            this.detailTransaksiMasukToolStripMenuItem.Click += new System.EventHandler(this.detailTransaksiMasukToolStripMenuItem_Click);
            // 
            // menuhelp
            // 
            this.menuhelp.BackColor = System.Drawing.Color.LightSeaGreen;
            this.menuhelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuabout});
            this.menuhelp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.menuhelp.Name = "menuhelp";
            this.menuhelp.Size = new System.Drawing.Size(44, 20);
            this.menuhelp.Text = "&Help";
            // 
            // menuabout
            // 
            this.menuabout.Name = "menuabout";
            this.menuabout.Size = new System.Drawing.Size(107, 22);
            this.menuabout.Text = "&About";
            this.menuabout.Click += new System.EventHandler(this.menuabout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Reglisse", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(920, 62);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELAMAT DATANG DI APLIKASI GUDANG ES KRIM";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::AplikasiGudang.Properties.Resources.ice_cream_feature_scaled_e1630664958334;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.STLabel2,
            this.STLabel4,
            this.STLabel6,
            this.STLabel7,
            this.STLabel8,
            this.STLabel9,
            this.STLabel10});
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(668, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // STLabel2
            // 
            this.STLabel2.Name = "STLabel2";
            this.STLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // STLabel4
            // 
            this.STLabel4.Name = "STLabel4";
            this.STLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // STLabel6
            // 
            this.STLabel6.Name = "STLabel6";
            this.STLabel6.Size = new System.Drawing.Size(0, 17);
            // 
            // STLabel7
            // 
            this.STLabel7.Name = "STLabel7";
            this.STLabel7.Size = new System.Drawing.Size(34, 17);
            this.STLabel7.Text = "Jam :";
            // 
            // STLabel8
            // 
            this.STLabel8.Name = "STLabel8";
            this.STLabel8.Size = new System.Drawing.Size(0, 17);
            // 
            // STLabel9
            // 
            this.STLabel9.Name = "STLabel9";
            this.STLabel9.Size = new System.Drawing.Size(54, 17);
            this.STLabel9.Text = "Tanggal :";
            // 
            // STLabel10
            // 
            this.STLabel10.Name = "STLabel10";
            this.STLabel10.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMenuUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.BackgroundImage = global::AplikasiGudang.Properties.Resources.istockphoto_1278990546_170667a;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(668, 458);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenuUtama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APLIKASI GUDANG ESKRIM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenuUtama_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem menudataadmin;
        private System.Windows.Forms.ToolStripMenuItem menudatapemasok;
        private System.Windows.Forms.ToolStripMenuItem menudatabarang;
        private System.Windows.Forms.ToolStripMenuItem menuabout;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem menufile;
        public System.Windows.Forms.ToolStripMenuItem menumaster;
        public System.Windows.Forms.ToolStripMenuItem menuhelp;
        public System.Windows.Forms.ToolStripMenuItem menulogin;
        public System.Windows.Forms.ToolStripMenuItem menuexit;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStripMenuItem menutransaksi;
        public System.Windows.Forms.ToolStripMenuItem menudatapelanggan;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel STLabel2;
        private System.Windows.Forms.ToolStripStatusLabel STLabel4;
        private System.Windows.Forms.ToolStripStatusLabel STLabel6;
        private System.Windows.Forms.ToolStripStatusLabel STLabel7;
        private System.Windows.Forms.ToolStripStatusLabel STLabel8;
        private System.Windows.Forms.ToolStripStatusLabel STLabel9;
        private System.Windows.Forms.ToolStripStatusLabel STLabel10;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ToolStripMenuItem transaksi;
        private System.Windows.Forms.ToolStripMenuItem detailtransaksi;
        public System.Windows.Forms.ToolStripMenuItem menutransaksilaporan;
        private System.Windows.Forms.ToolStripMenuItem detailTransaksiMasukToolStripMenuItem;
    }
}