//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineAlumniPortalMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public Student()
        {
            this.tblStudentEvents = new HashSet<tblStudentEvent>();
            this.FeeRecords = new HashSet<FeeRecord>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DateofBirth { get; set; }
        public Nullable<int> CNIC { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> UniversityCampusID { get; set; }
        public string StudyProgram { get; set; }
        public string YearofPassing { get; set; }
        public string Photo { get; set; }
        public string EntityType { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
        public string FatherName { get; set; }
        public Nullable<int> ClassID { get; set; }
        public string Religion { get; set; }
        public string FFatherName { get; set; }
        public string FCNIC { get; set; }
        public string FCell { get; set; }
        public string FDesignation { get; set; }
        public Nullable<int> FEmployedID { get; set; }
        public string FWorkAdress { get; set; }
        public string FOrganization { get; set; }
        public Nullable<int> FMonthlyIncome { get; set; }
        public string FPhone { get; set; }
        public string FMotherName { get; set; }
        public Nullable<int> WifeID { get; set; }
        public string MContact { get; set; }
        public string MEmail { get; set; }
        public string MedicalCondtion { get; set; }
        public string EMName { get; set; }
        public string EMRESAddress { get; set; }
        public string EMPhone { get; set; }
        public string EMCell { get; set; }
        public string EMRelationship { get; set; }
        public string AQInstitue { get; set; }
        public string AQExamination { get; set; }
        public string AQBoard { get; set; }
        public string AQYearOfPassing { get; set; }
        public string AQRollNo { get; set; }
        public string AQMarksObtained { get; set; }
        public string AQPercentageMarks { get; set; }
        public bool IsApprove { get; set; }
        public string OUSection { get; set; }
        public string OURegistration { get; set; }
        public string OURemarks { get; set; }
        public Nullable<int> AdmissionFee { get; set; }
    
        public virtual tblCity tblCity { get; set; }
        public virtual tblCountry tblCountry { get; set; }
        public virtual tblUniversityCampu tblUniversityCampu { get; set; }
        public virtual tblUniversityCampu tblUniversityCampu1 { get; set; }
        public virtual ICollection<tblStudentEvent> tblStudentEvents { get; set; }
        public virtual tblClass tblClass { get; set; }
        public virtual ICollection<FeeRecord> FeeRecords { get; set; }
    }
}