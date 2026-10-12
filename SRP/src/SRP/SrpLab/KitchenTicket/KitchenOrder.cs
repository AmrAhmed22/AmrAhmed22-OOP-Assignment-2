using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed class KitchenOrder
    {
        private readonly List<KitchenItem> _items = new();

        public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
        {
            var cleaned = ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList();
            _items.Add(new KitchenItem(item, cleaned, prepMinutes));
        }

        public List<KitchenItem> Items() => new(_items);
    }
}
