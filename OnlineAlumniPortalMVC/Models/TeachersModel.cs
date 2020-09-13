using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineAlumniPortalMVC.Models;

namespace Silkways.Models
{
    public class TeachersModel
    {
        AlumniEntities db1 = new AlumniEntities();
        public void save(Teacher tch)
        {
            db1.Teachers.Add(tch);
            db1.SaveChanges();
        }
        public void Update(Teacher tchr)
        {
           db1.Teachers.Attach(tchr);
            var Update = db1.Entry(tchr);
            Update.Property(x => x.Address).IsModified = true;
            Update.Property(x => x.BasicSalary).IsModified = true;
            Update.Property(x => x.CellNo).IsModified = true;
            Update.Property(x => x.CityID).IsModified = true;
            Update.Property(x => x.CountryID).IsModified = true;
            Update.Property(x => x.Description).IsModified = true;
            Update.Property(x => x.DesignationID).IsModified = true;
            Update.Property(x => x.EndDate).IsModified = true;
            Update.Property(x => x.MaritalStatus).IsModified = true;
            Update.Property(x => x.FirstName).IsModified = true;
            Update.Property(x => x.ID).IsModified = true;
            Update.Property(x => x.LastName).IsModified = true;
            Update.Property(x => x.Religion).IsModified = true;
            Update.Property(x => x.StartDate).IsModified = true;
           
           db1.SaveChanges();
        }
        public Teacher GetByID(int ID)
        {
            return db1.Teachers.Where(x=>x.ID ==  ID).FirstOrDefault();
        }
       public void Delete(int ID)
        {
            var item = db1.Teachers.Where(x => x.ID == ID).FirstOrDefault();
            db1.Teachers.Remove(item);
            db1.SaveChanges();
        }
       public List<Designation> GetAllDesignation()
       {
           return db1.Designations.ToList();
       }
        public List<Teacher> GetAll()
       {
           return db1.Teachers.OrderByDescending(x => x.ID).ToList();
       }
        public List<SalaryRecord> GetAllRecord()
        {
            return db1.SalaryRecords.OrderByDescending(x => x.ID).ToList();
        }
        public void SaveSR(SalaryRecord sr)
        {
            db1.SalaryRecords.Add(sr);
            db1.SaveChanges();

        }
        public SalaryRecord GetRByID(int ID)
        {
            return db1.SalaryRecords.Where(x => x.ID == ID).FirstOrDefault();

        }
        public void UpdateR(SalaryRecord SR)
        {
            db1.SalaryRecords.Attach(SR);
            var update = db1.Entry(SR);
            update.Property(x => x.ID).IsModified = true;
            update.Property(x => x.FirstName).IsModified = true;
            update.Property(x => x.Date).IsModified = true;
            update.Property(x => x.IsActive).IsModified = true;
            update.Property(x => x.IsDelete).IsModified = true;
            update.Property(x => x.LastName).IsModified = true;
            update.Property(x => x.Salary).IsModified = true;
           
        }
        public void DeleteR(int ID)
        {
            var item = db1.SalaryRecords.Where(x => x.ID == ID).FirstOrDefault();
            db1.SalaryRecords.Remove(item);
            db1.SaveChanges();
                
        }
        public List<Teacher> Search(string memberName, string designation, int pageno)
        {
            List<Teacher> lst = new List<Teacher>();
            

            string query = "select  top(50) * from ( select  ROW_NUMBER() over(order by p.ID desc)as RowNumber, p.*, COUNT(*) OVER() AS TotalCount from dbo.Teachers p  where 1=1  and p.IsActive = 1";
            if (!string.IsNullOrEmpty(memberName))
            {
                query += " and FirstName like '%" + memberName + "%'";
            }
            if (!string.IsNullOrEmpty(designation))
            {
                query += " and Designation like '%" + designation + "%'";
            }
            query += ") a where a.RowNumber > " + pageno + " * 50";
            return db1.Teachers.SqlQuery(query).ToList();           

        }


        public int SearchCount(string memberName, string designation)
        {


            string query = "select  Count(*) from dbo.Teachers p  where 1=1 and p.IsActive = 1";
            if (!string.IsNullOrEmpty(memberName))
            {
                query += " and FirstName like '%" + memberName + "%'";
            }
            if (!string.IsNullOrEmpty(designation))
            {
                query += " and Designation like '%" + designation + "%'";
            }

            var abc = db1.Database.SqlQuery<int>(query).FirstOrDefault();
            int counts = Convert.ToInt32(abc);
            return counts;

        }
    }
}