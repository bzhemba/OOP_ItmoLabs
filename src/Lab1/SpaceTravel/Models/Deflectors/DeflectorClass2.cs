namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

public class DeflectorClass2 : Deflector, ICanReflectAntimatter
{
    private int _countReflectedFlares;
    public DeflectorClass2()
        : base(5000)
    {
        _countReflectedFlares = 0;
    }

    public bool ReflectAntimatterFlare()
    {
        if (_countReflectedFlares < 3)
        {
            _countReflectedFlares += 1;
            return true;
        }

        return false;
    }
}