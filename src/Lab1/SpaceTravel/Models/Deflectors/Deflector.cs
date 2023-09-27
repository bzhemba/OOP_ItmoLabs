using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

public class Deflector : ITakeDamage
{
    private int _hitPoints;
    private bool _isON = true;
    private bool _hasPhotonModification;
    private int _countReflectedFlares;

    protected Deflector(int hitPoints)
    {
        _hitPoints = hitPoints;
    }

    public bool IsOn
    {
        get => _isON;
        private set => _isON = value;
    }

    public bool HasPhotonModification
    {
        get => _hasPhotonModification;
        private set => _hasPhotonModification = value;
    }

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
        if (HasPhotonModification)
        {
            if (_countReflectedFlares < 3)
            {
                _countReflectedFlares += 1;
                return true;
            }

            return false;
        }

        return false;
    }

    public int TakeDamage(int damage)
    {
            int remainingHitPoints = _hitPoints - damage;
            if (remainingHitPoints < 0)
            {
                _hitPoints = 0;
                this.DeflectorOff();
                return Math.Abs(remainingHitPoints);
            }
            else if (remainingHitPoints == 0)
            {
                _hitPoints = 0;
                this.DeflectorOff();
                return 0;
            }
            else
            {
                _hitPoints -= damage;
                return 0;
            }
    }
}