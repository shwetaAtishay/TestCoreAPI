using BO;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using StaffBO = BO.Models.StaffBO;

namespace DL
{
    public class StaffDL
    {
        ErrorBO objResponseData = new ErrorBO();
        public ErrorBO SaveStaff(StaffBO.Staff _obj)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[32];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@Name", _obj.Name);
                param[2] = new SqlParameter("@Email", _obj.Email);
                param[3] = new SqlParameter("@Mobile", _obj.Mobile);
                param[4] = new SqlParameter("@RoleId", _obj.Role);
                param[5] = new SqlParameter("@Qualification", _obj.Qualification);
                param[6] = new SqlParameter("@CatType", _obj.Type);

                param[7] = new SqlParameter("@Aadhaar", _obj.Aadhaar);
                param[8] = new SqlParameter("@Pan", _obj.Pan);
                param[9] = new SqlParameter("@Profile", _obj.Profile);
                param[10] = new SqlParameter("@Experience", _obj.Experience);

                param[11] = new SqlParameter("@AadharExtension", _obj.AadhaarExtension);
                param[12] = new SqlParameter("@AadharDocumentContent", _obj.AadhaarContentType);
                param[13] = new SqlParameter("@PanExtension", _obj.PanExtension);
                param[14] = new SqlParameter("@PanDocumentContent", _obj.PanContentType);
                param[15] = new SqlParameter("@ProfileExtension", _obj.ProfileExtension);
                param[16] = new SqlParameter("@ProfileDocumentContent", _obj.ProfileContentType);

                param[17] = new SqlParameter("@ExperienceExtension", _obj.ExperienceExtension);
                param[18] = new SqlParameter("@ExperienceContentType", _obj.ExperienceContentType);
                param[19] = new SqlParameter("@Guid", _obj.Guid);


                param[20] = new SqlParameter("@DOB", _obj.DOB);
                param[21] = new SqlParameter("@DOJ", _obj.DOJ);
                param[22] = new SqlParameter("@DOA", _obj.DOA);

                param[23] = new SqlParameter("@ResearchGuide", _obj.ResearchGuide);
                param[24] = new SqlParameter("@PFDeduction", _obj.PFDeduction);
                param[25] = new SqlParameter("@PFNumber", _obj.PFNumber);

                param[26] = new SqlParameter("@Salary", _obj.Salary);
                param[27] = new SqlParameter("@StaffStatus", _obj.StaffStatus);
                param[28] = new SqlParameter("@Specialization", _obj.Specialization);

                param[29] = new SqlParameter("@CourseId", _obj.Course.NulllToInt());
                param[30] = new SqlParameter("@Subjectwithcourse", _obj.Subject.NulllToInt());
                param[31] = new SqlParameter("@ExpNo", _obj.ExpNo);

