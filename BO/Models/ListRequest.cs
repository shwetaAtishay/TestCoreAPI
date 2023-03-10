using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class ListRequest
    {
        public string PartyID { get; set; }
        public string LoginID { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string ParentID { get; set; }
        public string CangeRequestType { get; set; }
    }

    public class ListData
    {
        public string ListID { get; set; }
        public string ListName { get; set; }
    }

    public class SelectedList : ErrorBO
    {
        public List<ListData> Data { get; set; }
    }
}
