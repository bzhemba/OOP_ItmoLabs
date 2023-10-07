using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

public class Deflector : ITakeDamage
{
    private int _hitPoints;
    private int _countReflectedFlares;

    protected Deflector(int hitPoints)
    {
        if (hitPoints < 0)
            throw new IncorrectFormatException($"Hit points can't be a negative number");
        _hitPoints = hitPoints;
        IsOn = true;
    }

    public bool IsOn { get; private set; }

    public bool HasPhotonModification { get; private set; }

    public void DeflectorOff()
    {
        IsOn = false;
    }

    public void AddPhotonModification()
    {
        HasPhotonModification = true;
    }

    public bool ReflectAntimatterFlare()
    {
        if (!HasPhotonModification || _countReflectedFlares >= 3)
        {
            return false;
        }

        _countReflectedFlares += 1;
        return true;
    }

    public int GetRemainedDamage(int damage)
    {
            int remainingDamagePoints = _hitPoints - damage;
            if (remainingDamagePoints < 0)
            {
                _hitPoints = 0;
                this.DeflectorOff();
                return Math.Abs(remainingDamagePoints);
            }
            else if (remainingDamagePoints == 0)
            {
                _hitPoints = 0;
                this.DeflectorOff();
                return remainingDamagePoints;
            }
            else
            {
                _hitPoints -= damage;
                remainingDamagePoints = 0;
                return remainingDamagePoints;
            }
    }
}
