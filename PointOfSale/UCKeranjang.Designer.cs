
namespace PointOfSale
{
    partial class UCKeranjang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCKeranjang));
            this.GambarMenu = new Guna.UI2.WinForms.Guna2PictureBox();
            this.LabelNama = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.LabelQty = new System.Windows.Forms.Label();
            this.TambahQty = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.LabelTambahQty = new System.Windows.Forms.Label();
            this.KurangQty = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.LabelKurangQty = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GambarMenu)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.TambahQty.SuspendLayout();
            this.KurangQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GambarMenu
            // 
            this.GambarMenu.BorderRadius = 10;
            this.GambarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.GambarMenu.Image = ((System.Drawing.Image)(resources.GetObject("GambarMenu.Image")));
            this.GambarMenu.ImageRotate = 0F;
            this.GambarMenu.Location = new System.Drawing.Point(0, 0);
            this.GambarMenu.Margin = new System.Windows.Forms.Padding(0);
            this.GambarMenu.Name = "GambarMenu";
            this.GambarMenu.Size = new System.Drawing.Size(85, 85);
            this.GambarMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GambarMenu.TabIndex = 1;
            this.GambarMenu.TabStop = false;
            // 
            // LabelNama
            // 
            this.LabelNama.AutoSize = true;
            this.LabelNama.Font = new System.Drawing.Font("Berlin Sans FB", 13F);
            this.LabelNama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.LabelNama.Location = new System.Drawing.Point(95, 2);
            this.LabelNama.Margin = new System.Windows.Forms.Padding(0);
            this.LabelNama.Name = "LabelNama";
            this.LabelNama.Size = new System.Drawing.Size(104, 20);
            this.LabelNama.TabIndex = 2;
            this.LabelNama.Text = "Nama Menu";
            this.LabelNama.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.LabelQty);
            this.guna2Panel1.Controls.Add(this.TambahQty);
            this.guna2Panel1.Controls.Add(this.KurangQty);
            this.guna2Panel1.Location = new System.Drawing.Point(217, 55);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(123, 29);
            this.guna2Panel1.TabIndex = 4;
            // 
            // LabelQty
            // 
            this.LabelQty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelQty.Font = new System.Drawing.Font("Berlin Sans FB", 14F);
            this.LabelQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.LabelQty.Location = new System.Drawing.Point(30, 3);
            this.LabelQty.Margin = new System.Windows.Forms.Padding(0);
            this.LabelQty.Name = "LabelQty";
            this.LabelQty.Size = new System.Drawing.Size(48, 21);
            this.LabelQty.TabIndex = 5;
            this.LabelQty.Text = "1";
            this.LabelQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelQty.TextChanged += new System.EventHandler(this.LabelQty_TextChanged);
            // 
            // TambahQty
            // 
            this.TambahQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TambahQty.BackColor = System.Drawing.Color.Transparent;
            this.TambahQty.Controls.Add(this.LabelTambahQty);
            this.TambahQty.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(69)))));
            this.TambahQty.Location = new System.Drawing.Point(78, 2);
            this.TambahQty.Margin = new System.Windows.Forms.Padding(0);
            this.TambahQty.Name = "TambahQty";
            this.TambahQty.Radius = 5;
            this.TambahQty.ShadowColor = System.Drawing.Color.Black;
            this.TambahQty.ShadowDepth = 0;
            this.TambahQty.ShadowShift = 0;
            this.TambahQty.Size = new System.Drawing.Size(25, 25);
            this.TambahQty.TabIndex = 4;
            // 
            // LabelTambahQty
            // 
            this.LabelTambahQty.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.LabelTambahQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelTambahQty.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTambahQty.ForeColor = System.Drawing.Color.White;
            this.LabelTambahQty.Location = new System.Drawing.Point(0, 0);
            this.LabelTambahQty.Name = "LabelTambahQty";
            this.LabelTambahQty.Padding = new System.Windows.Forms.Padding(2, 0, 0, 3);
            this.LabelTambahQty.Size = new System.Drawing.Size(25, 25);
            this.LabelTambahQty.TabIndex = 0;
            this.LabelTambahQty.Text = "+";
            this.LabelTambahQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelTambahQty.Click += new System.EventHandler(this.LabelTambahQty_Click);
            // 
            // KurangQty
            // 
            this.KurangQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KurangQty.BackColor = System.Drawing.Color.Transparent;
            this.KurangQty.Controls.Add(this.LabelKurangQty);
            this.KurangQty.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(69)))));
            this.KurangQty.Location = new System.Drawing.Point(5, 2);
            this.KurangQty.Margin = new System.Windows.Forms.Padding(0);
            this.KurangQty.Name = "KurangQty";
            this.KurangQty.Radius = 5;
            this.KurangQty.ShadowColor = System.Drawing.Color.Black;
            this.KurangQty.ShadowDepth = 0;
            this.KurangQty.ShadowShift = 0;
            this.KurangQty.Size = new System.Drawing.Size(25, 25);
            this.KurangQty.TabIndex = 3;
            // 
            // LabelKurangQty
            // 
            this.LabelKurangQty.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.LabelKurangQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelKurangQty.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelKurangQty.ForeColor = System.Drawing.Color.White;
            this.LabelKurangQty.Location = new System.Drawing.Point(0, 0);
            this.LabelKurangQty.Name = "LabelKurangQty";
            this.LabelKurangQty.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.LabelKurangQty.Size = new System.Drawing.Size(25, 25);
            this.LabelKurangQty.TabIndex = 0;
            this.LabelKurangQty.Text = "-";
            this.LabelKurangQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelKurangQty.Click += new System.EventHandler(this.LabelKurangQty_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 13F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(116, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rp170.000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(96, 60);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(20, 20);
            this.guna2PictureBox1.TabIndex = 6;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // UCKeranjang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.LabelNama);
            this.Controls.Add(this.GambarMenu);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.Name = "UCKeranjang";
            this.Size = new System.Drawing.Size(331, 85);
            ((System.ComponentModel.ISupportInitialize)(this.GambarMenu)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.TambahQty.ResumeLayout(false);
            this.KurangQty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2PictureBox GambarMenu;
        public System.Windows.Forms.Label LabelNama;
        public System.Windows.Forms.Label LabelQty;
        public System.Windows.Forms.Label LabelTambahQty;
        public System.Windows.Forms.Label LabelKurangQty;
        public System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public Guna.UI2.WinForms.Guna2ShadowPanel TambahQty;
        public Guna.UI2.WinForms.Guna2ShadowPanel KurangQty;
        public Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
