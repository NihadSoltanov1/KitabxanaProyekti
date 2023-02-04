using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    [Authorize]
    public class IstifadeciSidebarController : Controller
    {
        // GET: IstifadeciSidebar
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        [HttpGet]
       [Authorize]
        public ActionResult Index()
        {
            var melumat1 = (string)Session["Mail"];

            var elan = db.Elan_Table.ToList();
            var deyer1 = db.Istifadeci_Table.Where(x => x.Mail == melumat1.ToString()).Select(x => x.Ad).FirstOrDefault();
            var deyer2 = db.Istifadeci_Table.Where(x => x.Mail == melumat1).Select(x => x.Soyad).FirstOrDefault();
            ViewBag.AdSoyad = deyer1 + " " + deyer2;

            var id = db.Istifadeci_Table.Where(x => x.Mail == melumat1.ToString()).Select(X => X.ID).FirstOrDefault();
            var deyer3 = db.Emeliyyat_Table.Where(x => x.Istifadeci == id).Count();
            ViewBag.dyr3 = deyer3;

            var deyer4 = db.IstifadeciMesaj_Table.Where(x => x.QebulEden == melumat1.ToString()).Count();
            ViewBag.dyr4 = deyer4;

            var deyer5 = db.Elan_Table.Count();
            ViewBag.dyr5 = deyer5;

            var deyer7 = db.Istifadeci_Table.Where(x => x.ID == id).Select(x => x.TehsilYeri).FirstOrDefault();
            ViewBag.dyr7 = deyer7;

            var deyer6 = db.Istifadeci_Table.Where(x => x.ID == id).Select(x => x.IstifadeciAdi).FirstOrDefault();
            ViewBag.dyr6 = deyer6;

            var deyer8 = db.Istifadeci_Table.Where(x => x.ID == id).Select(x => x.Telefon).FirstOrDefault();
            ViewBag.dyr8 = deyer8;

            var deyer9 = db.Istifadeci_Table.Where(x => x.ID == id).Select(x => x.Mail).FirstOrDefault();
            ViewBag.dyr9 = deyer9;

            return View(elan);
        }
        [HttpPost]
        
        public ActionResult Index2(Istifadeci_Table p)
        {
            var melumat3 = (string)Session["Mail"];
            var melumat4 = db.Istifadeci_Table.FirstOrDefault(x => x.Mail == melumat3);
            melumat4.Ad = p.Ad;
            melumat4.Soyad = p.Soyad;
            melumat4.IstifadeciAdi = p.IstifadeciAdi;
            melumat4.Mail = p.Mail;
            melumat4.Sifre = p.Sifre;
            melumat4.Telefon = p.Telefon;
            melumat4.Foto = p.Foto;
            melumat4.TehsilYeri = p.TehsilYeri;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Partial1()
        {
            return PartialView();
        }

        public ActionResult Partial2()
        {
            var melumat1 = (string)Session["Mail"];
            var melumat2 = db.Istifadeci_Table.FirstOrDefault(x => x.Mail == melumat1);
            return PartialView("Partial2", melumat2);
        }

        public ActionResult Kitablarim()
        {
            var melumat1 = (string)Session["Mail"];
            var id = db.Istifadeci_Table.Where(x => x.Mail == melumat1.ToString()).Select(x => x.ID).FirstOrDefault();
            var emeliyyat = db.Emeliyyat_Table.Where(x => x.Istifadeci == id).ToList();
            return View(emeliyyat);
        }

      
    }
}