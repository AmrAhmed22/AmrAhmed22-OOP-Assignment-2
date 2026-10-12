using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public sealed class LedgerJournalExporter
    {
        public string Line(string customerId, string invoiceNumber, decimal amount) => $"{customerId},{invoiceNumber},{amount:0.00},AR-SUB";
    }
}
