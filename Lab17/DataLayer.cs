using Lab17.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
    static class BusinessLayer
    {
        public static int AddStudent(string name, int age)
        {
            var student = new Student { Name = name, Age = age };
            using var ctx = new SchoolManagementDbContext();
            ctx.Add(student);
            ctx.SaveChanges();
            return student.Id;
        }
        public static void AddMarkToStudent(int studentId, int courseId, int value)
        {
            using var ctx = new SchoolManagementDbContext();

            var student = ctx.Students.Include(s => s.Courses).First(c => c.Id == studentId);
            var course = ctx.Courses.First(c => c.Id == courseId);

            if (student == null)
            {
                //
            }
            if (course == null)
            {
                //
            }
            if (!student.Courses.Any(c => c.Id == courseId))
            {
                throw new Exception($"student{student.Name} does not attain course {course.Name}");
            }

            student.Marks.Add(new Mark { CourseId = courseId, Value=value});

            ctx.SaveChanges();
        }
        public static void AddCourse(Course c)
        {
            using var ctx = new SchoolManagementDbContext();
            ctx.Add(c);
            ctx.SaveChanges();
        }

        public static void RegisterStudentToCourse(int studentId, int courseId) {
            using var ctx = new SchoolManagementDbContext();

            var student = ctx.Students.Include(s => s.Courses).First(s => s.Id == studentId);
            var course = ctx.Courses.First(c=> c.Id == courseId);

            if (!student.Courses.Contains(course))
            {
                student.Courses.Add(course);
            }

            ctx.SaveChanges();
        }

        public static double GetOverallAverage(int StudentId)
        {
            using var ctx = new SchoolManagementDbContext();
            return ctx.Students
                .Where(s => s.Id == StudentId)
                .Include(s => s.Marks)
                .Select(s => new { Average = s.Marks.Average(m => m.Value) }).First().Average;
        }
        public static List<double> GetOverallAverage(List<int> StudentIds)
        {
            using var ctx = new SchoolManagementDbContext();
            return ctx.Students
                .Where(s => StudentIds.Contains(s.Id) && s.Marks.Count>0)
                .Include(s => s.Marks)
                .Select(s => s.Marks.Average(m => m.Value)).ToList();
        }

        public static double GetAverageForStudentPerSubject(int studentId, int courseId)
        {
            using var ctx = new SchoolManagementDbContext();

            var student = ctx.Students.Include(s=>s.Courses).First(s => s.Id == studentId);

            if (student == null)
            {
                //null
            }

            if (!student.Courses.Any(c => c.Id == courseId))
            {
                //
            }

            if (student.Marks.Count(m=>m.CourseId == courseId) == 0) 
            {
                return 0;
            }

            return student.Marks.Average(m => m.Value);

            //&& s.Marks.Count>0 && s.Marks.Any(m=>m.CourseId == courseId)
        }
    }
}
