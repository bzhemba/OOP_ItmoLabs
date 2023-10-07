namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

public abstract class Engine
{
    private protected const double SpecificImpulse = 3222.6;
    private int _consumedFuelAmount;
    public abstract int JumpRange { get; }
    public abstract int Thrust { get; }
    public abstract TypeOfEngine TypeOfEngine { get; }

    public virtual double Power()
    {
        return Thrust / SpecificImpulse;
    }

    public double ConsumedFuel(int time)
    {
        _consumedFuelAmount += (int)Power() * time;
        return _consumedFuelAmount;
    }

    public abstract void StartingEngine();

    public abstract void AddFuel(int extraFuel);
}