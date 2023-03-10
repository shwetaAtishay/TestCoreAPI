using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class SwitchVendorBL
    {
        ErrorBO ErrorBO = new ErrorBO();
        SwitchVendorDL _ObjswitchDL = new SwitchVendorDL();
        public SelectedList SelectList(ListRequest ObjReq)
        {
            return _ObjswitchDL.SelectList(ObjReq);
        }
        //public VendorFilterdetailList GetVendorList(SwitchVendor _switchdet)
        //{
        //    return _ObjswitchDL.GetVendorDetailsList(_switchdet);
        //}

        //public ClientRequestData GetVendorDetail(SwitchVendor _switchdet)
        //{
        //    return _ObjswitchDL.GetVendorDetail(_switchdet);
        //}

        //public BO.ResponseData SaveChangeRequest(string PartyId, string ParentId, string RequestFor, string doyouknowresource)
        //{
        //    return _ObjswitchDL.SaveChangeRequest(PartyId, ParentId, RequestFor, doyouknowresource);
        //}

        //public VendorFilterdetailList RetailerByDistributorID(SwitchVendor _switchdet)
        //{
        //    return _ObjswitchDL.RetailerByDistributorID(_switchdet);
        //}

        //public ErrorBO SwitchParent(SwitchVendor BOobj)
        //{
        //    return _ObjswitchDL.SwitchParent(BOobj);
        //}

        //public List<ClientSwitchRequestData> GetPendingchangeRequestList(string PartyId)
        //{
        //    return _ObjswitchDL.GetPendingchangeRequestList(PartyId);
        //}
    }
}
