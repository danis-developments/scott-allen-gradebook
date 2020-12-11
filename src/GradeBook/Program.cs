using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }
            var grades = new List<double>{12.3,34.5,56.74,78.9};
            grades.Add(56.1);
            double result = 0.0;
            foreach(var grade in grades)
            {
                result += grade;
            }
            result = result / grades.Count;
            Console.WriteLine($"The average grade is {result:N1}");
        }

    }
}
