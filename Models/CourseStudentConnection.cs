using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt.Models
{
    internal class CourseStudentConnection
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public byte? Grade { get; set; } // Making this nullable because grade is not set until course ends
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }
    }
}
