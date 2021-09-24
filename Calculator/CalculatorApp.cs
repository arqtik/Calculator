using System;
using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorApp
    {
        /// <summary>
        /// Essentially the Main method of this calculator app
        /// Call this to start a loop with the menu
        /// </summary>
        public void Start()
        {
            bool isRunning = true;

            // Main app while loop, runs until user inputs number 0
            while (isRunning)
            {
                ShowMenu();

                // Get input and parse it to int, making a menu selection
                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    // Use the parse input as selection for which operation to do
                    switch (selection)
                    {
                        case 0:
                            isRunning = false;
                            break;
                        case 1:
                            Console.WriteLine(Addition());
                            break;
                        case 2:
                            Console.WriteLine(Subtraction());
                            break;
                        case 3:
                            Console.WriteLine(Multiplication());
                            break;
                        case 4:
                            Console.WriteLine(Division());
                            break;
                        case 5:
                            Console.WriteLine(SquareRoot());
                            break;
                        case 6:
                            Console.WriteLine(Exponential());
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
        private void ShowMenu()
        {
            Console.WriteLine("Make a menu selection:");
            Console.WriteLine("[0] Quit");
            Console.WriteLine("[1] Addition");
            Console.WriteLine("[2] Subtraction");
            Console.WriteLine("[3] Multiplication");
            Console.WriteLine("[4] Division");
            Console.WriteLine("[5] Square root");
            Console.WriteLine("[6] x^y");
        }

        /// <summary>
        /// Gets input from user and converts them to a list of doubles, separated by ','.
        /// Decimal inputs are allowed.
        /// </summary>
        /// <returns>Returns list of doubles parsed from input</returns>
        private List<double> GetNumbersFromInput()
        {
            Console.WriteLine("Operations are calculated from left to right");
            Console.Write("Numbers for operation (Separated by ','): ");

            // Gets input and trims trailing spaces
            string input = Console.ReadLine().Trim();

            // Splits input into array with the separator ','
            string[] splitInput = input.Split(',');

            List<double> numbers = new List<double>();

            // Parse our array of inputs to doubles and add them to the list of numbers
            for (int i = 0; i < splitInput.Length; i++)
            {
                // Trailing ','s create entries
                // If this is one of them then ignore it and continue loop
                if (splitInput[i] == string.Empty)
                    continue;

                // Trim leading and trailing empty spaces for the input
                // Parse it and add to list to return
                if (double.TryParse(splitInput[i].Trim(), out double d))
                {
                    numbers.Add(d);
                }
                else
                {
                    // One of the inputs was invalid, return empty list.
                    Console.WriteLine($"{splitInput[i]} was invalid number input");
                    return new List<double>();
                }
            }

            return numbers;
        }

        /// <summary>
        /// Sums up numbers
        /// </summary>
        /// <returns>Returns formatted string with the result of the addition</returns>
        private string Addition()
        {
            double result = 0;
            foreach (double d in GetNumbersFromInput())
            {
                result += d;
            }

            return $"Result: {result}";
        }

        /// <summary>
        /// Subtracts numbers with each other
        /// </summary>
        /// <returns>Returns formatted string with the result of the subtraction</returns>
        private string Subtraction()
        {
            // Get the numbers from user
            List<double> numbers = GetNumbersFromInput();

            // Check so we have numbers to subtract
            if (numbers.Count > 0)
            {
                // Assign first element so we don't get unexpected results
                // e.g. first input -10 so first iteration would be 0 - (-10) = 10
                double result = numbers[0];

                // Remove first element since we just used it
                numbers.RemoveAt(0);

                foreach (double d in numbers)
                {
                    result -= d;
                }

                return $"Result: {result}";
            }

            return "No valid inputs for operation";
        }

        /// <summary>
        /// Multiplies numbers with each other
        /// </summary>
        /// <returns>Returns formatted string with result of the multiplication</returns>
        private string Multiplication()
        {
            double result = 0;
            foreach (double d in GetNumbersFromInput())
            {
                result *= d;
            }

            return $"Result: {result}";
        }

        /// <summary>
        /// Divides numbers with each other (e.g. 1,2,2 == 0.25)
        /// </summary>
        /// <returns>Returns formatted string with result of the divison</returns>
        private string Division()
        {
            double result = 0;
            foreach (double d in GetNumbersFromInput())
            {
                result /= d;
            }

            return $"Result: {result}";
        }

        /// <summary>
        /// Square root input numbers
        /// </summary>
        /// <returns>Returns a string formatted with square rooted numbers</returns>
        private string SquareRoot()
        {
            List<double> result = new List<double>();

            // Add all inputs square rooted to our result list
            foreach (double d in GetNumbersFromInput())
            {
                result.Add(Math.Sqrt(d));
            }

            string strResult = "Result:";

            // Format strResult with all of our results
            foreach (double item in result)
            {
                strResult += $" {item},";
            }

            // Clean up return string by checking for a trailing comma and removing it
            if (strResult[strResult.Length - 1] == ',')
            {
                strResult = strResult.Remove(strResult.Length - 1);
            }

            return strResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string Exponential()
        {
            Console.WriteLine("First input is the base, the rest are exponents");

            // Get the base number from user
            List<double> numbers = GetNumbersFromInput();

            // Check so we have more than one input so we can do the operation
            if (numbers.Count > 1)
            {
                // Assign first element so we don't get unexpected results
                // e.g. input is 3,2 would make it
                // 0 ^ 3 ^ 2 = 0
                double result = numbers[0];

                // Remove first element we already assigned
                numbers.RemoveAt(0);

                foreach (double d in numbers)
                {
                    result = Math.Pow(result, d);
                }

                return $"Result: {result}";
            }

            return "None or not enough inputs for operation, need more than 1";
        }
    }
}
