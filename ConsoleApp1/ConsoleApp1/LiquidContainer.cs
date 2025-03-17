namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardous = false;
    public LiquidContainer()
    {
        Type = 'L';
        SerialNumber = $"KON-{Type}-{lastNumber}";
    }

    public virtual void Notify()
    {
        Console.WriteLine($"Hazardous situation with container: {SerialNumber}");
        IsHazardous = true;
    }

    public override void Load(int CargoMass)
    {
        if (!IsHazardous)
        {
            if (CargoMass > MaxPayload / 2)
            {
                base.CargoMass /= 2;
                Console.WriteLine($"Dangerous situation with container: {SerialNumber}");
            }

            base.CargoMass = CargoMass;
        }
        else
        {
            if (CargoMass > MaxPayload*0.9)
            {
                base.CargoMass *= (int)(MaxPayload*0.9);
                Console.WriteLine($"Dangerous situation with container: {SerialNumber}");
            }

            base.CargoMass = CargoMass;
        }
    }
}