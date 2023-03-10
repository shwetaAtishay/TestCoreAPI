using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class VertinaryBL
    {
        VertinaryDL objvertinaryDL = new VertinaryDL();
        public ResponseData addVertinaryDetails(VertinaryModalSave vertinary)
        {
            return objvertinaryDL.addVertinaryDetails(vertinary);
        }
    }
}
