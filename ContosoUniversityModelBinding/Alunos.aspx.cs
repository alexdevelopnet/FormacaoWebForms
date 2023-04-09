using ContosoUniversityModelBinding.Data;
using ContosoUniversityModelBinding.Models;
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ContosoUniversityModelBinding
{
    public partial class Alunos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public IQueryable<Student> studentsGrid_GetData()
        {
            SchoolContext db = new SchoolContext();
             

             var query = db.Students.Include(s => s.Enrollments.Select(e => e.Course));
            return (IQueryable<Student>)query;
        }
        public void studentsGrid_UpdateItem(int studentID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student item = null;
                item = db.Students.Find(studentID);
                if (item == null)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} was not found", studentID));
                    return;
                }

                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                }
            }
        }

        public void studentsGrid_DeleteItem(int studentID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                var item = new Student { StudentID = studentID };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} no longer exists in the database.", studentID));
                }
            }
        }

    }
}