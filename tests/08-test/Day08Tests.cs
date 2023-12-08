/*
namespace _08_test;
using Shouldly;
public class Day08Tests
{
    const string part1Input1 = "../../../../../data/08test1.dat";
    const string part1Input2 = "../../../../../data/08test2.dat";

    const string part2Input = "../../../../../data/08test3.dat";



    [Theory]
    [InlineData(part1Input1, "RL", "AAA", "BBB", "CCC", 7)]
    [InlineData(part1Input2, "LLR", "AAA", "BBB", "BBB", 3)]
    [InlineData(part2Input, "LR", "11A", "11B", "XXX", 8)]
    public void TestInputParsing(string inputFile, string expectedDirections, string expectedNodeZeroID, string expectedLeftID, string expectedRightID, int expectedNodeCount)
    {
        var input = File.ReadAllText(inputFile);
        DesertMapper dm = new(input);
        dm.Directions.ShouldBe(expectedDirections);
        dm.Nodes[0].ID.ShouldBe(expectedNodeZeroID);
        dm.Nodes[0].Left.ID.ShouldBe(expectedLeftID);
        dm.Nodes[0].Right.ID.ShouldBe(expectedRightID);
        dm.Nodes.Count.ShouldBe(expectedNodeCount);
    }

    [Theory]
    [InlineData(part1Input1,2)]
    [InlineData(part1Input2,6)]
    private void TestDirections(string inputFile, int expectedcount)
    {
        var input = File.ReadAllText(inputFile);
        DesertMapper dm = new(input);
        dm.FollowDirections(dm.Directions, "ZZZ").ShouldBe(expectedcount);
    
    }

    [Theory]
    [InlineData("11A", 2)]
    [InlineData("22A", 3)]
    private void CheckStepCountsPerPath(string startnode, int expectedcount)
    {
        DesertMapper DM = new(part2Input);
        DM.FollowGhostDirections(DM.Directions, startnode).ShouldBe(expectedcount);

    }

    [Fact]
    private void CheckTotalGhostSteps()
    {
        var input = File.ReadAllText(part2Input);
        DesertMapper DM = new(input);
        var startnodes = DM.Nodes.Where(n => n.ID.EndsWith('A')).ToList();
        var ghostResults = startnodes.Select(s => DM.FollowGhostDirections(DM.Directions, s.ID)).ToList();
        DM.LeastCommonMultiple(ghostResults).ShouldBe(6);
    }
}
*/