using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstDemo
{
    class Program
    {
        public class Student
        {
            
            public int StudentId { get; set; }
            public string LastName { get; set; }
            public string FirstMidName { get; set; }
            public DateTime  EnrollmentDate { get; set; }
            public virtual ICollection<Enrollment> Enrollments { get; set; }

        }

        public class Course
        {
            public int CourseId { get; set; }
            public string Title { get; set; }
            public int Credit { get; set; }
            public virtual ICollection< Enrollment > Enrollments { get; set; }
           
        }

        public enum Grade
        { A,B,C,D,F}
        public class Enrollment
        {
            public int EnrollmentID { get; set; }
            public int CourseID { get; set; }
            public int StudentID { get; set; }
            public Grade ? Grades { get; set; }
            
        }

        public class Mycontext : DbContext
        {
            public Mycontext() : base() { }
            public virtual DbSet<Student> Students { get; set; }
            public virtual DbSet<Course > Courses { get; set; }
            public virtual DbSet<Enrollment> Enrollments { get; set; }
        }


        static void Main(string[] args)
        {
            using (var Context = new Mycontext())
            {
                Console.WriteLine("Adding new Student");
                Console.WriteLine("==========================================================");
                var student = new Student { LastName = "Singh", FirstMidName = "Soni", EnrollmentDate = DateTime.Parse("2019-05-22") };
                Context.Students.Add(student);

                var student2 = new Student { LastName = "Smith", FirstMidName = "Robin", EnrollmentDate = DateTime.Parse("2012-06-11") };
                Context.Students.Add(student2);
                Context.SaveChanges();
                Console.WriteLine("Adding Students Completed");
                Console.WriteLine("============================================================");


                Console.WriteLine("Retreving All Student");
                Console.WriteLine("=============================================================");

                var students = Context.Students.ToList();
                foreach (var std in students)
                {
                    Console.WriteLine("Student LastName=" + std.LastName + " " + "firstname =" + std.FirstMidName + " " + "Enrollment date=" + std.EnrollmentDate); ;
                }
                Console.WriteLine( "retreving All student complete");
                Console.WriteLine("==============================================================");

            }
        }
    }
}
