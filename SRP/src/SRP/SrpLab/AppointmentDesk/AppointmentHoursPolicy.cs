using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.AppointmentDesk
{
    public sealed class AppointmentHoursPolicy
    {
        public TimeOnly Open { get; }
        public TimeOnly Close { get; }

        public int SlotMinutes { get; }

        public AppointmentHoursPolicy(TimeOnly open, TimeOnly close, int slotMinutes)
        {
            Open = open;
            Close = close;
            SlotMinutes = slotMinutes;
        }

        public bool IsWithinBusinessHours(DateTimeOffset when)
        {
            // Clinic calendar policy — HR/ops — not the same as ICS serialization.
            if (when.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday) return false;
            var t = TimeOnly.FromDateTime(when.DateTime);
            return t >= Open && t.AddMinutes(SlotMinutes) <= Close;
        }


    }
}
