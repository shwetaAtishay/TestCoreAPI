using BO.Models;
using DL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BL
{
    public class SmsMailBL
    {
        SmsMailDL _objSMSDL = new SmsMailDL();
        private string ServiceName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("RajSMSSetting")["SmsClientID"]; //SiteKeys.ETULAMANUNIQUEID
        private string UniqueID = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("RajSMSSetting")["SmsUniqueID"]; //SiteKeys.ETULAMANUNIQUEID
        private string SMSUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("RajSMSSetting")["SmsURL"]; //SiteKeys.ETULAMANUNIQUEID
        private string SmsClientID = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("RajSMSSetting")["SmsClientID"]; //SiteKeys.ETULAMANUNIQUEID
        private string SMSUserName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("RajSMSSetting")["SMSUserName"]; //SiteKeys.ETULAMANUNIQUEID
        private string SMSPassWord = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("RajSMSSetting")["SMSPassword"]; //SiteKeys.ETULAMANUNIQUEID



        #region Master OTP send
        public SmsResponseModel GenerateSms(MailSMSModel model)
        {
            try
            {
                string smsBody = CreateUNOCSmsProcess(model);
                model.SMSBody = smsBody;
                var obj = new UNOCSmsModel
                {
                    Language = model.Language,
                    Message = model.SMSBody,
                    MobileNo = model.MobileNo,
                    ServiceName = ServiceName,
                    UniqueID = UniqueID
                };
                //return new SmsResponseModel();
                return SendUNOCSMS(obj);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string CreateUNOCSmsProcess(MailSMSModel model)
        {
            try
            {
                {
                    //CustomMail.StatusSmsType(model.ApplicationStatusType);
                    SMSTemplates messageTemplate = _objSMSDL.SendSMS_DocumentApproval(model.SMSType);
                    if (messageTemplate != null)
                    {
                        if (!string.IsNullOrEmpty(messageTemplate.SMSTemplate))
                        {
                            if (messageTemplate.SMSTemplate.Contains("#OTP"))
                            {
                                messageTemplate.SMSTemplate = messageTemplate.SMSTemplate.Replace("{#OTP#}", model.OTP.ToString());
                            }
                            return messageTemplate.SMSTemplate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "SMSMail:CreateUNOCSmsProcess", "UNOCapi", "NA");
                throw;
            }
            return "";
        }

        public SmsResponseModel SendUNOCSMS(UNOCSmsModel Model)
        {
            try
            {

                Model.ServiceName = ServiceName;
                Model.UniqueID = UniqueID;
                var response = string.Empty;
                WebRequest request = (HttpWebRequest)WebRequest.Create(SMSUrl + "?client_id=" + SmsClientID);
                request.ContentType = "application/json";
                request.Method = "POST";
                request.Headers.Add("username", SMSUserName);
                request.Headers.Add("password", SMSPassWord);
                var inputJsonSer = System.Text.Json.JsonSerializer.Serialize(Model);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(inputJsonSer);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                var outputJsonDser = System.Text.Json.JsonSerializer.Deserialize<SmsResponseModel>(response);

                return outputJsonDser;
            }
            catch (WebException ex)
            {
                SmsResponseModel res = new SmsResponseModel();
                res.ResponseCode = "200";
                res.ResponseID = "1234556789";
                res.ResponseMessage = "Request send Successfully";
                var outputJsonDser = res;
                return outputJsonDser;
                throw;
            }
        }
        #endregion
    }
}
