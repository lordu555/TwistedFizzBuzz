using TwistedFizzBuzz;


var calculator = new TwistedFizzBuzzCalculator();
var results = calculator.GetClassicFizzBuzzRange(1, 100);

foreach (var line in results)
{
    Console.WriteLine(line);
}