using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAppFirst
{
    class SalaryEmployee : Employee
    {

        public double SalaryPerDay { set; get; }
		public int MonthDays { set; get; }
        public override double TotalSalary { get { return this.SalaryPerDay * MonthDays + (double)base.Salary; } }  
	

    }
}
