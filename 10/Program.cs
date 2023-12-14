


string[] map = File.ReadAllLines("../data/10.dat");
int Sx = 0, Sy = 0;
for (int y = 0; y < map.Length; y++)
{
    for (int x = 0; x < map[0].Length; x++)
    {
        if (map[y][x] == 'S')
        {
            Sx = x;
            Sy = y;
        }
    }
}

Console.WriteLine($"Part 1: {GetSteps(map, Sx, Sy)}");

int GetSteps(string[] Map, int startX, int startY)
{

    Queue<(int, int)> q = new();
    HashSet<(int, int)> Visited = new();
    char[] north = { 'S', '|', 'L', 'J' };
    char[] south = { 'S', '|', '7', 'F' };
    char[] east = { 'S', '-', 'L', 'F' };
    char[] west = { 'S', '-', 'J', '7' };

    q.Enqueue((startY, startX));
    Visited.Add((startY, startX));
    while (q.Count > 0)
    {
        (int y, int x) = q.Dequeue();
        // go north
        if (y > 0 && !Visited.Contains((y - 1, x)) && north.Any(c => c == Map[y][x]) && south.Any(c => c == Map[y - 1][x]))
        {
            Visited.Add((y - 1, x));
            q.Enqueue((y - 1, x));
        }

        // go south
        if (y < Map.Length - 1 && !Visited.Contains((y + 1, x)) && south.Any(c => c == Map[y][x]) && north.Any(c => c == Map[y + 1][x]))
        {
            Visited.Add((y + 1, x));
            q.Enqueue((y + 1, x));
        }

        // go west
        if (x > 0 && !Visited.Contains((y, x - 1)) && west.Any(c => c == Map[y][x]) && east.Any(c => c == Map[y][x - 1]))
        {
            Visited.Add((y, x - 1));
            q.Enqueue((y, x - 1));
        }

        // go east
        if (x < Map[0].Length - 1 && !Visited.Contains((y, x + 1)) && east.Any(c => c == Map[y][x]) && west.Any(c => c == Map[y][x + 1]))
        {
            Visited.Add((y, x + 1));
            q.Enqueue((y, x + 1));
        }

    }
    return Visited.Count / 2;
}


