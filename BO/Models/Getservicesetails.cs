using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class Getservicesetails
    {
        public string RateMasterId { get; set; }
        public string ServiceName { get; set; }
        public string CategoryID { get; set; }
        public string Name { get; set; }
        public string className { get; set; }
        public string ChargeType { get; set; }
        public string UnitType { get; set; }
        public string PaymentType { get; set; }
        public int Amount { get; set; }
        public int Isactive { get; set; }
    }
    public class GetservicesetailsAndroid
    {
        public string CategoryID { get; set; }
        public string Name { get; set; }
        public string ServiceIcon { get; set; }
        public string RegistrationCharge { get; set; }
        public string AnnualMaintenanceCharge { get; set; }
        public string GSTPercentage { get; set; }
    }


    public class GetservicesetailsAndroidNew
    {
        public string CategoryId { get; set; }
        public string TypeName { get; set; }
        public decimal GstAmount { get; set; }
        public decimal IGST { get; set; }
        public decimal CGST { get; set; }
        public decimal Commision { get; set; }
        public decimal ServiceCharges { get; set; }
        public decimal CourierCharges { get; set; }
        public decimal TotalAmount { get; set; }
        public string CategoryName { get; set; }
        public DateTime Createddate { get; set; }
        public string services { get; set; }
        public string ServiceIcon { get; set; }
        public int IsActive { get; set; }
    }



    public class Services
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string varificationList { get; set; }
        public string DocumentList { get; set; }
        public string HardwareList { get; set; }

    }

    public class HardwareList
    {
        public string HardwareId { get; set; }
        public string Name { get; set; }
        public string GST { get; set; }
        public string Amount { get; set; }
        public string ChargeType { get; set; }
        public string UnitType { get; set; }
    }


    public class HardwareNameList
    {
        public string HardwareName { get; set; }
    }
    public class ServiceNameList
    {
        public string ServiceName { get; set; }
    }
    public class DocumentList
    {
        public string PartyId { get; set; }
        public string UploadDocumentUrl { get; set; }
        public string Name { get; set; }
    }

    public class PaymentDetails
    {
        public string PaymentMode { get; set; }
        public string Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string PartyId { get; set; }
    }




    public class UserModel
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int MobileVerified { get; set; }
        public int AdhaarVerified { get; set; }
        public int PanVerified { get; set; }
        public int EmailVerified { get; set; }
        public string PanCard { get; set; }
        public string AdhaarCard { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string JanAadharNo { get; set; }
        public string PartyId { get; set; }
        public string ParentService { get; set; }
        public string UserType { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public string ParentName { get; set; }
    }
    public class UserDetailsData
    {
        public UserModel userDetails { get; set; }
        public List<ServiceNameList> serviceName { get; set; }
        public List<HardwareNameList> harwareName { get; set; }
        public List<DocumentList> documents { get; set; }
        public List<PaymentDetails> payDetails { get; set; }
    }



    public class ServiceIDs
    {
        public string serviceList { get; set; }
    }

    public class MobileVerification
    {
        public string Mobile { get; set; }
        public string Message { get; set; }
    }
}
