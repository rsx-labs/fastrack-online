using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FASTService.Model;

namespace FASTService.Process
{
    public class AssignmentProcess : BaseProcess
    {
        public List<vwAssetAssignment> GetAllAssignmentByEmployeeID( int employeeID)
        {
            List<vwAssetAssignment> assignments = (from assigns in FastDB.vwAssetAssignments
                                                   where assigns.EmployeeID == employeeID
                                                   select assigns).ToList();

            return assignments;
        }

        public List<vwAssetAssignment> GetCurrentAssignmentByEmployeeID(int employeeID)
        {
            List<vwAssetAssignment> assignments = (from assigns in FastDB.vwAssetAssignments
                                                   where assigns.EmployeeID == employeeID 
                                                   && assigns.AssignmentStatusID == Common.Constants.ASSIGNMENT_STATUS_ACCEPTED 
                                                   && assigns.AssetStatusID == Common.Constants.ASSET_STATUS_ASSIGNED
                                                   select assigns).ToList();

            return assignments;
        }

        public List<vwAssetAssignment> GetForAcceptanceAssignmentByEmployeeID(int employeeID)
        {
            List<vwAssetAssignment> assignments = (from assigns in FastDB.vwAssetAssignments
                                                   where assigns.EmployeeID == employeeID
                                                   && assigns.AssignmentStatusID == Common.Constants.ASSIGNMENT_STATUS_WT_ACCEPTANCE
                                                   && assigns.AssetStatusID == Common.Constants.ASSET_STATUS_ASSIGNED
                                                   select assigns).ToList();

            return assignments;
        }


        public vwAssetAssignment GetAssignmentByID(int assignID)
        {
            List<vwAssetAssignment> assignments = (from assigns in FastDB.vwAssetAssignments
                                                   where assigns.AssetAssignmentID == assignID
                                                   select assigns).ToList();

            if ( assignments != null )
            {
                return assignments[0];
            }

            return null;
        }

    }
}
