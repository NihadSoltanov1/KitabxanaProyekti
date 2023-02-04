using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KitabxanaProyekti.Models.Entity;
namespace KitabxanaProyekti.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin_Table p)
        {
            var melumat = db.Admin_Table.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (melumat != null)
            {
                FormsAuthentication.SetAuthCookie(melumat.Mail, false);
                Session["Mail"] = p.Mail.ToString();
                return RedirectToAction("Index", "Statistika");
            }
            else
            {
                return View();
            }
            

        }

    }
}