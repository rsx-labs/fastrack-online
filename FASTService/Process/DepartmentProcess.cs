using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FASTService.Model;
namespace FASTService.Process
{
    public class DepartmentProcess : BaseProcess
    {
        public List<Department> GetDepartments()
        {
            return FastDB.Departments.ToList();
        }


        public vwDepartmentList GetDepartmentDetail(int departmentID)
        {

            using (var db = FastDB)
            {
                List<vwDepartmentList> result = (from dept in db.vwDepartmentLists
                                           where dept.DepartmentID == departmentID
                                           select dept).ToList();

                if (result != null)
                {
                    return result[0];
                }
            }

            return null;
        }
    }

}
