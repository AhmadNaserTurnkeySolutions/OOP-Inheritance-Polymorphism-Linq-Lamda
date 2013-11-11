using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 AhmadNaser.com
 * ahmadnassr@gmail.com
 */

namespace CSAppFirst
{
    class Program
    {

        static void Main(string[] args)
        {

            Employee Admin1 = new Employee { FirstName = "Emad", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };
            Employee Admin2 = new Employee { FirstName = "Ali", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };

            Department D1 = new Department { Name = "CS", Id = 10009, StartDate = DateTime.Now, Budget = 1000009, Admin = new Employee { FirstName = "Emad", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 } };
            Department D2 = new Department { Name = "Engineering", Id = 10339, StartDate = DateTime.Now, Budget = 1000009, Admin = Admin2 };

            List<Department> Departments = new List<Department>();

            Departments.Add(D1);
            Departments.Add(D2);


            Employee Emoloyee1 = new Employee { FirstName = "Asad", LastName = "James", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 800, Department = D1 };
            Employee Emoloyee2 = new Employee { FirstName = "James", LastName = "Redii", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D2 };
            Employee Emoloyee3 = new Employee { FirstName = "John", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 2000, Department = D1 };
            Employee Emoloyee4 = new Employee { FirstName = "Issam", LastName = "John", Id = 1000, BirthDate = DateTime.Now, Address = "Hebron", Rating = Employee.ERating.Good, Salary = 777, Department = D1 };
            Employee Emoloyee5 = new Employee { FirstName = "Khami", LastName = "Kil", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 3000, Department = D2 };
            Employee Emoloyee6 = new Employee { FirstName = "Redii", LastName = "Naher", Id = 1000, BirthDate = DateTime.Now, Address = "USA", Rating = Employee.ERating.Good, Salary = 990, Department = D1 };
            Employee Emoloyee7 = new Employee { FirstName = "Ismaeil", LastName = "REd", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D2 };
            Employee Emoloyee8 = new Employee { FirstName = "Naher", LastName = "IOU", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D1 };

            List<Employee> Employees = new List<Employee>();

            Employees.Add(Emoloyee1);
            Employees.Add(Emoloyee2);
            Employees.Add(Emoloyee3);
            Employees.Add(Emoloyee4);
            Employees.Add(Emoloyee5);
            Employees.Add(Emoloyee6);
            Employees.Add(Emoloyee7);
            Employees.Add(Emoloyee8);


            //LINQ TO SQL



            //1Get All Employees with salary less than 1000
            //var EmpsLinq = from emp in Employees where emp.Salary < 1000 select emp;


    
         



            //2.1Get All Employees with salary big than 1000 and less than 3000
            // var EmpsLinq = from emp in Employees where emp.Salary >= 1000 && emp.Salary <= 3000 select emp;

            //2.2Get All Employees with salary big than 1000 and less than 3000 as anynmous
            //  var EmpsLinq = from emp in Employees where emp.Salary >= 1000 && emp.Salary <= 3000 select new { emp.FullName,emp.BirthDate};


     

            //3Get All Employees with department name is CS
            //var EmpsLinq = from emp in Employees where emp.Department.Name=="CS" select emp;



            //4group employees by address


            //method 1 make using oo-style
            var EmployeeGroupQuery1 =
                 from emp in Employees
                 group emp by emp.Address into EmployeeGroup
                 where EmployeeGroup.Count() > 0
                 orderby EmployeeGroup.Key
                 select EmployeeGroup;


            //method 3 make using sql-like style with anynmous
           /* var EmployeeGroupQuery2 =
            Employees.GroupBy(e => e.Address) //3groups
                     .Select(group =>
                                   new
                                   {
                                       Address = group.Key,
                                       EmployeesIn = group.ToList<Employee>()
                                   }
                             ).OrderBy(E=>E.Address);
            * */

            //method 3 make without anynmous based on group key
            var EmployeeGroupQuery2 =
  Employees.GroupBy(e => e.Address) //3groups
           .Select(group =>group).OrderBy(E => E.Key);


            //method 1 print
         
 
                        foreach (var EmployeeGp in EmployeeGroupQuery1)
                        {
                            Console.WriteLine(EmployeeGp.Key);
                            foreach (Employee Empx in EmployeeGp)
                            {
                                Console.WriteLine("    {0}", Empx.FullName);
                            }
                        }


                        Console.WriteLine("***********************************************");


            //method 2 print


         /*  foreach (var EmployeeGp in EmployeeGroupQuery2)
            {
                Console.WriteLine(EmployeeGp.Address);
                foreach (var Empx in EmployeeGp.EmployeesIn)
                {
                    Console.WriteLine("    {0}", Empx.FullName);
                }
            }
          * */

                        //method 3 print

                        foreach (var EmployeeGp in EmployeeGroupQuery2)
                        {
                            Console.WriteLine(EmployeeGp.Key);
                            foreach (var Empx in EmployeeGp)
                            {
                                Console.WriteLine("    {0}", Empx.FullName);
                            }
                        }








            //5Get Average of salaries per deparment
            /* var EmpsLinq = Employees.GroupBy(e => e.Department)
                                  .Select(g=> 
                                    new {
                                       Department = g.Key.Name,
                                       SalaryAvg = g.Average(x=>x.Salary)
                                   });


             foreach (var X in EmpsLinq)
             {
                 string EmpInfo = "Department: " + X.Department + "\n" +
                   "Average Salary: " + X.SalaryAvg + "\n";

                 Console.WriteLine(EmpInfo);
             }

             */


            //6group by average salaries
           // GroupByRange(Employees);


            // Console.WriteLine(EmpsLinq.Count);

            /*
      List<Employee> Emps = EmpsLinq.ToList<Employee>();
   foreach (var Emp in Emps)
            {
                string EmpInfo = "Id:" + Emp.Id + "\n" +
                  "Full Name: " + Emp.FullName + "\n" +
                  "BirthDate: " + Emp.BirthDate + "\n" +
                                "Rating: " + Emp.Rating + "\n" +
                                "Salary: " + Emp.Salary + "\n";

                Console.WriteLine(EmpInfo);
            }
             */
            Console.ReadLine();

        }


