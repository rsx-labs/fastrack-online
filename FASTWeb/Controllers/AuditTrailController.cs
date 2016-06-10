using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FASTWeb.Controllers
{
    public class AuditTrailController : Controller
    {
        //
        // GET: /AuditTrail/
        [Authorize]
        public ActionResult Index()
        {
            FASTService.Process.AuditTrailProcess trailProcess = new FASTService.Process.AuditTrailProcess();
            List<FASTService.AuditTrail> trails = trailProcess.GetAuditTrails();
            return View(trails);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Search(string startDate, string employeeID, string assetTag, string assignmentID)
        {
            TempData["StartDate"] = startDate;
            TempData["EmployeeID"] = employeeID;
            TempData["AssetTag"] = assetTag;
            TempData["AssignmentID"] = assignmentID;

            FASTService.Process.AuditTrailProcess trailProcess = new FASTService.Process.AuditTrailProcess();
            List<FASTService.AuditTrail> trails = trailProcess.SearchAuditTrail(startDate, employeeID, assetTag, assignmentID);


            if (Request["Search"] != null)
            {
                
                return View("Index", trails);
            }
            else
            {
                return View("AuditReport", trails);
            }


            
        }
    }

       
}