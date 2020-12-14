using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Dan's Gradebook");
            book.GradeAdded += OnGradeAdded;

            System.Console.WriteLine("Welcome to the Gradebook!");
            var done = false;
            do{
                Console.Write("Please enter the next grade or Q to quit: ");
                var input = Console.ReadLine();
                if(input.ToUpper() == "Q")
                {
                    done = true;
                }
                else
                {
                    try
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("**");
                    }
                }
            } while(!done);

            var stats = book.GetStatistics();
            
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
         }

         static void OnGradeAdded(object sender, EventArgs e)
         {
             Console.WriteLine("A Grade Was Added.");
         }
    }
}