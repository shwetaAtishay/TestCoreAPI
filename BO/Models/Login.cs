using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class ResetPassword : Login
    {
        public string Type { get; set; }
    }
    public class Login
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserModelSession
    {
        public string PartyId { get; set; }
        public string Hirarchy { get; set; }
        public string Type { get; set; }
        public string UserType { get; set; }
        public string Username { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string ServicesCollection { get; set; }
        public string IsActive { get; set; }
        public string PartialOrderID { get; set; }
        public string RegistrationNo { get; set; }
        public string profileImage { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }

        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public int iLocLvl { get; set; }

        public double CashInWallet { get; set; }
        public double CashOutWallet { get; set; }
        public double UseableAmtWallet { get; set; }
        public double PendingTransationinQueyWallet { get; set; }
    }
    //public class UserModel
    //{
    //    public string Name { get; set; }
    //    public string FirstName { get; set; }
    //    public int MobileVerified { get; set; }
    //    public int AdhaarVerified { get; set; }
    //    public int PanVerified { get; set; }
    //    public int EmailVerified { get; set; }
    //    public string PanCard { get; set; }
    //    public string AdhaarCard { get; set; }
    //    public string MobileNumber { get; set; }
    //    public string EmailId { get; set; }
    //    public string JanAadharNo { get; set; }
    //    public string PartyId { get; set; }
    //    public string ParentService { get; set; }
    //    public string UserType { get; set; }
    //    public string State { get; set; }
    //    public string District { get; set; }
    //    public string City { get; set; }
    //    public string Status { get; set; }
    //    public string ParentName { get; set; }
    //}

    public class RegistredUser
    {
        public string userType { get; set; }
        public string RegistrationNo { get; set; }
        public string PartyId { get; set; }
        public string userName { get; set; }
        public string FirstName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string ServiceList { get; set; }
        public string HardwareList { get; set; }
        public string PaymentStatus { get; set; }
        public int IsActive { get; set; }
    }

    public class UploadDoc
    {
        public string PartyId { get; set; }
        public byte[] Image { get; set; }
        public string ImageURL { get; set; }
        public string DocumentID { get; set; }
        public string DocumentName { get; set; }
    }
    public class RequestData : ErrorBO
    {
        public string PartyId { get; set; }
        public string LoginID { get; set; }
        public string Token { get; set; }
        public string URL { get; set; }
    }
}
