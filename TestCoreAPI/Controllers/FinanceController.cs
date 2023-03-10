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
    public class FinanceController : Controller
    {
        FinanceBL financeBL = new FinanceBL();
        ResponseData objResponse = new ResponseData();

        [HttpPost]
        [Route("addFinanceDetails")]
        public ResponseData addFinanceDetails(FinanceModalSave financeModal)
        {
            objResponse = financeBL.addFinanceDetails(financeModal);
            return objResponse;
        }

    }
}
