using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WardBoard
{
    public sealed class CensusCsvExporter
    {
        public string ExportCensusCsv(WardBoard board)
        {
            var lines = new List<string> { "bed,patient,acuity" };
            foreach (var bed in board.BedNumbers())
            {
                board.TryGetBed(bed, out var patient, out var acuity);
                lines.Add($"{bed},{patient},{acuity}");
            }
            return string.Join('\n', lines);
        }
    }
}
