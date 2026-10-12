using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class PickerScriptWriter
    {
        private readonly StockAllocator _allocator;
        private readonly WalkingPathPlanner _planner;

        public PickerScriptWriter(StockAllocator allocator, WalkingPathPlanner planner)
        {
            _allocator = allocator;
            _planner = planner;
        }

        public string PickerScript(WarehousePickList pickList)
        {
            var steps = _planner.WalkingOrder(pickList)
                .Select((s, i) => $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");
            var shortfalls = _allocator.Allocate(pickList).Where(a =>
            {
                var need = pickList.Lines().First(l => l.Sku == a.Sku).QtyNeeded;
                return a.Allocated < need;
            });
            var warn = shortfalls.Any()
                ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
                : "SHORTAGES: none";
            return string.Join('\n', steps) + "\n" + warn;
        }
    }
}
