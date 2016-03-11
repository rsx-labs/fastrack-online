using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Enum
{
    [Flags]
    public enum RegistrationStatus
    {
        Successful = 0,
        EmployeeIDAlreadyExists = 1,
        EmployeeIDDontExists = 2,
        PasswordsDidNotMatch = 3
    }
}
