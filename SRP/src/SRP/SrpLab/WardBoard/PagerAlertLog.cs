using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WardBoard
{
    public sealed class PagerAlertLog
    {
        private readonly List<string> _pagerLog = new();

        public void RaiseIfCritical(int bed, int acuity)
        {
            if (acuity >= 8)
                _pagerLog.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");
        }

        public IReadOnlyList<string> DrainPagerLog()
        {
            var copy = _pagerLog.ToList();
            _pagerLog.Clear();
            return copy;
        }
    }
}
