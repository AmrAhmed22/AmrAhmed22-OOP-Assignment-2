using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public sealed class DunningEmailWriter
    {
        public string Write(string customerName, DateOnly asOf, int failedPayments,decimal amount, string invoiceNumber)
        {
            var severity = failedPayments switch
            {
                <= 1 => "friendly reminder",
                2 => "second notice",
                _ => "final notice before suspension"
            };
            return $"Subject: {severity} {invoiceNumber}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({failedPayments} failures).\n";
        }
    }
}
