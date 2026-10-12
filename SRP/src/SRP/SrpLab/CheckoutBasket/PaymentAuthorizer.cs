using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public sealed class PaymentAuthorizer
    {
        public string Authorize(Basket basket, decimal grandTotal, string cardLast4)
        {
            var payload = $"{grandTotal:0.00}|{cardLast4}|{basket.Lines.Count}";
            var hash = payload.GetHashCode();
            return $"AUTH-{Math.Abs(hash):X8}";
        }
    }
}
