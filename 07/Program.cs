
var fileData = File.ReadAllLines("../data/07.dat");
List<CamelCardHand> handsList = new();
foreach (string line in fileData)
{
    var parts = line.Split(" ");
    CamelCardHand cch = new(parts[0], int.Parse(parts[1]));
    handsList.Add(cch);
}
CamelCardHand[] SortedHands = handsList.OrderBy(h => h.Weight).ToArray();
int totsum=0;
for (int i = 0; i < SortedHands.Length; i++)
{
    string hand = SortedHands[i].Cards;
    string sortedhand = SortedHands[i].SortedCards;
    string handtype = SortedHands[i].handType.ToString();
    long weight = SortedHands[i].Weight;
    int index = i+1;
    int bid = SortedHands[i].BidAmount;
    int sum = index * bid;
    totsum+=sum;
    Console.WriteLine($"{index}\t{hand}\t{sortedhand}\t{handtype}\t{weight}\t{bid}\t{sum}");
}
Console.WriteLine($"TOTSUM: {totsum}");
/*
int step1 = CamelCards.GetCardStackTotalWinnings("../data/07.dat");

Console.WriteLine($"Step 1: {step1}");

250637920 is too high
*/