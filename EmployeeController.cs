using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDef
{
    class EmployeeController
    {
        public static CRUDefEntities db = new CRUDefEntities();

        public static void AddEmployee() {
            Employee employee = new Employee();

            Console.WriteLine("Enter Employee Name: ");
            employee.Name = Console.ReadLine();

            Console.WriteLine("Enter Employee Address: ");
            employee.Email = Console.ReadLine();

            Console.WriteLine("Enter Employee Phone: ");
            employee.Phone = Console.ReadLine();
            
            Console.WriteLine("Enter Employer ID: ");
            int EmpID = Int32.Parse(Console.ReadLine());

            var emplyr = db.Employer.Find(EmpID);

            emplyr.Employee.Add(employee);
            db.SaveChanges();

        }

        //public static void GetEmployerName()
        //{
        //    Employee employee = db.Employee.Include(x => x.CustomUser).Find(3);
        //}
    }
}
