using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17.Models
{
    internal class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