        static void Mainx2(string[] args)//oop implementation
        {

            Employee Admin1 = new Employee { FirstName = "Emad", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };
            Employee Admin2 = new Employee { FirstName = "Ali", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };

            Department D1 = new Department { Name = "CS", Id = 10009, StartDate = DateTime.Now, Budget = 1000009, Admin = new Employee { FirstName = "Emad", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 } };
            Department D2 = new Department { Name = "Engineering", Id = 10339, StartDate = DateTime.Now, Budget = 1000009, Admin = Admin2 };

            List<Department> Departments = new List<Department>();

            Departments.Add(D1);
            Departments.Add(D2);


            Employee Emoloyee1 = new SalaryEmployee { FirstName = "Asad", LastName = "James", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D1,MonthDays=21,SalaryPerDay=150.8};
            Employee Emoloyee2 = new SalaryEmployee { FirstName = "James", LastName = "Redii", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D2, MonthDays = 19, SalaryPerDay = 130.8 };
            Employee Emoloyee3 = new SalaryEmployee { FirstName = "John", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 2000, Department = D1, MonthDays = 18, SalaryPerDay = 170.8 };
            Employee Emoloyee4 = new HourlyEmployee { FirstName = "Issam", LastName = "John", Id = 1000, BirthDate = DateTime.Now, Address = "Hebron", Rating = Employee.ERating.Good, Salary = 777, Department = D1,HourRate=10,NumberOfHours=130};
            Employee Emoloyee5 = new HourlyEmployee { FirstName = "Khami", LastName = "Kil", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 3000, Department = D2, HourRate = 5, NumberOfHours = 150 };
            Employee Emoloyee6 = new HourlyEmployee { FirstName = "Redii", LastName = "Naher", Id = 1000, BirthDate = DateTime.Now, Address = "USA", Rating = Employee.ERating.Good, Salary = 990, Department = D1, HourRate = 21, NumberOfHours = 90 };
            Employee Emoloyee7 = new Employee { FirstName = "Ismaeil", LastName = "REd", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D2};
            Employee Emoloyee8 = new Employee { FirstName = "Naher", LastName = "IOU", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D1 };

            List<Employee> Employees = new List<Employee>();

            Employees.Add(Emoloyee1);
            Employees.Add(Emoloyee2);
            Employees.Add(Emoloyee3);
            Employees.Add(Emoloyee4);
            Employees.Add(Emoloyee5);
            Employees.Add(Emoloyee6);
            Employees.Add(Emoloyee7);
            Employees.Add(Emoloyee8);


            foreach (var Emp in Employees)
            {
                string Seperator = "\n***********\n";
                string EmpInfo =


                  Seperator + Emp.GetType().Name + Seperator +
                  "Id:" + Emp.Id + "\n" +
                  "Full Name: " + Emp.FullName + "\n" +
                  "BirthDate: " + Emp.BirthDate + "\n" +
                  "Rating: " + Emp.Rating + "\n" +
                  "Total Salary: " + Emp.TotalSalary + "\n";

                Console.WriteLine(EmpInfo);
            }


            Console.Read();

          
           
        }

