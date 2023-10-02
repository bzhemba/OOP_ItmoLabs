namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

public class DeflectorClassThree : Deflector, ICanResistSpaceWhale
{
    private const int DeflectorClassThreeHitPoints = 10000;
    public DeflectorClassThree()
        : base(DeflectorClassThreeHitPoints)
    {
    }

    public bool CanConfrontTheSpaceWhale()
    {
        if (IsOn)
        {
            DeflectorOff();
            return true;
        }

        return false;
    }
}