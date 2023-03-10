using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class DeptCourseMap
    {
        public int pk_MapId { get; set; }
        public int deptId { get; set; }
        public int courseId { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }
        public int SubjectID { get; set; }
        public int ClassID { get; set; }
    }
}
