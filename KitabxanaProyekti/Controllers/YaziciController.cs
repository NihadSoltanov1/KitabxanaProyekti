using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    public class YaziciController : Controller
    {
        // GET: Yazici
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult Index()
        {
            var yzr1 = db.Yazici_Table.ToList();
            return View(yzr1);

        }
        [HttpGet]
        public ActionResult YaziciElaveEt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YaziciElaveEt(Yazici_Table p1)
        {
            db.Yazici_Table.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YaziciSil(int id)
        {
            var yzr2 = db.Yazici_Table.Find(id);
            db.Yazici_Table.Remove(yzr2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YaziciGetir(int id)
        {
            var yzr3 = db.Yazici_Table.Find(id);
            return View("YaziciGetir", yzr3);
        }

        public ActionResult YaziciGuncelle(Yazici_Table p)
        {
            var yzr4 = db.Yazici_Table.Find(p.ID);
            yzr4.Ad = p.Ad;
            yzr4.Soyad = p.Soyad;
            yzr4.Aciqlama = p.Aciqlama;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazicininKitablari(int id)
        {
            var melumatlar3 = db.Kitab_Table.Where(k => k.Yazici == id).ToList();
            ViewBag.yzr = db.Yazici_Table.Where(x => x.ID == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            return View(melumatlar3);
        }

    }
}