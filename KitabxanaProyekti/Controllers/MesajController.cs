using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GelenMesajlar()
        {
            var email1 = (string)Session["Mail"];
            var mesaj1 = db.IstifadeciMesaj_Table.Where(x => x.QebulEden == email1.ToString()).ToList();

            return View(mesaj1);
        }
        public ActionResult GonderilenMesajlar()
        {
            var email2 = (string)Session["Mail"];
            var mesaj2 = db.IstifadeciMesaj_Table.Where(x => x.Gonderen == email2.ToString()).ToList();
            return View(mesaj2);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(IstifadeciMesaj_Table p)
        {
            var email3 = (string)Session["Mail"];
            p.Gonderen = email3.ToString();
            db.IstifadeciMesaj_Table.Add(p);
            db.SaveChanges();
            return RedirectToAction("GonderilenMesajlar", "Mesaj");
        }

        public ActionResult Partial1()
        {
            var email1 = (string)Session["Mail"];
            var deyer1 = db.IstifadeciMesaj_Table.Where(x => x.QebulEden == email1.ToString()).Count();
            ViewBag.dyr1 = deyer1;

            var deyer2 = db.IstifadeciMesaj_Table.Where(x => x.Gonderen == email1.ToString()).Count();
            ViewBag.dyr2 = deyer2;

            return PartialView();
        }

    }
}