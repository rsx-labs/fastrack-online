using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Process
{
    public class AccessRightProcess : BaseProcess
    {
       public List<AccessRight> GetAccessEmployeeRight(int employeeID)
        {
              return (from access in FastDB.AccessRights
                       where access.EmployeeID == employeeID
                       select access).ToList();
           
        }

        public bool HasAccessMode(int employeeID, int accessLevel)
       {
            List<AccessRight> res = (from access in FastDB.AccessRights
                           where access.EmployeeID == employeeID && access.AccessLevel == accessLevel
                           select access).ToList();

                if (res != null)
                {
                    if (res.Count() > 0)
                    {
                        return true;
                    }
                }

                return false;
            
       }


    }
}
