using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FASTService.Utilities;
using FASTService.Enum;
namespace FASTService.Process
{
    public class AuthenticateProcess
    {
        public LoginStatus ValidateLogin(int EmployeeID, string Password)
        {
            var hashedPassword = Encryption.MD5Hash(Password);
            using (var db = new FASTDBEntities())
            {
                //This will check the Registration table if supplied EmployeeID and PassPhrase exists.
                bool employeeExists = db.Registrations.Where(k => k.EmployeeID == EmployeeID && k.Password == hashedPassword).Any();
                if (employeeExists)
                {
                    //If employee credential exists, validation will be successful.
                    return LoginStatus.Successful;
                }
                else
                {
                    //If employee credential seems not to apear in the initial query in Registration table, 
                    //another query will be run to check if the EmployeeID exists.
                    employeeExists = db.Registrations.Where(k => k.EmployeeID == EmployeeID).Any();
                    if (employeeExists)
                        return LoginStatus.IncorrectPassword; //If EmployeeID exists, it is therefore validated that the supplied password is incorrect.
                    else
                        return LoginStatus.EmployeeIDUnknown; //If EmployeeID does not exists, it is therefore validated that it is not a registered Employee.
                }
            }
        }

        public List<AccessRight> GetAccessRight(int employeeID)
        {
            using (var db = new FASTDBEntities())
            {
                return db.AccessRights.Select(emp => new AccessRight() ).Where(emp => emp.EmployeeID == employeeID ).ToList();
            }
        }

        public string HashString(string input)
        {
            return Encryption.MD5Hash(input);
        }
    }
}
