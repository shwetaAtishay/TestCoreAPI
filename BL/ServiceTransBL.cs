using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{

    public class ServiceTransBL
    {
        ServiceTransDL objSerTransDL = new ServiceTransDL();
        public List<ServiceTransationBO> GetServicesTransation(string PartyId, int fk_SrvTyp)
        {
            //ResponseData objResponseData = new ResponseData();
            return objSerTransDL.GetServicesTransation(fk_SrvTyp, PartyId);
        }
        //public List<ServiceWisePartCountBO> SerwisePartnerCount(string PartyId)
        //{

        //    return objSerTransDL.GetSerwisePartnerCount(PartyId);
        //}
        public List<PartwiseStatementBO> PartwiseViewStatement(string PartyId)
        {

            return objSerTransDL.PartwiseViewStatementDetails(PartyId);
        }
        public List<UserProfileDetailsBO> UserProfileDetails(string PartyId)
        {

            return objSerTransDL.GetUserProfileDetails(PartyId);
        }
        public List<UserPartywiseProfileBO> UserPartywise(string PartyId)
        {

            return objSerTransDL.UserPartywiseProfileReport(PartyId);
        }
        public List<DashBoardUserTypewiseProfitBO> DashBoardUserTypewiseProfit(string PartyId)
        {

            return objSerTransDL.GetDashBoardUserTypewiseProfit(PartyId);
        }
        //public List<WalletAMTBO> WalletBlanceShow(string PartyId)
        //{

        //    return objSerTransDL.GetWalletAMT(PartyId);
        //}
        //public List<WalletAMTBO> DashboardPendingTransactions(string PartyId)
        //{

        //    return objSerTransDL.GetDashboardPendingTransactions(PartyId);
        //}
        //public List<WalletAMTBO> DashboardTopBusinessMakers(string PartyId)
        //{

        //    return objSerTransDL.GetDashboardTopBusinessMakers(PartyId);
        //}
        //public List<WalletAMTBO> DashboardStateWiseCollection(string PartyId)
        //{

        //    return objSerTransDL.GetDashboardStateWiseCollection(PartyId);
        //}
        ////Traget Vs Actuchual
        //public List<WalletAMTBO> DashboardTargetvsActual()
        //{

        //    return objSerTransDL.GetDashboardTargetvsActual();
        //}
        ////Partner wise count
        //public List<WalletAMTBO> DashboardUserwisePartnerCount(string PartyId)
        //{

        //    return objSerTransDL.GetDashboardUserwisePartnerCount(PartyId);
        //}
        ////DashBoard Service Wise Income
        //public List<WalletAMTBO>DashBoardServiceWiseIncome()
        //{
        //    return objSerTransDL.GetDashBoardServiceWiseIncome();
        //}

        
    }
}
