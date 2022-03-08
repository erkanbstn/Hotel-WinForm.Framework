using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Rezervasyon  // Rezervasyon İşlemlerini Tutacak Tabloya Denk Düşen Sınıf
    {
        /* Veritabanındaki tablomuzun bilgilerini Sınıflar üzerinde taşıyıp işlem yapmak için 
         Varlık Katmanı altında Rezervasyon Tablomuz ve Propertielerini oluşturduk.
         */
        public string TC { get; set; }  // Erişim belirleyicisi Public olan string türünde bir PROPERTIE 
        public string Musteri { get; set; }
        public string Telefon { get; set; }
        public string Yas { get; set; }
        public string GirisTarih { get; set; }
        public string CikisTarih { get; set; }
        public string Cocuk { get; set; }
        public string Yetiskin { get; set; }
        public string OdaTipi { get; set; }
        public int Fiyat { get; set; } // Erişim belirleyicisi Public olan int türünde bir PROPERTIE 
    }
}
