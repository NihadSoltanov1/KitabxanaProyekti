using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitabxanaProyekti.Models.Entity;
using System.Web.Security;
namespace KitabxanaProyekti.Controllers
{
    [AllowAnonymous]
    public class GirisController : Controller
    {
        // GET: Giris
        KitabxanaDBEntities1 db = new KitabxanaDBEntities1();
        public ActionResult GirisView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisView(Istifadeci_Table p)
        {
            var melumatlar = db.Istifadeci_Table.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (melumatlar != null)
            {
                FormsAuthentication.SetAuthCookie(melumatlar.Mail, false);
                Session["Mail"] = melumatlar.Mail.ToString();
                return RedirectToAction("Index", "IstifadeciSidebar");
            }
            else
            {
                return View();

            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisView");
        }
    }
}

//Session["Soyad"] = p.Soyad.ToString();
//Session["IstifadeciAdi"] = p.IstifadeciAdi.ToString();
//Session["Sifre"] = p.Sifre.ToString();
//Session["Telefon"] = p.Telefon.ToString();
//Session["Foto"] = p.Foto.ToString();
//Session["Mekteb"] = p.Mekteb.ToString();