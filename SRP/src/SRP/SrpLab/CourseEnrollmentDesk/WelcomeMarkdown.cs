using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CourseEnrollmentDesk
{
    public sealed class WelcomeMarkdown
    {
        public string Write(Course course, string studentEmail, string studentName)
        {
            var status = course.IsSeated(studentEmail)
                ? "confirmed seat"
                : $"waitlist #{course.WaitlistPosition(studentEmail)}";

            return $"# Welcome to {course.CourseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
                   $"Bring a laptop. Discord onboarding link: https://example.invalid/{course.CourseCode.ToLowerInvariant()}\n";
        }
    }
}
