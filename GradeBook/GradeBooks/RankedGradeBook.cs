﻿using System;
using System.Linq;
namespace GradeBook.GradeBooks
{         
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Trzeba conajmniej 5");
            var prog = (int)Math.Ceiling(Students.Count * 0.2);
            var oceny = Students.OrderByDescending(a => a.AverageGrade).Select(a => a.AverageGrade).ToList();
            if (averageGrade >= oceny[prog - 1])
            {
                return 'A';
            }
            if (averageGrade >= oceny[(prog * 2) - 1])
            {
                return 'B';
            }
            if (averageGrade >= oceny[(prog * 3) - 1])
            {
                return 'C';
            }
            if (averageGrade >= oceny[(prog * 4) - 1])
            { 
                return 'D';
            }            
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }
            
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if ( Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }
            
            base.CalculateStudentStatistics(name);
        }
    }
    
    
}
