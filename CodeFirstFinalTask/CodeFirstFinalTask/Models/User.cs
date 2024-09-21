using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstFinalTask.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
       
        public string Password { get; set; }

      
        public string Email { get; set; }


    }
}