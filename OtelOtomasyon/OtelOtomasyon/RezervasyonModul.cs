using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeriErisimKatmani;
using IsKatmani;
using VarlikKatmani;

namespace OtelOtomasyon
{
    public partial class RezervasyonModul : Form
    {
        public RezervasyonModul()
        {
            InitializeComponent();
        }

        void Listele()  // Listeleme işlemi için geri dönüş tipi olmayan bir method tanımlıyoruz
        {
            // Liste tipinde Varlık katmanındaki Sınıfımızı kullanarak bir nesne oluşturuyoruz
            // Ardından bu nesneye İş Katmanındaki Listeleme Methodumuzu atıyoruz
            List<Rezervasyon> RezList = RezervasyonBll.RezervasyonListeleBll();
            gridControl1.DataSource = RezList; // Son olarak GridControl aracında bu nesnemizi veri kaynağı olarak tanımlıyoruz
        }
        private void RezervasyonModul_Load(object sender, EventArgs e)
        {
            Listele(); // Modül açıldığı zaman Listeleme işlemi gerçekleşsin ve veriler karşımıza çıksın diye
            // Baştaki methodumuzu buraya çağırıyoruz.
        }
    }
}
