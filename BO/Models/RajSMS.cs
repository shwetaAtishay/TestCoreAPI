using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class RajSMS
    {
        public string UniqueID { get; set; } = "HGHTCH_EDU_SMS";
        public string username { get; set; } = "HighEduSms";
        public string password { get; set; } = "Ed#MsmDt_0o1";
        public string serviceName { get; set; } = "eSanchar Send SMS Request";
        public string language { get; set; } = "ENG";
        public string message { get; set; } 
        public List<string> mobileNo { get; set; } 
    }
    public class mobileNoCollection
    {
        public List<string> mobileNos { get; set; }
        public string textMessage { get; set; }
    }
}
