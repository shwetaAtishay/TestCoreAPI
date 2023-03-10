using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DL
{
    public class SwitchVendorDL
    {
        ErrorBO _Access = new ErrorBO();
        ResponseData objResponseData = new ResponseData();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();
        public SelectedList SelectList(ListRequest ObjReq)
        {
            SelectedList cliData = new SelectedList();
            try
            {
                List<ListData> list = new List<ListData>();
                
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Type", ObjReq.Type);
                param[1] = new SqlParameter("@ParentId", ObjReq.ParentID);
                param[2] = new SqlParameter("@VendorType", ObjReq.CangeRequestType);
                param[3] = new SqlParameter("@LoginId", ObjReq.PartyID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_GetDetailsVendorWiseWhileParentChangeRequest_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    cliData.ResponseCode = "1";
                    cliData.Messsage = "Success";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ListData()
                        {
                            ListID = dr["ListID"].NulllToString()
                            ,
                            ListName = dr["ListName"].NulllToString()
                        });
                    }
                    cliData.Data = list;
                }
                else
                {
                    cliData.ResponseCode = "0";
                    cliData.Messsage = "No Data Found-Un!";
                    cliData.Data = null;
                }
            }
            catch (Exception ex)
            {
                cliData.ResponseCode = "5";
                cliData.Messsage = "No Data Found-Un!";
                cliData.Data = null;
                //ExceptionLog.SendExcepToDB(ex, "NA", "SwitchVendorDA:SelectList", ex.Message.ToString());
                return cliData;
            }           
            return cliData;
        }

        //public VendorFilterdetailList GetVendorDetailsList(SwitchVendor _switchdet)
        //{
        //    VendorFilterdetailList vendordetList = new VendorFilterdetailList();
        //    try
        //    {
        //        List<ListData> list = new List<ListData>();
                
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@Type", "GetVendorList");
        //        param[1] = new SqlParameter("@VendorType", _switchdet.PartyType);
        //        param[2] = new SqlParameter("@LoginId", _switchdet.PartyId);             
        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_GetDetailsVendorWiseWhileParentChangeRequest_View]", param);
        //        vendordetList.vendetList = new List<VendorFilterdetail>();
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                vendordetList.ResponseCode = "1";
        //                vendordetList.Messsage = "Success";
        //                foreach (DataRow DR in DT.Rows)
        //                {
        //                    vendordetList.vendetList.Add(
        //                   new VendorFilterdetail
        //                   {
        //                       VendorId = DR[0].NulllToString(),
        //                       FullName = DR[1].NulllToString(),
        //                       Wallet = DR[2].NulllToString(),
        //                       State = DR[3].NulllToString(),
        //                       ParentName = DR[4].NulllToString(),
        //                       ASMID = DR[5].NulllToString(),
        //                       ParentId = DR[6].NulllToString(),
        //                       ASMName = DR[7].NulllToString()

        //                   }
        //              );

        //                }
        //            }
        //            else
        //            {
        //                vendordetList.Messsage = "Data Not Found";
        //                vendordetList.ResponseCode = "0";
        //            }
        //        }
        //        else
        //        {
        //            vendordetList.Messsage = "Data Not Found";
        //            vendordetList.ResponseCode = "0";
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        vendordetList.ResponseCode = "5";
        //        vendordetList.Messsage = "Invalid Request! Please contact Support...";
        //        //ExceptionLog.SendExcepToDB(e, "NA", "SwitchVendorDA:GetVendorDetailsList", "Invalid Request! Please contact Support...");
        //    }
        //    return vendordetList;
        //}

        //public ClientRequestData GetVendorDetail(SwitchVendor _switchdet)
        //{
        //    ClientRequestData PartyDetail = new ClientRequestData();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@Type", "GetPartyDetail");
        //        param[1] = new SqlParameter("@ParentId", _switchdet.ParentID);
        //        param[2] = new SqlParameter("@LoginId", _switchdet.PartyId);
        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_GetDetailsVendorWiseWhileParentChangeRequest_View]", param);
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                //vendordetList.ResponseCode = "1";
        //                //vendordetList.Messsage = "Success";
        //                PartyDetail.Name = DT.Rows[0]["PartyName"].NulllToString();
        //                PartyDetail.PartyId = DT.Rows[0]["sPK_PrtyCode"].NulllToString();
        //                PartyDetail.RegistrationId = DT.Rows[0]["sRegNo"].NulllToString();
        //                PartyDetail.ParentId = DT.Rows[0]["sPrntId"].NulllToString();
        //                PartyDetail.Mobilenumber = DT.Rows[0]["sMobileNo"].NulllToString();
        //                PartyDetail.EmailId = DT.Rows[0]["sEmailId"].NulllToString();
        //                PartyDetail.PartyType = DT.Rows[0]["iTyp"].NulllToString();
        //                PartyDetail.State = DT.Rows[0]["State"].NulllToString();
        //                PartyDetail.CompanyAddress = DT.Rows[0]["CompanyAddress"].NulllToString();
        //            }
        //            else
        //            {
        //                //vendordetList.Messsage = "Data Not Found";
        //                //vendordetList.ResponseCode = "0";
        //            }
        //        }
        //        else
        //        {
        //            //vendordetList.Messsage = "Data Not Found";
        //            //vendordetList.ResponseCode = "0";
        //        }                
        //    }
        //    catch (Exception e)
        //    {
        //        //vendordetList.ResponseCode = "5";
        //        //vendordetList.Messsage = "Invalid Request! Please contact Support...";
        //        //ExceptionLog.SendExcepToDB(e, "NA", "SwitchVendorDA:GetVendorDetailsList", "Invalid Request! Please contact Support...");
        //    }
        //    return PartyDetail;
        //}


        public ResponseData SaveChangeRequest(string PartyId, string ParentId, string RequestFor, string doyouknowresource)
        {
            DataSet ds = new DataSet();
            bool IsParentKnow = false;
            if (doyouknowresource == "Yes")
            {
                IsParentKnow = true;
            }
            try
            {
                
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Type", "SwitchParentRequest");
                param[1] = new SqlParameter("@SubType", "");
                param[2] = new SqlParameter("@PartyId", PartyId);
                param[3] = new SqlParameter("@FromParentID", ParentId);
                param[4] = new SqlParameter("@ToParentID", ParentId);
                param[5] = new SqlParameter("@IsParentKnow", IsParentKnow);
                param[6] = new SqlParameter("@PartyTypeRequest", "NA");
                param[7] = new SqlParameter("@Switchtype", RequestFor);


                ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_SwitchParentRequestApproveReject_SaveUpdate]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }                
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }

        //public VendorFilterdetailList RetailerByDistributorID(SwitchVendor _switchdet)
        //{
        //    VendorFilterdetailList vendordetList = new VendorFilterdetailList();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@Type", "RetailerListByDistributorID");
        //        param[1] = new SqlParameter("@ParentId", _switchdet.ParentID);
        //        param[2] = new SqlParameter("@LoginId", _switchdet.PartyId);               


        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_GetDetailsVendorWiseWhileParentChangeRequest_View]", param);
        //        vendordetList.vendetList = new List<VendorFilterdetail>();
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                vendordetList.ResponseCode = "1";
        //                vendordetList.Messsage = "Success";
        //                foreach (DataRow DR in DT.Rows)
        //                {

        //                    vendordetList.vendetList.Add(
        //                   new VendorFilterdetail
        //                   {
        //                       VendorId = DR["sPK_PrtyCode"].NulllToString(),
        //                       MobileNo = DR["MobileNo"].NulllToString(),
        //                       FullName = DR["Name"].NulllToString(),
        //                       Wallet = DR["MainWalletBalance"].NulllToString(),

        //                   }
        //              );

        //                }
        //            }
        //            else
        //            {
        //                vendordetList.Messsage = "Data Not Found";
        //                vendordetList.ResponseCode = "0";
        //            }
        //        }
        //        else
        //        {
        //            vendordetList.Messsage = "Data Not Found";
        //            vendordetList.ResponseCode = "0";
        //        }                
        //    }
        //    catch (Exception e)
        //    {
        //        vendordetList.ResponseCode = "5";
        //        vendordetList.Messsage = "Invalid Request! Please contact Support...";
        //        //ExceptionLog.SendExcepToDB(e, "NA", "SwitchVendorDA:RetailerByDistributorID", "Invalid Request! Please contact Support...");
        //    }
        //    return vendordetList;
        //}

        //public ErrorBO SwitchParent(SwitchVendor BOobj)
        //{
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[6];
        //        param[0] = new SqlParameter("@Type", "SwitchParent");
        //        param[1] = new SqlParameter("@SubType", BOobj.SwitchType);
        //        param[2] = new SqlParameter("@PartyId", BOobj.PartyId);
        //        param[3] = new SqlParameter("@SwitchVendorId", BOobj.SwitchVendorId);
        //        param[4] = new SqlParameter("@ToParentID", BOobj.ToParentID);
        //        param[5] = new SqlParameter("@FromParentID", BOobj.FromParentID);

        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_SattelmentWhileSwitchingParent]", param);
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                foreach (DataRow oRow in DT.Rows)
        //                {
        //                    _Access.Messsage = oRow["Message"].NulllToString();
        //                    _Access.ResponseCode = oRow["Flag"].NulllToString();
        //                }
        //            }
        //            else
        //            {
        //                _Access.Messsage = "Data Not Found";
        //                _Access.ResponseCode = "0";
        //            }
        //        }
        //        else
        //        {
        //            _Access.Messsage = "Data Not Found";
        //            _Access.ResponseCode = "0";
        //        }                
        //        return _Access;
        //    }
        //    catch (Exception ex)
        //    {
        //        //ExceptionLog.SendExcepToDB(ex, "NA", "SwitchVendorDA:SwitchParent", ex.Message.ToString());
        //        _Access.ResponseCode = "5";
        //        _Access.Messsage = "Details Not Found-Ex!Please Contact Support.";
        //        return _Access;
        //    }
        //}

        //public List<ClientSwitchRequestData> GetPendingchangeRequestList(string PartyId)
        //{
        //    List<ClientSwitchRequestData> _result = new List<ClientSwitchRequestData>();
            
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[2];
        //        param[0] = new SqlParameter("@StringType", "VenderWiseList");
        //        param[1] = new SqlParameter("@PartyId", PartyId);

        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_ChangeRequest_View]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            // First tabe
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[0].Rows)
        //                {
        //                    _result.Add(new ClientSwitchRequestData
        //                    {
        //                        //From Request
        //                        PartyId = dr["sPK_PrtyCode"].NulllToString(),
        //                        RegistrationNo = dr["sRegNo"].NulllToString(),
        //                        PartyType = dr["PartyType"].NulllToString(),
        //                        Currentstatus = dr["CurrentStatus"].NulllToString(),
        //                        MainWalletBalance = dr["MainWalletBalance"].NulllToDouble(),
        //                        PartyName = dr["PartyName"].NulllToString(),
        //                        MobileNo = dr["sMobileNo"].NulllToString(),
        //                        CompanyAddress = dr["CompanyAddress"].NulllToString(),
        //                        State = dr["StateId"].NulllToString(),
        //                        District = dr["DistrictId"].NulllToString(),
        //                    });
        //                }
        //            }
        //        }                
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return _result;
        //}
    }
}
