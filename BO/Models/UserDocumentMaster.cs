using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public partial class UserDocumentMaster
    {
        public int UserDocumentId { get; set; }
        public int? DocumentId { get; set; }
        public string PartyId { get; set; }
        public string UploadDocumentUrl { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public int? VerifiedStatus { get; set; }
        public int? DocumentType { get; set; }
    }
    public partial class Documentlist
    {
        public string UploadDocumentUrl { get; set; }
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public int DocumentStatus { get; set; }
    }

    public class Dropdown
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string ID1 { get; set; }
        public string PartyId { get; set; }
    }
}
