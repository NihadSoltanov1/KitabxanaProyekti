using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    public class KitabController : Controller
    {
        // GET: Kitab
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult Index(string p)
        {
            var kitab = from i in db.Kitab_Table select i;
            if (!string.IsNullOrEmpty(p))
            {
                kitab = kitab.Where(k => k.Ad.Contains(p));
            }
            return View(kitab.ToList());
        }
        [HttpGet]
        public ActionResult KitabElaveEt()
        {


            List<SelectListItem> deyer1 = (from i in db.Kategoriya_Table
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deyer2 = (from y in db.Yazici_Table
                                           select new SelectListItem
                                           {
                                               Text = y.Ad,
                                               Value = y.ID.ToString()
                                           }).ToList();
            ViewBag.dyr1 = deyer1;
            ViewBag.dyr2 = deyer2;
            return View("KitabElaveEt");
        }
        [HttpPost]
        public ActionResult KitabElaveEt(Kitab_Table p1)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("KitabElaveEt");
            //}

            var ktg1 = db.Kategoriya_Table.Where(k => k.ID == p1.Kategoriya_Table.ID).FirstOrDefault();
            var yzr1 = db.Yazici_Table.Where(y => y.ID == p1.Yazici_Table.ID).FirstOrDefault();
            p1.Kategoriya_Table = ktg1;
            p1.Yazici_Table = yzr1;
            p1.Veziyyet = true;
            db.Kitab_Table.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult KitabSil(int id)
        {
            var ktb = db.Kitab_Table.Find(id);
            db.Kitab_Table.Remove(ktb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitabGetir(int id)
        {
            var ktb2 = db.Kitab_Table.Find(id);
            List<SelectListItem> deyer1 = (from i in db.Kategoriya_Table
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deyer2 = (from y in db.Yazici_Table
                                           select new SelectListItem
                                           {
                                               Text = y.Ad,
                                               Value = y.ID.ToString()
                                           }).ToList();
            ViewBag.dyr1 = deyer1;
            ViewBag.dyr2 = deyer2;
            return View("KitabGetir", ktb2);
        }
        public ActionResult KitabGuncelle(Kitab_Table p1)
        {
            var ktb3 = db.Kitab_Table.Find(p1.ID);

            ktb3.YayinEvi = p1.YayinEvi;
            ktb3.NesrTarix = p1.NesrTarix;
            ktb3.Seyfe = p1.Seyfe;
            var ktg1 = db.Kategoriya_Table.Where(k => k.ID == p1.Kategoriya_Table.ID).FirstOrDefault();
            var yzr1 = db.Yazici_Table.Where(y => y.ID == p1.Yazici_Table.ID).FirstOrDefault();
            ktb3.Kategoriya = ktg1.ID;
            ktb3.Yazici = yzr1.ID;
            db.SaveChanges();
            return RedirectToAction("Index","Kitab");
        }

    }
}