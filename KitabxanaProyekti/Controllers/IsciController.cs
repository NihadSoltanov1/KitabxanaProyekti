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
    public class IsciController : Controller
    {
        // GET: Isci
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult Index(int seyfe = 1)
        {
            var ishc = db.Isci_Table.ToList().ToPagedList(seyfe, 5);
            return View(ishc);
        }
        [HttpGet]
        public ActionResult IsciElaveEt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IsciElaveEt(Isci_Table p1)
        {
            if (!ModelState.IsValid)
            {
                return View("IsciElaveEt");
            }
            db.Isci_Table.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IsciGetir(int id)
        {

            var isci2 = db.Isci_Table.Find(id);
            return View("IsciGetir", isci2);
        }

        public ActionResult IsciGuncelle(Isci_Table p6)
        {
            if (!ModelState.IsValid)
            {
                return View("IsciGetir");
            }
            var isci6 = db.Isci_Table.Find(p6.ID);
            isci6.Isci = p6.Isci;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IsciSil(int id)
        {
            var isci2 = db.Isci_Table.Find(id);
            db.Isci_Table.Remove(isci2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}