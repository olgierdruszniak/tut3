using System.ComponentModel;

namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    private int Pressure {set;get;}
    
    public GasContainer()
    {
        Type = 'G';
    }

    public override void EmptyCargo()
    {
        CargoMass = (int)(MaxPayload * 0.05);
    }

    public virtual void Notify()
    {
        
    }
}