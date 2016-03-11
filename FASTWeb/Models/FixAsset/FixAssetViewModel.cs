using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTWeb.Models.FixAsset
{
    public class FixAssetViewModel
    {
        public int FixAssetID { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string AssetTag { get; set; }
        public string Brand { get; set; }
        public string Remarks { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? IssuerID { get; set; }
        public string Issuer { get; set; }
        public int? LocationID { get; set; }
        public string Location { get; set; }

        public int AssetTypeID { get; set; }
        public string AssetType { get; set; }

        public int AssetStatusID { get; set; }
        public string AssetStatus { get; set; }

        public int AssetClassID { get; set; }
        public string AssetClass { get; set; }
    }
}