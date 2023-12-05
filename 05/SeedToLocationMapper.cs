using System.Text.RegularExpressions;

public class SeedToLocationMapper
{

    private long[] seeds;
    public long[] Seeds { get => seeds; set => seeds = value; }
    private ElfMapper SeedToSoilMap;
    private ElfMapper SoilToFertilizerMap;
    private ElfMapper FertilizerToWaterMap;
    private ElfMapper WaterToLightMap;
    private ElfMapper LightToTemperatureMap;
    private ElfMapper TemperatureToHumidityMap;
    private ElfMapper HumidityToLocationMap;


    public long MapSeedToLocation(long seed)
    {
        return HumidityToLocationMap.GetDestination(
            TemperatureToHumidityMap.GetDestination(
                LightToTemperatureMap.GetDestination(
                    WaterToLightMap.GetDestination(
                        FertilizerToWaterMap.GetDestination(
                            SoilToFertilizerMap.GetDestination(
                                SeedToSoilMap.GetDestination(seed)
                            )
                        )
                    )
                )
            )
        );
    }

    public long MapLocationToSeed(long location)
    {
        return SeedToSoilMap.GetSourceFromDestination(
            SoilToFertilizerMap.GetSourceFromDestination(
                FertilizerToWaterMap.GetSourceFromDestination(
                    WaterToLightMap.GetSourceFromDestination(
                        LightToTemperatureMap.GetSourceFromDestination(
                            TemperatureToHumidityMap.GetSourceFromDestination(
                                HumidityToLocationMap.GetSourceFromDestination(location)
                            )
                        )
                    )
                )
            )
        );
    }
    public SeedToLocationMapper(string rawinput)
    {
        string[] inputData = rawinput.Split("\r\n\r\n");
        ParseInput(inputData);
    }
    private void ParseInput(string[] input)
    {
        foreach (var s in input)
        {   
            string[] mapperinput;
            switch (s.Substring(0,6))
            {
                case "seeds:":
                    string seednums = s.Split(": ")[1];
                    string seedpattern = @"(\d+)";
                    MatchCollection matches = Regex.Matches(seednums,seedpattern);
                    List<string> seeds = new();
                    foreach(Match m in matches)
                    {
                        seeds.Add(m.Groups[1].Value);
                    }
                    Seeds = seeds.Select(s=> long.Parse(s)).ToArray();
                    break;
                case "seed-t":
                    mapperinput = s.Replace("seed-to-soil map:\r\n","").Split("\r\n");
                    SeedToSoilMap = new ElfMapper(mapperinput);
                    break;
                case "soil-t":
                    mapperinput = s.Replace("soil-to-fertilizer map:\r\n","").Split("\r\n");
                    SoilToFertilizerMap = new ElfMapper(mapperinput);
                    break;
                case "fertil":
                    mapperinput = s.Replace("fertilizer-to-water map:\r\n","").Split("\r\n");
                    FertilizerToWaterMap = new ElfMapper(mapperinput);
                    break;
                case "water-":
                    mapperinput = s.Replace("water-to-light map:\r\n","").Split("\r\n");
                    WaterToLightMap = new ElfMapper(mapperinput);
                    break;
                case "light-":
                    mapperinput = s.Replace("light-to-temperature map:\r\n","").Split("\r\n");
                    LightToTemperatureMap = new ElfMapper(mapperinput);
                    break;
                case "temper":
                    mapperinput = s.Replace("temperature-to-humidity map:\r\n","").Split("\r\n");
                    TemperatureToHumidityMap = new ElfMapper(mapperinput);
                    break;
                case "humidi":
                    mapperinput = s.Replace("humidity-to-location map:\r\n","").Split("\r\n");
                    HumidityToLocationMap = new ElfMapper(mapperinput);
                    break;
                default:
                    break;
            }
        }
    }

}
