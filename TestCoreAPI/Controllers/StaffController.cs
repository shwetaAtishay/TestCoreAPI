using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffBO = BO.Models.StaffBO;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : Controller
    {
        StaffBL _objStaffBL = new StaffBL();

        #region Trustee
        [HttpPost]
        [Route("AddStaff")]
        public ErrorBO AddStaff(StaffBO.Staff _obj)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objStaffBL.SaveStaff(_obj);
        }

        [HttpPost]
        [Route("StaffDelete")]
        public ErrorBO StaffDelete(int Id)
        {
            return _objStaffBL.StaffDelete(Id);
        }

        [HttpGet]
        [Route("StaffList")]
        public List<StaffBO.Staff> StaffList(string Guid)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objStaffBL.StaffList(Guid);
        }
        #endregion

        [HttpPost]
        [Route("ExistingNOCStaffDetails")]
        public List<StaffBO.Staff> ExistingNOCStaffDetails(ExistingNOCRequest obj)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objStaffBL.ExistingNOCDetails(obj);
        }
    }
}
