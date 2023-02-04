using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    public class StatistikaController : Controller
    {

        // GET: Statistika
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult Index()
        {
            var deyer1 = db.Ceza_Table.Sum(x => x.Cerime);
            var deyer2 = db.Istifadeci_Table.Count();
            var deyer3 = db.Kitab_Table.Count();
            var deyer4 = db.Kitab_Table.Where(x => x.Veziyyet == false).Count();
            ViewBag.dyr1 = deyer1;
            ViewBag.dyr2 = deyer2;
            ViewBag.dyr3 = deyer3;
            ViewBag.dyr4 = deyer4;
            return View();
        }

        public ActionResult Galeriya()
        {
            return View();
        }

        public ActionResult resimyukle(HttpPostedFileBase fayl)
        {
            if (fayl.ContentLength > 0)
            {
                string fayl1 = Path.Combine(Server.MapPath("~/web2/images/"), Path.GetFileName(fayl.FileName));
                fayl.SaveAs(fayl1);
            }
            return RedirectToAction("Galeriya");
        }
    }
}