using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class TrackException
    {
        public long TrackExceptionId { get; set; }
        public long? UserId { get; set; }
        public bool? Apiexception { get; set; }
        public bool? WebException { get; set; }
        public bool? AndroidException { get; set; }
        public bool? StoredProcedurebException { get; set; }
        public string ExceptionMsg { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionUrl { get; set; }
        public DateTime? LogDate { get; set; }
        public int? LogYear { get; set; }
        public int? LogMonth { get; set; }
        public int? LogDay { get; set; }
        public int? LogHours { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsResolved { get; set; }
        public string ResolutionDesciption { get; set; }
        public string ResolvedBy { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public string VerifiedBy { get; set; }
        public DateTime? VerifieDate { get; set; }
    }
}
