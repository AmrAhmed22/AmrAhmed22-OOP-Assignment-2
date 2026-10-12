using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed record WalkStep(string Aisle, int Bin, string Sku, int Qty);

}
