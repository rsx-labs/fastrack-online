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
    
    public partial class Issuer
    {
        public Issuer()
        {
            this.FixAssets = new HashSet<FixAsset>();
        }
    
        public int IssuerID { get; set; }
        public int IssuerType { get; set; }
        public string IssuerName { get; set; }
    
        public virtual ICollection<FixAsset> FixAssets { get; set; }
    }
}