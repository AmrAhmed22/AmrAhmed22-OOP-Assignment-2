using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CourseEnrollmentDesk
{
    public sealed class TuitionFeeCalculator
    {
        private const decimal VatRate = 0.14m;

        public decimal Tuition { get; }

        public TuitionFeeCalculator(decimal tuition)
        {
            Tuition = tuition;
        }

        public decimal Vat() => Math.Round(Tuition * VatRate, 2);

        public decimal Total() => Tuition + Vat();
    }
}
