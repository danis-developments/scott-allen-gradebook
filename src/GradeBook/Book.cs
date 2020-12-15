using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get;}
        event GradeAddedDelegate GradeAdded;
    }
    
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var bookFile = File.AppendText($"{Name}.txt"))
            {
                bookFile.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var bookFile = File.OpenText($"{Name}.txt"))
            {
                while(true)
                {
                    var line =  bookFile.ReadLine();
                    if(line == null)
                    {
                        break;
                    }
                    else
                    {
                        var grade = double.Parse(line);
                        result.AddNum(grade);
                    }
                }
                return result;
            }
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
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

        public override void AddGrade(double grade)
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

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {

            var result = new Statistics();
            
            foreach(var grade in grades)
            {
                result.AddNum(grade);
            }
            return result;
        }

        private List<double> grades;
        
        public const string CATEGORY = "Science";
    }
}