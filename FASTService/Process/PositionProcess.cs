using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FASTService.Model;
namespace FASTService.Process
{
    public class PositionProcess : BaseProcess
    {
        public List<Position> GetPositions()
        {
            return FastDB.Positions.ToList();
        }
    }
}
