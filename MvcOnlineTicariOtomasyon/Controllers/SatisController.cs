using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList() select new SelectListItem { Text = x.Urunad, Value = x.Urunid.ToString() }).ToList();
            ViewBag.dgr1=deger1;
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList() select new SelectListItem { Text = x.CariAd+" "+x.CariSoyad, Value = x.Cariid.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger3 = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd+" "+x.PersonelSoyad, Value = x.Personelid.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortTimeString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList() select new SelectListItem { Text = x.Urunad, Value = x.Urunid.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList() select new SelectListItem { Text = x.CariAd + " " + x.CariSoyad, Value = x.Cariid.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger3 = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.Personelid.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var satis = c.SatisHarekets.Find(id);
            return View("SatisGetir", satis);

        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var sts = c.SatisHarekets.Find(s.Satisid);
            sts.Cariid = s.Cariid;
            sts.Adet = s.Adet;
            sts.Fiyat = s.Fiyat;
            sts.Personelid = s.Personelid;
            sts.Tarih = s.Tarih;
            sts.ToplamTutar = s.ToplamTutar;
            sts.Urunid = s.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}