using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt.Models
{
    internal class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Job { get; set; }
        public DateTime Hired { get; set; }
        // public DateTime? Leave { get; set; } // Frågetecknet = nullable
        public int Salary { get; set; }
    }
}
