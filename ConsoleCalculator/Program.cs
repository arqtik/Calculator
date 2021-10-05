using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            bool isRunning = true;

            // Main app while loop, runs until user inputs number 0 in menu selection
            while (isRunning)
            {
                ShowMenu();

                // Get input and parse it to int, making a menu selection
                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    double[] inputNums = Array.Empty<double>();

                    // Get input from user until we get more than 0 values
                    do
                    {
                        string input = GetInputCommaSeparated();
                        try
                        {
                            inputNums = GetNumbersFromString(input);
                        }
                        catch (ArgumentException e)
                        {
                            // Something was wrong with the input from user
                            Console.WriteLine(e.Message);
                        }
                        
                        // If we don't have numbers, print to console
                        if (inputNums.Length == 0)
                        {
                            Console.WriteLine("Could not get any numbers from your input, try again.\n");
                        }
                    } while (inputNums.Length == 0);
                    
                    // Use the parse input as selection for which operation to do
                    switch (selection)
                    {
                        case 0:
                            isRunning = false;
                            break;
                        case 1:
                            if (inputNums.Length == 2)
                                PrintResult(calc.Addition(inputNums[0], inputNums[1]));
                            else
                                PrintResult(calc.Addition(inputNums));
                            break;
                        case 2:
                            if (inputNums.Length == 2)
                                PrintResult(calc.Subtraction(inputNums[0], inputNums[1]));
                            else
                                PrintResult(calc.Subtraction(inputNums));
                            break;
                        case 3:
                            if (inputNums.Length == 2)
                                PrintResult(calc.Multiplication(inputNums[0], inputNums[1]));
                            else
                                PrintResult(calc.Multiplication(inputNums));
                            break;
                        case 4:
                            if (inputNums.Length == 2)
                                try
                                {
                                    PrintResult(calc.Division(inputNums[0], inputNums[1]));
                                }
                                catch (DivideByZeroException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            else if (inputNums.Length > 2)
                                Console.WriteLine("Too many input numbers. Require 2 for this operation.");
                            else
                                Console.WriteLine("Too few input numbers. Require 2 for this operation.");
                            break;
                        default:
                            Console.WriteLine("Unknown choice selected");
                            break;
                    }
                } else
                {
                    // Parsed input was not an int
                    Console.WriteLine("Invalid selection input, try an integer!");
                }
            }
        }
        
        /// <summary>
        /// Prints lines of possible menu choices to the console
        /// </summary>
        private static void ShowMenu()
        {
            Console.WriteLine("Make a menu selection:");
            Console.WriteLine("[0] Quit");
            Console.WriteLine("[1] Addition");
            Console.WriteLine("[2] Subtraction");
            Console.WriteLine("[3] Multiplication");
            Console.WriteLine("[4] Division");
        }

        /// <summary>
        /// Print a double value as result to console
        /// </summary>
        /// <param name="result">The number we want to print as the result</param>
        private static void PrintResult(double result)
        {
            Console.WriteLine($"\nResult: {result}\n");
        }
        
        /// <summary>
        /// Ask user for comma separated numbers as input
        /// </summary>
        /// <returns>Returns trimmed input as string from user</returns>
        private static string GetInputCommaSeparated()
        {
            Console.WriteLine("Operations are calculated from left to right");
            Console.Write("Numbers for operation (Separated by ','): ");
            
            return Console.ReadLine()?.Trim();
        }
        
        /// <summary>
        /// Gets comma separated numbers from string as doubles
        /// </summary>
        /// <param name="input">The string that contains the comma separated numbers</param>
        /// <returns>Returns an array of doubles parsed from the string input parameter</returns>
        /// <exception cref="ArgumentException">Throws argument exception if an invalid input was detected</exception>
        public static double[] GetNumbersFromString(string input)
        {
            // Splits input into array with the separator ','
            string[] splitInput = input.Split(',');

            List<double> numbers = new List<double>();

            // Parse our array of inputs to doubles and add them to the list of numbers
            for (int i = 0; i < splitInput.Length; i++)
            {
                // Check for empty entries caused by user input and trailing ','s
                if (splitInput[i].Equals(string.Empty) || splitInput[i].Equals(" "))
                    continue;

                // Trim leading and trailing empty spaces for the input
                // Parse it and add to list to return
                if (double.TryParse(splitInput[i].Trim(), out double d))
                {
                    numbers.Add(d);
                }
                else
                {
                    // One of the inputs was invalid, throw argument exception.
                    // We want to throw exception because there is no point in trying to
                    // calculate numbers if user miss-typed something
                    throw new ArgumentException($"{splitInput[i]} was invalid number input");
                }
            }

            return numbers.ToArray();
        }
    }
}
