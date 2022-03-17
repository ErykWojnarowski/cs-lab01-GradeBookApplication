using System;
using System.Linq;
namespace GradeBook.GradeBooks
{         
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Trzeba conajmniej 5");
            var prog = (int)Math.Ceiling(Students.Count * 0.2);
            var oceny = Students.OrderByDescending(a => a.AverageGrade).Select(a => averageGrade).ToList();
            if (averageGrade >= oceny[prog - 1])
            {
                return 'A';
            }
            if (averageGrade >= oceny[prog * 2] - 1)
            {
                return 'B';
            }

            if (averageGrade >= oceny[prog * 3] - 1)
            {
                return 'C';
            }
            if (averageGrade >= oceny[prog * 4] -1)
            { 
                return 'D';
            }
            return 'F';
        }
    }
    
    
}
