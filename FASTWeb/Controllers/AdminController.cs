using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FASTWeb.Common;

namespace FASTWeb.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize]
        public ActionResult Index()
        {
            FASTService.Process.TransactionProcess transProcess = new FASTService.Process.TransactionProcess();
            FASTService.Process.AccessRightProcess accessProcess = new FASTService.Process.AccessRightProcess();
            FASTService.Process.FixAssetManagementProcess fixProcess = new FASTService.Process.FixAssetManagementProcess();

            List<FASTService.vwAssetAssignmentsForCustodian> acceptances = new List<FASTService.vwAssetAssignmentsForCustodian>();
            List<FASTService.vwFixAssetList> repairs = new List<FASTService.vwFixAssetList>();
            List<FASTService.vwFixAssetList> releases = new List<FASTService.vwFixAssetList>();


            List<FASTService.AccessRight> access = new List<FASTService.AccessRight>();
            access = accessProcess.GetAccessEmployeeRight(User.Identity.Name.ToInteger());

            foreach( FASTService.AccessRight right in access)
            {
                acceptances.AddRange(transProcess.GetAssignmentsForReleaseCustodians(right.DepartmentID,User.Identity.Name.ToInteger()));
            }

            repairs = fixProcess.GetAssetsForRepair();
            releases = fixProcess.GetReleasedAssets();

            ViewBag.Acceptances = acceptances;
            ViewBag.Repairs = repairs;
            ViewBag.Releases = releases;


            return View();
        }
	}
}