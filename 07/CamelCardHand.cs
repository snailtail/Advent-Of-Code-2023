// See https://aka.ms/new-console-template for more information
// klassa alla typer av "händer" från starkast 7 till svagast 1 - med multiplikator. 1000000, 100000, 10000, 1000, 100, 10, 1
// Klassa alla kort med ett värde. de är tretton stycken så 14 till 2 i värde.
// Positionen i handen ger en multiplikator. Första kortet har 5, andra 4 osv. Så att ett ess är mer värt på plats 1 än 4 t ex.
// För att särskilja bästa hand, fyrtal i ettor från triss i ess så använd en multiplikatorn för handtyp
// Summera värdet för korten och multiplicera med typen för att få vikt dvs ett fyrtal i nåt bör vara drygt tio ggr mer än ett tretal av ett bättre kort
// sortera efter vikten

// kortets weight består istället av ett typevalue , vilken typ av kort var det avgjort från klassificeringen (ex highcard = kortets värde * 10 ^ 1, onepair = kortets värde * 10 ^3) + serialnumber = summan av cardvalues?

using System.Text.RegularExpressions;

public class CamelCardHand
{
    public enum HandType
    {
        FiveOfAKind = 13,
        FourOfAKind = 11,
        FullHouse = 9,
        ThreeOfAKind = 7,
        TwoPair = 5,
        OnePair = 3,
        HighCard = 1,
    }

    private int _bidAmount;
    public long Weight {
        get{
            long weight = (long)(_cardWeights.Sum() * Math.Pow(10,(double)_handType));
            return weight;
        }
    }
    private string _sortedCards;

    private long[] _cardWeights = new long[5];
    private long _handTypeWeight = 0;
    private HandType _handType;
    public HandType handType { get => _handType;  }
    public string Cards;
    public long[] CardWeights { get => _cardWeights; }
    public string SortedCards { get => _sortedCards; }
    public int BidAmount { get => _bidAmount; set => _bidAmount = value; }

    public CamelCardHand(string cards, int bidAmount = 0)
    {
        Cards = cards;
        // calculate cardweight based on position in the hand
        for (int c = 0; c < cards.Length; c++)
        {
            long cardweight = CamelCards.CardValues[cards[c]] * (long)Math.Pow(10,(5 - c - 1));
            CardWeights[c] = cardweight;
        }
        var tempCards = cards.Select(c => c).ToArray();
        Array.Sort(tempCards);
        _sortedCards = new string(tempCards);
        _handType=CalculateHandType();
        _bidAmount = bidAmount;
    }

    // Calculate the handtype for this hand.

    /*
    Kopiera värdena till en annan array först, som sorteras. Annars kommer regex inte funka...
    Börja kolla högsta först - sluta med pair, eftersom den kommer ge träff även på full house, two pair, fours, fives.
    OnePair .*(\w)\1.*
    TwoPair = .*(\w)\\1.*(\w)\2.*
    Three = .*(\w)\1\1.*
    Four = .*(\w)\1{3}.*
    FullHouse = ((\w)\2\2(\w)\3|(\w)\4(\w)\5\5)
    fiveofakind = .*#(\w)\1{4}
    */
    private HandType CalculateHandType()
    {
        Match match;

        string pattern = @"(\w)\1{4}"; // Five of a kind
        match = Regex.Match(_sortedCards, pattern);
        if (match.Success)
        {
            return HandType.FiveOfAKind;
        }

        pattern = @"(\w)\1{3}.*"; // Four of a kind
        match = Regex.Match(_sortedCards, pattern);
        if (match.Success)
        {
            return HandType.FourOfAKind;
        }

        pattern = @"((\w)\2\2(\w)\3|(\w)\4(\w)\5\5)"; // Full house
        match = Regex.Match(_sortedCards, pattern);
        if (match.Success)
        {
            return HandType.FullHouse;
        }

        pattern = @"(\w)\1\1.*"; // Three of a kind
        match = Regex.Match(_sortedCards, pattern);
        if (match.Success)
        {
            return HandType.ThreeOfAKind;
        }

        pattern = @"(\w)\1.*(\w)\2.*"; // Two pair
        match = Regex.Match(_sortedCards, pattern);
        if (match.Success)
        {
            return HandType.TwoPair;
        }

        pattern = @"(\w)\1.*"; // One pair
        match = Regex.Match(_sortedCards, pattern);
        if (match.Success)
        {
            return HandType.OnePair;
        }

        // no mathces == high card
        return HandType.HighCard;

    }

}