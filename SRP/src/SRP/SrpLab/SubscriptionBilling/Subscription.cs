using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public sealed class Subscription
    {
        public string CustomerId { get; }
        public decimal MonthlyPrice { get; }
        public DateOnly PeriodStart { get; }
        public DateOnly PeriodEnd { get; }
        public int FailedPayments { get; private set; }

        public Subscription(string customerId, decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd)
        {
            CustomerId = customerId;
            MonthlyPrice = monthlyPrice;
            PeriodStart = periodStart;
            PeriodEnd = periodEnd;
        }

        public void RegisterFailedPayment() => FailedPayments++;
    }
}
