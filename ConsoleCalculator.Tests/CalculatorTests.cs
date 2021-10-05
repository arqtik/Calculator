using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(new double[]{-10, 5, -5}, -10)]
        [InlineData(new double[]{10}, 10)]
        [InlineData(new double[]{}, 0)]
        public void AdditionArrayTest(double[] input, double expected)
        {
            Calculator calculator = new Calculator();
            double result = calculator.Addition(input);
            Assert.Equal(expected, result);
        }
        

        [Theory]
        [InlineData(new double[]{-10, 5, -5}, -10)]
        [InlineData(new double[]{-10}, -10)]
        [InlineData(new double[]{}, 0)]
        public void SubtractionArrayTest(double[] input, double expected)
        {
            Calculator calculator = new Calculator();
            double result = calculator.Subtraction(input);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(new double[]{2, 2, 2}, 8)]
        [InlineData(new double[]{10}, 10)]
        [InlineData(new double[]{}, 0)]
        public void MultiplicationArrayTest(double[] input, double expected)
        {
            Calculator calculator = new Calculator();
            double result = calculator.Multiplication(input);
            Assert.Equal(expected, result);
        }       
        
        [Fact]
        public void DivisionByZeroTest()
        {
            Calculator calculator = new Calculator();
            DivideByZeroException ex = Assert.Throws<DivideByZeroException>(() => calculator.Division(1, 0));
            Assert.Equal("Undefined. Can not divide by zero.", ex.Message);
        }   
    }
}