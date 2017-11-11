#region KUTUPHANELER

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Web;
using Microsoft.VisualBasic;

#endregion

namespace Notix
{
    public partial class anasayfa : Form
    {
        public object inputBox { get; private set; }
        int yer;    //
        int i;      //
        public static Bitmap Goruntu;

        public anasayfa()
        {
            InitializeComponent();
        }

        #region FORM
        private void Form1_Load(object sender, EventArgs e)
        {
            //Başlangıç durumlarında capsLock ve numLock tuşlarının durumunu kontrol eder.
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                toolStripStatusLabel1.Text = "CapsLock AÇIK";
            }
            else
            {
                toolStripStatusLabel1.Text = "CapsLock KAPALI";
            }
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                toolStripStatusLabel2.Text = "NumLock AÇIK";
            }
            else
            {
                toolStripStatusLabel2.Text = "NumLock KAPALI";
            }
        }
        #endregion

        #region DOSYA_MENUSU

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Eğer kullanıcı herhangi bir değişiklik yapmadıysa hiçbir şey sorma.
            if (richTextBox1.Text == "")
                Application.Restart();
            //Eğer kullanıcı herhangi bir değişiklik yaptıysa kaydedilsin mi diye sor.
            else
            { 
                DialogResult dr = MessageBox.Show("Değişiklikleri kaydetmek ister misiniz?", "Yeni Belge", MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Yes)
                    kaydetToolStripMenuItem_Click(sender, e);
                else if (dr == DialogResult.Cancel)
                    return;
                Application.Restart();
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yazılan metni farklı kaydeder.(Her seferinde isim ister.)
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                this.Text = "Notix # 1.6   [" + saveFileDialog1.FileName + "]";
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Daha önce oluşturulmuş bir metin dosyası açar.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                this.Text = "Notix # 1.6 [" + openFileDialog1.FileName + "]";
            }
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Varolan metni yazdırır.
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void pDFÇevirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Dosya adı random olarak oluşturulmaktaidi (v1.2).
            //Random rnd = new Random();
            //int sayi = rnd.Next(10000, 99999);

            //Kullanıcının masaüstü.
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Kullanıcıdan dosya ismini girmesini ister.
            string dosyaAdi = Interaction.InputBox("Dosyanız Masaüstüne kaydedilecektir.\n\nLütfen Dosyanın İsmini Giriniz:\n\nDosya adında aşağıdaki karakterler bulunamaz:\n/ \\ : * ? \" < > |", "PDF Olarak Kaydet");
            //FileStream fs = new FileStream(@"C:\Users\Karaca\Desktop\Notix KRC" + sayi.ToString() + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);

            //PDF belgesinin yazı rengi ve arkaplan rengi Notix in ki ile aynı olarak ayarlandı.
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            rec.BackgroundColor = new BaseColor(richTextBox1.BackColor);
            var fontColor = new BaseColor(richTextBox1.ForeColor);

            //PDF Dosyasını seçme imkanı sunmadan , Masaüstüne kaydediyor.
            FileStream fs = new FileStream(path + "\\" + dosyaAdi + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document(rec);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            //Türkçe Font Desteği
            BaseFont yaziTipi = BaseFont.CreateFont("c:\\windows\\fonts\\consola.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font TRfont = new iTextSharp.text.Font(yaziTipi, richTextBox1.Font.Size, iTextSharp.text.Font.NORMAL, fontColor);

            doc.Open();
            doc.Add(new Paragraph(richTextBox1.Text, TRfont));
            //Ekranda bir şey yazılı değilken pdf çevir dendiğinde hata veriyordu, o hata giderildi.
            if (richTextBox1.Text == "")
                doc.Add(new Paragraph(" ", TRfont));
            doc.Close();

            //MessageBox.Show("PDF Belgeniz Masaüstüne\n" + "Notix KRC" + sayi.ToString() + "\nismiyle oluşturuldu.","UYARI");
        }


        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uygulamayı kapatır.
            Application.Exit();
        }
        #endregion

        #region DUZEN_MENUSU
        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yapılan değişiklikler geri alınır.
            richTextBox1.Undo();
        }

        private void temizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bütün metin temizlenir.
            richTextBox1.Clear();
        }

        private void ortalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Metni ortalar.
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void solaYaslaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Metni sola yaslar.
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void sağaYaslaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Metni sağa yaslar.
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Metni keser.
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Metni kopyalar.
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Metin yapıştırır.
            richTextBox1.Paste();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Metnin tümünü seçer.
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
        }

        private void saatTarihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tarih ve saati ekrana basar.
            richTextBox1.Text = DateTime.Now.ToString();
        }
        #endregion

        #region GORUNUM_MENUSU
        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yazı tipini , fontunu , büyüklüğünü değiştirme penceresini açar.
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yazı rengi değiştirme penceresini açar.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void arkaplanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Arkaplan rengi değiştirme penceresini açar.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog1.Color;
            }
        }
        #endregion
        
        #region HAKKINDA_ve_YARDIM_FORMLARI
        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hakkinda formunu açar.
            Notix.hakkinda hakkinda = new Notix.hakkinda();
            hakkinda.Show();

        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //yardim formunu açar.
            Notix.yardim yardim = new Notix.yardim();
            yardim.Show();
        }

        #endregion
        
        #region C_LOCK_NUM_LOCK
        /*
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //capsLock ve numLock tuşlarının durumlarını text-boxta bir değişiklik yapıldığında
            //sürekli olarak değiştirir.
            
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                toolStripStatusLabel1.Text = "CapsLock AÇIK";
            }
            else
            {
                toolStripStatusLabel1.Text = "CapsLock KAPALI";
            }
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                toolStripStatusLabel2.Text = "NumLock AÇIK";
            }
            else
            {
                toolStripStatusLabel2.Text = "NumLock KAPALI";
            }
        }
        */
        #endregion

        #region VURGULAMA
        private void Vurgula_Click(object sender, EventArgs e)
        {
            //i=1 yapıldıktan sonra buraya gelir , tekrar tıklandığında vurgulama kalkar.
            if (i==1)
            {
                i = 0;
                richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            }
            //İlk tıklandığında vurgulama sarı yapılır ve seçili kalır.
            else
            {
                i = 1;
                richTextBox1.SelectionBackColor = Color.Yellow;
            }
        }
        #endregion

        #region ARAMA_KUTUSU
        private void arama_Clear(object sender, EventArgs e)
        {
            aramaBox.Clear();
        }

        private void araButon_Click(object sender, EventArgs e)
        {
             yer = richTextBox1.Text.ToUpper().IndexOf(aramaBox.Text.ToUpper());
             //int a = richTextBox1.Text.IndexOf(aramaBox.Text);

             if (yer < 0)
                 MessageBox.Show("Aramak istediğiniz bulunamadı.","Notix #");
             else
             {
                 sBulButon.Visible = true;

                 richTextBox1.SelectionStart = yer;
                 richTextBox1.SelectionLength = aramaBox.Text.Length;
                 richTextBox1.SelectionBackColor = Color.Yellow;

                 //richTextBox1.Select(a, aramaBox.Text.Length);//richTextBox1.SelectionBackColor = Color.Yellow;
                 //MessageBox.Show("Bulundu...", "Notix #");
             }
        }

        private void sBulButon_Click(object sender, EventArgs e)
        {
            yer = richTextBox1.Text.ToUpper().IndexOf(aramaBox.Text.ToUpper(), yer + 1);
            if (yer < 0)
                MessageBox.Show("Daha fazla bulunamadı.", "Notix #");
            else
            {
                richTextBox1.SelectionStart = yer;
                richTextBox1.SelectionLength = aramaBox.Text.Length;
                richTextBox1.SelectionBackColor = Color.Yellow;
                //MessageBox.Show("Bulundu...", "Notix #");
            }
        }

        private void aramaBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Arama kutusundayken Enter e basıldığında AraButon a tıklanmış gibi yapar.
            if (e.KeyCode == Keys.Enter)
            {
                araButon_Click(sender,e);
            }
        }
        #endregion

        #region FORM_KAPANIRKEN
        private void anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Form kapanırken bir değişiklik yapıldıysa kaydedeyim mi diye sorar.
            if (richTextBox1.Text != "")
            {
                DialogResult dr = MessageBox.Show("Değişiklikleri kaydetmek ister misiniz?", "Uyarı !", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                    kaydetToolStripMenuItem_Click(sender, e);
                else if (dr == DialogResult.Cancel)
                    Application.Exit();
            }
        }
        #endregion

        #region EKRAN_GORUNTUSU
        private void EkranGoruntusu_Click(object sender, EventArgs e)
        { 
            //Yeni bir goruntu nesnesi oluşturulur ve formun boyutları verilir.
            Goruntu = new Bitmap(this.Width, this.Height);
            Graphics Grnt = Graphics.FromImage(Goruntu);
            Grnt.CopyFromScreen(this.Left, this.Top, 0, 0, this.Size);

            //Formun nesnesi oluşturulur ve arkaplanına çekilen ekran görüntüsü atanır.
            Notix.ekranGoruntusu ekranGoruntusu = new Notix.ekranGoruntusu();
            ekranGoruntusu.BackgroundImage = Goruntu;
            ekranGoruntusu.Show();

        }

        #endregion
        
        #region ANLIK_C-LOCK_N-LOCK
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                toolStripStatusLabel1.Text = "CapsLock AÇIK";
            }
            else
            {
                toolStripStatusLabel1.Text = "CapsLock KAPALI";
            }

            if (Control.IsKeyLocked(Keys.NumLock))
            {
                toolStripStatusLabel2.Text = "NumLock AÇIK";
            }
            else
            {
                toolStripStatusLabel2.Text = "NumLock KAPALI";
            }
        }
        #endregion
    }
}