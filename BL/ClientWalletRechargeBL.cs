using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class ClientWalletRechargeBL
    {
        ClientWalletRechargeDL objWalletRechargeDA = new ClientWalletRechargeDL();
        #region WalletRequestAccept/Reject:added by Shipra Garg
        //public ErrorBO ClientWalletRequest(ClientWalletRecharge BOobj)
        //{
        //    return objWalletRechargeDA.ClientWalletRequest(BOobj);
        //}
        //public ErrorBO RequestAcceptReject(ClientWalletRecharge BOobj)
        //{
        //    return objWalletRechargeDA.RequestAcceptReject(BOobj);
        //}

        //public WalletRechargeReqList GetClientRequestDetails(WalletRechargeHistory partyDet)
        //{
        //    return objWalletRechargeDA.GetClientRequestDetails(partyDet);
        //}
        //public WalletRechargeReqList WRHistory(WalletRechargeHistory partyDet)
        //{
        //    return objWalletRechargeDA.WRHistory(partyDet);
        //}
        //public WalletRechargeReqList GetWalletRechargeReceipt(WalletRechargeHistory ObjRegistartion)
        //{
        //    return objWalletRechargeDA.GetWalletRechargeReceipt(ObjRegistartion);
        //}
        //public SelectedList SelectList(ListRequest ObjReq)
        //{
        //    return objWalletRechargeDA.SelectList(ObjReq);
        //}
        #endregion
    }
}
