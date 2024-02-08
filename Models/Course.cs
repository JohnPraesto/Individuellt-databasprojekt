using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt.Models
{
    internal class Course
    {
        [Key]
        public int CourseId { get; set; }
        [MaxLength(50)]
        public string CourseName { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
