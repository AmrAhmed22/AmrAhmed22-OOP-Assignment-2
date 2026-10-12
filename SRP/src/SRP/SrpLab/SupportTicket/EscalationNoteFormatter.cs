using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public sealed class EscalationNoteFormatter
    {
        public string Format(string ticketId, string priority, DateTimeOffset deadline) =>  $"ESCALATE {ticketId} priority={priority} breachAt={deadline:u} keywords-scanned=yes";
    }
}
