using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class WalkingPathPlanner
    {
        public IReadOnlyList<WalkStep> WalkingOrder(WarehousePickList pickList)
        {
            return pickList.Lines()
                .OrderBy(l => l.Aisle)
                .ThenBy(l => l.Bin)
                .Select(l => new WalkStep(l.Aisle, l.Bin, l.Sku, Math.Min(l.QtyNeeded, l.QtyOnHand)))
                .Where(x => x.Qty > 0)
                .ToList();
        }

    }
}
