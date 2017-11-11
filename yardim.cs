using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notix
{
    public partial class yardim : Form
    {
        public yardim()
        {
            InitializeComponent();
        }
  
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seciliNesne = comboBox1.SelectedIndex;

            //Seçilen nesneye göre yardım metni gösterilecek.
            if (seciliNesne == 0)
            {   
                richTextBox1.Text = "Notix # , temel bir metin düzenleme programıdır ve" + " genellikle metin dosyalarını görüntülemek veya düzenlemek için kullanılır.\n\n"
                + "Metin dosyası, genellikle .txt dosya adı uzantısıyla tanımlanan bir dosya türüdür.";
            }
            if (seciliNesne == 1)
            {
                richTextBox1.Text = "Notix # 'ı tıklatarak açın. ";
            }
            if (seciliNesne == 2)
            {
                richTextBox1.Text = "Yazı tipi stilinde ve boyutunda yapılan değişiklikler belgedeki metnin tümünü etkiler.\n\n"
                + "1.Notix # 'ı Tıklatıp Açın.\n\n"
                + "2.Görünüm menüsünü ve ardından Yazı Tipi'ni tıklatın.\n\n"
                + "3.Yazı Tipi, Yazı Tipi stili ve Boyut kutularında seçimlerinizi yapın.\n\n"
                + "4.Yazı tipinizin görünüm örneği Örnek'te gösterilecektir.\n\n"
                + "5.Yazı tipi seçimlerini tamamladığınızda, Tamam'ı tıklatın.";
            }
            if (seciliNesne == 3)
            {
                richTextBox1.Text = "Notix # 'ı tıklatıp açın.\n\n"
                + "Aşağıdakilerden birini yapın:\n\n"
                + "Metni başka bir yere taşımak üzere kesmek için metni seçin, Düzen menüsünü ve ardından Kes'i tıklatın.\n\n"
                + "Metni başka bir yere yapıştırmak üzere kopyalamak için metni seçin, Düzen menüsünü ve ardından Kopyala'yı tıklatın.\n\n"
                + "Kestiğiniz veya kopyaladığınız metni yapıştırmak için, dosyada metni yapıştırmak istediğiniz yeri tıklatın, Düzen menüsünü ve ardından Yapıştır'ı tıklatın.\n\n"
                + "Metni silmek için, metni seçin, Düzen menüsünü ve ardından Temizle'yi tıklatın.\n\n"
                + "Son eyleminizi geri almak için, Düzen menüsünü ve ardından Geri Al'ı tıklatın.";
            }
            if (seciliNesne == 4)
            {
                richTextBox1.Text = "1.Notix # 'ı tıklatıp açın.\n\n"
                + "2.Dosya menüsünü ve ardından Yazdır'ı tıklatın.\n\n"
                + "3.Genel sekmesini tıklatın, istediğiniz yazıcıyı ve seçenekleri belirleyin ve ardından Yazdır'ı tıklatın.\n\n";
            }
            if (seciliNesne == 5)
            {
                richTextBox1.Text = "1.Notix # 'ı tıklatıp açın.\n\n"
                + "2.Belgede saat ve tarihi eklemek istediğiniz yeri tıklatın.\n\n"
                + "3.Düzen menüsünü ve ardından Saat - Tarih'i tıklatın.";
            }

        }

        private void yardim_Load(object sender, EventArgs e)
        {
            //ComboBox'da ki ilk nesnenin otomatik olarak gelmesini sağlıyor.
            comboBox1.Text = comboBox1.Items[0].ToString();
        }
    }
}
