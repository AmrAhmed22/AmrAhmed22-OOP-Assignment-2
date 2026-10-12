using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Loan
    {
        private static int _nextId = 1;

        public int LoanId { get; }
        public DateTime BorrowDate { get; }
        public Member Member { get; }
        public LibraryItem Item { get; }
        public LoanStatus Status { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public Loan(Member member, LibraryItem item, DateTime borrowDate)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));
            
            if (item == null) 
                throw new ArgumentNullException(nameof(item));

            LoanId = _nextId++;
            Member = member;
            Item = item;
            BorrowDate = borrowDate;
            Status = LoanStatus.Borrowed;

        }

        public DateTime DueDate
        {
            get { return BorrowDate.AddDays(Item.LoanPeriodDays); }
        }

        public decimal LateFee
        {
            get
            {
                if (Status != LoanStatus.Returned || ReturnDate == null)
                    return 0m;

                int lateDays = (ReturnDate.Value.Date - DueDate.Date).Days;


                if (lateDays <= 0)
                    return 0m;

                decimal gross = lateDays * Item.GetDailyLateFee();
                
                return gross - gross * Member.DiscountPercent / 100m;
           
            }
        }

        public void ReturnItem(DateTime returnDate)
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException($"Loan {LoanId} cannot be returned: its status is {Status}.");
            
            if (returnDate < BorrowDate)
                throw new ArgumentException("Return date cannot be earlier than the borrow date.");

            Status = LoanStatus.Returned;
            ReturnDate = returnDate;
            Item.MarkAsReturned();
        
        }

        public void MarkAsLost()
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException($"Loan {LoanId} cannot be marked as lost: its status is {Status}.");

      
            Status = LoanStatus.Lost;
      
        
        }
    }
}
