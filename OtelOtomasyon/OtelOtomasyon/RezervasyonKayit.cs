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
    public partial class RezervasyonKayit : Form
    {
        public RezervasyonKayit()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();  // İPTAL Tuşuna basılırsa bu modülü kapatıyoruz.
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RezervasyonModul m = new RezervasyonModul();  // Rezervasyon Görüntüle tuşuna basılırsa o modülü açtırıyoruz.
            m.Show();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TRezervasyon t = new TRezervasyon();  // Entitiymize ait Tablomuzdaki alanlara erişmek için bir nesne türetiyoruz.
            t.TC = maskedTextBox2.Text;  // Bu alanlara atamak istediğimiz Araç değerlerimizi atıyoruz.
            t.Musteri = textBox2.Text;
            t.Telefon = maskedTextBox1.Text;
            t.Yas = textBox4.Text;
            t.GirisTarih = dateTimePicker1.Text;
            t.CikisTarih = dateTimePicker2.Text;
            t.Cocuk = textBox7.Text;
            t.Yetiskin = textBox8.Text;
            t.OdaTipi = comboBox1.Text;
            t.Fiyat = Convert.ToInt32(textBox9.Text); 
            EntityConnect.db.TRezervasyon.Add(t);    // Entitiymize ekleme işlemini yapıyoruz ve parametre olarak başta oluşturduğumuz nesneyi giriyoruz
            EntityConnect.db.SaveChanges();   // Veritabanındaki işlemlerimizi gerçekleştirme komutu
            XtraMessageBox.Show("Rezervasyon Başarıyla Oluşturuldu", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Herşey tamamlandıktan sonra mesaj kutusunu gösteriyoruz.
        }

        int yetiskin, cocuk, odatipi,gunsayisi;  // Hafızaya fiyat hesaplaması için 4 adet değişken tanımlıyoruz.

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            yetiskin = Convert.ToInt32(textBox8.Text);  // Yetiskin sayısını tutmak için hafızadaki degiskenimizi kullanıyoruz.
            cocuk = Convert.ToInt32(textBox7.Text); // Çocuk sayısını tutmak için hafızadaki degiskenimizi kullanıyoruz.
            gunsayisi = Convert.ToInt32(textBox1.Text); // Gün sayısını tutmak için hafızadaki degiskenimizi kullanıyoruz.
            if (comboBox1.Text == "Suit")  // Oda tipine ait fiyatı belirlemek için Suit mi Normal mi kontrolü yaptırıyoruz
            {
                odatipi = 500;  // Suitse eğer odatipi değişkenimize 500 değerini veriyoruz
            }
            else
            {
                odatipi = 300; // Normalse eğer odatipi değişkenimize 300 değerini veriyoruz
            }
            textBox9.Text = ((yetiskin * 300 + cocuk * 200 + odatipi)*gunsayisi).ToString();  // Fiyat kutucuğumuza Fiyat Yetiskin 300 - Cocuk 200 - Normal 300 ve Suit 500
                                                                                              // * Gün sayısı olacak şekilde fiyat hesabı yaptırıyoruz.
        }

    }
}
