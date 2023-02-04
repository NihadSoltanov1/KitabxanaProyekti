using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace KitabxanaProyekti.Controllers
{
    public class IstifadeciController : Controller
    {
        // GET: Istifadeci
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        //public ActionResult Index(int seyfe = 1)
        //{
        //    var ist1 = db.Istifadeci_Table.ToList().ToPagedList(seyfe, 3);
        //    return View("Index",ist1);
        //}
        public ActionResult Index()
        {
            var ist1 = db.Istifadeci_Table.ToList();
            return View("Index", ist1);
        }
        [HttpGet]
        public ActionResult IstifadeciElaveEt()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IstifadeciElaveEt(Istifadeci_Table p1)
        {
           
            db.Istifadeci_Table.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IstifadeciGetir(int id)
        {
            var ist3 = db.Istifadeci_Table.Find(id);
            return View("IstifadeciGetir", ist3);
        }

        public ActionResult IstifadeciGuncelle(Istifadeci_Table p)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("IstifadeciGetir");
            }
            var ist5 = db.Istifadeci_Table.Find(p.ID);
            ist5.Ad = p.Ad;
            ist5.Soyad = p.Soyad;
            ist5.IstifadeciAdi = p.IstifadeciAdi;
            ist5.Mail = p.Mail;
            ist5.Sifre = p.Sifre;
            ist5.Telefon = p.Telefon;
            ist5.TehsilYeri = p.TehsilYeri;
            db.SaveChanges();
            return View("Index");
        }
        public ActionResult IstifadeciSil (int id)
        {
            var ist3 = db.Istifadeci_Table.Find(id);
            db.Istifadeci_Table.Remove(ist3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitabKecmisi(int id)
        {
            var kitab = db.Emeliyyat_Table.Where(x => x.Istifadeci == id).ToList();
            ViewBag.ist = db.Istifadeci_Table.Where(x => x.ID == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            return View(kitab);
        }
    }
}