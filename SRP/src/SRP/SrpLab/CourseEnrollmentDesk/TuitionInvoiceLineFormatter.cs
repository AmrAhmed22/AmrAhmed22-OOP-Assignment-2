using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CourseEnrollmentDesk
{
    public sealed class TuitionInvoiceLineFormatter
    {
        public string Format(Course course, TuitionFeeCalculator fees, string studentEmail)
        {
            if (!course.IsSeated(studentEmail))
                return $"{course.CourseCode},WAITLIST,0.00";

            return $"{course.CourseCode},TUITION,{fees.Tuition:0.00},VAT,{fees.Vat():0.00},TOTAL,{fees.Total():0.00}";
        }
    }


}
