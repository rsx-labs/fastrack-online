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

        [Authorize]
        public ActionResult ViewAccessRights()
        {
            List<FASTService.vwAccessRight> rights = new List<FASTService.vwAccessRight>();
            FASTService.Process.AccessRightProcess accessProcess = new FASTService.Process.AccessRightProcess();

            rights = accessProcess.GetAccesRightsView();

            return View(rights);
        }

        //[Authorize]
        //public ActionResult NewAccess()
	}
}