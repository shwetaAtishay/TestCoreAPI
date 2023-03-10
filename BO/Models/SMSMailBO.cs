using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class MailSMSModel
    {
        public int TemplateId { get; set; }
        public string Language { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public List<string> MobileNo { get; set; }
        public string SSOID { get; set; }
        public string SMSBody { get; set; }
        public string RegNo { get; set; }
        public string SMSType { get; set; }
        public int OTP { get; set; }

    }

    public class SmsResponseModel
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseID { get; set; }
        public string TrustType { get; set; }

    }

    public class UNOCSmsModel
    {
        public string UniqueID { get; set; }
        public string ServiceName { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
        public List<string> MobileNo { get; set; }
    }

    public class SMSTemplates
    {
        public int EmailTemplateId { get; set; }
        public string TemplateKey { get; set; }
        public string SMSTemplate { get; set; }
        public string DLTTemplate { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public bool DeleteFlag { get; set; }
        public string TemplateId { get; set; }
    }
}
