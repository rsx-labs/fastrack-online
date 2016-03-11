using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FASTWeb.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        public ActionResult Index()
        {

            int empID = 0;
            Int32.TryParse(User.Identity.Name, out empID);

            FASTService.Process.EmployeeManagementProcess empProcess = new FASTService.Process.EmployeeManagementProcess();
            FASTService.Process.DepartmentProcess deptProcess= new FASTService.Process.DepartmentProcess();
            FASTService.Model.EmployeeDashboardViewModel emp = empProcess.GetEmployeeCompleteProfile(empID);
            List<FASTService.vwDepartmentList> departments = new List<FASTService.vwDepartmentList>();

            if (emp.accessRights != null)
            {
                foreach(FASTService.AccessRight access in emp.accessRights)
                {
                    departments.Add(deptProcess.GetDepartmentDetail(access.DepartmentID));
                }
            }

            return View(departments);
        }

        [HttpPost]
        public ActionResult Index(int departmentID)
        {
            return RedirectToAction("MyDepartment", new  { departmentID=departmentID });
        }

        [Authorize]
        public ActionResult MyDepartment(int departmentID)
        {
            FASTService.Process.DepartmentProcess deptProcess= new FASTService.Process.DepartmentProcess();
            FASTService.vwDepartmentList department = deptProcess.GetDepartmentDetail(departmentID);
            TempData["Department"] = department;

            return View();
        }

        [Authorize]
        public ActionResult Others()
        {
            return PartialView("_PartialManageUnavailable.cshtml");
        }

        
	}
}