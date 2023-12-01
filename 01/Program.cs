using System.Text.RegularExpressions;

var lines = File.ReadAllLines(@"../data/01.dat");

int process(bool stepTwo = false)
{
    int sum = 0;
    string pattern = stepTwo ? "[1-9]|one|two|three|four|five|six|seven|eight|nine" : "[1-9]";
    foreach (var line in lines)
    {
        var matchesFirst = Regex.Matches(line,pattern);
        var matchesLast = Regex.Matches(line,pattern,RegexOptions.RightToLeft);
        var firstNumber = matchesFirst.First().Value;
        var lastNumber = matchesLast.First().Value;
        if(firstNumber.Length > 1)
        {
                firstNumber = firstNumber switch
                {
                    "one" => "1",
                    "two" => "2",
                    "three" => "3",
                    "four" => "4",
                    "five" => "5",
                    "six" => "6",
                    "seven" => "7",
                    "eight" => "8",
                    "nine" => "9",
                    _ => "?"
                };
        }
        if(lastNumber.Length > 1)
        {
                lastNumber = lastNumber switch
                {
                    "one" => "1",
                    "two" => "2",
                    "three" => "3",
                    "four" => "4",
                    "five" => "5",
                    "six" => "6",
                    "seven" => "7",
                    "eight" => "8",
                    "nine" => "9",
                    _ => "?"
                };
        }
        sum += int.Parse($"{firstNumber}{lastNumber}");
    }
    return sum;
}

Console.WriteLine($"Step 1: {process(false)}");
Console.WriteLine($"Step 2: {process(true)}");


