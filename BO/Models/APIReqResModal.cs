using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class APIReqResModal
    {

        public int ReqResID { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string API_Request { get; set; }
        public string API_Response { get; set; }
    }
}
