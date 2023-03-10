using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
   public partial class AcdmcMst
    {
        public string FromYear { get; set; }
        public string ToYear { get; set; }
        public int NoOfStudent { get; set; }
        public int Fk_Result { get; set; }
        public int NoOfStudentPass { get; set; }
        public int TotalStudent { get; set; }
        public int Course { get; set; }
        public decimal Percentage { get; set; }
        public string GUIID { get; set; }
        public int iPk_AcdmcId { get; set; }
        public string Type { get; set; }
        public string clgID { get; set; }
    }
}
