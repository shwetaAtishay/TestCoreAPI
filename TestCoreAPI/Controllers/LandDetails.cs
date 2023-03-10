using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LandDetails : Controller
    {
        LandDetailsBL objLandDetailsBL = new LandDetailsBL();
        ErrorBO _Result = new ErrorBO();

        [HttpPost]
        [Route("BuldingDetail")]
        public ResponseData BuldingDetail(LandBuildingBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = objLandDetailsBL.LandBuldingDetail(obj);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {
                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }
            return objResponseData;

        }

        [HttpPost]
        [Route("AddLandInfo")]
        public ResponseData AddLandInfo(List<LandInfoBO> _obj)
        {
            return objLandDetailsBL.SaveLandInfo(_obj);
        }

        [HttpGet]
        [Route("GetLandData")]
        public ResponseData GetLandData(string APPGUID)
        {
            return objLandDetailsBL.GetLandData(APPGUID);
        }

        [HttpPost]
        [Route("AddBuildingInfo")]
        public ResponseData AddBuildingInfo(BuildingDetails _obj)
        {
            return objLandDetailsBL.AddBuildingInfo(_obj);
        }
    }
}
