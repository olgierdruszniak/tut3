namespace ConsoleApp1;

public class Container
{
    private static int next_number = 1;
    protected int CargoMass { get; set; }
    private int Height { get; set; }
    private int TareWeight { get; set; }
    private int Depth { get; set; }
    protected string SerialNumber { get; set; }
    protected int MaxPayload { get; set; }
    protected int lastNumber;
    protected char Type { get; set; }

    public Container()
    {
        lastNumber = next_number++;
    }

    public virtual void EmptyCargo()
    {
        CargoMass = 0;
    }

    public virtual void Load(int CargoMass)
    {   
        if (CargoMass > MaxPayload)
        {
            throw new OverfillException();
        }
        else
        {
            this.CargoMass = CargoMass;
        }
    }
}