using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using TestCoreAPI.Controllers;
using BO.Models;
using DL;

namespace TestCoreAPI.Helper
{
    public class GetSettings
    {
        #region JWT Token Generate
        string secret = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["secret"];
        string issuer = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["issuer"];
        string audience = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["audience"];
        string accessExpiration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["accessExpiration"];
        string baseURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["baseUrl"];
        #endregion

        #region Send Email Setting
        static string ESenderID = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SendEmailSettings")["SenderID"];
        static string ESenderDisplayName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SendEmailSettings")["SenderDisplayName"];
        static string ESenderIdPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SendEmailSettings")["SenderIdPassword"];
        static string EURLToBeSend = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SendEmailSettings")["URLToBeSend"];
        static string EURLToBeSendLogin = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SendEmailSettings")["URLToBeSendLogin"];
        static string ESMTPHost = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SendEmailSettings")["SMTPHost"];
        static string EPort = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SendEmailSettings")["Port"];
        #endregion
        public string JWT_GetToken(string username)
        {
            var claims = new[]
{
                 new Claim(ClaimTypes.Name,username)
             };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(double.Parse(accessExpiration)), signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        public static SendEmail GetEmailSettings()
        {
            return new SendEmail
            {
                SenderID = ESenderID,
                SenderDisplayName = ESenderDisplayName,
                SenderIdPassword = ESenderIdPassword,
                SMTPHost = ESMTPHost,
                Port = EPort.NulllToInt(),
                URLToBeSend = EURLToBeSend,
                URLToBeSendLogin = EURLToBeSendLogin
            };

        }
        public static string SendMail(SendEmail email)
        {
            try
            {
                var sendEmailSetting = GetEmailSettings();
                var senderEmail = new MailAddress(sendEmailSetting.SenderID, sendEmailSetting.SenderDisplayName);
                var receiverEmail = new MailAddress(email.RecieverEmailID, email.RecieverDisplayName);
                var password = sendEmailSetting.SenderIdPassword;
                var sub = email.Subject;
                var text = email.Message;
                if (email.Message == "DeletionData")
                {

                    text = $"<div>Hello Dear {email.RecieverDisplayName},<br/><br/>Your Assignment to Application Number : <b>{email.Username}</b> has been revised, and your are no more belong to this application..<br/><br/>Thanks,<br/> Team NOC";
                }

                var body = text;
                var smtp = new SmtpClient
                {
                    Host = sendEmailSetting.SMTPHost,
                    Port = sendEmailSetting.Port,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(mess);
                }
                return "Email Sent";
            }
            catch (Exception ex)
            {
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "GetSetting:SendMail", "UNOCapi", "NA");
                throw ex;
            }
        }
    }
}
