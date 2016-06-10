using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FASTService.Model;

namespace FASTService.Process
{
   public  class FixAssetManagementProcess:BaseProcess
    {
       public List<AssetClass> GetAssetClasses()
       {
           return FastDB.AssetClasses.ToList();
       }
       public List<AssetType> GetAssetTypes()
       {
           return FastDB.AssetTypes.ToList();
       }
       public List<AssetStatu> GetAssetStatus()
       {
           return FastDB.AssetStatus.ToList();
       }

       public List<FixAssetModel> GetAllAssets()
       {
           var AssetList = FastDB.FixAssets.Select(k => new FixAssetModel
           {
               FixAssetID = k.FixAssetID,
               Model = k.Model,
               SerialNumber = k.SerialNumber,
               AssetTag = k.AssetTag,
               Brand = k.Brand,
               Remarks = k.Remarks,
               AcquisitionDate = k.AcquisitionDate.Value,
               ExpiryDate = k.ExpiryDate.Value,

               IssuerID = k.IssuerID.Value,
               Issuer = k.Issuer.IssuerName,


               LocationID = k.LocationID.Value,
               Location = k.Location.LocationName,

               AssetTypeID = k.AssetTypeID,
               AssetType = k.AssetType.TypeDescription,

               AssetStatusID = k.AssetStatusID,
               AssetStatus = k.AssetStatu.StatusDescription,

               AssetClassID = k.AssetClassID,
               AssetClass = k.AssetClass.ClassDescription

               
           }).ToList();

           
                return AssetList;
       }

       public bool NewAsset(FixAssetModel assetModel)
       {
           FixAsset asset = new FixAsset();
           asset.Model = assetModel.Model;
           asset.SerialNumber = assetModel.SerialNumber;
           asset.AssetTag = assetModel.AssetTag;
           asset.Brand = assetModel.Brand;
           asset.Remarks = assetModel.Remarks;
           if (assetModel.AcquisitionDate != null)
               asset.AcquisitionDate = assetModel.AcquisitionDate;
           if (assetModel.ExpiryDate != null)
               asset.ExpiryDate = assetModel.ExpiryDate;
           if (assetModel.IssuerID != null)
               asset.IssuerID = assetModel.IssuerID;
           if (assetModel.LocationID != null)
               asset.LocationID = assetModel.LocationID;

           asset.AssetTypeID = assetModel.AssetTypeID;

           asset.AssetStatusID = assetModel.AssetStatusID;

           asset.AssetClassID = assetModel.AssetClassID;


           FastDB.FixAssets.Add(asset);
           FastDB.SaveChanges();
           return true;
       }
       public bool UpdateAsset(FixAssetModel assetModel)
       {
           var asset = FastDB.FixAssets.Where(k => k.FixAssetID == assetModel.FixAssetID).FirstOrDefault();
           asset.Model = assetModel.Model;
           asset.SerialNumber = assetModel.SerialNumber;
           asset.AssetTag = assetModel.AssetTag;
           asset.Brand = assetModel.Brand;
           asset.Remarks = assetModel.Remarks;
           if (assetModel.AcquisitionDate != null)
               asset.AcquisitionDate = assetModel.AcquisitionDate;
           if (assetModel.ExpiryDate != null)
               asset.ExpiryDate = assetModel.ExpiryDate;
           if (assetModel.IssuerID != null)
               asset.IssuerID = assetModel.IssuerID;
           if (assetModel.LocationID != null)
               asset.LocationID = assetModel.LocationID;

           asset.AssetTypeID = assetModel.AssetTypeID;

           asset.AssetStatusID = assetModel.AssetStatusID;

           asset.AssetClassID = assetModel.AssetClassID;


           FastDB.SaveChanges();
           return true;
       }

       public List<vwFixAssetList> GetAssetsForRepair()
       {
           return (from assets in FastDB.vwFixAssetLists
                       where assets.AssetStatusID == Common.Constants.ASSET_STATUS_FORREPAIR
                       select assets).ToList();
           
       }

       public List<vwFixAssetList> GetReleasedAssets()
       {
           return (from assets in FastDB.vwFixAssetLists
                       where assets.AssetStatusID == Common.Constants.ASSET_STATUS_RELEASED
                       select assets).ToList();
           
       }
    }
}
