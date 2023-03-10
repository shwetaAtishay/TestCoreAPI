using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;
using StaffBO = BO.Models.StaffBO;

namespace BL
{
    public class StaffBL
    {
        StaffDL objAdminDL = new StaffDL();
        public ErrorBO SaveStaff(StaffBO.Staff _obj)
        {
            return objAdminDL.SaveStaff(_obj);
        }
        public List<StaffBO.Staff> StaffList(string Guid)
        {
            return objAdminDL.StaffList(Guid);
        }

        public ErrorBO StaffDelete(int Id)
        {
            return objAdminDL.StaffDelete(Id);
        }

        public List<StaffBO.Staff> ExistingNOCDetails(ExistingNOCRequest obj)
        {
            return objAdminDL.ExistingNOCDetails(obj);
        }
    }
}
