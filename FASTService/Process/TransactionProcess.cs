using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Process
{
    public class TransactionProcess : BaseProcess
    {
        public List<vwAssetAssignment> GetAssetAssignments(int employeeID)
        {
            return ( from assigns in FastDB.vwAssetAssignments
                     where assigns.EmployeeID == employeeID
                     select new vwAssetAssignment
                     {
                         AssetAssignmentID = assigns.AssetAssignmentID,
                         AssetClassID = assigns.AssetClassID,
                         AssetRemarks = assigns.AssetRemarks,
                         AssetStatusID = assigns.AssetStatusID,
                         AssetTag = assigns.AssetTag,
                         AssetTypeID = assigns.AssetTypeID,
                         AssignmentRemarks = assigns.AssignmentRemarks,
                         AssignmentStatus = assigns.AssignmentStatus,
                         AssignmentStatusID = assigns.AssignmentStatusID,
                         Brand = assigns.Brand,
                         ClassDescription = assigns.ClassDescription,
                         Country = assigns.Country,
                         DateAssigned = assigns.DateAssigned,
                         DateReleased = assigns.DateReleased,
                         EmployeeID = assigns.EmployeeID,
                         FixAssetID = assigns.FixAssetID,
                         FromID = assigns.FromID,
                         LocationID = assigns.LocationID,
                         LocationName = assigns.LocationName,
                         Model = assigns.Model,
                         SerialNumber = assigns.SerialNumber,
                         StatusDescription = assigns.StatusDescription,
                         ToID = assigns.ToID,
                         TypeDescription = assigns.TypeDescription,
                         
                     }).ToList();
        }

        public List<vwAssetAssignmentsForCustodian> GetAssetAssignmentsForCustodianByEmpID(int employeeID)
        {
            return (from assigns in FastDB.vwAssetAssignmentsForCustodians
                    where assigns.AdminID == employeeID
                    select new vwAssetAssignmentsForCustodian
                    {
                        AssetAssignmentID = assigns.AssetAssignmentID,
                        AssetClassID = assigns.AssetClassID,
                        AssetRemarks = assigns.AssetRemarks,
                        AssetStatusID = assigns.AssetStatusID,
                        AssetTag = assigns.AssetTag,
                        AssetTypeID = assigns.AssetTypeID,
                        AssignmentRemarks = assigns.AssignmentRemarks,
                        AssignmentStatus = assigns.AssignmentStatus,
                        AssignmentStatusID = assigns.AssignmentStatusID,
                        Brand = assigns.Brand,
                        ClassDescription = assigns.ClassDescription,
                        Country = assigns.Country,
                        DateAssigned = assigns.DateAssigned,
                        DateReleased = assigns.DateReleased,
                        EmployeeID = assigns.EmployeeID,
                        FixAssetID = assigns.FixAssetID,
                        FromID = assigns.FromID,
                        LocationID = assigns.LocationID,
                        LocationName = assigns.LocationName,
                        Model = assigns.Model,
                        SerialNumber = assigns.SerialNumber,
                        StatusDescription = assigns.StatusDescription,
                        ToID = assigns.ToID,
                        TypeDescription = assigns.TypeDescription,
                        AdminID = assigns.AdminID,
                        DepartmentID = assigns.DepartmentID
                        
                        
                    }).ToList();
        }

        public List<vwAssetAssignmentsForCustodian> GetAssignmentsForReleaseCustodians(int departmentID, int adminID)
        {
          
            using (var db = FastDB)
            {
                List<vwAssetAssignmentsForCustodian> assigns = (from assign in db.vwAssetAssignmentsForCustodians
                                                              where assign.DepartmentID == departmentID && assign.AdminID == adminID
                                                              select assign).ToList();

                return assigns;
            }
        }

        

        public List<vwAssetAssignmentsForManager> GetAssetAssignmentsForManagerByDeptID(int deptID, int empID)
        {
     

            using (var db = FastDB)
            {
                List<vwAssetAssignmentsForManager> assigns = (from assign in db.vwAssetAssignmentsForManagers
                                                              where assign.DepartmentID == deptID && assign.ManagerID == empID
                                                              select assign).ToList();

                return assigns;
            }
        }

        public List<vwAssetAssignmentsForMI> GetAssignmentsForMIS(int deptID, int MISID)
        {

          
            return (from assigns in FastDB.vwAssetAssignmentsForMIS
                    where assigns.DepartmentID == deptID && assigns.MISEmployeeID == MISID &&
                            assigns.AssignmentStatusID == Common.Constants.ASSIGNMENT_STATUS_ACCEPTED &&
                            assigns.AssetStatusID == Common.Constants.ASSET_STATUS_WITH_MIS
                    select assigns).ToList();

            
        }

        public List<vwAssetAssignmentsForMI> GetAssignmentForAcceptanceMIS(int deptID,int MISID)
        {

            return (from assigns in FastDB.vwAssetAssignmentsForMIS
                    where assigns.DepartmentID == deptID && assigns.MISEmployeeID == MISID &&
                            assigns.AssignmentStatusID == Common.Constants.ASSIGNMENT_STATUS_WT_ACCEPTANCE &&
                            assigns.AssetStatusID == Common.Constants.ASSET_STATUS_WITH_MIS
                    select assigns).ToList();


        }

    }
}
