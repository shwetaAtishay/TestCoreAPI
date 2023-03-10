using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class ListDataBL
    {
        ListDataDL _objDl = new ListDataDL();
        public List<CustomList> GetCommonList(CustomListRequest req)
        {
            return _objDl.GetCommonList(req);
        }
    }
}
