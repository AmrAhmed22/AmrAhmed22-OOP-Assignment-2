using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed class EligibilityPolicy
    {
        private const decimal MinRiskScore = 55m;
        private const int MinCreditScore = 580;

        public bool IsEligible(LoanApplication app, decimal riskScore) =>
            riskScore >= MinRiskScore && app.CreditScore >= MinCreditScore;
    }
}
