using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDef
{
    class Program
    {
      
        static void Main(string[] args)
        {
            StudentController studentcontroller = new StudentController();
            studentcontroller.AddStudent();
            //studentcontroller.MapStudentToCourseOtherWay();

            //multipleupdaterecordbyNonPK();
            //updaterecordbyNonPK();
            //readrecordbyNonPK();
            //addStudentClassx();
            //AddData();
            //EmployerController employerController = new EmployerController()
            //EmployerController.AddData();
            //EmployerController.UpdateData();
            //EmployerController.DeleteData();
            //EmployeeController.AddEmployee();
            //CourseController.AddCourse();
            //StudentController.AddStudent();
            //CourseController.MapCourse2Student();
            //CourseController.NewMapCourse2Student();
            //StudentController.NewMapStudent2Course();
            //CourseController.RemoveCourse2Student();
            //StudentController.StudentCoursesCount();
            //StudentController.StudentCourses();
            Console.ReadLine();

        }

        private static void multipleupdaterecordbyNonPK()
        {
            CRUDefEntities db = new CRUDefEntities();
            Student student = db.Student.Find(5);
            var courses = db.Course.ToList();
            foreach(Course course2 in courses)
            {
                course2.Student.Remove(student);
            }
            //course.Student.Add(student);
            
            Course course = db.Course.Find(3);
            student.Course.Add(course);
            db.SaveChanges();

        }

        private static void updaterecordbyNonPK()
        {
            CRUDefEntities db = new CRUDefEntities();
            //Student student = db.Student.Find(5);
            Student student = db.Student.Include(nameof(StudentClass)).Where(x=> x.StudentID==5).Single();
            student.StudentClassID = 2;
            db.SaveChanges();

            Console.WriteLine(student.StudentClass.Name);
        }

        private static void readrecordbyPK()
        {
            CRUDefEntities db = new CRUDefEntities();
            Student student = db.Student.Find(5);
            Console.WriteLine(student.Name);
            
        }
        private static void readrecordbyNonPK()
        {
            CRUDefEntities db = new CRUDefEntities();
            //Student student = db.Student.Where(x => x.Name == "bestererere").SingleOrDefault();
            //Console.WriteLine(student?.Email);
            //var student = db.Student.Where(x => x.StudentClassID == 3).ToList().FirstOrDefault();
            var student = db.Student.Where(x => x.StudentClassID == 3).ToList().Take(1);
            
            Console.WriteLine(student);

        }

        private static void addStudentClass()
        {
            CRUDefEntities db = new CRUDefEntities();
            StudentClass studentClass = new StudentClass();
            studentClass.Name = "4 west";
            Student student = new Student()
            {
                Name = "brian",
                Gender="Male",
                Email="brian@mra.mw"
            };
            student.StudentClass = studentClass;
            db.StudentClass.Add(studentClass);
            db.Student.Add(student);
            db.SaveChanges();
        }
        private static void addStudentClassx()
        {
            CRUDefEntities db = new CRUDefEntities();
            StudentClass studentClass = new StudentClass();
            studentClass.Name = "2 south";
            Student student = new Student()
            {
                Name = "bester",
                Gender = "Male",
                Email = "bester@mra.mw"
            };
            studentClass.Student.Add(student);
            db.StudentClass.Add(studentClass);
            //db.Student.Add(student);
            db.SaveChanges();
        }
    }
}
