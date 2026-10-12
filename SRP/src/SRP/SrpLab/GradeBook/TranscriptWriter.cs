using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.GradeBook
{
    public sealed class TranscriptWriter
    {
        public string Write(string studentId, string fullName, decimal average, string letter, bool honor)
        {
            return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {average}\nLetter: {letter}\nHonor: {honor}\n";
        }
    }


}
