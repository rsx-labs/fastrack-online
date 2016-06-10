using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Enum
{
    [Flags]
    public enum LoginStatus
    {
        Successful = 0,
        EmployeeIDUnknown = 1,
        IncorrectPassword = 2
    }
}
