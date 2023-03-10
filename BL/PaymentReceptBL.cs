using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class PaymentReceptBL
    {
        PaymentReceptDL objUserDL = new PaymentReceptDL();
        public ResponseData PayReceptDetails(ParticalPaymentBO master)
        {
            return objUserDL.PayReceptDetails(master);
        }

        public List<ParticalPaymentBO> GetReceptData()
        {
            return objUserDL.GetReceptDataList();
        }
        public List<OLDNOCBO> GetOLDNOCData()
        {
            return objUserDL.GetOLDNOCDataList();
        }
    }
}
