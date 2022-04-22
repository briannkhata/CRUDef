using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDef
{
    class StudentController
    {
    public static CRUDefEntities db = new CRUDefEntities();

        public static void AddStudent()
        {
            Student student = new Student();
            student.Name = "Yankho GGgG ";
            student.Gender = "M";
            student.Email = "yankho@gmail.com";

            db.Student.Add(student);
            db.SaveChanges();
        }

        public static void MapStudent2Course()
        {
            Course course = db.Course.Find(1);
            Student student = db.Student.Find(2);
            course.Student.Add(student);
            db.SaveChanges();
        }
        public static void NewMapStudent2Course()
        {
            Student student = new Student();
            student.Name = "Chisomo Wisck";
            student.Gender = "M";
            student.Email = "chisomo@gmail.com";

            Course course = db.Course.Find(3);
            course.Student.Add(student);
            db.SaveChanges();
        }

        public static void StudentCoursesCount()
        {
            Student student = db.Student.Find(1);
            int studentCourseCount = student.Course.Count();

            Console.WriteLine("Student 2 has:  " + studentCourseCount);

       }

        public static void StudentCourses()
        {
            Student student = db.Student.Find(2);
            List<Course> courses = student.Course.ToList();

            foreach (Course course in courses)
            {

            Console.WriteLine("Name: " + course.Name + "\nCode: " + course.Code + "\n");
            }


        }

    }

   
}
