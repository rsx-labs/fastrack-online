using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Common
{
    public class Constants
    {
        public const int ASSET_CLASS_NON_IT = 1;
        public const int ASSET_CLASS_IT = 2;
        public const int ASSET_CLASS_OTHERS = 3;

        public const int ASSIGNMENT_STATUS_WT_APPROVAL = 1;
        public const int ASSIGNMENT_STATUS_WT_ACCEPTANCE = 2;
        public const int ASSIGNMENT_STATUS_ACCEPTED = 3;
        public const int ASSIGNMENT_STATUS_FOR_TRANSFER = 4;
        public const int ASSIGNMENT_STATUS_REJECTED = 5;
        public const int ASSIGNMENT_STATUS_RELEASED = 6;
        public const int ASSIGNMENT_STATUS_DENIED = 7;

        public const int ASSET_STATUS_NEW = 1;
        public const int ASSET_STATUS_FORASSIGNMENT = 2;
        public const int ASSET_STATUS_WITH_MIS = 3;
        public const int ASSET_STATUS_ASSIGNED = 4;
        public const int ASSET_STATUS_DECOMMISSIONED = 5;
        public const int ASSET_STATUS_FORTRANSFER = 6;
        public const int ASSET_STATUS_FORRELEASE = 7;
        public const int ASSET_STATUS_FORREPAIR = 8;
        public const int ASSET_STATUS_RELEASED = 9;

        public const int RELEASE_REASON_FOR_REASSIGNMENT = 1;
        public const int RELEASE_REASON_FOR_REPAIR = 2;
        public const int RELEASE_REASON_FOR_DISPOSAL = 3;
        public const int RELEASE_REASON_FOR_CORRECTION = 4;
        public const int RELEASE_REASON_OTHERS = 5;

        public const string ASSET_STATUS = "FA";
        public const string ASSIGN_STATUS = "AA";
    }
}
