using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class LibraryItem
    {
        private readonly decimal _lateFeeMultiplier;

        public string CatalogNumber { get; }
        public string Title { get; }
        public int LoanPeriodDays { get; }
        public decimal BaseLateFee { get; private set; }
        public bool IsWithdrawn { get; private set; }
        public bool IsOnLoan { get; private set; }

        protected LibraryItem(string catalogNumber, string title, decimal baseLateFee,
                              int loanPeriodDays, decimal lateFeeMultiplier)
        {
            if (string.IsNullOrWhiteSpace(catalogNumber))
                throw new ArgumentException("Catalog number must not be empty.");
            
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title must not be empty.");
            
            if (baseLateFee <= 0)
                throw new ArgumentException("Base late fee must be greater than zero.");
           
            if (loanPeriodDays <= 0)
                throw new ArgumentException("Loan period must be greater than zero.");
            
            
            if (lateFeeMultiplier <= 0) 
                throw new ArgumentException("Late fee multiplier must be greater than zero.");

            CatalogNumber = catalogNumber;
            Title = title;
            BaseLateFee = baseLateFee;
            LoanPeriodDays = loanPeriodDays;
            _lateFeeMultiplier = lateFeeMultiplier;
        }

        public decimal GetDailyLateFee()
        {
            return BaseLateFee * _lateFeeMultiplier;
        }

        public void ChangeBaseLateFee(decimal newBaseFee)
        {
            if (newBaseFee <= 0)
                throw new ArgumentException("Late fee must be greater than zero.");
            
            BaseLateFee = newBaseFee;
        }

        public void Withdraw()
        {
            IsWithdrawn = true;
        }

        public void Restore()
        {
            IsWithdrawn = false;
        }

        public void MarkAsBorrowed()
        {
            if (IsWithdrawn) 
                throw new InvalidOperationException($"'{Title}' is withdrawn from circulation and cannot be borrowed.");
            
            if (IsOnLoan)
                throw new InvalidOperationException($"'{Title}' is already on loan.");
           
            IsOnLoan = true;
       
        }

        public void MarkAsReturned()
        {
            IsOnLoan = false;
        }
    
    
    }
}
