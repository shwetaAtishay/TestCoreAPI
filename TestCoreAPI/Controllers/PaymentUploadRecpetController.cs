using BL;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentUploadRecpetController : Controller
    {
        PaymentReceptBL ObjRate =new PaymentReceptBL();

        [HttpPost]
        [Route("PayRecept")]
        public ResponseData PayRecept(ParticalPaymentBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjRate.PayReceptDetails(obj);
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

        [HttpGet]
        [Route("GetReceptData")]
        public List<ParticalPaymentBO> GetReceptData()
        {
            return ObjRate.GetReceptData();

        }

        [HttpGet]
        [Route("GetOLDNOCData")]
        public List<OLDNOCBO> GetOLDNOCData()
        {
            return ObjRate.GetOLDNOCData();

        }
    }
}
