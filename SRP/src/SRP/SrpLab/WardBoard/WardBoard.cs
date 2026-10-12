using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WardBoard
{
    public sealed class WardBoard
    {
        private readonly Dictionary<int, string> _bedPatient = new();
        private readonly Dictionary<int, int> _vitalsScore = new();
        private readonly AcuityScorer _scorer;
        private readonly PagerAlertLog _pager;

        public WardBoard(AcuityScorer scorer, PagerAlertLog pager)
        {
            _scorer = scorer;
            _pager = pager;
        }



        public void AssignBed(int bed, string patientId, int heartRate, int spo2)
        {
            if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
            if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

            _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
            _vitalsScore[bed] = _scorer.Score(heartRate, spo2);

            _pager.RaiseIfCritical(bed, _vitalsScore[bed]);
        }




        // to use in the handoff and csv
        public bool TryGetBed(int bed, out string patient, out int acuity)
        {
            if (_bedPatient.TryGetValue(bed, out var p))
            {
                patient = p;
                acuity = _vitalsScore[bed];
                return true;
            }
            patient = "";
            acuity = 0;
            return false;
        }


        public IReadOnlyList<int> BedNumbers() => _bedPatient.Keys.OrderBy(x => x).ToList();
    }
}
