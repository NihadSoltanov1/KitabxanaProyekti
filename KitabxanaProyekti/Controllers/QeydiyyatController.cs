using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    [AllowAnonymous]
    public class QeydiyyatController : Controller
    {
        // GET: Qeydiyyat
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult QeydiyyatView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QeydiyyatView(Istifadeci_Table p)
        {
            db.Istifadeci_Table.Add(p);
            db.SaveChanges();
            return View();
        }

    }
}