﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17.Models
{
    internal class Student
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Mark> Marks { get; set; } = new List<Mark>();
    }
}
