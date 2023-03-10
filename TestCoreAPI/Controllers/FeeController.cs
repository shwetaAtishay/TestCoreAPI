using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreAPI.Helper;

namespace TestCoreAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FeeController : Controller
    {
        FeeBL feeBL = new FeeBL();
        ResponseData objResponse = new ResponseData();

        [HttpPost]
        [Route("addFeeDetails")]
        public ResponseData addVertinaryDetails(FeeMaster fee)
        {
            objResponse = feeBL.addFeeDetails(fee);
            return objResponse;
        }

        [HttpGet]
        [Route("GetFeeData")]
        public ResponseData GetFeeData()
        {
            objResponse = feeBL.GetFeeData();
            return objResponse;
        }

    }
}
