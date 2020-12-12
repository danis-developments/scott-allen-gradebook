using System;
using System.Collections.Generic;

namespace GradeBook
{

    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public bool AddGrade(double grade)
        {
            if(grade < 0 | grade > 100)
            {
                return false;
            }
            grades.Add(grade);
            return true;
        }

        public void ShowStatistics()
        {
            double result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(var grade in grades)
            {
                highGrade = Math.Max(grade, highGrade);
                lowGrade = Math.Min(grade, lowGrade);
                result += grade;
            }
            result /= grades.Count;
            Console.WriteLine($"The lowest grade is {lowGrade:N1}");
            Console.WriteLine($"The highest grade is {highGrade:N1}");
            Console.WriteLine($"The average grade is {result:N1}");
        }

        private List<double> grades;
        private string name;
    }
}