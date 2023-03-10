using BL;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using TestCoreAPI.Helper;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmsMailController : Controller
    {
        SmsMailBL _objSmsMailBL = new SmsMailBL();
        TrusteeBL _objTrustBL = new TrusteeBL();
        private string Mode = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApplicationMode")["Mode"]; //SiteKeys.ETULAMANUNIQUEID
        private string Number = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApplicationMode")["LocalNumber"]; //SiteKeys.ETULAMANUNIQUEID
        private string Email = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApplicationMode")["LocalEmail"]; //SiteKeys.ETULAMANUNIQUEID

        [HttpGet]
        [Route("SendSMsTrustVerificationOTP")]
        public SmsResponseModel SendSMsTrustVerificationOTP(string RegNo, int? otp)
        {
            SmsResponseModel _result = new SmsResponseModel();
            try
            {
                TrusteeBO.TrusteeInfo _request = new TrusteeBO.TrusteeInfo();
                _request.RegistrationNo = RegNo;
                TrusteeBO.TrusteeInfo res = _objTrustBL.GetTrustInfo(_request);
                MailSMSModel req = new MailSMSModel();
                req.Language = "ENG";
                req.MobileNo = new List<string> { res.Mobile };
                req.SMSType = "TrustVerificationOTPMessage";
                req.OTP = otp.NulllToInt();
                if (!string.Equals(Mode, "live", StringComparison.OrdinalIgnoreCase))
                {
                    req.MobileNo = new List<string> { Number };
                    res.Email = Email;
                }

                string smsBody = _objSmsMailBL.CreateUNOCSmsProcess(req);
                //model.SMSBody = smsBody;

                //var mailStatus = GetSettings.SendMail(new SendEmail
                //{
                //    RecieverEmailID = res.Email,//"sumit.tiwari@atishay.com",//party.EmailId,
                //    RecieverDisplayName = res.SocietyName,
                //    Subject = "Trust OTP Verification",
                //    Username = "",
                //    Message = smsBody,
                //});
                _result.ResponseCode = "200";
                _result.ResponseID = res.Mobile;
                _result.ResponseMessage = res.Email;
                _result.TrustType = res.TrustType;
                return _result;
                //return _objSmsMailBL.GenerateSms(req);                           
            }
            catch (Exception ex)
            {
                //base.HandleException(ex);
                //return NewtonSoftJsonResult(new RequestOutcome<string> { IsSuccess = false, Data = ex.Message });
            }
            return _result;
        }
    }
}
