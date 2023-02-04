using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    public class AyarlarController : Controller
    {
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        // GET: Ayarlar
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="A")]
        public ActionResult AdminAyarlar()
        {
            var admin = db.Admin_Table.ToList();
            return View("AdminAyarlar", admin);
        }
        [HttpPost]
        public ActionResult YeniAdmin(Admin_Table p)
        {
            db.Admin_Table.Add(p);
            db.SaveChanges();
            return RedirectToAction("AdminAyarlar");
        }

        public ActionResult AdminSil(int id)
        {
            var admin1 = db.Admin_Table.Find(id);
            db.Admin_Table.Remove(admin1);
            db.SaveChanges();
            return RedirectToAction("AdminAyarlar");
        }

        public ActionResult AdminGetir(int id)
        {
            var admin2 = db.Admin_Table.Find(id);
            return View("AdminGetir", admin2);
        }

        public ActionResult AdminGuncelle(Admin_Table p)
        {
            var admin3 = db.Admin_Table.Find(p.ID);
            admin3.Mail = p.Mail;
            admin3.Sifre = p.Sifre;
            admin3.Vezife = p.Vezife;
            db.SaveChanges();
            return RedirectToAction("AdminAyarlar", "Ayarlar");
                                     
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminAyarlar","Ayarlar");
        }
    }
}