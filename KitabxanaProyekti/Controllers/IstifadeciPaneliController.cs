using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
using KitabxanaProyekti.Models.Sinifler;
namespace KitabxanaProyekti.Controllers
{
    [AllowAnonymous]
    public class IstifadeciPaneliController : Controller
    {
        // GET: IstifadeciPaneli
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();


        [HttpGet]
        public ActionResult Index()
        {
            Class1 a = new Class1();
            a.Deyer1 = db.Kitab_Table.ToList();
            a.Deyer2 = db.Haqqimizda_Table.ToList();
            return View(a);
        }
        [HttpPost]
        public ActionResult Index(Mesaj_Table p)
        {
            db.Mesaj_Table.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}