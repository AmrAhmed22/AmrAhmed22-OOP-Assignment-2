using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class WarehousePickList
    {
        private readonly List<PickLine> _lines = new();

        public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
        {
            _lines.Add(new PickLine(sku, aisle, bin, qtyNeeded, qtyOnHand));
        }

        public IReadOnlyList<PickLine> Lines() => _lines;
    }
}
