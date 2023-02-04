using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    public class KitabVerController : Controller
    {
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        // GET: KitabVer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult KitabVer()
        {
            List<SelectListItem> deyer1 = (from i in db.Kitab_Table.Where(x => x.Veziyyet == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deyer2 = (from i in db.Istifadeci_Table.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deyer3 = (from i in db.Isci_Table.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Isci,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dyr1 = deyer1;
            ViewBag.dyr2 = deyer2;
            ViewBag.dyr3 = deyer3;
            return View();
        }
        [HttpPost]
        public ActionResult KitabVer(Emeliyyat_Table p)
        {
            var deyer1 = db.Kitab_Table.Where(x => x.ID == p.Kitab_Table.ID).FirstOrDefault();
            var deyer2 = db.Istifadeci_Table.Where(x => x.ID == p.Istifadeci_Table.ID).FirstOrDefault();
            var deyer3 = db.Isci_Table.Where(x => x.ID == p.Isci_Table.ID).FirstOrDefault();
            p.Kitab_Table = deyer1;
            p.Istifadeci_Table = deyer2;
            p.Isci_Table = deyer3;
            db.Emeliyyat_Table.Add(p);
            db.SaveChanges();
            return RedirectToAction("KitabQaytar","KitabVer");
        }

        public ActionResult KitabQaytar()
        {
            var emeliyyat2 = db.Emeliyyat_Table.Where(e => e.EmeliyyatVeziyyet == true).ToList();
            return View(emeliyyat2);
        }

        public ActionResult KitabQaytarGetir(Emeliyyat_Table p)
        {
            var emeliyyat5 = db.Emeliyyat_Table.Find(p.ID);
            DateTime gun1 = Convert.ToDateTime(emeliyyat5.QaytarmaTarix.ToString());
            DateTime gun2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan gunferq = gun2 - gun1;
            ViewBag.gun = gunferq.TotalDays;
            return View("KitabQaytarGetir", emeliyyat5);
        }

        public ActionResult KitabQaytarGuncelle(Emeliyyat_Table p)
        {
            var emeliyyat6 = db.Emeliyyat_Table.Find(p.ID);
            emeliyyat6.IstifadeciQaytarmaTarix = p.IstifadeciQaytarmaTarix;
            emeliyyat6.EmeliyyatVeziyyet = false;
            db.SaveChanges();
            return RedirectToAction("KitabQaytar");
        }

        public ActionResult KitabQaytarKecmisi()
        {
            var emeliyyat2 = db.Emeliyyat_Table.Where(e => e.EmeliyyatVeziyyet == false).ToList();
            return View(emeliyyat2);
        }

    }
}