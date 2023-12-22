public class Grid2d
{
    private readonly string[][] grid;

    public int Height { get; }
    public int Width { get; }

    public Grid2d(string[] lines)
    {
        grid = new string[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].Split(' ');
        }

        Height = grid.Length;
        Width = grid[0].Length;
    }

    public string this[int x, int y]
    {
        get
        {
            if (0 <= x && x < Height && 0 <= y && y < Width)
            {
                return grid[x][y];
            }

            return null;
        }
    }
}
