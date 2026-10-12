using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public sealed class GiftMessageSender
    {
        public string Send(Basket basket, decimal grandTotal, string fromName)
        {
            var items = string.Join(", ", basket.Lines.Select(l => l.Sku));
            return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal:C}\n";
        }
    }
}
