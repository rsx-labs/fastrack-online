using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Process
{
    public class IssuerProcess:BaseProcess
    {
        public List<Issuer> GetIssuers()
        {
            return FastDB.Issuers.ToList();
        }
    }
}
