var rawinput = File.ReadAllText("../../../../data/05.dat");
SeedToLocationMapper stlm = new(rawinput);
long step1 = long.MaxValue;
foreach (var s in stlm.Seeds)
{
    step1 = Math.Min(step1, stlm.MapSeedToLocation(s));
}
Console.WriteLine($"Step 1: {step1}");


//step 2
List<IEnumerable<long>> Step2Ranges = new();
for(int i = 0; i < stlm.Seeds.Length; i+=2)
{
    Step2Ranges.Add(CreateRange(stlm.Seeds[i],stlm.Seeds[i+1]));
}


bool step2Solved=false;
long lowestLocation=0;
while(!step2Solved)
{
    var testseed = stlm.MapLocationToSeed(lowestLocation);
    System.Console.WriteLine($"At lowestLocation {lowestLocation}");
    if(Step2Ranges.Any(sr=> sr.Contains(testseed)))
    {
        step2Solved=true;
        Console.WriteLine($"Step 2: {lowestLocation}");
        break;
    }
    lowestLocation++;
}



IEnumerable<long> CreateRange(long start, long count)
{
    var limit = start + count;

    while (start < limit)
    {
        yield return start;
        start++;
    }
}
record Step2Range(long Start, long Count);