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
    public class VertinaryDL
    {
        ResponseData objResponseData = new ResponseData();

        public ResponseData addVertinaryDetails(VertinaryModalSave vertinary)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@sNameOfVtnry", vertinary.sNameOfVtnry);
                param[1] = new SqlParameter("@dDistance", vertinary.dDistance);
                param[2] = new SqlParameter("@sPersnNm", vertinary.sPersnNm);
                param[3] = new SqlParameter("@sMobileNO", vertinary.sMobileNO);
                param[4] = new SqlParameter("@sLocation", vertinary.sLocation);
                param[5] = new SqlParameter("@sEmailId", vertinary.sEmailId);
                param[6] = new SqlParameter("@IsOnBoard", vertinary.IsOnBoard);
                param[7] = new SqlParameter("@sNameOfAdmin", vertinary.sNameOfAdmin);
                param[8] = new SqlParameter("@iFk_DesgntnId", vertinary.iFk_DesgntnId);
                param[9] = new SqlParameter("@sRelWithInst", vertinary.sRelWithInst);
                param[10] = new SqlParameter("@sRemark", vertinary.sRemark);
                param[11] = new SqlParameter("@appGuid", vertinary.AppGUID);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_VertinaryDetails_Save]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        var id = ds.Tables[0].Rows[0]["vertinaryID"].NulllToInt();
                        if (vertinary.animals != null && vertinary.animals.Count > 0)
                        {
                            foreach (var item in vertinary.animals)
                            {
                                addVertinaryTrnDetails(item, vertinary.AppGUID, id);
                            }
                        }

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

        public string addVertinaryTrnDetails(AnimalDetails animals, string Appguid, int PKID)
        {
            DataSet ds = new DataSet();
            var status = "";
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@appGuid", Appguid);
                param[1] = new SqlParameter("@iFK_AnmlTypeID", animals.AnimalID);
                param[2] = new SqlParameter("@iCnt", animals.Count);
                param[3] = new SqlParameter("@iFK_VTNRY_ID", PKID);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_VertinaryTRNDetails_Save]", param);


                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = status = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = "0";
                        objResponseData.statusCode = 1;

                    }
                    else
                    {
                        objResponseData.Message = status = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        objResponseData.statusCode = 0;
                        return "";
                    }
                }
                else
                {
                    objResponseData.Message = status = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.statusCode = 0;

                }


            }
            catch (Exception ex)
            {
                //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
                //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                status = ex.Message.ToString();
            }
            return status;
        }


    }
}
