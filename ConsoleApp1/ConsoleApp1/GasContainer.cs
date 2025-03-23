using System.ComponentModel;

namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    private int Pressure {set;get;}
    
    public GasContainer()
    {
        Type = 'G';
        SerialNumber = $"KON-{Type}-{lastNumber}";
    }

    public override void EmptyCargo()
    {
        CargoMass = (int)(CargoMass * 0.05);
    }

    public virtual void Notify()
    {
        Console.WriteLine("Hazardous event for sNumber: " +SerialNumber);
    }

    public virtual void Load(int CargoMass) 
    {
        if (this.CargoMass + CargoMass > MaxPayload)
        {
            throw new Exception("ERROR");
        }
    }
}