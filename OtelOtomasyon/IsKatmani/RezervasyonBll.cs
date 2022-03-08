using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;
using VeriErisimKatmani;

namespace IsKatmani
{
    public class RezervasyonBll  // Veri Erişim Katmanındaki Methodların Kontrolünün Yapıldığı Sınıf
    {

        /* Veri Erişim Katmanındaki Ekleme Methodumuzu Şartlarımıza Göre Çalıştırmak İçin
         İş Katmanında Kontrollerimizi Yaptığımız ve Geriye Veri Erişim Katmanındaki Methodu
         Döndürdüğümüz Methodumuzu Yazdık.*/
        public static int RezervasyonEkleBll(Rezervasyon r) // INT tipinde Rezervasyon Sınıfından Türetilen Nesneyi Parametre Alan Method
        {
            if (r.Fiyat < 0 || r.Fiyat != 0) // Parametredeki Fiyat değeri var mı yok mu boş mu kontrolü
            {
                return RezervasyonDal.RezervasyonEkle(r); // Parametre varsa Veri Erişim Katmanındaki Methodun İçerisinde İstenilen Parametreyi Direkt Atadık.
            }
            return -1; // Eğer parametre boşsa Methodun tipi int olduğu için -1 değeri döndürecek yani İşlem yapmayacak
        }


        /* Veri Erişim Katmanındaki Silme Methodumuzu Şartlarımıza Göre Çalıştırmak İçin
        İş Katmanında Kontrollerimizi Yaptığımız ve Geriye Veri Erişim Katmanındaki Methodu
        Döndürdüğümüz Methodumuzu Yazdık.*/
        public static bool RezervasyonSilBll(string tc)  //  Parametre olarak string tc girilmesi Veritabanında TC ye göre Silme işlemi yapması sağlanıyor
        {
            if (tc != "" && tc != null)  // Parametre var mı yok mu boş mu kontrolü
            {
                return RezervasyonDal.RezervasyonSil(tc);  // Parametre varsa Veri Erişim Katmanındaki Methodun İçerisinde İstenilen Parametreyi Direkt Atadık.
            }
            return false;  // Eğer parametre boşsa Methodun tipi BOOL olduğu için False değeri döndürecek yani İşlem yapmayacak
        }

        /* Veri Erişim Katmanındaki Güncelleme Methodumuzu Şartlarımıza Göre Çalıştırmak İçin
      İş Katmanında Kontrollerimizi Yaptığımız ve Geriye Veri Erişim Katmanındaki Methodu
      Döndürdüğümüz Methodumuzu Yazdık.*/
        public static bool RezervasyonGuncelleBll(Rezervasyon r) // Bool tipinde Rezervasyon Sınıfından Türetilen Nesneyi Parametre Alan Method
        {
            if (r.TC != "" && r.TC != null && r.Fiyat < 0) // Parametre var mı yok mu boş mu kontrolü
            {
                return RezervasyonDal.RezervasyonGuncelle(r); // Parametre varsa Veri Erişim Katmanındaki Methodun İçerisinde İstenilen Parametreyi Direkt Atadık.
            } 
            return false; // Eğer parametre boşsa Methodun tipi BOOL olduğu için False değeri döndürecek yani İşlem yapmayacak
        }

        /* Veri Erişim Katmanındaki Listeleme Methodumuzu Şartsız Yazdık.*/
        public static List<Rezervasyon> RezervasyonListeleBll()  // Listeleme İşlemi İçin Kontrol Yapmamıza Gerek Yok
        {
            return RezervasyonDal.RezervasyonListesi();  // Bu Sebeple Direkt Veri Erişim Katmanındaki Listeleme Methodumuzu Çağırdık
        }
    }
}
