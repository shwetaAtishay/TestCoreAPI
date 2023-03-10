using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Controllers
{
    
    [Route("ListData")]
    [ApiController]
    public class ListData : Controller
    {       
        ListDataBL _objBL = new ListDataBL();

        [HttpPost]
        [Route("GetList")]
        public ResponseData GetCommonList(CustomListRequest req)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = _objBL.GetCommonList(req);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List Data Retrive";
                objResponseData.statusCode = 1;
            }
            else
            {
                objResponseData.Data = null;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "No Data Available";
                objResponseData.statusCode = 0;

            }
            return objResponseData;
        }

    }
}
