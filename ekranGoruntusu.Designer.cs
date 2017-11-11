namespace Notix
{
    partial class ekranGoruntusu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ekranGoruntusu));
            this.KAYDET = new System.Windows.Forms.Button();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KAYDET
            // 
            this.KAYDET.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.KAYDET.BackColor = System.Drawing.Color.Yellow;
            this.KAYDET.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.KAYDET.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KAYDET.FlatAppearance.BorderSize = 0;
            this.KAYDET.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.KAYDET.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.KAYDET.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KAYDET.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KAYDET.ForeColor = System.Drawing.Color.Black;
            this.KAYDET.Location = new System.Drawing.Point(0, 473);
            this.KAYDET.Name = "KAYDET";
            this.KAYDET.Size = new System.Drawing.Size(648, 39);
            this.KAYDET.TabIndex = 0;
            this.KAYDET.Text = "KAYDET";
            this.KAYDET.UseVisualStyleBackColor = false;
            this.KAYDET.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileName = "Resim için isim giriniz";
            this.saveFileDialog2.Filter = "PNG (*.png)|";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 26);
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kaydetToolStripMenuItem.Image")));
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.kaydetToolStripMenuItem.Text = "Kaydet";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // ekranGoruntusu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(648, 512);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.KAYDET);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ekranGoruntusu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekran Görüntüsü Alma Ekranı - Notix #";
            this.Load += new System.EventHandler(this.ekranGoruntusu_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button KAYDET;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
    }
}