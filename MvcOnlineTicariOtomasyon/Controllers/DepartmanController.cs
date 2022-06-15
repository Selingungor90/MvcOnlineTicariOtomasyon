using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {

        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {

            var degerler = c.Departmen.Where(x=>x.Durum== true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var deger = c.Departmen.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var g = c.Departmen.Find(id);
            return View("DepartmanGetir", g);

        }
        
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dep = c.Departmen.Find(d.Departmanid);
            dep.Departmanad = d.Departmanad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x=>x.departmanid==id).ToList();
            var dpt = c.Departmen.Where(x => x.Departmanid == id).Select(y => y.Departmanad).FirstOrDefault();
            ViewBag.d = dpt;



            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id )
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd+" "+y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;

            return View(degerler);
        }
        
    
    }
}