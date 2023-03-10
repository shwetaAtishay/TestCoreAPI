using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class Activeclass
    {
        public string Tablename { get; set; }
        public int Id { get; set; }
        public int status { get; set; }
    }
    public class Permissionclass
    {
        public string Type { get; set; }
        public int MappingId { get; set; }
        public int MstGroupId { get; set; }
        public int PermissionId { get; set; }
        public int status { get; set; }
        public string PartyId { get; set; }
    }
}
