using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                if(Count == 0)
                {
                    return 0;
                }
                else
                {
                    return Total / Count;
                }
            }
        }
        public int Count
        {
            get;
            private set;
        }
        public double High;
        public char LetterGrade
        {
            get
            {
                switch(Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    
                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';
                    
                    case var d when d >= 60.0:
                        return 'D';
                    
                    default:
                        return 'F';
                }

            }
        }
        public double Low;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Total = 0.0;
            Count = 0;
        }

        public void AddNum(double num)
        {
            Total += num;
            Count += 1;
            UpdateStatistics(num);
        }

        private void UpdateHigh(double num)
        {
            High = Math.Max(num, High);
        }

        private void UpdateLow(double num)
        {
            Low = Math.Min(num, Low);
        }

        private void UpdateStatistics(double num)
        {
            UpdateHigh(num);
            UpdateLow(num);
        }

        private double Total;

    }
}