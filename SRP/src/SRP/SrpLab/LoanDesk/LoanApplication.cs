using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed class LoanApplication
    {
        public decimal RequestedAmount { get; }
        public int CreditScore { get; }
        public int EmploymentMonths { get; }
        public bool HasCollateral { get; }

        public LoanApplication(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
        {
            RequestedAmount = requestedAmount;
            CreditScore = creditScore;
            EmploymentMonths = employmentMonths;
            HasCollateral = hasCollateral;
        }
    }
}
