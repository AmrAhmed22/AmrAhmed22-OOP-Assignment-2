using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed record KitchenItem(string Name, List<string> Ingredients, int PrepMinutes);
}
