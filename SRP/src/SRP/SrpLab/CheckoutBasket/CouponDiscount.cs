using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public sealed class CouponDiscount
    {


        public decimal Calculate(Basket basket)
        {
            // Parsing marketing strings is a different reason to change than pricing math.
            if (string.IsNullOrWhiteSpace(basket.CouponText)) return 0m;
            var t = basket.CouponText.Trim().ToUpperInvariant();
            if (t.StartsWith("SAVE") && int.TryParse(t[4..], out var pct) && pct is > 0 and <= 50)
                return Math.Round(basket.SubTotal() * pct / 100m, 2);
            if (t.Contains("FREESHIP")) return 0m; // ship is elsewhere — still parsed here
            if (t == "WELCOME10") return Math.Min(10m, basket.SubTotal());
            return 0m;
        }


    }
}
