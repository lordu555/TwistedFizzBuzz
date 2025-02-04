using TwistedFizzBuzz;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwistedFizzBuzz.Tests
{
    public class TwistedFizzBuzzCalculatorTests
    {
        [Fact]
        public void ClassicFizzBuzzRangeMultipleOf3ReturnsFizz()
        {
            var calculator = new TwistedFizzBuzzCalculator();
            var singleValue = calculator.GetClassicFizzBuzzRange(6, 6).First();
            Assert.Equal("Fizz", singleValue);
        }
        [Fact]
        public void ClassicFizzBuzzRangeMultipleOf5ReturnsBuzz()
        {
            var calculator = new TwistedFizzBuzzCalculator();
            var singleValue = calculator.GetClassicFizzBuzzRange(10, 10).First();
            Assert.Equal("Buzz", singleValue);
        }
        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(7, "7")]
        public void ClassicFizzBuzzRangeSeveralChecks(int input, string expected)
        {
            var calculator = new TwistedFizzBuzzCalculator();
            var result = calculator.GetClassicFizzBuzzRange(input, input).First();
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ClassicFizzBuzzListNonSequential()
        {
            var calculator = new TwistedFizzBuzzCalculator();
            var numbers = new List<int> { -5, 0, 6, 15 };

            var results = calculator.GetClassicFizzBuzzList(numbers).ToList();

            Assert.Equal("Buzz", results[0]);
            Assert.Equal("FizzBuzz", results[1]);
            Assert.Equal("Fizz", results[2]);
            Assert.Equal("FizzBuzz", results[3]);
        }
        [Fact]
        public void CustomFizzBuzzRange_Concatenation()
        {
            var calculator = new TwistedFizzBuzzCalculator();
            var divisors = new List<(int, string)>
            {
                (2, "Foo"),
                (3, "Bar")
            };

            var result = calculator.GetCustomFizzBuzzRange(6, 6, divisors).First();
            Assert.Equal("FooBar", result);
        }
        [Fact]
        public async Task TokensFromApiFetcherFetchOneTokenAsyncWorks()
        {
            var fetcher = new TokensFromApiFetcher();

            var (divisor, token) = await fetcher.FetchOneTokenAsync();
            Assert.True(divisor != 0, "Expected a non-zero divisor from the API");
            Assert.False(string.IsNullOrWhiteSpace(token), "Expected a non-empty token from the API");
        }
    }
}
