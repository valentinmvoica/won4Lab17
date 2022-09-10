using Lab17;
using Lab17.Models;
using Microsoft.EntityFrameworkCore;

//ResetDb();

var x = BusinessLayer.GetOverallAverage(new List<int> { 1,2,3});
x.ForEach(m => Console.WriteLine(x));

var ionita = BusinessLayer.AddStudent("Costi I.", 55);

var avg = BusinessLayer.GetAverageForStudentPerSubject(ionita, 1);

static void ResetDb()
{
    using var ctx = new SchoolManagementDbContext();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();

    var englishCourse = new Course
    {
        Name = "English"
    };
    var maths = new Course
    {
        Name = "Maths"
    };
    var sports = new Course
    {
        Name = "Football"
    };


    ctx.Courses.Add(englishCourse);
    ctx.Courses.Add(maths);
    ctx.Add(sports);

    var t1 = new Teacher { Name = "Marin Chitac" };
    var t2 = new Teacher { Name = "Chitac Marin" };
    var t3 = new Teacher { Name = "M.M.S." };

    englishCourse.Teacher = t1;
    maths.Teacher = t2;
    sports.Teacher = t3;
    ctx.Add(t1);
    ctx.Add(t2);
    ctx.Add(t3);

    var s1 = new Student { Name = "Simion G.", Age = 45 };
    var s2 = new Student { Name = "Gigi", Age = 23 };
    var s3 = new Student { Name = "Costica", Age = 21 };
    ctx.Add(s1);
    ctx.Add(s2);
    ctx.Add(s3);

    s1.Courses.Add(sports);
    s1.Courses.Add(englishCourse);

    s1.Marks.Add( new Mark { Course = sports, Value=9 });
    s1.Marks.Add(new Mark { Course = sports, Value = 5 });
    s1.Marks.Add(new Mark { Course = sports, Value = 7 });
    s1.Marks.Add(new Mark { Course = englishCourse, Value = 3 });
    s1.Marks.Add(new Mark { Course = englishCourse, Value = 6 });


    s2.Courses.Add(maths);
    s2.Courses.Add(englishCourse);

    s2.Marks.Add(new Mark { Course = sports, Value = 4 });
    s2.Marks.Add(new Mark { Course = maths, Value = 5 });
    s2.Marks.Add(new Mark { Course = englishCourse, Value = 10 });
    s2.Marks.Add(new Mark { Course = maths, Value = 7 });
    s2.Marks.Add(new Mark { Course = maths, Value = 5 });

    s3.Courses.Add(maths);
    s3.Courses.Add(sports);
    s3.Courses.Add(englishCourse);


    
    ctx.SaveChanges();
    //add elements
}