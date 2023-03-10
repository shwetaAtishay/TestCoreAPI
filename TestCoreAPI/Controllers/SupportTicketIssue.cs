using BL;
using BO;
using BO.Models;
using DL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupportTicketIssue : Controller
    {
        SupportTickBL objSupportBL = new SupportTickBL();
        ResponseData objResponse = new ResponseData();
        [HttpPost]
        [Route("SupportDetail")]
        public ResponseData SupportDetail(SupportIssue obj)
        {
            objResponse = objSupportBL.DetailsSupport(obj);
            return objResponse;
        }
        [HttpGet]
        [Route("GetSupportData")]
        public List<SupportIssue> GetSupportData()
        {
            return objSupportBL.SupportDetails();
            
        }
        [HttpPost]
        [Route("GetTicketsList")]
        public ResponseData GetTicketsList()
        {
            var objResponseData = objSupportBL.TicketsDropdown();
            return objResponseData;
        }
        [HttpGet]
        [Route("DeleteTickets")]
        public ResponseData DeleteTickets(int id)
        {
            var objResponseData = new ResponseData();
            var DeleteCourseBOs = objSupportBL.ListDeleteTickets(id);
            objResponseData.statusCode = 1;
            objResponseData.Data = DeleteCourseBOs;
            return objResponseData;
        }
        [HttpPost]
        [Route("DocumentTicketsDetail")]
        public SupportIssue DocumentTicketsDetail(int Identity)
        {
            return objSupportBL.GetTickets(Identity);

        }
    }
}
