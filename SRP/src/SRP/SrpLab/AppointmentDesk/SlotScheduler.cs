using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.AppointmentDesk
{
    public sealed class SlotScheduler
    {
        private readonly HashSet<DateTimeOffset> _booked = new();

        private readonly AppointmentHoursPolicy hoursPolicy ;

        public SlotScheduler(AppointmentHoursPolicy hoursPolicy)
        {
            this.hoursPolicy = hoursPolicy;
        }


        public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
        {
            var cursor = Align(from);
            var end = from.AddHours(searchHours);
            while (cursor < end)
            {
                if (hoursPolicy.IsWithinBusinessHours(cursor) && !_booked.Contains(cursor))
                    return cursor;
                cursor = cursor.AddMinutes(hoursPolicy.SlotMinutes);
            }
            return null;
        }


        public bool TryBook(DateTimeOffset slot)
        {
            if (!hoursPolicy.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
            _booked.Add(slot);
            return true;
        }


        private DateTimeOffset Align(DateTimeOffset from)
        {
            var minutes = from.Minute - (from.Minute % hoursPolicy.SlotMinutes);
            return new DateTimeOffset(from.Year, from.Month, from.Day, from.Hour, minutes, 0, from.Offset);
        }

    }
}
