using System;
using Xunit;

namespace TDDWorkshop.Test
{
    public class AddTests
    {
        private StringCalculator sut = new StringCalculator();

        [Fact]
        public void EmptyString_ShouldReturnZero()
        {
            int result = sut.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void SingleNumber_ShouldReturnValue()
        {
            string number = 17.ToString();

            int result = sut.Add(number);

            Assert.Equal(17, result);
        }

        [Theory]
        [InlineData(31, 8)]
        public void TwoNumbersCommaDelimited_ShouldReturnSum(int nr1, int nr2)
        {
            // arrange
            string numbers = nr1.ToString() + "," + nr2.ToString();

            // act
            int result = sut.Add(numbers);

            // assert
            int sum = nr1 + nr2;
            Assert.Equal(sum, result);
        }

        [Theory]
        [InlineData(31, 8)]
        public void TwoNumbersNewlineDelimited_ShouldReturnSum(int nr1, int nr2)
        {
            // arrange
            string numbers = nr1.ToString() + "\n" + nr2.ToString();

            // act
            int result = sut.Add(numbers);

            // assert
            int sum = nr1 + nr2;
            Assert.Equal(sum, result);
        }

        [Theory]
        [InlineData(6, 40, 827)]
        public void ThreeNumbersDelimitedEitherWay_ShouldReturnSum(int nr1, int nr2, int nr3)
        {
            // arrange
            string numbers = nr1.ToString() + "," + nr2.ToString() + "\n" + nr3.ToString();
            string numbers2 = nr1.ToString() + "\n" + nr2.ToString() + "," + nr3.ToString();


            // act
            int result = sut.Add(numbers);
            int result2 = sut.Add(numbers2);

            // assert
            int sum = nr1 + nr2 + nr3;
            Assert.Equal(sum, result);
            Assert.Equal(sum, result2);
        }

        [Theory]
        [InlineData(-5, 17)]
        public void NegativeNumbers_ShouldThrowArgumentException(int nr1, int nr2)
        {
            // arrange
            string numbers = nr1.ToString() + "," + nr2.ToString();

            // assert
            Assert.Throws<ArgumentException>(() => sut.Add(numbers));
        }

        [Fact]
        public void NumbersGreaterThan1000_ShouldBeIgnored()
        {
            // arrange
            int nr1 = 1001;
            int nr2 = 90;
            string numbers = nr1.ToString() + "\n" + nr2.ToString();

            // act
            int result = sut.Add(numbers);

            // assert
            int sum = 90;
            Assert.Equal(sum, result);
        }

        [Fact]
        public void SingleCharDelimiter_CanBeDefinedOnTheFirstLine()
        {
            // arrange
            char delimiter = '#';
            int nr1 = 829;
            int nr2 = 0;
            string numbers = "//" + delimiter + "\n" + nr1.ToString() + delimiter + nr2.ToString();

            // act
            int result = sut.Add(numbers);

            // assert
            int sum = nr1 + nr2;
            Assert.Equal(sum, result);
        }

        [Fact]
        public void MultiCharDelimiter_CanBeDefinedOnTheFirstLine()
        {
            // arrange
            string delimiter = "###";
            int nr1 = 432;
            int nr2 = 98;
            string numbers = "//[" + delimiter + "]" + "\n" + nr1.ToString() + delimiter + nr2.ToString();

            // act
            int result = sut.Add(numbers);

            // assert
            int sum = nr1 + nr2;
            Assert.Equal(sum, result);
        }

        //Many single or multi-char delimiters can be defined (each wrapped in square brackets)
    }
}
