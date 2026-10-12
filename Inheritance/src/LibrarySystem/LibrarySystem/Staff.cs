using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Staff : Person
    {
        private readonly decimal _allowance;

        public DateTime HireDate { get; }
        public decimal MonthlySalary { get; private set; }


        // protected aslo
        protected Staff(string personId, string fullName, string phone, DateTime hireDate, decimal monthlySalary, decimal allowance)
            : base(personId, fullName, phone)
        {
            if (monthlySalary <= 0)
                throw new ArgumentException("Salary must be greater than zero.");
           
            if (allowance < 0)
                throw new ArgumentException("Allowance must not be negative.");

            HireDate = hireDate;
            MonthlySalary = monthlySalary;
            _allowance = allowance;
        }

        public void GiveRaise(decimal percent)
        {

            if (percent <= 0)
                throw new ArgumentException("Raise percentage must be greater than zero.");
           
            MonthlySalary = MonthlySalary + MonthlySalary * percent / 100m;
      
        }

        public decimal GetMonthlyPay()
        {
            return MonthlySalary + _allowance;
        }



    }
}
