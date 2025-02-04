using TwistedFizzBuzz;
using System;
using System.Collections.Generic;

var calculator = new TwistedFizzBuzzCalculator();

var localDivisors = new List<(int, string)>
{
    (5, "Fizz"),
    (9, "Buzz"),
    (27, "Bar")
};

var extendedResults = calculator.GetCustomFizzBuzzRange(-20, 127, localDivisors);

Console.WriteLine("=== Extended FizzBuzz from -20 to 127 ===");
foreach (var line in extendedResults)
{
    Console.WriteLine(line);
}

var fetcher = new TokensFromApiFetcher();

Console.WriteLine();
Console.WriteLine("=== fetching tokens from the API ===");
var tokensFromApi = await fetcher.FetchMultipleTokensAsync(3);

Console.WriteLine("Tokens obtained from the API:");
foreach (var (divisor, token) in tokensFromApi)
{
    Console.WriteLine($"  Divisor={divisor}, Token={token}");
}

Console.WriteLine();
Console.WriteLine("=== Custom FizzBuzz using API tokens (1..30) ===");
var apiResults = calculator.GetCustomFizzBuzzRange(1, 30, tokensFromApi);
foreach (var line in apiResults)
{
    Console.WriteLine(line);
}
