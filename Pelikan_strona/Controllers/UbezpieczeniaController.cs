using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pelikan.Controllers
{
    public class UbezpieczeniaController : Controller
    {
        //
        // GET: /Ubezpieczenia/

        public ActionResult NaZycie()
        {
            return View();
        }

        public ActionResult Turystyczne()
        {
            return View();
        }
        public ActionResult Zdrowotne()
        {
            return View();
        }

    }
}
