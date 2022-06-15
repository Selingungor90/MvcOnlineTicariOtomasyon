using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Key oluşturmak için kullandığımız kütüphane
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Kategori
    {
        [Key] //Tabloda Primary Key oluşturmak için kullanıyoruz
        public  int KategoriID { get; set; } //Tablo sütunları
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String KategoriAd { get; set;}
        public IComparable<Urunler> Uruns { get; set;} //Birden fazla ürünü veri tabanında tutabilecek icollection 
    }
}