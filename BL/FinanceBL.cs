using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class FinanceBL
    {
        FinanceDL objFinanceDL = new FinanceDL();
        public ResponseData addFinanceDetails(FinanceModalSave financeModal)
        {
            return objFinanceDL.addFinanceDetails(financeModal);
        }
    }
}
