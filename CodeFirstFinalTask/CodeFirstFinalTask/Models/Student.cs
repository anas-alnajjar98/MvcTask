using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstFinalTask.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        public string Email { get; set; }

        public int ClassId { get; set; }
        public Classes Class { get; set; }
    }
}