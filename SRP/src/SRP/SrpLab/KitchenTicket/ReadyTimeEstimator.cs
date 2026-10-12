using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed class ReadyTimeEstimator
    {
        private const int AllergyDelayMinutes = 3;

        public int Estimate(KitchenOrder order, bool hasAllergens, int openStations)
        {
            if (openStations <= 0) openStations = 1;

            var items = order.Items();
            var sequential = items.Sum(i => i.PrepMinutes);
            var parallel = (int)Math.Ceiling(sequential / (double)openStations);
            if (hasAllergens) parallel += AllergyDelayMinutes;

            var longest = items.Count == 0 ? 0 : items.Max(i => i.PrepMinutes);
            return Math.Max(parallel, longest);
        }
    }
}
