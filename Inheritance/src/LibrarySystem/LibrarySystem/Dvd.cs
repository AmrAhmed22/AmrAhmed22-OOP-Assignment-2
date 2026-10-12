using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Dvd : LibraryItem
    {
        public Dvd(string catalogNumber, string title, decimal baseLateFee)
            : base(catalogNumber, title, baseLateFee, 7, 2m)
        {
        }
    }
}
