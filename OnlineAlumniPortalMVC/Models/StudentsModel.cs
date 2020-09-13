using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineAlumniPortalMVC.Models;

namespace Silkways.Models
{
    public class StudentsModel
    {
        AlumniEntities db = new AlumniEntities();
        public void Save( Student stu )
        {
            db.Students.Add(stu);
            db.SaveChanges();
        }
        public void SaveRecord(FeeRecord FR)
        {
          var tbl= db.FeeRecords.Add(FR);
          db.SaveChanges();
        }
		public List<Student> GetStudentsByID(int StudentID)
		{
			return db.Students.Where(x => x.ID == StudentID).ToList();
		}
        public List<tblWife> GetAllWifeOccupation()
        {
            return db.tblWives.ToList();
        }

        public List<tblClass> GetAllClasses()
        {
           return db.tblClasses.ToList();
        }
        public List<tblEmployed> GetAllEmployed()
        {
            return db.tblEmployeds.ToList();
        }
         public void UpdateRecord(FeeRecord fees)
        {
            db.FeeRecords.Attach(fees);
            var Update = db.Entry(fees);
            Update.Property(x => x.StudenName).IsModified = true;
            Update.Property(x => x.FatherName).IsModified = true;
            Update.Property(x => x.classID).IsModified = true;
            Update.Property(x => x.Section).IsModified = true;
            Update.Property(x => x.RollNo).IsModified = true;
            Update.Property(x => x.IssueDate).IsModified = true;
            Update.Property(x => x.DueDate).IsModified = true;
            Update.Property(x => x.UniversityCampusID).IsModified = true;
            Update.Property(x => x.PaperFund).IsModified = true;
            Update.Property(x => x.Misc).IsModified = true;
            Update.Property(x => x.BasicFee).IsModified = true;
            Update.Property(x => x.AdmissionFee).IsModified = true;
            Update.Property(x => x.PayableInDueDate).IsModified = true;
            Update.Property(x => x.PayableAfterDueDate).IsModified = true;
            //Update.Property(x => x.Class).IsModified = true;

           // Update.Property(x => x.Date).IsModified = true;
            Update.Property(x => x.ID).IsModified = true;
            Update.Property(x => x.Section).IsModified = true;
           // Update.Property(x => x.submittedFee).IsModified = true;
          //  Update.Property(x => x.IsDelete).IsModified = true;
            db.SaveChanges();

        }
        public void Update(Student slider)
        {
            db.Students.Attach(slider);
            var Update = db.Entry( slider );
            Update.Property( x => x.CreatedDate ).IsModified = true;
            Update.Property( x => x.Address ).IsModified = true;
            Update.Property( x => x.CityID ).IsModified = true;
            Update.Property( x => x.CNIC ).IsModified = true;
            Update.Property( x => x.CountryID ).IsModified = true;
            Update.Property( x => x.DateofBirth ).IsModified = true;
            Update.Property( x => x.IsActive ).IsModified = true;
            Update.Property(x => x.Email).IsModified = true;
            Update.Property(x => x.MaritalStatus).IsModified = true;
            Update.Property(x => x.Password).IsModified = true;
            Update.Property(x => x.Name).IsModified = true;
            Update.Property(x => x.Photo).IsModified = true;
            Update.Property(x => x.StudyProgram).IsModified = true;
            Update.Property(x => x.YearofPassing).IsModified = true;
            db.SaveChanges();
        }

        public Student GetByID( int ID )
        {
            return db.Students.Where(x => x.ID == ID).FirstOrDefault();
        }
        public FeeRecord GetFeeRecord(int ID)
        {
            return db.FeeRecords.Where(x => x.ID==ID).FirstOrDefault();
        }
        public List<Student> GetAll()
        {
            return db.Students.OrderByDescending( x => x.ID ).ToList();
        }
		
		public List<FeeRecord> GetFeeRecordByStudentID(int StudentID)
        {
            return db.FeeRecords.Where(x=>x.StudentID==StudentID).OrderByDescending(x => x.ID).ToList();           
        }
		public List<FeeRecord> GetAllRecord()
		{
			return db.FeeRecords.OrderByDescending(x => x.ID).ToList();
		}
		public void DeleteFeeRecord(int ID)
        {
            var item = db.FeeRecords.Where(x => x.ID == ID).FirstOrDefault();
            db.FeeRecords.Remove(item);
            db.SaveChanges();
        }
        public void Delete( int ID )
        {
            var item = db.Students.Where(x => x.ID == ID).FirstOrDefault();
            db.Students.Remove( item );
            db.SaveChanges();
        }
        public List<Student> Search(string memberName, string email, int pageno)
        {
            List<Student> lst = new List<Student>();

            string query = "select  top(50) * from ( select  ROW_NUMBER() over(order by p.ID desc)as RowNumber, p.*, COUNT(*) OVER() AS TotalCount from dbo.Students p  where 1=1  and p.IsActive = 1";
            if (!string.IsNullOrEmpty(memberName))
            {
                query += " and Name like '%" + memberName + "%'";
            }
            if (!string.IsNullOrEmpty(email))
            {
                query += " and email like '%" + email + "%'";
            }
            query += ") a where a.RowNumber > " + pageno + " * 50";
            return db.Students.SqlQuery(query).ToList();

        }
        

        public int SearchCount(string memberName, string email)
        {


            string query = "select  Count(*) from dbo.Students p  where 1=1 and p.IsActive = 1";
            if (!string.IsNullOrEmpty(memberName))
            {
                query += " and Name like '%" + memberName + "%'";
            }
            if (!string.IsNullOrEmpty(email))
            {
                query += " and email like '%" + email + "%'";
            }

            var abc = db.Database.SqlQuery<int>(query).FirstOrDefault();
            int count = Convert.ToInt32(abc);
            return count;

        }
        //public List<FeeRecord> SearchFeeRecord(string StudenName, string submittedFee, int pageno)
        //{
        //    List<FeeRecord> lst = new List<FeeRecord>();

        //    string query = "select  top(50) * from ( select  ROW_NUMBER() over(order by p.ID desc)as RowNumber, p.*, COUNT(*) OVER() AS TotalCount from dbo.FeeRecords p  where 1=1  and p.IsDelete = 0";
        //    if (!string.IsNullOrEmpty(StudenName))
        //    {
        //        query += " and Name like '%" + StudenName + "%'";
        //    }
        //    if (!string.IsNullOrEmpty(submittedFee))
        //    {
        //        query += " and email like '%" + submittedFee + "%'";
        //    }
        //    query += ") a where a.RowNumber > " + pageno + " * 50";
        //    return db.FeeRecords.SqlQuery(query).ToList();

        //}
        //public int FeeRecordSearchCount(string StudenName, string submittedFee)
        //{


        //    string query = "select  Count(*) from dbo.FeeRecords p  where 1=1 and p.IsDelete = 0";
        //    if (!string.IsNullOrEmpty(StudenName))
        //    {
        //        query += " and Name like '%" + StudenName + "%'";
        //    }
        //    if (!string.IsNullOrEmpty(submittedFee))
        //    {
        //        query += " and email like '%" + submittedFee + "%'";
        //    }

        //    var abc = db.Database.SqlQuery<int>(query).FirstOrDefault();
        //    int count = Convert.ToInt32(abc);
        //    return count;

        //}
    }
}