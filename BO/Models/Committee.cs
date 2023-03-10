using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class Committee
    {
        public int iPk_AsgnID { get; set; }
        public int iFk_CmtyID { get; set; }
        public int iFk_CmtytypeID { get; set; }
        public string sApplNo { get; set; }
        public string sCrtdBy { get; set; }
        public string dtCrtdOn { get; set; }
        public string isNotfy { get; set; }
        public string dtStrtDate { get; set; }
        public string tStrttime { get; set; }
        public string dtEndDate { get; set; }
        public string tEndtime { get; set; }

    }
    public class SendMailToCommittee
    {
        public List<EmailAddress> EmailList { get; set; }
        public string applicationNumber { get; set; }
        public string type { get; set; }
    }
    public class EmailAddress
    {
        public string Emails { get; set; }
    }
}
