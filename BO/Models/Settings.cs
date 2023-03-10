using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class Settings
    {
        public int Id { get; set; }
        public string SettingName { get; set; }
        public int IsActive { get; set; }
        public string Type { get; set; }
    }
   
}
