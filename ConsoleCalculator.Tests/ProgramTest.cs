using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class ProgramTest
    {
        [Theory]
        [InlineData("1,4,2,3", new double[]{1, 4, 2, 3})]
        [InlineData(",1,, ,3,", new double[]{1, 3})]
        [InlineData("", new double[]{})]
        [InlineData(" ", new double[]{})]
        public void GetNumbersFromStringTest(string str, double[] expected)
        {
            double[] result = Program.GetNumbersFromString(str);
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("%20")]
        [InlineData("\n")]
        [InlineData("@")]
        [InlineData("/")]
        [InlineData("a")]
        public void GetNumbersFromStringExceptionTest(string input)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => Program.GetNumbersFromString(input));
            Assert.Equal($"{input} was invalid number input", ex.Message);
        }
    }
}