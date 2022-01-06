using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubDomainClasses.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string Year { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Student> CourseStudents { get; set; }
    }
}
