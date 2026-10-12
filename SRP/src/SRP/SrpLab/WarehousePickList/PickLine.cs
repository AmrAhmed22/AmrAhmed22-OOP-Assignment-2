using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed record PickLine(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand);


}
