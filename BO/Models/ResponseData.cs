using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class ErrorBO
    {
        public string ResponseCode { get; set; }
        public string Messsage { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class ResponseData
    {
        public string ResponseCode { get; set; }
        public int statusCode { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public int ID { get; set; }
        public object Data { get; set; }
        public string Body { get; set; }
        public string JWT { get; set; }
        public string RegistrationId { get; set; }
        public JObject Data1 { get; set; }
        public decimal FemaleCount { get; set; }
    }
    public class MobileVerificationSettings
    {
        public string ApiKey { get; set; }
        public string senderID { get; set; }
        public string Chennel { get; set; }
        public string URL { get; set; }
    }
    #region MobileRecharge Request Response
    public class MobileRechargeSetting
    {
        public string LoginID { get; set; }
        public string Website { get; set; }
        public string Authorization { get; set; }
        public string ClientId { get; set; }
        public string DeviceID { get; set; }
        public string WalletLeftURL { get; set; }
        public string PlansURL { get; set; }
        public string ShowOperatorURL { get; set; }
        public string RechargeURL { get; set; }
    }
    public class RechargeWalletLeftResponse
    {
        public string Messsage { get; set; }
        public string ResponseCode { get; set; }
        public string Amount { get; set; }
        public object PartyId { get; set; }
        public string CashOutAmount { get; set; }
    }
    public class MobileOperators
    {
        public string ListID { get; set; }
        public string ListName { get; set; }
    }
    public class AllMobileOperators
    {
        public string Messsage { get; set; }
        public string ResponseCode { get; set; }
        public List<MobileOperators> Data { get; set; }
    }

    public class PlansRequest
    {
        public string CircleName { get; set; }
        public string OperatorName { get; set; }
    }

    public class COMBO
    {
        public string desc { get; set; }
        //public string last_update { get; set; }
        public string rs { get; set; }
        public string validity { get; set; }
    }
    public class FULLTT
    {
        public string desc { get; set; }
        //public string last_update { get; set; }
        public string rs { get; set; }
        public string validity { get; set; }
    }
    public class Romaing
    {
        public string desc { get; set; }
        //public string last_update { get; set; }
        public string rs { get; set; }
        public string validity { get; set; }
    }
    public class TOPUP
    {
        public string desc { get; set; }
        // public string last_update { get; set; }
        public string rs { get; set; }
        public string validity { get; set; }
    }
    public class Records
    {
        public List<COMBO> COMBO { get; set; }
        public List<FULLTT> FULLTT { get; set; }
        public List<Romaing> Romaing { get; set; }
        public List<TOPUP> TOPUP { get; set; }
        public object SMS { get; set; }
        public object RATECUTTER { get; set; }
        public object _2G { get; set; }
        public object _3G4G { get; set; }
    }
    public class AllExistingPlans
    {
        public string APIResponseCode { get; set; }
        public string APIResponseMessage { get; set; }
        public Records records { get; set; }
        public int status { get; set; }
        public double time { get; set; }
    }
    public class RechargeRequest
    {
        public string OperatorName { get; set; }
        public string MobileNumber { get; set; }
        public string Platform { get; set; }
        public string ServiceType { get; set; }
        public string Amount { get; set; }
        public string RechargeType { get; set; }
    }
    public class TransactionResponse
    {
        public string APIResponseCode { get; set; }
        public string APIResponseMessage { get; set; }
        public int Amount { get; set; }
        public string MobileNumber { get; set; }
        public string OperatorName { get; set; }
        public object ReferenceTransactionID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string TransactionID { get; set; }
        public object TransactionOperatorID { get; set; }
        public int Walletbalance { get; set; }
    }


    #endregion

    #region Mobile Recharge Plans

    public class MobileRecharge_MPlanSettings
    {
        public string APIKey { get; set; }
        public string ShaktiAPIKey { get; set; }

    }


    #endregion
    public class AddPurchase
    {
        public string PartyId { get; set; }
        public string OrderId { get; set; }
        public int appTandCId { get; set; }
        public List<PurchaseList> PurchaseLists { get; set; }
    }

    #region MobileOTPVerification
    public class MessageData
    {
        public string Number { get; set; }
        public string MessageId { get; set; }
        public object Message { get; set; }
    }

    public class MobileOTPResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string JobId { get; set; }
        public string OTP { get; set; }
        public List<MessageData> MessageData { get; set; }

    }

    #endregion

    #region Aadhaar Full data

    public class AadharAddress
    {
        public string country { get; set; }
        public string dist { get; set; }
        public string state { get; set; }
        public string po { get; set; }
        public string loc { get; set; }
        public string vtc { get; set; }
        public string subdist { get; set; }
        public string street { get; set; }
        public string house { get; set; }
        public string landmark { get; set; }
    }

    public class AadharData
    {
        public string client_id { get; set; }
        public string full_name { get; set; }
        public string aadhaar_number { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public AadharAddress address { get; set; }
        public bool face_status { get; set; }
        public int face_score { get; set; }
        public string zip { get; set; }
        public string profile_image { get; set; }
        public bool has_image { get; set; }
        public string email_hash { get; set; }
        public string mobile_hash { get; set; }
        public string raw_xml { get; set; }
        public string zip_data { get; set; }
        public string care_of { get; set; }
        public string share_code { get; set; }
        public bool mobile_verified { get; set; }
        public string reference_id { get; set; }
        public object aadhaar_pdf { get; set; }
    }

    public class AadharFullDetails
    {
        public AadharData data { get; set; }
        public int status_code { get; set; }
        public bool success { get; set; }
        public bool Failure { get; set; }
        public object message { get; set; }
        public string message_code { get; set; }
    }
    public class AadharWithPartyId
    {
        public string PartyId { get; set; }
        public AadharFullDetails Aadhaar { get; set; }
    }

    #endregion

}
