using System;
using CoursesDAL;
using Microsoft.EntityFrameworkCore;
using System.Linq; //for update

namespace CoursesClient
{
    class Program
    {
        static void Main(string[] args)
        {

            ShowData();
            //InsertData();
            //UpdateData();
            //DeleteData();
            Console.ReadKey();    
        }

        static void ShowData()
        {
            using(var context = new ApplicationDbContext()) {
                Console.WriteLine("*** Show courses ***");
                var c = context.Course.AsNoTracking();
                foreach(var course in c){
                    Console.WriteLine(course.Title+"\n--> "+course.Description);
                }

                Console.WriteLine("\n*** Show courses and its prices ***");
                c = context.Course.Include( p => p.PriceCourse ).AsNoTracking();
                foreach(var course in c){
                    Console.WriteLine(course.Title+"\n--> "+course.PriceCourse.CurrentPrice);
                }

                Console.WriteLine("\n*** Show comments per course ***");
                c = context.Course.Include( p => p.CommentList ).AsNoTracking();
                foreach(var course in c){
                    Console.WriteLine(course.Title);
                    foreach(var comment in course.CommentList){
                        Console.WriteLine("-->"+comment.Text);
                    }
                }

                Console.WriteLine("\n*** Show instructors per course ***");
                c = context.Course.Include( p => p.CourseInstructorList ).ThenInclude( ci => ci.Instructor).AsNoTracking();
                foreach(var course in c){
                    Console.WriteLine(course.Title);
                    foreach(var courseInstructor in course.CourseInstructorList ){
                        Console.WriteLine("-->"+courseInstructor.Instructor.Name);
                    }
                }

            }
        }

        static void InsertData() 
        {
            using (var context = new ApplicationDbContext()) {
                var instructor1 = new Instructor{
                    Name = "Cecilia",
                    LastName = "Gonzales",
                    Category = "Engineer"
                };
                var instructor2 = new Instructor{
                    Name = "David",
                    LastName = "Martinez",
                    Category = "Developer"
                };

                context.Add(instructor1);
                context.Add(instructor2);
                var state = context.SaveChanges();
                Console.WriteLine("Transaction state: "+state);
            }
        }

        static void UpdateData()
        {
            using (var context = new ApplicationDbContext()) {
                var instructor = context.Instructor.Single( p => p.LastName == "Sanchez");
                if (instructor != null) {
                    instructor.Name = "Juan";
                    instructor.Category = "Developer";
                    var state = context.SaveChanges();
                    Console.WriteLine("Transaction state: "+state);
                }
            }
        }

        static void DeleteData()
        {
            using (var context = new ApplicationDbContext()) {
                var instructor = context.Instructor.Single( p => p.InstructorId == 5 );
                if (instructor != null) {
                    context.Remove(instructor);
                    var state = context.SaveChanges();
                    Console.WriteLine("Transaction state: "+state);
                }
            }
        }

    }
}
