public class Node
{
    public int X { get; }
    public int Y { get; }
    public char PrevDir { get; }

    public Node(int x, int y, char prevDir)
    {
        X = x;
        Y = y;
        PrevDir = prevDir;
    }
}
