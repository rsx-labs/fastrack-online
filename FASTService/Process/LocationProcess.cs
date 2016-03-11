using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Process
{
    public class LocationProcess:BaseProcess
    {
        public List<Location> GetLocations()
        {
            return FastDB.Locations.ToList();
        }
    }
}
