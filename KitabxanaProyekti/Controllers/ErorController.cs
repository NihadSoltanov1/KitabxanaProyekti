using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitabxanaProyekti.Controllers
{
    [AllowAnonymous]
    public class ErorController : Controller
    {
        // GET: Eror
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }


         
    }
}