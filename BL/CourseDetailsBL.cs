using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class CourseDetailsBL
    {

        CourseDetailDL objCourseDetailDL = new CourseDetailDL();

        public ResponseData AddCourseDetail(AddCourseBO master)
        {
            return objCourseDetailDL.CourseDetailConfigure(master);
        }
        public List<AddCourseBO> ListAddCourse(string TrustId)
        {
            return objCourseDetailDL.GetCourseData(TrustId);
        }
        //Subject Insert Data
        public ResponseData SubjectNameDetail(AddCourseBO master)
        {
            return objCourseDetailDL.SubjectDetails(master);
        }
        //Get Page Subject Details
        public List<AddCourseBO> SubjectDetails(string applGUID)
        {
            return objCourseDetailDL.SubjectPageDetailsList(applGUID);
        }
        //Get Details
        public List<AddCourseBO> ListSubjectDetails(string applGUID)
        {
            return objCourseDetailDL.SubjectDetailsList(applGUID);
        }
        //by Id
        public List<AddCourseBO> ListSubjects(string type, int iPK_SubId, string SubjectName)
        {
            return objCourseDetailDL.DetailsList(type, iPK_SubId, SubjectName);
        }
        public List<CustomEnum> ListCollegeDetails()
        {
            return objCourseDetailDL.CollegeDetailsList();
        }

        public List<AddCourseBO> ListEditCourse(int id)
        {
            return objCourseDetailDL.GetEditData(id);
        }
        public ResponseData ListDeleteCourse(int id)
        {
            return objCourseDetailDL.RemoveData(id);
        }
        public ResponseData ListEditUpdate(AddCourseBO master)
        {
            return objCourseDetailDL.PutEditData(master);
        }

        public List<AddCourseBO> ExistingNOCGetSubjectList(ExistingNOCRequest obj)
        {
            return objCourseDetailDL.ExistingNOCGetSubjectList(obj);
        }
        public List<CustomEnum> GetSubject(int id)
        {
            return objCourseDetailDL.SubjectList(id);
        }
    }
}