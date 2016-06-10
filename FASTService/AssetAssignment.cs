//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FASTService
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssetAssignment
    {
        public int AssetAssignmentID { get; set; }
        public int EmployeeID { get; set; }
        public int FixAssetID { get; set; }
        public int AssignmentStatusID { get; set; }
        public Nullable<System.DateTime> DateAssigned { get; set; }
        public Nullable<System.DateTime> DateReleased { get; set; }
        public string Remarks { get; set; }
        public string FromID { get; set; }
        public string ToID { get; set; }
    
        public virtual AssignmentStatu AssignmentStatu { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual FixAsset FixAsset { get; set; }
    }
}