using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.HullExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.SpaceShipExeptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Hulls;

public class Hull : ITakeDamage
{
    private int _hitPoints;

    protected Hull(int hitPoints)
    {
        _hitPoints = hitPoints;
    }

    public int TakeDamage(int damage)
    {
            if (_hitPoints - damage < 0)
            {
                _hitPoints = 0;
                throw new SpaceShipDestroyedException($"Can't stand this damage. Space ship destroyed");
            }
            else if (_hitPoints - damage == 0)
            {
                _hitPoints = 0;
                throw new HullDestroyedException($"Hull critically destroyed");
            }
            else
            {
                _hitPoints -= damage;
                return 0;
            }
    }
}
