using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class WmsXmlWriter
    {
        private readonly StockAllocator _allocator;

        public WmsXmlWriter(StockAllocator allocator)
        {
            _allocator = allocator;
        }

        public string WmsXmlBatch(WarehousePickList pickList, string batchId)
        {
            var parts = _allocator.Allocate(pickList).Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
            return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
        }
    }
}
