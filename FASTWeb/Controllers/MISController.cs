using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FASTWeb.Common;

namespace FASTWeb.Controllers
{
    public class MISController : Controller
    {
        //
        // GET: /MIS/
        [Authorize]
        public ActionResult Index()
        {
            FASTService.Process.AccessRightProcess accessProcess = new FASTService.Process.AccessRightProcess();
            FASTService.Process.TransactionProcess transProcess = new FASTService.Process.TransactionProcess();

            List<FASTService.vwAssetAssignmentsForMI> assignments = new List<FASTService.vwAssetAssignmentsForMI>();
            List<FASTService.vwAssetAssignmentsForMI> acceptances = new List<FASTService.vwAssetAssignmentsForMI>();

            List<FASTService.AccessRight> access = accessProcess.GetAccessEmployeeRight(User.Identity.Name.ToInteger());

            foreach( FASTService.AccessRight right in access)
            {
                assignments.AddRange(transProcess.GetAssignmentsForMIS(right.DepartmentID, User.Identity.Name.ToInteger()));
                acceptances.AddRange(transProcess.GetAssignmentForAcceptanceMIS(right.DepartmentID, User.Identity.Name.ToInteger()));
            }

            ViewBag.Acceptances = acceptances;
            ViewBag.Assignments = assignments;

            return View();
        }


	}
}