        private static void CarInheritanceAndPloymorphism()
        {
            Car MyCar = new Car();

            // MyCar.CarType();

            Volvo MyVolvo = new Volvo();
            //    MyVolvo.CarType();

            BMW MyBMW = new BMW();
            // MyBMW.CarType();


            List<Car> Cars = new List<Car>();
            Cars.Add(new BMW());
            Cars.Add(new Volvo());
            Cars.Add(new BMW());
            Cars.Add(new Mazda());
            Cars.Add(new Volvo());

            foreach (Car Car in Cars)
            {
                Car.CarType();
            }



            Console.Read();
        }




        public static void GroupByRange(List<Employee> Employees)
        {
            Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");

            var queryNumericRange =
                from Emp in Employees
                let percentile = GetPercentile(Emp)
                group new { Emp.FirstName, Emp.LastName } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;

            // Nested foreach required to iterate over groups and group items. 
            foreach (var eGroup in queryNumericRange)
            {
                Console.WriteLine("Salary Rangek: {0}", (eGroup.Key * 10));
                foreach (var item in eGroup)
                {
                    Console.WriteLine("\t{0}, {1}", item.LastName, item.FirstName);
                }
            }
        }

        protected static int GetPercentile(Employee e)
{
    double avg = (double)e.Salary;
    return avg > 0 ? (int)avg / 10 : 0;
}

        private static List<Employee> GetAllEmployessByDepartment(Department D1, List<Employee> Employees2)
        {
            List<Employee> TempList = new List<Employee>();
             foreach (Employee E in Employees2) 
             {
             if(E.Department.Id==D1.Id)
             {
                 TempList.Add(E);
             }
             
             }
            return TempList;
        }

     



        private static void PrintEmployee(Employee Emp,string msg)
        {

            string EmpInfo = "\n*****************" + msg + "***********\n";
             EmpInfo += "Id:" + Emp.Id + "\n" +
  "Full Name: " + Emp.FullName + "\n" +
  "BirthDate: " + Emp.BirthDate + "\n" +
                "Rating: " + Emp.Rating + "\n" +
                "Salary: " + Emp.Salary + "\n";
             EmpInfo+= "\n**************************\n";

             Console.WriteLine(EmpInfo);
        }

        private static void SortEmployeesBySalaryDescending(List<Employee> Employees)
        {
            List<Employee> SortedList = Employees.OrderBy(x => x.Salary).ToList<Employee>();
            SortedList.Reverse();

            foreach (Employee Emp in SortedList)
            {
                string EmpInfo = "Id:" + Emp.Id + "\n" +
                  "Full Name: " + Emp.FullName + "\n" +
                  "BirthDate: " + Emp.BirthDate + "\n" +
                                "Rating: " + Emp.Rating + "\n"+
                                "Salary: " + Emp.Salary + "\n";

                Console.WriteLine(EmpInfo);
            }
            Console.ReadLine();
        }

        private static Employee getMinSalaryEmployee(List<Employee> Employees)
        {
            Employee Temp2=null;
            decimal Current=Employees.ElementAt(0).Salary;
            foreach (Employee E in Employees)
            {
                if (E.Salary <= Current) 
                {
                    Current = E.Salary;
                   Temp2 = E;
            
                    
                }
            }

            return Temp2;
           
        }

        private static Employee getMaxSalaryEmployee(List<Employee> Employees)
        {
            Employee Temp = null;
            decimal max = 0;
            foreach (Employee E in Employees)
            {
                if (E.Salary >= max)
                {
                    max = E.Salary;
                    Temp = E;
                }
            }

            return Temp;
        }

        private static List<Employee> getAllEmployees()
        {
            Employee Emp1 = new Employee { FirstName = "Ahmad1", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };
            Employee Emp2 = new Employee { FirstName = "Ahmad2", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 3000 };
            Employee Emp3 = new Employee { FirstName = "Ahmad3", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 2200 };
            Employee Emp4 = new Employee { FirstName = "Ahmad4", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };
            Employee Emp5 = new Employee { FirstName = "Ahmad5", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 9000 };
            Employee Emp6 = new Employee { FirstName = "Ahmad6", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 8200 };
            Employee Emp7 = new Employee { FirstName = "Ahmad7", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 3000 };
            Employee Emp8 = new Employee { FirstName = "Ahmad8", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };
            Employee Emp9 = new Employee { FirstName = "Ahmad9", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 4200 };
            Employee Emp10 = new Employee { FirstName = "Ahmad10", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 800 };



            List<Employee> emps = new List<Employee>();

            emps.Add(Emp1);
            emps.Add(Emp2);
            emps.Add(Emp3);
            emps.Add(Emp4);
            emps.Add(Emp5);
            emps.Add(Emp6);
            emps.Add(Emp7);
            emps.Add(Emp8);
            emps.Add(Emp9);
            emps.Add(Emp10);

            return emps;
        }

