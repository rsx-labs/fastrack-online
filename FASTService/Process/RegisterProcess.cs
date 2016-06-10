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
    public class RegisterProcess : BaseProcess
    {
        public RegistrationStatus CreateNewUser(NewUserModel UserModel)
        {
            var hashedPassword = Encryption.MD5Hash(UserModel.Password);
            var hashedConfirmPassword = Encryption.MD5Hash(UserModel.ConfirmPassword);

            if(hashedPassword == hashedConfirmPassword)
            {
                bool EmployeeExists = FastDB.Employees.Where(k => k.EmployeeID == UserModel.EmployeeID).Any();
                if(EmployeeExists)
                {
                    bool IsEmployeeAlreadyRegistered = FastDB.Registrations.Where(k => k.EmployeeID == UserModel.EmployeeID).Any();
                    if(IsEmployeeAlreadyRegistered)
                    {
                        return RegistrationStatus.EmployeeIDAlreadyExists;
                    }
                    else
                    {
                        // Main registration process starts here.
                        Registration reg = new Registration();
                        reg.DateStamp = DateTime.Now;
                        reg.Password = hashedPassword;
                        reg.Status = 0;
                        reg.EmployeeID = UserModel.EmployeeID;

                        FastDB.Registrations.Add(reg);
                        FastDB.SaveChanges();
                        return RegistrationStatus.Successful;
                    }
                }
                else
                {
                    return RegistrationStatus.EmployeeIDDontExists;
                }
            }
            else
            {
                return RegistrationStatus.PasswordsDidNotMatch;
            }
        }
    }
}
