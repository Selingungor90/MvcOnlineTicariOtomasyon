using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunlerController : Controller
    {
        Context c = new Context();
        // GET: Urunler
        public ActionResult Index()
        {
            var Urunler = c.Urunlers.Where(x=>x.Durum==true).ToList();
            return View(Urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList() select new SelectListItem {Text=x.KategoriAd , Value=x.KategoriID.ToString()}).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler u)
        {
            c.Urunlers.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Urunlers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList() select new SelectListItem { Text = x.KategoriAd, Value = x.KategoriID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            var urun = c.Urunlers.Find(id);
            return View("UrunGetir",urun);
        }
        public ActionResult UrunGuncelle(Urunler p)
        {
            var urn = c.Urunlers.Find(p.Urunid);
            urn.AlısFiyat = p.AlısFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyatı = p.SatisFiyatı;
            urn.Stok = p.Stok;
            urn.Urunad = p.Urunad;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public  ActionResult UrunListesi()
        {
            var degerler = c.Urunlers.ToList();
            return View(degerler);
        }
    }
}