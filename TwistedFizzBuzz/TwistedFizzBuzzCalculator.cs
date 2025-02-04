using System;
using System.Collections.Generic;

namespace TwistedFizzBuzz
{
    public class TwistedFizzBuzzCalculator
    {
        public IEnumerable<string> GetClassicFizzBuzzRange(int start, int end)
        {
            var results = new List<string>();
            int lower = Math.Min(start, end);
            int upper = Math.Max(start, end);

            for (int i = lower; i <= upper; i++)
            {
                results.Add(GetClassicFizzBuzzValue(i));
            }
            return results;
        }
        public IEnumerable<string> GetClassicFizzBuzzList(IEnumerable<int> numbers)
        {
            foreach (var num in numbers)
            {
                yield return GetClassicFizzBuzzValue(num);
            }
        }
        private string GetClassicFizzBuzzValue(int number)
        {
            if (number % 15 == 0) return "FizzBuzz";
            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";
            return number.ToString();
        }
        public IEnumerable<string> GetCustomFizzBuzzRange(int start, int end, List<(int Divisor, string Token)> divisorsWithTokens)
        {
            var results = new List<string>();
            int lower = Math.Min(start, end);
            int upper = Math.Max(start, end);

            for (int i = lower; i <= upper; i++)
            {
                results.Add(GetCustomFizzBuzzValue(i, divisorsWithTokens));
            }

            return results;
        }
        public IEnumerable<string> GetCustomFizzBuzzList(IEnumerable<int> numbers,List<(int Divisor, string Token)> divisorsWithTokens)
        {
            foreach (var num in numbers)
            {
                yield return GetCustomFizzBuzzValue(num, divisorsWithTokens);
            }
        }
        private string GetCustomFizzBuzzValue(int num, List<(int Divisor, string Token)> divisorsWithTokens)
        {
            string output = string.Empty;

            foreach (var (divisor, token) in divisorsWithTokens)
            {
                if (num % divisor == 0)
                {
                    output += token;
                }
            }
            return string.IsNullOrEmpty(output) ? num.ToString() : output;
        }
    }
}
