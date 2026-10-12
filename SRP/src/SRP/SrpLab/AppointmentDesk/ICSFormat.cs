using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.AppointmentDesk
{
    public sealed class ICSFormat
    {
        private readonly AppointmentHoursPolicy hoursPolicy;

        public ICSFormat(AppointmentHoursPolicy hoursPolicy)
        {
            this.hoursPolicy = hoursPolicy;
        }

        public string ToIcs(DateTimeOffset slot, string patientName, string clinician)
        {
            // Calendar interoperability format changes with clients — not opening hours.
            var uid = Guid.NewGuid();
            var end = slot.AddMinutes(hoursPolicy.SlotMinutes);
            return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
                   $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
                   $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
        }


    }
}