        public void Ex1() 
        {
            Employee Emp1 = new Employee();
            Emp1.Address = "Ramallah";
            Emp1.FirstName = "Ahmad";
            Emp1.LastName = "Hadi";
            Emp1.BirthDate = DateTime.Now;
            Emp1.Id = 100005;

            Employee Emp2 = new Employee();
            Emp2.Address = "Hebron";
            Emp2.FirstName = "Mahdi";
            Emp2.LastName = "Sami";
            Emp2.BirthDate = DateTime.Now;
            Emp2.Id = 100006;

            //  Emp2.Address = "Nablus"; // Set Address
            // String x = Emp2.Address; // Get Address

            string Emp1Info = "Id:" + Emp1.Id + "\n" +
                              "Full Name: " + Emp1.FullName + "\n" +
                              "BirthDate: " + Emp1.BirthDate;

            Console.WriteLine(Emp1Info);


            string Emp2Info = "Id:" + Emp2.Id + "\n" +
                  "Full Name: " + Emp2.FullName + "\n" +
                  "BirthDate: " + Emp2.BirthDate;

            Console.WriteLine(Emp2Info);
            Console.ReadLine();

           
        }
        public void Ex2() 
        {
            string fn = "Ahmad";
            string ln = "Naser";
            DateTime t = DateTime.Now;
            int id = 1000;
            string address = "Canada";

            Employee Emp1 = new Employee(fn, ln, t, id, address);

        }

        public void Ex3() 
        {
            Employee Emp1 = new Employee { FirstName = "Ahmad", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good };


            string Emp1Info = "Id:" + Emp1.Id + "\n" +
                              "Full Name: " + Emp1.FullName + "\n" +
                              "BirthDate: " + Emp1.BirthDate + "\n" +
                                            "Rating: " + Emp1.Rating + "\n";

            Console.WriteLine(Emp1Info);
            Console.ReadLine();
        }

        public static void Ex4()
        {
            Employee Emp1 = new Employee { FirstName = "Ahmad1", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good };
            Employee Emp2 = new Employee { FirstName = "Ahmad2", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good };
            Employee Emp3 = new Employee { FirstName = "Ahmad3", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good };


            Employee[] emps = { Emp1, Emp2, Emp3 };



            Employee[] employees = new Employee[3];
            employees[0] = Emp1;
            employees[1] = Emp2;
            employees[2] = Emp3;




            foreach (Employee Emp in emps)
            {
                string EmpInfo = "Id:" + Emp.Id + "\n" +
                  "Full Name: " + Emp.FullName + "\n" +
                  "BirthDate: " + Emp.BirthDate + "\n" +
                                "Rating: " + Emp.Rating + "\n";

                Console.WriteLine(EmpInfo);
            }

            for (int i = 0; i < emps.Length; i++)
            {


                string EmpInfo = "Id:" + emps[i].Id + "\n" +
                  "Full Name: " + emps[i].FullName + "\n" +
                  "BirthDate: " + emps[i].BirthDate + "\n" +
                                "Rating: " + emps[i].Rating + "\n";

                Console.WriteLine(EmpInfo);
            }

            Console.ReadLine();
        }

