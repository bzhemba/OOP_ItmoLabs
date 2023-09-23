using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;

public class PhotonDeflector : IPhotonDeflector
{
    private int _hitPoints = 6000;

    public void ReflectAntimatterFlare(AntimatterFlares antimatterFlare)
    {
        if (antimatterFlare != null)
        {
            int damage = _hitPoints - antimatterFlare.DamagePoints;
            if (damage >= 0)
            {
                _hitPoints -= antimatterFlare.DamagePoints;
            }
            else
            {
                throw new SpaceCrewDestroyedException($"The ship's crew has been destroyed");
            }
        }
    }
}