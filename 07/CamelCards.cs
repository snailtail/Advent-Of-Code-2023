public static class CamelCards
{

//210 är maxvärdet för korten i sig. (5 st A)
    public static Dictionary<char,int> CardValues = new(){
        {'2',2},
        {'3',3},
        {'4',4},
        {'5',5},
        {'6',6},
        {'7',7},
        {'8',8},
        {'9',9},
        {'T',10},
        {'J',11},
        {'Q',12},
        {'K',13},
        {'A',14},
        };
    
    public static int GetCardStackTotalWinnings(string inputFilePath)
    {
        int expectedWinnings = 6440;
        var fileData = File.ReadAllLines(inputFilePath);
        List<CamelCardHand> handsList = new();
        foreach (string line in fileData)
        {
            var parts = line.Split(" ");
            CamelCardHand cch = new(parts[0], int.Parse(parts[1]));
            handsList.Add(cch);
        }
        CamelCardHand[] SortedHands = handsList.OrderBy(h => h.Weight).ToArray();
        int totalWinnings = 0;
        for(int i = 0; i < SortedHands.Length; i++)
        {
            int rank = i+1;
            int bid = SortedHands[i].BidAmount;
            totalWinnings += rank*bid;
        }
        return totalWinnings;
    }
}
