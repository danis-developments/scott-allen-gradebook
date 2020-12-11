using System.Collections.Generic;

namespace GradeBook
{

    public class Book
    {

        public bool AddGrade(double grade)
        {
            if(grade < 0 | grade > 100)
            {
                return false;
            }
            grades.Add(grade);
            return true;
        }
        List<double> grades;
    }
}