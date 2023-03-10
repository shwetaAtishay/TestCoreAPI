using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class ServicesDocument
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public bool? IsActive { get; set; }
        public string CreateBy { get; set; }
        public string CreateName { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
