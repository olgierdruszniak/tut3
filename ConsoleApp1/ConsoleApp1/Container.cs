namespace ConsoleApp1;

public class Container
{
    private static int next_number = 1;
    private int CargoMass { get; set; }
    private int Height { get; set; }
    private int TareWeight { get; set; }
    private int CargoWeight { get; set; }
    private int Depth { get; set; }
    private string SerialNumber { get; set; }
    private int MaxPayload { get; set; }
    private int lastNumber;
    protected char Type { get; set; }

    public Container()
    {
        lastNumber = next_number++;
        
    }
}