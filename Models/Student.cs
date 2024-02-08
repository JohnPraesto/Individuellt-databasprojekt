using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt.Models
{
    internal class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string PersonalNumber { get; set; }
        [MaxLength(50)]
        public string Class { get; set; }
    }
}
