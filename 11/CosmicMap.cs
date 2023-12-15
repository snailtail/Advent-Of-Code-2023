using System.Runtime.CompilerServices;

public class CosmicMap
{
    private int mapWidth;
    private string map;
    private int rowCount;
    private List<Galaxy> galaxies = new();

    public List<Galaxy> Galaxies => galaxies;

    public int MapWidth => mapWidth;
    public int RowCount => rowCount;
    private int columnsAdded;
    private int rowsAdded;
    private Queue<int> columnsToDuplicate = new();
    private Queue<int> rowsToDuplicate = new();
    private HashSet<GalaxyCoordinate> UsedInpair = new();

    public CosmicMap(string filePath = "../data/11test.dat")
    {
        string[] mapData = File.ReadAllText(filePath).Split(Environment.NewLine);
        mapWidth = mapData[0].Length;
        map = string.Join("", mapData);
        rowCount = map.Length / mapWidth;
        ExtendMap();
        ScanForGalaxies();
    }


    public long SumOfShortestPathsBetweenPairs()
    {
        long sum = 0;
        for(int x = 0; x < galaxies.Count; x++)
        {
            UsedInpair.Add(galaxies[x].Coordinate);
            var neighborGalaxies = galaxies.Where(g=> !UsedInpair.Contains(g.Coordinate)).ToArray();
            foreach(var g in neighborGalaxies)
            {
                long distance = CalculateManhattanDistance(galaxies[x].Coordinate,g.Coordinate);
                sum += distance;
            }
        }
        return sum;
    }


    public void ScanForGalaxies()
    {
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                if (map[row * mapWidth + col] == '#')
                {
                    galaxies.Add(new Galaxy(row, col));
                }
            }
        }
    }
    public void ExtendMap()
    {


        for (int i = 0; i < mapWidth; i++)
        {
            if (ColumnIsEmpty(i))
            {
                columnsToDuplicate.Enqueue(i);
            }

        }
        for (int i = 0; i * mapWidth < map.Length; i++)
        {
            if (RowIsEmpty(i))
            {
                rowsToDuplicate.Enqueue(i);
            }
        }

        // extend columns
        // every time we add a new column we increase the columnsAdded counter
        // which is used to get the correct index for the following columns after adding a new one before them
        while (columnsToDuplicate.Count > 0)
        {
            int columnIndex = columnsToDuplicate.Dequeue();
            columnIndex += columnsAdded;
            for (int row = 0; row < rowCount; row++)
            {
                map = map.Insert((row * mapWidth) + columnIndex + row + 1, ".");
            }


            columnsAdded++;
            mapWidth++;


        }
        rowCount = map.Length / mapWidth;


        // extend rows
        // every time we add a new row we increase the rowsAdded counter
        // which is used to get the correct index for the following columns after adding a new one before them
        while (rowsToDuplicate.Count > 0)
        {
            int rowIndex = rowsToDuplicate.Dequeue();
            rowIndex += rowsAdded;
            for (int col = 0; col < mapWidth; col++)
            {
                map = map.Insert((rowIndex * mapWidth), ".");
            }


            rowsAdded++;
            rowCount = map.Length / mapWidth;

        }

    }


    public string GetPrintableMap()
    {
        int row = 0;
        string output = "";
        while (row * mapWidth < map.Length)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                output += map[row * mapWidth + col];
            }
            output += Environment.NewLine;
            row++;
        }
        return output;
    }


    public long CalculateManhattanDistance(GalaxyCoordinate point1, GalaxyCoordinate point2)
{
    long deltaY = Math.Abs(point1.Y - point2.Y);
    long deltaX = Math.Abs(point1.X - point2.X);

    return deltaY + deltaX;
}
    bool ColumnIsEmpty(int columnIndex)
    {
        int row = 0;
        while (row * mapWidth < map.Length)
        {

            if (map[row * mapWidth + columnIndex] == '#')
            {
                return false;
            }
            row++;
        }
        return true;
    }

    bool RowIsEmpty(int rowIndex)
    {
        for (int col = 0; col < mapWidth; col++)
        {
            if (map[rowIndex * mapWidth + col] == '#')
            {
                return false;
            }
        }
        return true;
    }
}