using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public sealed class GiftWrapPolicy
    {
        private const decimal Fee = 4.99m;

        public decimal FeeFor(Basket basket) => basket.GiftWrapRequested ? Fee : 0m;
    }
}
