using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class UploadDocumentBL
    {
        UploadDocumentDL objUserDL = new UploadDocumentDL();
        public ResponseData UploadDocDetails(AmendmentBO master)
        {
            return objUserDL.UploadDocDetails(master);
        }
        public ResponseData UploadNameCollege(AmendmentBO master)
        {
            return objUserDL.UploadNameCollege(master);
        }
        public ResponseData ManagmentDocDetails(AmendmentBO master)
        {
            return objUserDL.ManagmentDocDetails(master);
        }
        public ResponseData MergerDocDetails(AmendmentBO master)
        {
            return objUserDL.MergerDocDetails(master);
        }
        public ResponseData MergerDocPlaceInfo(AmendmentBO master)
        {
            return objUserDL.PlaceDocDetails(master);
        }

        #region list Coeducation
        public List<AmendmentBO> AmdList(int idclgID)
        {
            return objUserDL.AmdList(idclgID);
        }
        //Name College List
        public List<AmendmentBO> NameCollegeList(int idclgID)
        {
            return objUserDL.NameCollegeList(idclgID);
        }
        // College Place List
        public List<AmendmentBO> CollegePlaceList(int idclgID)
        {
            return objUserDL.CollegePlaceList(idclgID);
        }
        //ManagementCollegeList
        public List<AmendmentBO> ManagementCollegeList(int idclgID)
        {
            return objUserDL.ManagementCollegeList(idclgID);
        }
        //mergerDetails
        public List<AmendmentBO> MergerDetailsList(int idclgID)
        {
            return objUserDL.MergerDetailsList(idclgID);
        }

        #endregion

        #region Woman Doc
        public AmendmentBO DocumentDetail(int id)
        {
            return objUserDL.DocumentDetail(id);
        }
        public AmendmentBO CollegeDetail(int id)
        {
            return objUserDL.NameCollegeDetail(id);
        }
        public AmendmentBO CollegePlaceChnageDetail(int id)
        {
            return objUserDL.CollegePlaceChnageDetail(id);
        }
        public AmendmentBO ManagementCollegeDetail(int id)
        {
            return objUserDL.ManagementCollegeDetail(id);
        }
        //Merger
        public AmendmentBO MergerApplicantDetail(int id)
        {
            return objUserDL.MergerApplicantDetail(id);
        }
        #endregion
        #region Doc Details
        public ResponseData DeleteApplicantDetail(AmendmentBO obj)
        {
            return objUserDL.DeleteApplicantDetail(obj);
        }
        public ResponseData DeleteMergerApplicantion(AmendmentBO obj)
        {
            return objUserDL.DeleteMerger(obj);
        }
        #endregion 
    }
}
