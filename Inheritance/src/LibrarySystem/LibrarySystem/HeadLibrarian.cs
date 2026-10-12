using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class HeadLibrarian : Staff
    {
        private const decimal ResponsibilityAllowance = 400m;

        public HeadLibrarian(string personId, string fullName, string phone, DateTime hireDate, decimal monthlySalary)
            : base(personId, fullName, phone, hireDate, monthlySalary, ResponsibilityAllowance)
        {
        }

        public void ChangeLateFee(LibraryItem item, decimal newBaseFee)
        {

            if (item == null) 
                throw new ArgumentNullException(nameof(item));
           
            
            item.ChangeBaseLateFee(newBaseFee);
       
        }

        public void Withdraw(LibraryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            
            
            item.Withdraw();
       
        }

        public void Restore(LibraryItem item)
        {
            if (item == null) 
                throw new ArgumentNullException(nameof(item));
           
            item.Restore();

        }

    }
}
