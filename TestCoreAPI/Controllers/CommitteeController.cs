using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestCoreAPI.Helper;

namespace TestCoreAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CommitteeController : Controller
    {
        CommitteeBL committeeBL = new CommitteeBL();
        ResponseData objResponse = new ResponseData();

        [HttpGet]
        [Route("getCommitteeList")]
        public ResponseData getCommitteeList(int deptId)
        {
            try
            {
                objResponse = committeeBL.getCommitteeList(deptId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResponse;
        }

        [HttpGet]
        [Route("getCommitteeMembersList")]
        public ResponseData getCommitteeMembersList(int committeeID)
        {
            try
            {
                objResponse = committeeBL.getCommitteeMembersList(committeeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResponse;
        }

        [HttpPost]
        [Route("AssignCommitteeToApplication")]
        public ResponseData AssignCommitteeToApplication(Committee committeeDetails)
        {
            try
            {
                objResponse = committeeBL.AssignCommitteeToApplication(committeeDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResponse;
        }

        [HttpGet]
        [Route("GetExistingCommitteeAsignment")]
        public ResponseData GetExistingCommitteeAsignment(string applicationNumber)
        {
            try
            {
                objResponse = committeeBL.GetExistingCommitteeAsignment(applicationNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResponse;
        }

        [HttpPost]
        [Route("SendMailToCommitteeMembers")]
        public ResponseData SendMail(SendMailToCommittee mailToCommittee)
        {
            try
            {
                if (mailToCommittee.type == "Delete")
                    objResponse = committeeBL.SendMail(mailToCommittee);

                if (mailToCommittee.EmailList.Count > 0)
                {
                    foreach (var item in mailToCommittee.EmailList)
                    {
                        if (!string.IsNullOrEmpty(item.Emails))
                        {
                            var displayNam = item.Emails.Split('@')[0]; //user2@mail.com
                            var mailStatus = GetSettings.SendMail(new SendEmail
                            {
                                RecieverEmailID = item.Emails,//"sumit.tiwari@atishay.com",//party.EmailId,
                                RecieverDisplayName = displayNam,
                                Subject = "Assignment Update",
                                Username = mailToCommittee.applicationNumber,
                                Message = "DeletionData",
                            });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResponse;
        }

        [HttpPost]
        [Route("sendSMS")]
        public string Sendsms(mobileNoCollection mobileNo)
        {

            RajSMS sMS = new RajSMS();

            //            request ====
            //                {
            //                  "textMessage": "Please fill college priorities online for PSST, PSSST and PSAT for online counselling 2020-21 before 22nd Jan 2021. Visit hteapp.hte.rajasthan.gov.in/pssst for details - JRRSU",
            //                 "mobileNos": [
            //                                  9039737635,
            //                                  8518889156
            //                                  ]
            //                  }



            sMS.mobileNo = mobileNo.mobileNos;
            sMS.message = mobileNo.textMessage; //"Please fill college priorities online for PSST, PSSST and PSAT for online counselling 2020-21 before 22nd Jan 2021. Visit hteapp.hte.rajasthan.gov.in/pssst for details - JRRSU";

            var client = new RestClient("https://api.sewadwaar.rajasthan.gov.in/app/live/eSanchar/Prod/api/OBD/CreateSMS/Request?client_id=e6bc53b8-14c4-4501-b8f7-1abd83faf77e");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("username", sMS.username);
            request.AddHeader("password", sMS.password);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(sMS);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            return response.Content;
        }

    }
}
