using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class PremiumMember : Member
    {
        private const int PointsPerReturnedLoan = 5;

        public PremiumMember(string personId, string fullName, string phone, decimal discountPercent)
            : base(personId, fullName, phone, 10, discountPercent)
        {
        }

        
        public int ReadingPoints
        {
            get
            {
                int returned = 0;
            
                foreach (Loan loan in Loans)
                {
                    if (loan.Status == LoanStatus.Returned)
                        returned++;
                }
               
                return returned * PointsPerReturnedLoan;
            }

        }
    }
}
