using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Model
{
    public class EmployeeModel
    {
      public int EmployeeID {get;set;}
      public string FirstName {get;set;}
      public string MiddleName {get;set;}
      public string LastName {get;set;}
      public int? ManagerID {get;set;}
      public string Gender {get; set;}
      public string PhoneNumber {get; set;}
      public string EmailAddress {get; set;}
      public int DepartmentID { get; set; }
      public string Department { get; set; }
      public int PositionID {get; set;}
      public string Position { get; set; }
      public short IsCompany { get; set; }
      public string CompanyName{get;set;}
      public short Status { get; set; }
    }

    public class EmployeeDashboardViewModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public int PositionID { get; set; }
        public string Position { get; set; }
        public short IsCompany { get; set; }
        public bool IsCompany_booleanVal { get; set; }
        public string CompanyName { get; set; }
        public int Status { get; set; }
        public bool Status_booleanVal { get; set; }

        public List<FASTService.AccessRight> accessRights = new List<AccessRight>();
        public List<FASTService.vwAssetAssignment> assignments = new List<FASTService.vwAssetAssignment>();
    }
}
