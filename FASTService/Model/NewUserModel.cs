using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Model
{
    public class NewUserModel
    {
        public int EmployeeID { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
