using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

public class Deflector : ITakeDamage
{
    private int _hitPoints;
    private bool _isON;
    private PhotonDeflector? _photonDeflector;

    protected Deflector(int hitPoints)
    {
        _hitPoints = hitPoints;
        IsOn = true;
        _photonDeflector = null;
    }

    public bool IsOn
    {
        get => _isON;
        private set => _isON = value;
    }

    public void AddPhotonDeflector()
    {
        _photonDeflector = new PhotonDeflector();
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

    public void TakeAntimatterFlareDamage(AntimatterFlares antimatterFlare)
    {
        if (_photonDeflector is not null)
        {
            _photonDeflector.ReflectAntimatterFlare(antimatterFlare);
        }
        else
        {
            throw new NullObjectException(
                $"Can't reflect antimatter flare. This deflector doesn't have 'Photon Deflector' modification");
        }
    }
}