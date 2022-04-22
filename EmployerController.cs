using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDef
{
    static class EmployerController
    {

        //public EmployerController()
        //{

        //}
        public static CRUDefEntities db = new CRUDefEntities();



        public static void DeleteData()
        {
            Console.WriteLine("Enter Employer ID: ");
            int empID = Int16.Parse(Console.ReadLine());
            Employer employerRes = db.Employer.Find(empID);
            GetOne(empID);
            Console.WriteLine("deleting above employer..... ");
            db.Employer.Remove(employerRes);
            db.SaveChanges();
            GetAllData();

        }

        public static void UpdateData()
        {


            Console.WriteLine("Enter Employer ID: ");
            int empID = Int16.Parse(Console.ReadLine());

            GetOne(empID);

            Employer employerUp = db.Employer.Find(empID);

            Console.WriteLine("Enter Employer Name: ");
            employerUp.Name = Console.ReadLine();

            Console.WriteLine("Enter Employer Address: ");
            employerUp.Address = Console.ReadLine();

            //int ID = Convert.ToInt32(Console.ReadLine());



            //db.Employer.Add(employerRes);
            db.Entry(employerUp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            GetOne(empID);


        }

        public static void AddData()
        {
            Employer employer = new Employer();

            Console.WriteLine("Enter Employer Name: ");
            employer.Name = Console.ReadLine();

            Console.WriteLine("Enter Employer Address: ");
            employer.Address = Console.ReadLine();

            db.Employer.Add(employer);
            db.SaveChanges();

            GetAllData();
        }

        private static void GetAllData()
        {
            List<Employer> results = db.Employer.ToList();

            foreach (Employer item in results)
            {
                Console.WriteLine("Name: " + item.Name + " Address: " + item.Address);
            }
        }

        private static void GetOne(int ID)
        {
            Employer employerRes = db.Employer.Find(ID);

            Console.WriteLine("Name: " + employerRes.Name + " Address: " + employerRes.Address);

        }
    }
}

