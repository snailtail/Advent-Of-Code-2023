using Shouldly;

namespace _11_test;

public class Day11tests
{
    public const string testFilePath = "../../../../../data/11test.dat";

    [Fact]
    public void TestRowCount()
    {
        CosmicMap cm = new(testFilePath);
        cm.RowCount.ShouldBe(12);
    }

    [Fact]
    public void TestMapWidth()
    {
        CosmicMap cm = new(testFilePath);
        cm.MapWidth.ShouldBe(13);
        Console.WriteLine(cm.GetPrintableMap());
    }

    [Fact]
    public void TestMapOutput()
    {
        string expectedExtendecMapData = "....#........\n.........#...\n#............\n.............\n.............\n........#....\n.#...........\n............#\n.............\n.............\n.........#...\n#....#.......\n";
        CosmicMap cm = new(testFilePath);
        cm.GetPrintableMap().ShouldBe(expectedExtendecMapData);
    }

    [Theory]
    [InlineData(0,0,4)]
    [InlineData(1,1,9)]
    [InlineData(2,2,0)]
    [InlineData(3,5,8)]
    [InlineData(4,6,1)]
    [InlineData(5,7,12)]
    [InlineData(6,10,9)]
    [InlineData(7,11,0)]
    [InlineData(8,11,5)]
    private void CheckScannedGalaxieCoordinates(int GalaxyIndex, int Y, int X)
    {
        CosmicMap cm = new(testFilePath);
        
        cm.Galaxies[GalaxyIndex].Y.ShouldBe(Y);
        cm.Galaxies[GalaxyIndex].X.ShouldBe(X);
    }

    [Theory]
    [InlineData(0,6,15)]
    [InlineData(2,6,17)]
    [InlineData(7,8,5)]
    private void CheckManhattanDistances(int FromGalaxyIndex, int ToGalaxyIndex, long ExpectedDistance)
    {
        CosmicMap cm = new(testFilePath);
        var result = cm.CalculateManhattanDistance(cm.Galaxies[FromGalaxyIndex].Coordinate,cm.Galaxies[ToGalaxyIndex].Coordinate);
        result.ShouldBe(ExpectedDistance);
    }

    [Fact]
    private void TestSumBetweenGalaxyPairs()
    {
        CosmicMap cm = new(testFilePath);
        cm.SumOfShortestPathsBetweenPairs().ShouldBe(374);
    }
}