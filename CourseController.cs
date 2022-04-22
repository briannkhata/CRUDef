using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDef
{
    class CourseController
    {
        public static CRUDefEntities db = new CRUDefEntities();

        public static void AddCourse()
        {
            Course course = new Course();
            course.Name = "Software Development";
            course.Code = "SD-401";

            db.Course.Add(course);
            db.SaveChanges();
        }

        public static void MapCourse2Student()
        {
            Course course = db.Course.Find(1);
            Student student = db.Student.Find(2);
            course.Student.Add(student);
            db.SaveChanges();
        }

        public static void RemoveCourse2Student()
        {
            Course course = db.Course.Find(1);
            Student student = db.Student.Find(2);
            course.Student.Remove(student);
            db.SaveChanges();
        }
        public static void NewMapCourse2Student()
        {
            Course course = new Course();
            course.Name = "Physics";
            course.Code = "Phy-211";
            Student student = db.Student.Find(2);
            student.Course.Add(course);
            db.SaveChanges();
        }
    }
}