        public static void Ex5()
        {
            Employee Emp1 = new Employee  { FirstName = "Ahmad1", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good ,Salary=1000};
            Employee Emp2 = new Employee  { FirstName = "Ahmad2", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good ,Salary=3000};
            Employee Emp3 = new Employee  { FirstName = "Ahmad3", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good ,Salary=2200};
            Employee Emp4 = new Employee  { FirstName = "Ahmad4", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };
            Employee Emp5 = new Employee  { FirstName = "Ahmad5", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 9000 };
            Employee Emp6 = new Employee  { FirstName = "Ahmad6", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 8200 };
            Employee Emp7 = new Employee  { FirstName = "Ahmad7", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 3000 };
            Employee Emp8 = new Employee  { FirstName = "Ahmad8", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };
            Employee Emp9 = new Employee  { FirstName = "Ahmad9", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 4200 };
            Employee Emp10 = new Employee { FirstName = "Ahmad10", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 800 };



            List<Employee> emps = new List<Employee>();

            emps.Add(Emp1);
            emps.Add(Emp2);
            emps.Add(Emp3);
            emps.Add(Emp4);
            emps.Add(Emp5);
            emps.Add(Emp6);
            emps.Add(Emp7);
            emps.Add(Emp8);
            emps.Add(Emp9);
            emps.Add(Emp10);


            foreach (Employee Emp in emps)
            {
                string EmpInfo = "Id:" + Emp.Id + "\n" +
                  "Full Name: " + Emp.FullName + "\n" +
                  "BirthDate: " + Emp.BirthDate + "\n" +
                                "Rating: " + Emp.Rating + "\n";

                Console.WriteLine(EmpInfo);
            }

           /* for (int i = 0; i < emps.Count; i++)
            {
               
                
                string EmpInfo = "Id:" + emps.ElementAt(i).Id + "\n" +
                  "Full Name: " + emps.ElementAt(i).FullName + "\n" +
                  "BirthDate: " + emps.ElementAt(i).BirthDate + "\n" +
                                "Rating: " + emps.ElementAt(i).Rating + "\n";

                Console.WriteLine(EmpInfo);
            }
            * */

            Console.ReadLine();
        }

        void Ex6() 
        {


            List<Employee> Employees = getAllEmployees();




            Employee MaxSalaryEmp = getMaxSalaryEmployee(Employees);
            PrintEmployee(MaxSalaryEmp, "Max Salary Employee");


            Employee MinSalaryEmp = getMinSalaryEmployee(Employees);
            PrintEmployee(MinSalaryEmp, "Min Salary Employee");

            SortEmployeesBySalaryDescending(Employees);
        
        }

        static void Ex7() 
        {
            Employee Admin1 = new Employee { FirstName = "Emad", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };
            Employee Admin2 = new Employee { FirstName = "Ali", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 };

            Department D1 = new Department { Name = "CS", Id = 10009, StartDate = DateTime.Now, Budget = 1000009, Admin = new Employee { FirstName = "Emad", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000 } };
            Department D2 = new Department { Name = "Engineering", Id = 10339, StartDate = DateTime.Now, Budget = 1000009, Admin = Admin2 };

            List<Department> Departments = new List<Department>();

            Departments.Add(D1);
            Departments.Add(D2);


            Employee Emoloyee1 = new Employee { FirstName = "Asad", LastName = "James", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D1 };
            Employee Emoloyee2 = new Employee { FirstName = "James", LastName = "Redii", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D2 };
            Employee Emoloyee3 = new Employee { FirstName = "John", LastName = "Naser", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D1 };
            Employee Emoloyee4 = new Employee { FirstName = "Issam", LastName = "John", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D1 };
            Employee Emoloyee5 = new Employee { FirstName = "Khami", LastName = "Kil", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D2 };
            Employee Emoloyee6 = new Employee { FirstName = "Redii", LastName = "Naher", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D1 };
            Employee Emoloyee7 = new Employee { FirstName = "Ismaeil", LastName = "REd", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D2 };
            Employee Emoloyee8 = new Employee { FirstName = "Naher", LastName = "IOU", Id = 1000, BirthDate = DateTime.Now, Address = "Ramallah", Rating = Employee.ERating.Good, Salary = 1000, Department = D1 };

            List<Employee> Employees = new List<Employee>();

            Employees.Add(Emoloyee1);
            Employees.Add(Emoloyee2);
            Employees.Add(Emoloyee3);
            Employees.Add(Emoloyee4);
            Employees.Add(Emoloyee5);
            Employees.Add(Emoloyee6);
            Employees.Add(Emoloyee7);
            Employees.Add(Emoloyee8);


 //           List<Employee> Emps = GetAllEmployessByDepartment(D1, Employees);

            List<Employee> Emps = GetAllEmployessByDepartmentName("CS", Employees);

            Console.WriteLine(Emps.Count);

            foreach (Employee Emp in Emps)
            {
                string EmpInfo = "Id:" + Emp.Id + "\n" +
                  "Full Name: " + Emp.FullName + "\n" +
                  "BirthDate: " + Emp.BirthDate + "\n" +
                                "Rating: " + Emp.Rating + "\n" +
                                "Salary: " + Emp.Salary + "\n";

                Console.WriteLine(EmpInfo);
            }
            Console.ReadLine();
        }

        private static List<Employee> GetAllEmployessByDepartmentName(string DepName, List<Employee> Employees)
        {

            var ListOfEmployeesInAGivenDepartment = from Emp in Employees where Emp.Department.Name == DepName select Emp;

            return ListOfEmployeesInAGivenDepartment.ToList<Employee>();


      
        }

    }
}
