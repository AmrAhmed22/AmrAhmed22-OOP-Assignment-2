using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{

    public sealed class ExpoLaneCheck
    {
        private const int SlowThresholdMinutes = 20;

        public string Check(List<string> allergens, int etaMinutes)
        {
            if (allergens.Count > 0) return "LANE-ALLERGY";
            return etaMinutes > SlowThresholdMinutes ? "LANE-SLOW" : "LANE-FAST";
        }
    }

}
