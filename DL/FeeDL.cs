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
    public class FeeDL
    {
        ResponseData objResponseData = new ResponseData();

        public ResponseData addFeeDetails(FeeMaster fee)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@Type", fee.Type);
                param[1] = new SqlParameter("@DeptID", fee.DeptID);
                param[2] = new SqlParameter("@Startdate", fee.StartDate);
                param[3] = new SqlParameter("@Enddate", fee.EndDate);
                param[4] = new SqlParameter("@NOCTypID", fee.NOCTypID);
                param[5] = new SqlParameter("@FeeTypID", fee.FeeTypID);
                param[6] = new SqlParameter("@dBoys", fee.dBoys);
                param[7] = new SqlParameter("@dGirls", fee.dGirls);
                param[8] = new SqlParameter("@dCoEdu", fee.dCoEdu);
                param[9] = new SqlParameter("@dCutOff", fee.dCutOff);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_AddFeeDetails_Insert]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = "0";
                        objResponseData.statusCode = 1;
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
        public ResponseData GetFeeData()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_AddFeeDetails_Select]");

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = "Fee Master List";
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
                        objResponseData.Data = ds.Tables[0];
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.statusCode = 0;
                    objResponseData.Data = ds.Tables[0];
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