                dt = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_Staff_SaveView]", param);
                if (_obj.QualificationDetails != null)
                {
                    for (int i = 0; i <= _obj.QualificationDetails.Count - 1; i++) //Rows.Count - 1; i++
                    {
                        SqlParameter[] param1 = new SqlParameter[7];
                        param1[0] = new SqlParameter("@Type", "InsertEduDetail");
                        param1[1] = new SqlParameter("@PostQualification", _obj.QualificationDetails[i].Qualification.NulllToInt());
                        param1[2] = new SqlParameter("@Identity", dt.Rows[0]["Id"].NulllToInt());
                        param1[3] = new SqlParameter("@Subject", _obj.QualificationDetails[i].Subject);
                        param1[4] = new SqlParameter("@PassingYear", _obj.QualificationDetails[i].PassingYear);
                        param1[5] = new SqlParameter("@Institute", _obj.QualificationDetails[i].Institute);
                        param1[6] = new SqlParameter("@Marks", _obj.QualificationDetails[i].MarksPercentage);
                        ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Staff_SaveView]", param1);

                    }
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        objResponseData.Messsage = dt.Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = dt.Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = dt.Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = dt.Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }
        public List<StaffBO.Staff> StaffList(string Guid)
        {
            List<StaffBO.Staff> _result = new List<StaffBO.Staff>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "Details");
                param[1] = new SqlParameter("@Guid", Guid);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Staff_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new StaffBO.Staff
                                {
                                    Id = DR["Id"].NulllToString(),
                                    Name = DR["Name"].NulllToString(),
                                    Email = DR["Email"].NulllToString(),
                                    Role = DR["Role"].NulllToString(),
                                    Mobile = DR["Mobile"].NulllToString(),
                                    Qualification = DR["Qualification"].NulllToString(),
                                    Type = DR["Type"].NulllToString(),
                                    Aadhaar = DR["Aadhaar"].NulllToString(),
                                    Pan = DR["Pan"].NulllToString(),
                                    Profile = DR["Profile"].NulllToString(),
                                    Experience = DR["Experience"].NulllToString(),

                                    DOB = DR["DOB"].NulllToString(),
                                    DOJ = DR["DOJ"].NulllToString(),
                                    DOA = DR["DOA"].NulllToString(),
                                    Salary = DR["Salary"].NulllToString(),
                                    StaffStatus = DR["StaffStatus"].NulllToString(),
                                    ResearchGuide = DR["ResearchGuide"].NulllToString(),
                                    PFDeduction = DR["PFDeduction"].NulllToString(),
                                    PFNumber = DR["PFNumber"].NulllToString(),
                                    Specialization = DR["Specialization"].NulllToString(),
                                    Course = DR["Course"].NulllToString(),
                                    Subject = DR["Subject"].NulllToString(),
                                    ExpNo = DR["ExpNo"].NulllToString(),
                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }

        public ErrorBO StaffDelete(int Id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "Delete");
                param[1] = new SqlParameter("@Identity", Id);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Staff_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }

        public List<StaffBO.QualificationDetails> GetQualificationDetails(int Id)
        {
            List<StaffBO.QualificationDetails> _result = new List<StaffBO.QualificationDetails>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetEduDetail");
                param[1] = new SqlParameter("@Identity", Id);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Staff_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new StaffBO.QualificationDetails
                                {
                                    Institute = DR["sInstitute"].NulllToString(),
                                    MarksPercentage = DR["sMarkPersntgGrad"].NulllToString(),
                                    PassingYear = DR["sPssngYr"].NulllToString(),
                                    Subject = DR["sSubjct"].NulllToString(),
                                    Qualification = DR["sQualification"].NulllToString(),
                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }

        public List<StaffBO.Staff> ExistingNOCDetails(ExistingNOCRequest obj)
        {
            List<StaffBO.Staff> _result = new List<StaffBO.Staff>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Type", "StaffDetails");
                param[1] = new SqlParameter("@CollageId", obj.CollageId);
                param[2] = new SqlParameter("@CourseId", obj.CourseId);
                param[3] = new SqlParameter("@DepartmentId", obj.DepartmentId);
                param[4] = new SqlParameter("@TrustId", obj.TrustId);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ExistingNOCDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new StaffBO.Staff
                                {
                                    Id = DR["Id"].NulllToString(),
                                    Name = DR["Name"].NulllToString(),
                                    Email = DR["Email"].NulllToString(),
                                    Role = DR["Role"].NulllToString(),
                                    Mobile = DR["Mobile"].NulllToString(),
                                    Qualification = DR["Qualification"].NulllToString(),
                                    Type = DR["Type"].NulllToString(),
                                    Aadhaar = DR["Aadhaar"].NulllToString(),
                                    Pan = DR["Pan"].NulllToString(),
                                    Profile = DR["Profile"].NulllToString(),
                                    Experience = DR["Experience"].NulllToString(),

                                    DOB = DR["DOB"].NulllToString(),
                                    DOJ = DR["DOJ"].NulllToString(),
                                    DOA = DR["DOA"].NulllToString(),
                                    Salary = DR["Salary"].NulllToString(),
                                    StaffStatus = DR["StaffStatus"].NulllToString(),
                                    ResearchGuide = DR["ResearchGuide"].NulllToString(),
                                    PFDeduction = DR["PFDeduction"].NulllToString(),
                                    PFNumber = DR["PFNumber"].NulllToString(),
                                    Specialization = DR["Specialization"].NulllToString(),
                                    Course = DR["Course"].NulllToString(),
                                    Subject = DR["Subject"].NulllToString(),
                                });
                            }
                        }
                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }
    }
}
