using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class StockAllocator
    {
        public IReadOnlyList<(string Sku, int Allocated)> Allocate(WarehousePickList pickList)
        {
            var result = new List<(string, int)>();
            foreach (var line in pickList.Lines())
            {
                var alloc = Math.Min(line.QtyNeeded, line.QtyOnHand);
                result.Add((line.Sku, alloc));
            }
            return result;
        }
    }
}
