using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public sealed class Basket
    {
        private readonly List<OrderLine> _lines = new();

        public IReadOnlyList<OrderLine> Lines => _lines;
    
        public string? CouponText { get; private set; }
        public bool GiftWrapRequested { get; private set; }

        public void AddLine(string sku, decimal price, int qty)
        {
            if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
            _lines.Add(new OrderLine(sku, price, qty));
        }

        public void ApplyCouponText(string? couponText) => CouponText = couponText;
        public void EnableGiftWrap() => GiftWrapRequested = true;

        public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);


    }
}
