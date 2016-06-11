using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FASTWeb.Models;

namespace FASTWeb.Controllers
{
    public class AssignmentController : Controller
    {
        //
        private enum ACTION{
            ACCEPTREJECT = 0,
            APPROVEDENY =1,
            TRANSFERRELEASE = 2
        };

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ManageAssignment(int assignID)
        {
            Models.Assignment.ManageAssignmentViewModel model = new Models.Assignment.ManageAssignmentViewModel();
            model.FillData(assignID);

            if (model.AssignmentStatusID == 3)
            {
                ViewBag.Action = 2;
            }
            else if ( model.AssignmentStatusID == 1)
            {
                ViewBag.Action = 1;
            }
            else
            {
                ViewBag.Action = 0;
            }

      
            return View(model);
        }


        [HttpPost]
        [Authorize]
        public ActionResult ManageAssignment(Models.Assignment.ManageAssignmentViewModel model)
        {

            return RedirectToAction("Unavailable", "Home");
        }

	}
}