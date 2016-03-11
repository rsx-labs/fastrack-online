using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FASTWeb.Models.FixAsset;
using FASTService.Model;
using FASTService.Process;
using FASTService;
namespace FASTWeb.Controllers
{
    public class FixAssetController : Controller
    {
        //
        // GET: /FixAsset/
        public ActionResult Index()
        {
            FixAssetManagementProcess fixAssetManagement = new FixAssetManagementProcess();
            var AssetList = fixAssetManagement.GetAllAssets().Select(k => new FixAssetViewModel
            {
                FixAssetID = k.FixAssetID,
                Model = k.Model,
                SerialNumber = k.SerialNumber,
                AssetTag = k.AssetTag,
                Brand = k.Brand,
                Remarks = k.Remarks,
                AcquisitionDate = k.AcquisitionDate,
                ExpiryDate = k.ExpiryDate,

                Issuer = k.Issuer,

                Location = k.Location,

                AssetType = k.AssetType,

                AssetStatus = k.AssetStatus,

                AssetClass = k.AssetClass
            });
            return View(AssetList);
        }
        public ActionResult NewAsset()
        {
            FixAssetManagementProcess assetManagement = new FixAssetManagementProcess();
            LocationProcess location = new LocationProcess();
            IssuerProcess issuer = new IssuerProcess();

            ViewBag.Location = location.GetLocations();
            ViewBag.Issuer = issuer.GetIssuers();
            ViewBag.AssetType = assetManagement.GetAssetTypes();
            ViewBag.AssetStatus = assetManagement.GetAssetStatus();
            ViewBag.AssetClass = assetManagement.GetAssetClasses();
            return View(new FixAssetViewModel());
        }

        [HttpPost]
        public ActionResult SaveNewAsset(FixAssetViewModel assetModel)
        {
            FixAssetModel asset = new FixAssetModel();
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
            FixAssetManagementProcess assetManagement = new FixAssetManagementProcess();
            bool success = assetManagement.NewAsset(asset);

            return RedirectToAction("Index");
        }
        
        public ActionResult EditAsset(int mod)
        {
            int FixAssetID = mod;
            FixAssetManagementProcess assetManagement = new FixAssetManagementProcess();
            LocationProcess location = new LocationProcess();
            IssuerProcess issuer = new IssuerProcess();

           
            var AssetDetails = assetManagement.GetAllAssets().Where(k=>k.FixAssetID == FixAssetID).Select(k => new FixAssetViewModel
            {
                FixAssetID = k.FixAssetID,
                Model = k.Model,
                SerialNumber = k.SerialNumber,
                AssetTag = k.AssetTag,
                Brand = k.Brand,
                Remarks = k.Remarks,
                AcquisitionDate = k.AcquisitionDate,
                ExpiryDate = k.ExpiryDate,

                Issuer = k.Issuer,

                Location = k.Location,

                AssetType = k.AssetType,

                AssetStatus = k.AssetStatus,

                AssetClass = k.AssetClass
            }).FirstOrDefault();

            ViewBag.Location = location.GetLocations();
            ViewBag.Issuer = issuer.GetIssuers();
            ViewBag.AssetType = assetManagement.GetAssetTypes();
            ViewBag.AssetStatus = assetManagement.GetAssetStatus();
            ViewBag.AssetClass = assetManagement.GetAssetClasses();
            return View(AssetDetails);
        }
        
        [HttpPost]
        public ActionResult EditAsset(FixAssetViewModel assetModel)
        {
            FixAssetModel asset = new FixAssetModel();
            asset.FixAssetID = assetModel.FixAssetID;
            asset.Model = assetModel.Model;
            asset.SerialNumber = assetModel.SerialNumber;
            asset.AssetTag = assetModel.AssetTag;
            asset.Brand = assetModel.Brand;
            asset.Remarks = assetModel.Remarks;
            if(assetModel.AcquisitionDate != null)
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
            FixAssetManagementProcess assetManagement = new FixAssetManagementProcess();
            bool success = assetManagement.UpdateAsset(asset);
            return RedirectToAction("Index");
        }
	}
}