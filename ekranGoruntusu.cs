using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Notix
{
    public partial class ekranGoruntusu : Form
    {
        public ekranGoruntusu()
        {
            InitializeComponent();
        }

        private void ekranGoruntusu_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dialog kutusu gösterilir ve nereye kayıt edileceğini sorar.
            saveFileDialog2.ShowDialog();
            BackgroundImage.Save(saveFileDialog2.FileName + ".png", ImageFormat.Jpeg);

            MessageBox.Show("Ekran görüntüsü başarı ile kayıt edildi.\nResim yolu:\n" + saveFileDialog2.FileName + ".png", "Başarı ile Kayıt Edildi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
