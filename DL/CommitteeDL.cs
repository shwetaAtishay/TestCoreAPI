using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using static System.Exception;

namespace DL
{
    public class CommitteeDL
    {
        ResponseData objResponseData = new ResponseData();

        public ResponseData getCommitteeList(int deptID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@type", "GetCommittee");
                param[1] = new SqlParameter("@menuId", deptID);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = "Committee Data List";
                        objResponseData.ResponseCode = "0";
                        objResponseData.statusCode = 1;
                        objResponseData.Data = ds.Tables[0];
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        objResponseData.statusCode = 0;
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.statusCode = 0;
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
                //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }

        public ResponseData getCommitteeMembersList(int committeeID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@type", "GetCommitteeMembers");
                param[1] = new SqlParameter("@menuId", committeeID);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = "Committee Data List";
                        objResponseData.ResponseCode = "0";
                        objResponseData.statusCode = 1;
                        objResponseData.Data = ds.Tables[0];
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        objResponseData.statusCode = 0;
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.statusCode = 0;
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
                //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }
        
        public ResponseData AssignCommitteeToApplication(Committee committeeDetails)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@iFk_CmtyID", committeeDetails.iFk_CmtyID);
                param[1] = new SqlParameter("@sApplNo", committeeDetails.sApplNo);
                param[2] = new SqlParameter("@isNotfy", committeeDetails.isNotfy);
                param[3] = new SqlParameter("@dtStrtDate", committeeDetails.dtStrtDate);
                param[4] = new SqlParameter("@tStrttime", committeeDetails.tStrttime);
                param[5] = new SqlParameter("@dtEndDate", committeeDetails.dtEndDate);
                param[6] = new SqlParameter("@tEndtime", committeeDetails.tEndtime);


                ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_AssignCommittee_Insert]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                        objResponseData.ResponseCode = "0";
                        objResponseData.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusCode"].ToString());
                        objResponseData.Data = ds.Tables[0];
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        objResponseData.statusCode = 0;
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.statusCode = 0;
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
                //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }
        
        public ResponseData GetExistingCommitteeAsignment(string applicationNumber)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@type", "GetAssignedCommitteeAndMembers");
                param[1] = new SqlParameter("@menuId", applicationNumber);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = "Assigned Committee Details";
                        objResponseData.ResponseCode = "0";
                        objResponseData.statusCode = 1;
                        objResponseData.Data = ds.Tables[0];
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        objResponseData.statusCode = 0;
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.statusCode = 0;
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
                //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }
        public ResponseData SendMail(SendMailToCommittee mailToCommittee)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@type", "DeleteAssignedCommittee");
                param[1] = new SqlParameter("@menuId", mailToCommittee.applicationNumber);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                        objResponseData.ResponseCode = "0";
                        objResponseData.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusCode"]);
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        objResponseData.statusCode = 0;
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.statusCode = 0;
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
                //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }

    }
}
