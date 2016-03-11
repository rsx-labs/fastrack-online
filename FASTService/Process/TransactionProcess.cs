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

        public List<vwAssetAssignmentsForCustodian> GetAssetAssignmentsForCustodianByDeptID(int departmentID)
        {
            return (from assigns in FastDB.vwAssetAssignmentsForCustodians
                    where assigns.DepartmentID == departmentID
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

        public List<vwAssetAssignmentsForManager> GetAssetAssignmentsForManagerByEmpID(int employeeID)
        {
            return (from assigns in FastDB.vwAssetAssignmentsForManagers
                    where assigns.ManagerID == employeeID
                    select new vwAssetAssignmentsForManager
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
                        ManagerID = assigns.ManagerID,
                        DepartmentID = assigns.DepartmentID
                    }).ToList();
        }

        public List<vwAssetAssignmentsForManager> GetAssetAssignmentsForManagerByDeptID(int deptID)
        {
            return (from assigns in FastDB.vwAssetAssignmentsForManagers
                    where assigns.DepartmentID == deptID
                    select new vwAssetAssignmentsForManager
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
                        ManagerID = assigns.ManagerID,
                        DepartmentID = assigns.DepartmentID
                    }).ToList();
        }

        public List<vwAssetAssignmentsForMI> GetAssetAssignmentsForMISByEmpID(int employeeID)
        {
            return (from assigns in FastDB.vwAssetAssignmentsForMIS
                    where assigns.MISEmployeeID == employeeID
                    select new vwAssetAssignmentsForMI
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
                        MISEmployeeID = assigns.MISEmployeeID,
                        DepartmentID = assigns.DepartmentID
                    }).ToList();
        }

        public List<vwAssetAssignmentsForMI> GetAssetAssignmentsForMISByDeptID(int deptID)
        {

            return (from assigns in FastDB.vwAssetAssignmentsForMIS
                    where assigns.DepartmentID == deptID
                    select assigns).ToList();

            //return (from assigns in FastDB.vwAssetAssignmentsForMIS
            //        where assigns.DepartmentID == deptID
            //        select new vwAssetAssignmentsForMI
            //        {
            //            AssetAssignmentID = assigns.AssetAssignmentID,
            //            AssetClassID = assigns.AssetClassID,
            //            AssetRemarks = assigns.AssetRemarks,
            //            AssetStatusID = assigns.AssetStatusID,
            //            AssetTag = assigns.AssetTag,
            //            AssetTypeID = assigns.AssetTypeID,
            //            AssignmentRemarks = assigns.AssignmentRemarks,
            //            AssignmentStatus = assigns.AssignmentStatus,
            //            AssignmentStatusID = assigns.AssignmentStatusID,
            //            Brand = assigns.Brand,
            //            ClassDescription = assigns.ClassDescription,
            //            Country = assigns.Country,
            //            DateAssigned = assigns.DateAssigned,
            //            DateReleased = assigns.DateReleased,
            //            EmployeeID = assigns.EmployeeID,
            //            FixAssetID = assigns.FixAssetID,
            //            FromID = assigns.FromID,
            //            LocationID = assigns.LocationID,
            //            LocationName = assigns.LocationName,
            //            Model = assigns.Model,
            //            SerialNumber = assigns.SerialNumber,
            //            StatusDescription = assigns.StatusDescription,
            //            ToID = assigns.ToID,
            //            TypeDescription = assigns.TypeDescription,
            //            MISEmployeeID = assigns.MISEmployeeID,
            //            DepartmentID = assigns.DepartmentID
            //        }).ToList();
        }

    }
}
