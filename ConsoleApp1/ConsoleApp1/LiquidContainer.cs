namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer()
    {
        Type = 'L';
    }

    public virtual void Notify()
    {
        throw new NotImplementedException();
    }
}