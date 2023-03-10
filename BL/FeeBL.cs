using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class FeeBL
    {
        FeeDL objfeeDL = new FeeDL();
        public ResponseData addFeeDetails(FeeMaster fee)
        {
            return objfeeDL.addFeeDetails(fee);
        }
        public ResponseData GetFeeData()
        {
            return objfeeDL.GetFeeData();
        }
    }
}
