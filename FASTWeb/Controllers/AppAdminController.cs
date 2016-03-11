using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FASTWeb.Controllers
{
    public class AppAdminController : Controller
    {
        //
        // GET: /AppAdmin/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
	}
}