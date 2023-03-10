using BL;
using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class SupportTickBL
    {
        SupportTickDL objSupportDL = new SupportTickDL();

        public ResponseData DetailsSupport(SupportIssue obj)
        {

            return objSupportDL.SupportDetailSave(obj);
        }
        public List<SupportIssue> SupportDetails()
        {
            return objSupportDL.GetSupportData();
        }
        public ResponseData TicketsDropdown()
        {
            return objSupportDL.TicketsList();
        }
        public ResponseData ListDeleteTickets(int id)
        {
            return objSupportDL.RemoveDataTickets(id);
        }
        public SupportIssue GetTickets(int Identity)
        {
            return objSupportDL.GetTicketsImagesList(Identity);

        }
    }
}
