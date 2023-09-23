using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

public class Deflector : ITakeDamage
{
    private int _hitPoints;
    private bool _isON;

    protected Deflector(int hitPoints)
    {
        _hitPoints = hitPoints;
        IsOn = true;
    }

    public bool IsOn
    {
        get => _isON;
        private set => _isON = value;
    }

    public void DeflectorOff()
    {
        IsOn = false;
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