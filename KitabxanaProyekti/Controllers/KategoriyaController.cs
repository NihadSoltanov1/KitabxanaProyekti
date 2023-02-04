using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    public class KategoriyaController : Controller
    {
        // GET: Kategoriya
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult Index()
        {
            var ktgr1 = db.Kategoriya_Table.Where(k=>k.Veziyyet==true).ToList();
            return View(ktgr1);
        }
        [HttpGet]
        public ActionResult KategoriyaElaveEt()
        {
            return View("KategoriyaElaveEt");
        }
        [HttpPost]
        public ActionResult KategoriyaElaveEt(Kategoriya_Table p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriyaElaveEt");
            }
            p.Veziyyet = true;
            db.Kategoriya_Table.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriyaSil(int id)
        {
            var ktgr2 = db.Kategoriya_Table.Find(id);
            ktgr2.Veziyyet = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriyaGetir(int id)
        {
            
            var ktgr3 = db.Kategoriya_Table.Find(id);
            return View("KategoriyaGetir", ktgr3);
        }

        public ActionResult KategoriyaGuncelle(Kategoriya_Table c)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriyaGetir");
            }
            var ktgr4 = db.Kategoriya_Table.Find(c.ID);
            ktgr4.Ad = c.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}