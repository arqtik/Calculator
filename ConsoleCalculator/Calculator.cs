using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
    public class Calculator
    {
        /// <summary>
        /// Adds two numbers together
        /// </summary>
        /// <param name="a">First number to add</param>
        /// <param name="b">Second number to add</param>
        /// <returns>Returns the sum of the two numbers</returns>
        public double Addition(double a, double b)
        {
            return a + b;
        }
        
        /// <summary>
        /// Sums up numbers
        /// </summary>
        /// <returns>Returns formatted string with the result of the addition</returns>
        public double Addition(double[] numbers)
        {
            double result = 0;
            foreach (double d in numbers)
            {
                result += d;
            }

            return result;
        }

        /// <summary>
        /// Subtracts two numbers with each other
        /// </summary>
        /// <param name="a">First number to subtract</param>
        /// <param name="b">Second number to subtract</param>
        /// <returns>Returns the result of the subtraction as double</returns>
        public double Subtraction(double a, double b)
        {
            return a - b;
        }
        
        /// <summary>
        /// Subtracts two numbers with each other
        /// </summary>
        /// <param name="numbers">Array of numbers to subtract</param>
        /// <returns>Returns the result of the subtraction as double</returns>
        public double Subtraction(double[] numbers)
        {
            if (numbers.Length == 0)
                return 0;
            
            // Assign first element so we don't get unexpected results
            // (e.g. if we didn't do this) first input -10 so first iteration would be 0 - (-10) = 10
            double result = numbers[0];

            // Remove first element since we just used it
            numbers = numbers.Skip(1).ToArray();

            foreach (double d in numbers)
            {
                result -= d;
            }

            return result;
        }

        /// <summary>
        /// Multiplies numbers with each other
        /// </summary>
        /// <param name="a">First number to multiply</param>
        /// <param name="b">Second number to multiply</param>
        /// <returns>Returns the result of the multiplication as double</returns>
        public double Multiplication(double a, double b)
        {
            return a * b;
        }

        public double Multiplication(double[] numbers)
        {
            if (numbers.Length == 0)
                return 0;
            
            // Assign first element so we don't get unexpected results
            // (e.g. if we didn't do this) first input 5 so first iteration would be 0 * 5 = 0
            double result = numbers[0];

            // Remove first element since we just used it
            numbers = numbers.Skip(1).ToArray();
            
            foreach (double num in numbers)
            {
                result *= num;
            }

            return result;
        }

        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="dividend">The dividend of the division</param>
        /// <param name="divisor">The divisor of the division</param>
        /// <returns>Returns the result of the division as double</returns>
        /// <exception cref="ArgumentException">Throws argument exception if trying to divide by zero</exception>
        public double Division(double dividend, double divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException("Undefined. Can not divide by zero.");
            
            return dividend / divisor;
        }
    }
}
