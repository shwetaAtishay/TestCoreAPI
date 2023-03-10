using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class Partial
    {
        public partial class RegistratedUser
        {
            public string UserType { get; set; }
            public string PartyId { get; set; }
            public string RegistrationNo { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string MobileNumber { get; set; }
            public string Servicecollection { get; set; }
            public string Hardwarecollection { get; set; }
            public int IsActive { get; set; }
            public string PaymentStatus { get; set; }
            public string EncryPartyId { get; set; }
        }
        public class ACtivedServicesHardwarelist
        {
            public string OrderId { get; set; }
            public string PartyId { get; set; }
            public string Servicecollection { get; set; }
            public string Hardwarecollection { get; set; }
            public string OrderStatus { get; set; }
        }
        public partial class Commisssiondata
        {
            public string TableName { get; set; }
            public int CommissionMasterId { get; set; }
            public int UserType { get; set; }
            public int ServiceTypeId { get; set; }
            public int Isdefault { get; set; }
            public string PartyId { get; set; }

            public string IsdefaultPartyId { get; set; }
        }
        public class Tree
        {
            public string PartyId { get; set; }
            public string ParentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailId { get; set; }
            public int IsActive { get; set; }
        }

        public class SLBMST
        {
            public int? iPk_SlbMst { get; set; }
            public Nullable<int> iTxnAmtFm { get; set; }
            public Nullable<int> iTxnAmtTo { get; set; }
            public int iSts { get; set; }
            public string dtCrtDt { get; set; }
            public Boolean bRngSet { get; set; }
            public int iSerId { get; set; }
            public string sPatyCode { get; set; }
        }

        public partial class ApesSetCommission
        {
            public string TransactionAmountFrom { get; set; }
            public string TransactionAmountTo { get; set; }
            public string Retailer { get; set; }
            public string Distributer { get; set; }
            public string Stockist { get; set; }
            public string Whitelabel { get; set; }
            public string Retailer_Commission { get; set; }
            public string Distributer_Commission { get; set; }
            public string Stockist_Commission { get; set; }
            public string Whitelabel_Commission { get; set; }
        }
    }
}
