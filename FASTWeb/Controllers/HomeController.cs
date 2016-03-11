using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FASTWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (Request.IsAuthenticated)
            {
                //If authenticated, should go to the Dashboard. For now, lets assume that the Dashboard is the report page
                return RedirectToAction("MyAssets", "Employee");
            }
            else
            {
                return RedirectToAction("Login", "Authenticate");
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Unavailable()
        {
            return View();
        }

      
    }
}