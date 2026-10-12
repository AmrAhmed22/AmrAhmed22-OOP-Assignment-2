using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WardBoard
{
    public sealed class HandoffNoteWriter
    {
        public string BuildHandoffNote(WardBoard board, int bed)
        {
            if (!board.TryGetBed(bed, out var patient, out var acuity))
                return $"Bed {bed}: empty";

            var tone = acuity >= 8 ? "ESCALATE" : acuity >= 4 ? "WATCH" : "STABLE";
            return $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] Bed {bed} · {patient} · acuity={acuity} · {tone}";
        }
    }
}
