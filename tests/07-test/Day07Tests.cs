namespace _07_test;

using System.Configuration.Assemblies;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;
public class UnitTest1
{
    private string testFilePath = "../../../../../data/07test.dat";
    [Theory]
    [InlineData('2', 2)]
    [InlineData('3', 3)]
    [InlineData('4', 4)]
    [InlineData('5', 5)]
    [InlineData('6', 6)]
    [InlineData('7', 7)]
    [InlineData('8', 8)]
    [InlineData('9', 9)]
    [InlineData('T', 10)]
    [InlineData('J', 11)]
    [InlineData('Q', 12)]
    [InlineData('K', 13)]
    [InlineData('A', 14)]
    public void CheckCardValues(char card, int expectedvalue)
    {
        CamelCards.CardValues[card].ShouldBe(expectedvalue);
    }

    [Theory]
    [InlineData("22222", new long[] { 20000, 2000, 200, 20, 2 })]
    [InlineData("2222A", new long[] { 20000, 2000, 200, 20, 14 })]
    [InlineData("AQ4J3", new long[] { 140000, 12000, 400, 110, 3 })]
    [InlineData("23456", new long[] { 20000, 3000, 400, 50, 6 })]

    private void CheckCardWeights(string cards, long[] expectedCardWeight)
    {
        CamelCardHand cch = new(cards);
        for (int c = 0; c < cards.Length; c++)
        {
            cch.CardWeights[c].ShouldBe(expectedCardWeight[c]);
        }
    }

    [Theory]
    [InlineData("AKQJT", "AJKQT")]
    [InlineData("A2QJT", "2AJQT")]
    private void TestSortedCards(string hand, string expectedSortedHand)
    {
        CamelCardHand cch = new(hand);
        cch.SortedCards.ShouldBe(expectedSortedHand);
    }

    [Theory]
    [InlineData("A56AA", CamelCardHand.HandType.ThreeOfAKind)]
    [InlineData("32T3K", CamelCardHand.HandType.OnePair)]
    [InlineData("KK677", CamelCardHand.HandType.TwoPair)]
    [InlineData("T55J5", CamelCardHand.HandType.ThreeOfAKind)]
    [InlineData("66666", CamelCardHand.HandType.FiveOfAKind)]
    [InlineData("23456", CamelCardHand.HandType.HighCard)]
    [InlineData("J4JJJ", CamelCardHand.HandType.FourOfAKind)]
    private void TestHandType(string hand, CamelCardHand.HandType expectedHandType)
    {
        CamelCardHand cch = new(hand);
        cch.handType.ShouldBe(expectedHandType);
    }

    [Theory]
    [InlineData("23456", 234560)] //20000 + 3000 + 400 + 50 + 6
    [InlineData("32T3K", 33043000)]  //sum of cardweight = 72
    [InlineData("T55J5", 1056150000000)]  //112
    [InlineData("KK677", 14367700000)]  //156
    [InlineData("KTJJT", 14122000000)]  //170
    [InlineData("QQQJA", 1333240000000)]  //180
    private void TestHandWeight(string hand, long expectedHandWeight)
    {
        CamelCardHand cch = new(hand);
        cch.Weight.ShouldBe(expectedHandWeight);
    }



    [Theory]
    [InlineData("32T3K", 0)]
    [InlineData("T55J5", 3)]
    [InlineData("KK677", 2)]
    [InlineData("KTJJT", 1)]
    [InlineData("QQQJA", 4)]
    private void TestHandRankFromTestInput(string expectedHand, int Index)
    {
        var fileData = File.ReadAllLines(testFilePath);
        List<CamelCardHand> handsList = new();
        foreach (string line in fileData)
        {
            var parts = line.Split(" ");
            CamelCardHand cch = new(parts[0], int.Parse(parts[1]));
            handsList.Add(cch);
        }
        CamelCardHand[] SortedHands = handsList.OrderBy(h => h.Weight).ToArray();
        SortedHands[Index].Cards.ShouldBe(expectedHand);
    }

    [Fact]
    private void CheckTotalWinnings()
    {
        var result = CamelCards.GetCardStackTotalWinnings(testFilePath);
        result.ShouldBe(6440);
    }

    [Theory]
    [InlineData("268KQ","2349J",true)]
    private void TestWeightsBetweenSimilarHands(string hand1, string hand2, bool FirstHandIsGreater)
    {
        CamelCardHand cch1 = new(hand1,0);
        CamelCardHand cch2 = new(hand2,0);
        bool result = cch1.Weight > cch2.Weight;
        result.ShouldBe(FirstHandIsGreater);

    }
}
