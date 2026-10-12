using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.GradeBook
{
    public sealed class CalculateGradeAverage
    {
        public decimal Average(ScoreBook book, string studentId)
        {
            var scores = book.ScoresOf(studentId);
            if (scores.Count == 0) return 0m;
            return Math.Round(scores.Average(), 2);
        }
    }
}
