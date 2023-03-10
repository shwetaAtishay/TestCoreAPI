using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    //public class BasicDetails
    //{
    //    public int? Id { get; set; }
    //    public string Type { get; set; }
    //    public string TrustInfoId { get; set; }
    //    public string CollegeName { get; set; }
    //    public int UniverSity { get; set; }
    //    public string MobileNumber { get; set; }
    //    public string Email { get; set; }
    //    public int District { get; set; }
    //    public int Division { get; set; }
    //    public int SubDivision { get; set; }
    //    public int District1 { get; set; }
    //    public int Tehsil { get; set; }
    //    public int ParliamentArea { get; set; }
    //    public int AssembleArea { get; set; }
    //    public int CityTownVillage { get; set; }
    //    public int UrbanRular { get; set; }
    //    public int PanchayatSimiti { get; set; }
    //    public string AddressLine1 { get; set; }
    //    public string AddressLine2 { get; set; }
    //    public int PinCode { get; set; }
    //    public string Latitudedd { get; set; }
    //    public string Longitudedd { get; set; }
    //    public string AddiMobileNumber { get; set; }
    //    public string Websiteurl { get; set; }
    //    public string LandlineNumber { get; set; }
    //    public string CollageLogo { get; set; }
    //    public string CollageLogoExtension { get; set; }
    //    public string CollageLogoContenttype { get; set; }

    //    //public string Boys { get; set; }
    //    //public string Girls { get; set; }
    //    //public string CoEducation { get; set; }
    //    public int CollegeType { get; set; }
    //    public string ContactNo1 { get; set; }
    //    public string EmailAddress1 { get; set; }
    //    public string ContactNo2 { get; set; }
    //    public string EmailAddress2 { get; set; }

    //    public string collegeLevel { get; set; }
    //    public string collegeMedium { get; set; }

    //    public List<ContactDetails> ContactDetails { get; set; }

    //}

    public class BasicDetails
    {
        public int? Id { get; set; }
        public string TrustInfoId { get; set; }
        public string CollegeName { get; set; }
        public int UniverSity { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string LocationType { get; set; }
        public int DistrictId { get; set; }
        public int TehsilId { get; set; }
        public int CityId { get; set; }
        public int BlockId { get; set; }
        public string WardNo { get; set; }
        public int AssembleArea { get; set; }
        public int CityTownVillage { get; set; }
        public int UrbanRular { get; set; }
        public int PanchayatSimiti { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PinCode { get; set; }
        public string Latitudedd { get; set; }
        public string Longitudedd { get; set; }
        public string AddiMobileNumber { get; set; }
        public string Websiteurl { get; set; }
        public string LandlineNumber { get; set; }
        public string CollageLogo { get; set; }
        public string CollageLogoExtension { get; set; }
        public string CollageLogoContenttype { get; set; }
        //public string Boys { get; set; }
        //public string Girls { get; set; }
        //public string CoEducation { get; set; }
        public string collegeLevel { get; set; }
        public string collegeMedium { get; set; }
        public string CollageType { get; set; }

        public List<ContactDetails> ContactDetails { get; set; }
        public string CollageCategory { get; set; }
        public string AISHECodeStatus { get; set; }
        public string AIESHCode { get; set; }
        public int PaliamentAreaName { get; set; }
        public int LegislativeAreaName { get; set; }
        public string CollageNamehindi { get; set; }
        public int DivisionId { get; set; }
        public int SubDivisionId { get; set; }
        public string CollegeTypeId { get; set; }
        public string TagDegrees { get; set; }
    }
    public class ContactDetails
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }

    public class NewCollegeDetails
    {
        public string sNameOfClg { get; set; }
        public string clgAddress { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string iClgTyp { get; set; }
        public string collegeType { get; set; }
        public int DistrictID { get; set; }
        public string District { get; set; }
        public int TehsilID { get; set; }
        public string Tehsil { get; set; }
        public string backwardArea { get; set; }
        public string totalFee { get; set; }
        public List<CollegeCourseSubject> courseSubjects { get; set; }

    }
    public class CollegeCourseSubject
    {
        public string CourseName { get; set; }
        public string subjectName { get; set; }
    }



}
