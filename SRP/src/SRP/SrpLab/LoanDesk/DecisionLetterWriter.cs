using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed class DecisionLetterWriter
    {
        public string Write(string applicantName, LoanApplication app, bool isEligible,
                            decimal riskScore, List<string> requiredDocuments)
        {
            if (isEligible)
            {
                return $"Dear {applicantName},\nYour request for {app.RequestedAmount:C} is pre-approved (risk {riskScore:0}).\n" +
                       $"Please upload: {string.Join("; ", requiredDocuments)}.\n";
            }

            return $"Dear {applicantName},\nWe are unable to approve {app.RequestedAmount:C} at this time.\n" +
                   $"Reference risk={riskScore:0}. You may reapply after improving documentation.\n";
        }
    }
}