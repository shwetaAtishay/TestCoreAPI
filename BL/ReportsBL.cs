using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class ReportsBL
    {

        ReportsDL objReportsDL = new ReportsDL();

        #region Ledger Report:added by Shipra Garg
        //public LedgerReportDetails GetLedgerReport(LedgerReport objReport)
        //{
        //    return objReportsDL.GetLedgerReport(objReport);
        //}
        #endregion

        public List<AllReportBO> GetReport(string iFKTst_ID)
        {
            return objReportsDL.GetReportDetail(iFKTst_ID);

        }

    }
}
