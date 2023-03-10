using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
   public class TestBL
    {
        TestDL objAdminDL = new TestDL();
        public List<Testing> GetServicesDetail()
        {
            return objAdminDL.GetServicesDetail();
        }
    }
}
