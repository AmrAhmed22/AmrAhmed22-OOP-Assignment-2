using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed class UnderwriterCsvRowExporter
    {
        public string Export(string applicationId, LoanApplication app, decimal riskScore, bool isEligible)
        {
            return $"{applicationId},{app.CreditScore},{app.EmploymentMonths},{(app.HasCollateral ? 1 : 0)},{riskScore:0.00},{(isEligible ? "Y" : "N")}";
        }
    }
}
