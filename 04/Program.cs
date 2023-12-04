var input = File.ReadAllLines("../data/04.dat");
int step1Sum = 0;
foreach(var line in input)
{
    ScratchCard sc = new(line);
    step1Sum+=sc.Points;
}
Console.WriteLine($"Step 1: {step1Sum}");