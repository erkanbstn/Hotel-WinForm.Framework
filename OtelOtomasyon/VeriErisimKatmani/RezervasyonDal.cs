using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using VarlikKatmani;

namespace VeriErisimKatmani
{
    public class RezervasyonDal // Veritabanı işlemlerimizi (CRUD işlemleri) tanımladığımız sınıf 
    {
        // INT türünde Rezervasyon sınıfından aldığı nesneyi parametre olarak kullanan Ekleme Methodu
        public static int RezervasyonEkle(Rezervasyon r)
        {
            // Veritabanı komutlarını çalıştırmak için yazdığımız Sorgu Cümlesi ve Bağlantısı
            SqlCommand komut = new SqlCommand("Insert Into TRezervasyon Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@10)", SqlBaglanti.con);  // Ekleme Komutları
            if (komut.Connection.State != ConnectionState.Open) // Veritabanına bağlanmak için Bağlantı açık mı değil mi kontrolü
            {
                komut.Connection.Open(); // Eğer kapalıysa açma komutu
            }
            komut.Parameters.AddWithValue("@p1", r.TC);  // PROPERTIELERIMIZE Rezervasyon sınıfımızdan türetilen nesne aracılığıyla parametre atamaları 
            komut.Parameters.AddWithValue("@p2", r.Musteri);
            komut.Parameters.AddWithValue("@p3", r.Telefon);
            komut.Parameters.AddWithValue("@p4", r.Yas);
            komut.Parameters.AddWithValue("@p5", r.GirisTarih);
            komut.Parameters.AddWithValue("@p6", r.CikisTarih);
            komut.Parameters.AddWithValue("@p7", r.Cocuk);
            komut.Parameters.AddWithValue("@p8", r.Yetiskin);
            komut.Parameters.AddWithValue("@p9", r.OdaTipi);
            komut.Parameters.AddWithValue("@p10", r.Fiyat);
            komut.ExecuteNonQuery();  // Veritabanındaki işlemi gerçekleştirme komutu
            SqlBaglanti.con.Close(); // Bağlantıyla işimiz kalmadığından kapatma komutu 
            return komut.ExecuteNonQuery(); // Method geriye dönüş olarak Veritabanındaki işlemi gerçekleştir işlemini gerçekleştiriyor
        }
        // BOOL türünde string tc den aldığı değeri parametre olarak kullanan Silme Methodu

        public static bool RezervasyonSil(string tc)
        {
            SqlCommand komut = new SqlCommand("Delete From TRezervasyon Where TC=@p1", SqlBaglanti.con); // Silme komutları
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", tc);
            komut.ExecuteNonQuery();
            SqlBaglanti.con.Close();
            return komut.ExecuteNonQuery() > 0; // Method Bool tipinde olduğundan > 0 şeklinde geriye dönüş olarak Veritabanındaki işlemi gerçekleştir işlemini gerçekleştiriyor
        }

        // Listeleme işlemi için LİST tipinde değer döndüren Method 
        public static List<Rezervasyon> RezervasyonListesi()
        {
            List<Rezervasyon> degerler = new List<Rezervasyon>();  // Varlık katmanındaki Sınıfımızı Liste tipine çevirerek verilerimizi listelemeyi hedefliyoruz
            SqlCommand komut = new SqlCommand("Select * from TRezervasyon", SqlBaglanti.con);  // Listeleme komutları
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();  // Veri okuyucuyu Veritabanı komutumuzla ilişkilendiriyoruz
            while (dr.Read())  // Okuma işlemi devam ettiği sürece olmasını istediklerimiz için WHİLE döngüsü kullanıyoruz
            {
                Rezervasyon t = new Rezervasyon();  // VARLIK Katmanındaki sınıfımızdan nesne türetiyoruz
                t.TC = dr[0].ToString(); // Nesne aracılığıyla ulaştığımız Propertielerimize Okuyucunun Index değerlerini Stringe çevirerek atıyoruz.
                t.Musteri = dr[1].ToString();
                t.Telefon = dr[2].ToString();
                t.Yas = dr[3].ToString();
                t.GirisTarih = dr[4].ToString();
                t.CikisTarih = dr[5].ToString();
                t.Cocuk = dr[6].ToString();
                t.Yetiskin = dr[7].ToString();
                t.OdaTipi = dr[8].ToString();
                t.Fiyat = Convert.ToInt32(dr[9].ToString());
                degerler.Add(t);
            }
            dr.Close();  // İşlem sonunda okuyucuyu kapatıyoruz.
            return degerler;  // Method olarak geriye Listeyi döndürüyoruz.
        }


        // BOOL türünde Rezervasyon sınıfından aldığı nesneyi parametre olarak kullanan Güncelleme Methodu
        public static bool RezervasyonGuncelle(Rezervasyon r)
        {
            SqlCommand komut = new SqlCommand("Update TRezervasyon Set Musteri=@p2,Telefon=@p3,Yas=@p4,GirisTarih=@p5,CikisTarih=@p6,Cocuk=@p7,Yetiskin=@p8,OdaTipi=@p9,Fiyat=@10 Where TC=@p1", SqlBaglanti.con); // Güncelleme komutları
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", r.TC);
            komut.Parameters.AddWithValue("@p2", r.Musteri);
            komut.Parameters.AddWithValue("@p3", r.Telefon);
            komut.Parameters.AddWithValue("@p4", r.Yas);
            komut.Parameters.AddWithValue("@p5", r.GirisTarih);
            komut.Parameters.AddWithValue("@p6", r.CikisTarih);
            komut.Parameters.AddWithValue("@p7", r.Cocuk);
            komut.Parameters.AddWithValue("@p8", r.Yetiskin);
            komut.Parameters.AddWithValue("@p9", r.OdaTipi);
            komut.Parameters.AddWithValue("@p10", r.Fiyat);
            komut.ExecuteNonQuery();
            SqlBaglanti.con.Close();
            return komut.ExecuteNonQuery() > 0;  // Method Bool tipinde olduğundan > 0 şeklinde geriye dönüş olarak Veritabanındaki işlemi gerçekleştir işlemini gerçekleştiriyor
        }
    }
}
