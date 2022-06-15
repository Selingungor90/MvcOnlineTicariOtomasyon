using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList() select new SelectListItem { Text = x.Departmanad, Value = x.Departmanid.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList() select new SelectListItem { Text = x.Departmanad, Value = x.Departmanid.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            var g = c.Personels.Find(id);
            return View("PersonelGetir", g);
        }

        public ActionResult PersonelGuncelle(Personel d)
        {
            var prsn= c.Personels.Find(d.Personelid);
            prsn.PersonelAd = d.PersonelAd;
            prsn.PersonelSoyad = d.PersonelSoyad;
            prsn.PersonelGorsel = d.PersonelGorsel;
            prsn.departmanid = d.departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}