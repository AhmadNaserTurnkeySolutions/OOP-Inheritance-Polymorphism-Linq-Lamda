using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAppFirst
{
    public class Employee
    {
        public decimal Salary { set; get; }
        public string FirstName { get; set; }
        public string LastName { set; get; }

        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        public DateTime BirthDate { set; get; }

        public int Id { set; get; }
        public string Address { set; get; }

        public enum ERating { Bad,Good,VeryGood,Excelent}

        public ERating? Rating { set; get; }

        public Department Department { set; get; }

        public virtual double TotalSalary { get { return (double)this.Salary; } }

        public Employee(string fn,string ln,DateTime bd,int id,string address)
        {
            this.FirstName = fn;
            this.LastName = ln;
            this.BirthDate = bd;
            this.Id = id;
            this.Address = address;
        }


        public Employee() 
        {
        
        }


    
    }
}
