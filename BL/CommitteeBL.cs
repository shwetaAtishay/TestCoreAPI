using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class CommitteeBL
    {
        CommitteeDL objcommitteeDL = new CommitteeDL();
        public ResponseData getCommitteeList(int deptID)
        {
            return objcommitteeDL.getCommitteeList(deptID);
        }
        
        public ResponseData getCommitteeMembersList(int committeeID)
        {
            return objcommitteeDL.getCommitteeMembersList(committeeID);
        }
        
        public ResponseData AssignCommitteeToApplication(Committee committeeDetails)
        {
            return objcommitteeDL.AssignCommitteeToApplication(committeeDetails);
        }
        
        public ResponseData GetExistingCommitteeAsignment(string applicationNumber)
        {
            return objcommitteeDL.GetExistingCommitteeAsignment(applicationNumber);
        }
        
        public ResponseData SendMail(SendMailToCommittee mailToCommittee)
        {
            return objcommitteeDL.SendMail(mailToCommittee);
        }
    }
}
