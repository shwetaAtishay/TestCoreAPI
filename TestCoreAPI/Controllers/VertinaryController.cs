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
    public class VertinaryController : Controller
    {
        VertinaryBL vertinaryBL = new VertinaryBL();
        ResponseData objResponse = new ResponseData();

        [HttpPost]
        [Route("addVertinaryDetails")]
        public ResponseData addVertinaryDetails(VertinaryModalSave vertinary)
        {
            objResponse = vertinaryBL.addVertinaryDetails(vertinary);
            return objResponse;
        }

    }
}
