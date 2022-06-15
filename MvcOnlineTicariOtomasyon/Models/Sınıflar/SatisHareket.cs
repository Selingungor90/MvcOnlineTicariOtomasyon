using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int Satisid { get; set; }
        //Ürün ne satıldı ?
        //Cari kime satıldı ?
        //Personel kim sattı ?
        //Tarih Ne zaman satıldı ?
        //Adet kaç tane sattık ?

        //İlişkileri ürün cari ve personel olcak
        public DateTime Tarih{ get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }
        public virtual Urunler Urunler { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
        



    }
}