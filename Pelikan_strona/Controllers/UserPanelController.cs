using Pelikan_strona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pelikan_strona.Controllers
{
    
    public class UserPanelController : Controller
    {
        //
        // GET: /ListaPolis/
      
       [Authorize]
        public ActionResult WidokGłowny()
        {

          
            return PartialView();
        }

        public ActionResult Lista()
        {

            
            return View();
        }
    }
}
