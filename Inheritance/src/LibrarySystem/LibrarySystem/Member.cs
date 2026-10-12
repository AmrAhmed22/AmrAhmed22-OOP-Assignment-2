using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Member : Person
    {
        private readonly List<Loan> _loans = new List<Loan>();

        public int MaxLoans { get; }
        public decimal DiscountPercent { get; }




        //   cannot Add or Remove outside
        public IReadOnlyList<Loan> Loans
        {
            get { return _loans.AsReadOnly(); }
        }


        //also protected
        protected Member(string personId, string fullName, string phone, int maxLoans, decimal discountPercent)
            : base(personId, fullName, phone)
        {
            if (maxLoans <= 0)
                throw new ArgumentException("Max loans must be greater than zero.");
            
            if (discountPercent < 0 || discountPercent > 100) 
                throw new ArgumentException("Discount must be between 0 and 100.");


            MaxLoans = maxLoans;
            DiscountPercent = discountPercent;
        }

        public int ActiveLoanCount
        {
            get
            {
                int count = 0;
                
                foreach (Loan loan in _loans)
                {
                    if (loan.Status == LoanStatus.Borrowed)
                        count++;
                }
              
                
                return count;
            }
        }



        public Loan Borrow(LibraryItem item, DateTime borrowDate)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            
            if (ActiveLoanCount >= MaxLoans)
                throw new InvalidOperationException(
                    $"{FullName} already has {ActiveLoanCount} active loans (maximum {MaxLoans}).");


            item.MarkAsBorrowed();      
            
            Loan loan = new Loan(this, item, borrowDate);
            _loans.Add(loan);
           
            
            return loan;
        }
    }
}
