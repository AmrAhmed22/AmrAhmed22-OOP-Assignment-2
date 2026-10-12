using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Librarian : Staff
    {
        public Librarian(string personId, string fullName, string phone, DateTime hireDate, decimal monthlySalary)
            : base(personId, fullName, phone, hireDate, monthlySalary, 0m)
        {
        }

        public void ProcessReturn(Loan loan, DateTime returnDate)
        {
            if (loan == null)
                throw new ArgumentNullException(nameof(loan));
            
            loan.ReturnItem(returnDate);
       
        }

        
        
        public void MarkAsLost(Loan loan)
        {
            if (loan == null)
                throw new ArgumentNullException(nameof(loan));
           
            loan.MarkAsLost();
       
        
        }
    
    
    
    }
}
