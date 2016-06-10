using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FASTService.Process
{
    public class ReportsProcess : BaseProcess
    {
        public List<vwEmployeeList> GetEmployeeList(int status)
        {

            var query = (from emplist in FastDB.vwEmployeeLists
                             where emplist.Status == status
                             select emplist).ToList();

            if (query.Count() > 0) {
                return query;
            }

            return null;

        }

        public List<vwEmployeeList> GetEmployeeListByDepartmentID(int status, int departmentID)
        {

            var query = (from vwEmpList in FastDB.vwEmployeeLists
                                          where vwEmpList.Status == status && vwEmpList.DepartmentID == departmentID
                                          select vwEmpList).ToList();

            if (query.Count() > 0)
            {
                return query.ToList();
            }

            return null;
        }

        public List<vwEmployeeList> GetEmployeeListByPositionID(int status, int positionID)
        {

            var query = (from vwEmpList in FastDB.vwEmployeeLists
                                          where vwEmpList.Status == status && vwEmpList.PositionID == positionID
                                          select vwEmpList).ToList();

            if (query.Count() > 0)
            {
                return query.ToList();
            }

            return null;
        }

        public List<vwEmployeeList> GetEmployeeListByDepartmentIDPositionID(int status, int departmentID, int positionID)
        {

            var query = (from vwEmpList in FastDB.vwEmployeeLists
                                          where vwEmpList.Status == status
                                          && vwEmpList.DepartmentID == departmentID
                                          && vwEmpList.PositionID == positionID
                                          select vwEmpList).ToList();
            if (query.Count() > 0)
            {
                return query.ToList();
            }

            return null;
        }

        public List<vwFixAssetList> GetFixAssetList()
        {
            var query = (from fixAsset in FastDB.vwFixAssetLists
                         select fixAsset).ToList();

            if (query.Count() > 0){
                return query.ToList();
            }

            return null;
        }

        public List<vwFixAssetList> GetFixAssetListByClassTypeStatus(vwFixAssetList fixAsset)
        {
            List<vwFixAssetList> assets = new List<vwFixAssetList>();

            if (fixAsset.AssetClassID != 0 && fixAsset.AssetTypeID !=0 && fixAsset.AssetStatusID != 0) {
                assets = (from fixAssetList in FastDB.vwFixAssetLists
                          where fixAssetList.AssetClassID == fixAsset.AssetClassID
                          && fixAssetList.AssetTypeID == fixAsset.AssetTypeID
                          && fixAssetList.AssetStatusID == fixAsset.AssetStatusID
                          select fixAssetList).ToList();
            }
            else if (fixAsset.AssetClassID != 0 && fixAsset.AssetTypeID != 0 && fixAsset.AssetStatusID == 0)
            {
                assets = (from fixAssetList in FastDB.vwFixAssetLists
                          where fixAssetList.AssetClassID == fixAsset.AssetClassID
                          && fixAssetList.AssetTypeID == fixAsset.AssetTypeID
                          && fixAssetList.AssetStatusID != fixAsset.AssetStatusID
                          select fixAssetList).ToList();
            }
            else if (fixAsset.AssetClassID != 0 && fixAsset.AssetTypeID == 0 && fixAsset.AssetStatusID != 0)
            {
                assets = (from fixAssetList in FastDB.vwFixAssetLists
                          where fixAssetList.AssetClassID == fixAsset.AssetClassID
                          && fixAssetList.AssetTypeID != fixAsset.AssetTypeID
                          && fixAssetList.AssetStatusID == fixAsset.AssetStatusID
                          select fixAssetList).ToList();
            }
            else if (fixAsset.AssetClassID == 0 && fixAsset.AssetTypeID != 0 && fixAsset.AssetStatusID != 0)
            {
                assets = (from fixAssetList in FastDB.vwFixAssetLists
                          where fixAssetList.AssetClassID != fixAsset.AssetClassID
                          && fixAssetList.AssetTypeID == fixAsset.AssetTypeID
                          && fixAssetList.AssetStatusID == fixAsset.AssetStatusID
                          select fixAssetList).ToList();
            }
            else if (fixAsset.AssetClassID != 0 && fixAsset.AssetTypeID == 0 && fixAsset.AssetStatusID == 0)
            {
                assets = (from fixAssetList in FastDB.vwFixAssetLists
                          where fixAssetList.AssetClassID == fixAsset.AssetClassID
                          && fixAssetList.AssetTypeID != fixAsset.AssetTypeID
                          && fixAssetList.AssetStatusID != fixAsset.AssetStatusID
                          select fixAssetList).ToList();
            }
            else if (fixAsset.AssetClassID == 0 && fixAsset.AssetTypeID != 0 && fixAsset.AssetStatusID == 0)
            {
                assets = (from fixAssetList in FastDB.vwFixAssetLists
                          where fixAssetList.AssetClassID != fixAsset.AssetClassID
                          && fixAssetList.AssetTypeID == fixAsset.AssetTypeID
                          && fixAssetList.AssetStatusID != fixAsset.AssetStatusID
                          select fixAssetList).ToList();
            }
            else if (fixAsset.AssetClassID == 0 && fixAsset.AssetTypeID == 0 && fixAsset.AssetStatusID != 0)
            {
                assets = (from fixAssetList in FastDB.vwFixAssetLists
                          where fixAssetList.AssetClassID != fixAsset.AssetClassID
                          && fixAssetList.AssetTypeID != fixAsset.AssetTypeID
                          && fixAssetList.AssetStatusID == fixAsset.AssetStatusID
                          select fixAssetList).ToList();
            }
            else
            {
                assets = GetFixAssetList();
            }

            return assets;
        }
    }
}
