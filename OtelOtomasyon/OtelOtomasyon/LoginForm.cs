using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyon.EntityModel;
namespace OtelOtomasyon
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // EntityConnect sınıfımızda türettiğimiz Bağlantı nesnemiz aracılığıyla Admin tablomuza erişim
            // Lambda Expression yöntemiyle Kullanıcı ve Şifre değerlerimizi kontrol ettirip Dönen değerlerden ID 'nin ilk değerini hafızaya alıyoruz.
            var x = EntityConnect.db.TAdmin.Where(v => v.Kullanici == textBox1.Text && v.Sifre == textBox2.Text).Select(b => b.ID).FirstOrDefault();
            if (x > 0) // Hafızadaki değer 0 dan büyük mü kontrol ediyoruz
            {
                RezervasyonKayit m = new RezervasyonKayit(); // 0 dan büyükse Rezervasyon Kayıt modülümüzü açıyoruz.
                m.Show();
                this.Hide();  // Giriş modülümüzü saklıyoruz.
            }
            else
            {
                // Eğer hafızadaki değer 0 dan küçükse hata mesajı verdiriyoruz çünkü ID 0 dan küçük olamaz.
                XtraMessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre", "Sistem Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
