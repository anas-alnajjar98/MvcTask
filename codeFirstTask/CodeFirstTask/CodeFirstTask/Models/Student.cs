using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstTask.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        public string Name { get; set; }
        public int? age { get; set; }
        public string img { get; set; }
        public DateTime BirthDate { get; set; }
    }
}