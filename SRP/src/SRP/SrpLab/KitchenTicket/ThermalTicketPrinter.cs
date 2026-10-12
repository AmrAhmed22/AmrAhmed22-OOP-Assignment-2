using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed class ThermalTicketPrinter
    {
        private const int Width = 32;

        public string Print(int orderNumber, KitchenOrder order, int etaMinutes, List<string> allergens)
        {
            var line = new string('=', Width);
            var body = string.Join('\n', order.Items().Select(i => $"* {i.Name.ToUpperInvariant()} ({i.PrepMinutes}m)"));
            var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
            return $"{line}\nORDER #{orderNumber}\nETA {etaMinutes} MIN\n{body}\n{allergyLine}\n{line}\n";
        }
    }
}
