namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Deflectors;

public class Deflector
{
    public Deflector()
    {
    }

    public bool CanReflectAntimatter { get; private set; }

    public int CountReflectedAntimatter { get; private set; }

    public bool IsON { get; private set; }

    public void AddPhotonDeflector()
    {
        CanReflectAntimatter = true;
        CountReflectedAntimatter = 3;
    }

    public void DeflectorOff()
    {
        IsON = false;
    }
}