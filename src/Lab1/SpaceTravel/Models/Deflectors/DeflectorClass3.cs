namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

public class DeflectorClass3 : Deflector, ICanResistSpaceWhale
{
    public DeflectorClass3()
        : base(10000)
    {
    }

    public bool ConfrontTheSpaceWhale()
    {
        if (IsOn)
        {
            DeflectorOff();
            return true;
        }

        return false;
    }
}