using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDef
{
    class StudentController
    {
        public void AddStudent()
        {
            CRUDefEntities db = new CRUDefEntities();
            Student student = new Student();
            Course course = new Course();
            StudentClass studentClass = new StudentClass();

            Console.WriteLine("Name :");
            student.Name = Console.ReadLine();

            Console.WriteLine("Gender : ");
            student.Gender = Console.ReadLine();

            Console.WriteLine("Email : ");
            student.Email = Console.ReadLine();

            Console.WriteLine("Class : ");
            studentClass.Name = Console.ReadLine();

            Console.WriteLine("Coarse : ");
            course.Name = Console.ReadLine();

            Console.WriteLine("Code : ");
            course.Code = Console.ReadLine();

            db.Student.Add(student);
            db.Course.Add(course);
            db.StudentClass.Add(studentClass);
            student.StudentClass = studentClass;
            course.Student.Add(student);
            db.SaveChanges();
            Console.WriteLine("Date Saved Succesfully!");
            ShowStudents();
        }

        public void ShowStudents()
        {
            CRUDefEntities db = new CRUDefEntities();
            List<Student> studList = db.Student.ToList();
            foreach (Student stu in studList)
            {
                Console.WriteLine("Name: " + stu.Name + "\nCode: " + stu.Gender + "\n" + stu.Email + "\n");
                //Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Student Coarses");
                Console.WriteLine("++++++++++++++++++");
                StudentCourses(stu.StudentID);
                Console.WriteLine("----------------------------------------------------------------------");

            }
        }

        public static void MapStudentToCourse()
        {
            CRUDefEntities db = new CRUDefEntities();

            Course course = db.Course.Find(1);
            Student student = db.Student.Find(2);

            course.Student.Add(student);
            db.SaveChanges();
        }
        public void MapStudentToCourseOtherWay(string name, string code)
        {
            CRUDefEntities db = new CRUDefEntities();

            Student student = new Student();
            student.Name = "Chisomo Wisck";
            student.Gender = "M";
            student.Email = "chisomo@gmail.com";

            Course course = new Course();
            course.Name = "Descrete Mathematics";
            course.Code = "MAT - 404";

            db.Course.Add(course);
            db.Student.Add(student);
            course.Student.Add(student);
            db.SaveChanges();
        }

        public static void StudentCoursesCount()
        {
            CRUDefEntities db = new CRUDefEntities();

            Student student = db.Student.Find(1);
            int studentCourseCount = student.Course.Count();

            Console.WriteLine("Student 2 has:  " + studentCourseCount);

       }

        public void StudentCourses(int id = 0)
        {
            CRUDefEntities db = new CRUDefEntities();

            Student student = db.Student.Find(id);
            List<Course> courses = student.Course.ToList();

            foreach (Course course in courses)
            {

            Console.WriteLine("Name: " + course.Name + "\nCode: " + course.Code + "\n");
            }


        }

    }

   
}
