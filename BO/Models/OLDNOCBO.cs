using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class OLDNOCBO
    {
        public int iPK_Id { get; set; }
        public string sNameOfClg { get; set; }
        public string Numbers { get; set; }
        public string CourseName { get; set; }
        public string SubjectName { get; set; }
        public string NOCType { get; set; }
        public string sAttachFile { get; set; }
        public List<OLDNOCBO> AdminList { get; set; }
    }
}
