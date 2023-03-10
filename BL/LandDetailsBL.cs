using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class LandDetailsBL
    {
        LandDetailsDL objLandDetailsDL = new LandDetailsDL();
        public ResponseData LandBuldingDetail(LandBuildingBO master)
        {
            return objLandDetailsDL.BuildingDetailConfigure(master);
        }
        public ResponseData SaveLandInfo(List<LandInfoBO> master)
        {
            return objLandDetailsDL.SaveLandInfo(master);
        }

        public ResponseData GetLandData(string APPGUID)
        {
            return objLandDetailsDL.GetLandData(APPGUID);
        }

        public ResponseData AddBuildingInfo(BuildingDetails _obj)
        {
            return objLandDetailsDL.AddBuildingInfo(_obj);
        }
    }
}
