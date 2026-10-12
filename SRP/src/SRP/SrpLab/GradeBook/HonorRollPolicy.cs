using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.GradeBook
{
    public sealed class HonorRollPolicy
    {
        public bool Qualifies(decimal average, string letter) =>
            average >= 85 && letter is "A" or "B";
    }
}
