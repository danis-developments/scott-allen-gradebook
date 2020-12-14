using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;
            
                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                case 'F':
                    AddGrade(50);
                    break;

                default:
                    throw new ArgumentException($"Invalid {nameof(grade)}: {grade} out of range(A-D,F)");
            }
        }

        public void AddGrade(double grade)
        {
            if(grade < 0 || grade > 100)
            {
                throw new ArgumentException($"Invalid {nameof(grade)}: {grade} out of range(0-100)");
            }
            else
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {

            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            foreach(var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            if(grades.Count == 0)
            {
                result.High = 0.0;
                result.Low = 0.0;
            }
            else
            {
                result.Average /= grades.Count;
            }

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.LetterGrade = 'A';
                    break;
                
                case var d when d >= 80.0:
                    result.LetterGrade = 'B';
                    break;
                
                case var d when d >= 70.0:
                    result.LetterGrade = 'C';
                    break;
                
                case var d when d >= 60.0:
                    result.LetterGrade = 'D';
                    break;
                
                default:
                    result.LetterGrade = 'F';
                    break;
            }
            return result;
        }

        private List<double> grades;
        public string Name
        {
            get; 
            set;
        }
        
        public const string CATEGORY = "Science";
    }
}