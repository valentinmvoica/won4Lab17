using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Mark> Marks { get; set; } = new List<Mark>();
    }
}
