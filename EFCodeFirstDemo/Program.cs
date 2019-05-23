using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstDemo
{
    class Program
    {
        public class Student
        {

            public int StudentId { get; set; }
            public string LastName { get; set; }
            public string FirstMidName { get; set; }
           public int Age { get; set; }
            public DateTime EnrollmentDate { get; set; }
            public virtual ICollection<Enrollment> Enrollments { get; set; }

        }
        public class StudentLogIn
        {
            [Key, ForeignKey("Student")]
            public int ID { get; set; }
            public string EmailID { get; set; }
            public string Password { get; set; }

            public virtual Student Student { get; set; }
        }
        public class Course
        {
            public int CourseId { get; set; }
           [MaxLength(25),MinLength(4)]
            public string Title { get; set; }
            public int Credit { get; set; }
            [Timestamp ]
           public byte[] RowVersion { get; set; }
            public virtual ICollection<Enrollment> Enrollments { get; set; }

        }

        public enum Grade
        { A, B, C, D, F }
        public class Enrollment
        {

            public int EnrollmentID { get; set; }
            public int CourseID { get; set; }
            public int StudentID { get; set; }
            public Grade? Grades { get; set; }
           
            public virtual Course Course { get; set; }
            
            public virtual Student Student { get; set; }

        }

        public class MyContext : DbContext
        {

            public MyContext() : base("name=StudentEnrollmentDB")
            {
                 Database.SetInitializer<MyContext>(new UniDBInitializer<MyContext>());
                //    EFCodeFirstDemo.Migrations.Configuration > (MyContext);
                //}
                 Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, EFCodeFirstDemo.Migrations.Configuration>("StudentEnrollmentDB"));
            }

            public virtual DbSet<Course> Courses { get; set; }
            public virtual DbSet<Enrollment> Enrollments { get; set; }
            public virtual DbSet<Student> Students { get; set; }
            public virtual DbSet<StudentLogIn> StudentsLogIn { get; set; }
            private class UniDBInitializer<T> : DropCreateDatabaseAlways<MyContext>
            {

                protected override void Seed(MyContext context)
                {

                    IList<Student> students = new List<Student>();

                    students.Add(new Student()
                    {
                        FirstMidName = "Andrew",
                        LastName = "Peters",
                        EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    });

                    students.Add(new Student()
                    {
                        FirstMidName = "Brice",
                        LastName = "Lambson",
                        EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    });

                    students.Add(new Student()
                    {
                        FirstMidName = "Rowan",
                        LastName = "Miller",
                        EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    });

                    foreach (Student student in students)
                        context.Students.Add(student);
                    context.SaveChanges();
                    base.Seed(context);
                }
            }
        }


        public static void Main(string[] args)
        {
            using (var Context = new MyContext())
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
                Console.WriteLine("retreving All student complete");
                Console.WriteLine("==============================================================");

            }
        }
    }
}

