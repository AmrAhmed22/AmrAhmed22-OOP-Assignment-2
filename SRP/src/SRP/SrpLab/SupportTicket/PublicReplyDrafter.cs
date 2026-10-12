using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public sealed class PublicReplyDrafter
    {
        public string Draft(string ticketId, string priority, string agentName, DateTimeOffset deadline)
        {
            var apology = priority == "P1"
                ? "We are treating this as a critical incident."
                : "Thanks for reaching out.";
            return $"Hi,\n{apology}\nTicket {ticketId} is with {agentName}. Next update before {deadline:u}.\n";
        }
    }
}
