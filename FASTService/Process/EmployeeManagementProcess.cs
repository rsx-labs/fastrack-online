using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FASTService.Utilities;
using FASTService.Enum;
using FASTService.Model;

namespace FASTService.Process
{
    public class EmployeeManagementProcess : BaseProcess
    {
        public bool NewEmployee(EmployeeModel employee)
        {
                Employee emp = new Employee();
                emp.EmployeeID = employee.EmployeeID;
                emp.FirstName = employee.FirstName;
                emp.MiddleName = employee.MiddleName;
                emp.LastName = employee.LastName;
                emp.ManagerID = employee.ManagerID;
                emp.Gender = employee.Gender;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.EmailAddress = employee.EmailAddress;
                emp.DepartmentID = employee.DepartmentID;
                emp.PositionID = employee.PositionID;
                emp.IsCompany = employee.IsCompany;
                emp.CompanyName = employee.CompanyName;
                emp.Status = employee.Status;

                FastDB.Employees.Add(emp);
                FastDB.SaveChanges();
            return true;
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            
                var emp = (from k in FastDB.Employees where k.EmployeeID == employee.EmployeeID select k).FirstOrDefault();
                emp.FirstName = employee.FirstName;
                emp.MiddleName = employee.MiddleName;
                emp.LastName = employee.LastName;
                emp.ManagerID = employee.ManagerID;
                emp.Gender = employee.Gender;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.EmailAddress = employee.EmailAddress;
                emp.DepartmentID = employee.DepartmentID;
                emp.PositionID = employee.PositionID;
                emp.IsCompany = employee.IsCompany;
                emp.CompanyName = employee.CompanyName;
                emp.Status = employee.Status;

                
                //db.Employees.Add(emp);
                FastDB.SaveChanges();
            return true;
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            var query = (from k in FastDB.Employees
                        select new EmployeeModel
                        {
                            FirstName = k.FirstName,
                            MiddleName = k.MiddleName,
                            LastName = k.LastName,
                            EmployeeID = k.EmployeeID,
             
                            ManagerID = k.ManagerID.Value,
                            Gender = k.Gender,
                            PhoneNumber = k.PhoneNumber,
                            EmailAddress = k.EmailAddress,
                            Department = k.Department.GroupName,
                            DepartmentID = k.DepartmentID,
                            PositionID = k.PositionID,
                            Position = k.Position.Description,
                            IsCompany = k.IsCompany,
                            CompanyName = k.CompanyName,
                            Status = k.Status,
                        }).ToList();

            return query;
        }

        public EmployeeDashboardViewModel GetEmployeeCompleteProfile(int employeeID)
        {
            return (EmployeeDashboardViewModel) (from emp in FastDB.Employees
                                                 where emp.EmployeeID == employeeID   
                select new EmployeeDashboardViewModel()
                {
                    FirstName = emp.FirstName,
                    MiddleName = emp.MiddleName,
                    LastName = emp.LastName,
                    EmployeeID = emp.EmployeeID,
                    Gender = emp.Gender,
                    PhoneNumber = emp.PhoneNumber,
                    EmailAddress = emp.EmailAddress,
                    Department = emp.Department.GroupName,
                    DepartmentID = emp.DepartmentID,
                    PositionID = emp.PositionID,
                    Position = emp.Position.Description,
                    IsCompany = emp.IsCompany,
                    CompanyName = emp.CompanyName,
                    Status = emp.Status,

                    accessRights =( from rights in FastDB.AccessRights
                                    where rights.EmployeeID == emp.EmployeeID && rights.Status == 1
                                    select rights).ToList(),


                    assignments = (from assigns in FastDB.vwAssetAssignments
                                    where assigns.EmployeeID == emp.EmployeeID
                                    select assigns).ToList()

                                    
                }).SingleOrDefault();
        }

        public EmployeeModel GetEmployeeProfile(int employeeID)
        {
            return (EmployeeModel)(from emp in FastDB.Employees
                                                where emp.EmployeeID == employeeID
                                                select new EmployeeModel()
                                                {
                                                    FirstName = emp.FirstName,
                                                    MiddleName = emp.MiddleName,
                                                    LastName = emp.LastName,
                                                    EmployeeID = emp.EmployeeID,
                                                    Gender = emp.Gender,
                                                    PhoneNumber = emp.PhoneNumber,
                                                    EmailAddress = emp.EmailAddress,
                                                    Department = emp.Department.GroupName,
                                                    DepartmentID = emp.DepartmentID,
                                                    PositionID = emp.PositionID,
                                                    Position = emp.Position.Description,
                                                    IsCompany = emp.IsCompany,
                                                    CompanyName = emp.CompanyName,
                                                    Status = emp.Status

                                                }).SingleOrDefault();
        }

        
    }
}
