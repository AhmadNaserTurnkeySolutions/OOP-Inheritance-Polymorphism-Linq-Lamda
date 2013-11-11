using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAppFirst
{
    class HourlyEmployee : Employee
    {
        public double HourRate { set; get; }
        public int NumberOfHours { set; get; }
        public override double TotalSalary { get { return this.HourRate * NumberOfHours + (double)base.Salary; } }

    }
}
