using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
   public class CustomList
    {
        public int Id { get; set; }
        public string text { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
    public class setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> IsActive { get; set; }
    }   
    public class CustomListRequest
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string StrId { get; set; }
    }
    public class Architecturesave
    {
        public string Guid { get; set; }
        public string sGuidid { get; set; }
        public int? courseId { get; set; }
        public string coursetext { get; set; }
        public int? Width { get; set; }
        public int? length { get; set; }
        public int? Qty { get; set; }
        public int? iStts { get; set; }
        public string filedata { get; set; }
        public string sProfileExtension { get; set; }
        public int? Type { get; set; }
    }
}
