// See https://aka.ms/new-console-template for more information
public class DesertMapper
{
    private string directions;
    private DesertNode[] nodes;

    public string Directions { get => directions;}
    public DesertNode[] Nodes { get => nodes;}

    public DesertMapper(string mapinput)
    {
        string[] parts=mapinput.Split(Environment.NewLine);
        directions = parts[0].Trim();
    }
}