using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Reports : Controller
    {
        ServiceTransBL objServiceBL = new ServiceTransBL();
        RequestData _Access = new RequestData();
        ReportsBL _ReportBL = new ReportsBL();
        private readonly IHostingEnvironment _hostingEnvironment;
        public Reports(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("AllReport")]
        public List<AllReportBO> AllReport(string iFKTst_ID)
        {
            var objResponseData = _ReportBL.GetReport(iFKTst_ID);
            return objResponseData;

        }
        //[Route("LedgerReport")]
        //public LedgerReportDetails GetLedgerReport(LedgerReport objReport)
        //{
        //    Request.Headers.TryGetValue("LoginID", out var LoginID);
        //    objReport.LoginID = LoginID;
        //    return _ReportBL.GetLedgerReport(objReport);
        //}



    }
}
