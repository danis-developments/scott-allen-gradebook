using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void GradeValidationWorks()
        {
            var book = new Book("");

            var negativeGradeFails = book.AddGrade(-5);
            var greaterThanHunredFails = book.AddGrade(105);
            var hundredWorks = book.AddGrade(100);
            var zeroWorks = book.AddGrade(0);
            var bookStats = book.GetStatistics();

            Assert.Equal(false, negativeGradeFails);
            Assert.Equal(false, greaterThanHunredFails);
            Assert.Equal(true, hundredWorks);
            Assert.Equal(true, zeroWorks);
            
            Assert.Equal(0, bookStats.Low);
            Assert.Equal(100, bookStats.High);
            Assert.Equal(50.0, bookStats.Average, 1);


        }
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal('B',result.LetterGrade);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}
