using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.GradeBook
{
    public sealed class GradeCsvExporter
    {
        private readonly CalculateGradeAverage _averager;
        private readonly LetterGradePolicy _letters;
        private readonly HonorRollPolicy _honor;

        public GradeCsvExporter(CalculateGradeAverage averager, LetterGradePolicy letters, HonorRollPolicy honor)
        {
            _averager = averager;
            _letters = letters;
            _honor = honor;
        }

        public string Export(ScoreBook book)
        {
            var rows = new List<string> { "studentId,average,letter,honor" };
            foreach (var id in book.StudentIds())
            {
                var avg = _averager.Average(book, id);
                var letter = _letters.Letter(avg);
                rows.Add($"{id},{avg},{letter},{(_honor.Qualifies(avg, letter) ? 1 : 0)}");
            }
            return string.Join('\n', rows);
        }
    }
}