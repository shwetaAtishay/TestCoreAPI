using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class ServiceTransationBO
    {
        public string PartyId { get; set; }
        public int? fk_SrvTyp { get; set; }
        public string UserType { get; set; }
        public string Partyname { get; set; }
        public string ParentName { get; set; }
        public string RefId { get; set; }
        public string TxnId { get; set; }
        public string TrnsDate { get; set; }
        public string ServiceProvider { get; set; }
        public string OperatorId { get; set; }
        public string TransactionAmnt { get; set; }
        public string CommissonAmnt { get; set; }
        public string SoldPrice { get; set; }
        public string MobileNo { get; set; }
        public string CardNo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string IPAddress { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }


    }
    public class ListServiceTransationBOMaster : ResponseData
    {
        public List<ServiceTransationBO> ListRequest { get; set; }
    }
}
