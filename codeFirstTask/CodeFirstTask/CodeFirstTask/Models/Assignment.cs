using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstTask.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string Title { get; set; }

        public DateTime DueDate { get; set; }
        
    }
}