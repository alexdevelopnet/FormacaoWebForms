using ContosoUniversityModelBinding.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversityModelBinding.Models
{
    public class Student
    {
        [Key,Display(Name ="Id")]
        [ScaffoldColumn(false)]
        public int StudentID { get; set; }

        [Required, StringLength(40), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [EnumDataType(typeof(AcademicYear)), Display(Name = "Academic Year")]
        public AcademicYear Year { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}