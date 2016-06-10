using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Process
{
    /// <summary>
    /// This class contains the EF Instance which is called accros the project.
    /// </summary>
    public class BaseProcess
    {
        protected FASTDBEntities FastDB;
        public BaseProcess()
        {
            FastDB = new FASTDBEntities();
        }
    }
}
