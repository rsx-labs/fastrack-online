using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Process
{
    public class AuditTrailProcess : BaseProcess
    {
        public List<AuditTrail> GetAuditTrails()
        {
            return FastDB.AuditTrails.ToList();
        }

        public List<AuditTrail> GetAuditTrailByEmployeeID(int employeeID)
        {
            using ( var db = FastDB)
            {
                return (from audits in db.AuditTrails
                        where audits.EmployeeID == employeeID
                        select audits).ToList();
            }
        }

        public List<AuditTrail> SearchAuditTrail(string startDate, string employeeID,string assetTag, string assignmentID)
        {

            int empID = 0;
            Int32.TryParse(employeeID, out empID);
            DateTime startD = DateTime.Now;
            DateTime.TryParse(startDate, out startD);

            using (var db = FastDB)
            {
                List<AuditTrail> result = new List<AuditTrail>();

                //If startDate is blank, it will return all
                result = (from audits in db.AuditTrails
                              where audits.Date >= startD
                              select audits).ToList();
                

                if ( empID != 0)
                {
                    result = (from audits in result
                              where audits.EmployeeID == empID
                              select audits).ToList();
                }

                if (!string.IsNullOrEmpty(assetTag))
                {
                    result = (from audits in result
                              where audits.AssetTag == assetTag
                              select audits).ToList();
                }

                if (!string.IsNullOrEmpty(assignmentID))
                {
                    result = (from audits in result
                              where audits.AssignmentID == assignmentID
                              select audits).ToList();
                }

                return result;

            }
        }

        public List<AuditTrail> GetAuditTrailByAssignmentID(int assignmentID)
        {
            using (var db = FastDB)
            {
                return (from audits in db.AuditTrails
                        where audits.AssignmentID == assignmentID.ToString()
                        select audits).ToList();
            }
        }

        public List<AuditTrail> GetAuditTrailByAssetID(string assetTag)
        {
            using (var db = FastDB)
            {
                return (from audits in db.AuditTrails
                        where audits.AssetTag == assetTag
                        select audits).ToList();
            }
        }

        public List<AuditTrail> GetAuditTrailByDate(DateTime startDate)
        {
            using (var db = FastDB)
            {
                return (from audits in db.AuditTrails
                        where ((audits.Date == startDate))
                        select audits).ToList();
            }
        }


    }
}
