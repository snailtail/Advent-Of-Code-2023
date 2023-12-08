namespace _08_test;
using Shouldly;
public class Day08Tests
{
    [Fact]
    public void TestInputParsing()
    {
        string input = @"RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)";
        DesertMapper dm = new(input);
        dm.Directions.ShouldBe("RL");
    }
}