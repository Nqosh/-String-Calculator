using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_String_Calculator
{
    class StringCalculator
    {
        private const int DEFAULT_NUMBER = 0;
        private const string CUSTOM_SEPERATOR_INDICATOR = "//";
        private static List<string> SEPERATORS = new List<string>() { ",", "\n" ,"n","\\", ";"};
        private const int MAX_NUMBER = 1000;

        public static int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers))
                return DEFAULT_NUMBER;
            if (numbers.StartsWith(CUSTOM_SEPERATOR_INDICATOR))
            {
                numbers = RemoveSpecialCharactersFromNumber(numbers);
            }
            var cleanedNumbers = CleanNumbers(numbers);

            return cleanedNumbers.Sum();
        }

        private static string RemoveSpecialCharactersFromNumber(string numbers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in numbers)
            {
                if ((c >= '0' && c <= '9'))
                {
                    sb.Append(c + ",");
                }
            }
            return sb.ToString();
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9'))
                {
                    sb.Append(c + ",");
                }
            }
            return sb.ToString();
        }

        private static IList<int> CleanNumbers(string numbers)
        {
            var nums = numbers.Split(SEPERATORS.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var cleaned = new List<int>();
            foreach (var num in nums)
            {
                var cleanedNumber = int.Parse(num);
                if (cleanedNumber < 0)
                {
                    throw new ApplicationException("Number cannot be negative");
                }
                if (cleanedNumber <= MAX_NUMBER)
                {
                    cleaned.Add(cleanedNumber);
                }
            }
            return cleaned;
        }
        static void Main(string[] args)
        {
            string numbers = string.Empty;
 
            Console.WriteLine("Input the number: ");

            var input = Console.ReadLine();

            var result = Add(input);

            Console.WriteLine("Sum is {0}", result);
        }


    }
}
