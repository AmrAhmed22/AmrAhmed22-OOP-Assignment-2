using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public sealed class BasketCalculation
    {
        private readonly CouponDiscount _coupons;
        private readonly GiftWrapPolicy _giftWrap;

        public BasketCalculation(GiftWrapPolicy giftWrap, CouponDiscount coupons)
        {
            _coupons = coupons;
            _giftWrap = giftWrap;
        }

        public decimal CalculateGrandTotal(Basket basket)
        {
            var total = basket.SubTotal() - _coupons.Calculate(basket) + _giftWrap.FeeFor(basket);
            return Math.Max(0m, total);
        }

    }
}
