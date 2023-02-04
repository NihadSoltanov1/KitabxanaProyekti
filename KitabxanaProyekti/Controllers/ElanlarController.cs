using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    public class ElanlarController : Controller
    {
        // GET: Elanlar
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult Index()
        {
            var elan1 = db.Elan_Table.ToList();
            return View(elan1);
        }
        [HttpGet]
        public ActionResult YeniElan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniElan (Elan_Table p)
        {
            db.Elan_Table.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ElanSil(int id)
        {
            var elan2 = db.Elan_Table.Find(id);
            db.Elan_Table.Remove(elan2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ElanGetir(int id)
        {
            var elan3 = db.Elan_Table.Find(id);
            return View("ElanGetir", elan3);
        }
        public ActionResult ElanGuncelle(Elan_Table p)
        {
            var elan4 = db.Elan_Table.Find(p.ID);
            elan4.Kategoriya = p.Kategoriya;
            elan4.Mezmun = p.Mezmun;
            elan4.Tarix = p.Tarix;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ElanDetay(int id)
        {
            var elan5 = db.Elan_Table.Find(id);
            ViewBag.eln = db.Elan_Table.Where(x => x.ID == id).Select(z => z.Kategoriya).FirstOrDefault();
            return View("ElanDetay", elan5);
        }
    
    }
}