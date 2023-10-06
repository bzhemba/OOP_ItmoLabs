using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public class SpaceShipService : ISpaceShipService
{
    public double LaunchCost(Engine engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        if (time < 0)
        {
            throw new IncorrectFormatException($"Time can't be a negative number");
        }

        if (engine.TypeOfEngine == TypeOfEngine.Jumping)
        {
            return engine.ConsumedFuel(time) * (int)FuelExchange.GravitonMatterCost;
        }
        else
        {
            return engine.ConsumedFuel(time) * (int)FuelExchange.ActivePlasmaCost;
        }
    }

    public double LaunchTotalCost(ISpaceShip spaceShip, int time)
    {
        double totalCost = 0;
        if (time < 0)
        {
            throw new IncorrectFormatException($"Time can't be a negative number");
        }

        if (spaceShip != null)
        {
            foreach (Engine engine in spaceShip.Engines)
            {
                    totalCost += LaunchCost(engine, time);
            }
        }

        return totalCost;
    }

    public TheBestSpaceShip TheBestByPrice(Collection<ISpaceShip> spaceShips, int time)
    {
        if (time < 0)
        {
            throw new IncorrectFormatException($"Time can't be a negative number");
        }

        var spaceShipsCost = new Dictionary<double, ISpaceShip>();
        if (spaceShips != null)
        {
            foreach (ISpaceShip spaceShip in spaceShips)
            {
                spaceShipsCost[LaunchTotalCost(spaceShip, time)] = spaceShip;
            }
        }

        var sortedDict =
            spaceShipsCost.OrderBy(x
                => x.Value).ToDictionary(x => x.Key, x => x.Value);
        KeyValuePair<double, ISpaceShip> first = sortedDict.First();
        var bestForSpace = new TheBestSpaceShip(first.Value, first.Key);
        return bestForSpace;
    }

    public TheBestSpaceShip TheBestForInscreasedDensityOfSpace(Collection<ISpaceShip> spaceShips)
    {
        var spaceShipsJumpingRange = new Dictionary<double, ISpaceShip>();
        if (spaceShips != null)
        {
            foreach (ISpaceShip spaceShip in spaceShips)
            {
                int maxJumpRange = 0;
                foreach (Engine engine in spaceShip.Engines)
                {
                    if (engine.JumpRange > maxJumpRange)
                    {
                        maxJumpRange = engine.JumpRange;
                    }
                }

                spaceShipsJumpingRange.Add(maxJumpRange, spaceShip);
            }
        }

        var sortedDict =
            spaceShipsJumpingRange.OrderBy(x
                => x.Value).ToDictionary(x => x.Key, x => x.Value);
        KeyValuePair<double, ISpaceShip> last = sortedDict.Last();
        var bestForSpace = new TheBestSpaceShip(last.Value, last.Key);
        return bestForSpace;
    }

    public TheBestSpaceShip TheBestForNebulaeOfNitrineParticles(Collection<ISpaceShip> spaceShips)
    {
        var spaceShipsEnginePower = new Dictionary<double, ISpaceShip>();
        if (spaceShips != null)
        {
            foreach (ISpaceShip spaceShip in spaceShips)
            {
                double sumPower = 0;
                foreach (Engine engine in spaceShip.Engines)
                {
                    if (engine.GetType().IsAssignableFrom(typeof(EngineClassE)))
                        sumPower += engine.Power();
                }

                spaceShipsEnginePower.Add(sumPower, spaceShip);
            }
        }

        var sortedDict =
            spaceShipsEnginePower.OrderBy(x
                => x.Value).ToDictionary(x => x.Key, x => x.Value);
        KeyValuePair<double, ISpaceShip> last = sortedDict.Last();
        var bestForSpace = new TheBestSpaceShip(last.Value, last.Key);
        return bestForSpace;
    }

    public TheBestSpaceShip TheBestForSpace(Collection<ISpaceShip> spaceShips)
    {
        var spaceShipsEnginePower = new Dictionary<double, ISpaceShip>();
        if (spaceShips != null)
        {
            foreach (ISpaceShip spaceShip in spaceShips)
            {
                foreach (Engine engine in spaceShip.Engines)
                {
                    if (engine.GetType().IsAssignableFrom(typeof(EngineClassC)))
                        spaceShipsEnginePower.Add(engine.Power(), spaceShip);
                }
            }
        }

        var sortedDict =
            spaceShipsEnginePower.OrderBy(x
                => x.Value).ToDictionary(x => x.Key, x => x.Value);

        KeyValuePair<double, ISpaceShip> first = sortedDict.First();
        var bestForSpace = new TheBestSpaceShip(first.Value, first.Key);
        return bestForSpace;
    }

    public Report GetReport(ISpaceShip spaceShip, double distance)
    {
        if (distance < 0)
        {
            throw new IncorrectFormatException($"Distance can't be a negative number");
        }

        if (spaceShip != null)
        {
            int time = (int)(distance / spaceShip.ComputeSpeed());
            double totalCost = LaunchTotalCost(spaceShip, time);
            var report = new Report(time, totalCost);
            return report;
        }
        else
        {
            throw new NullObjectException($"No Space Ship to get report");
        }
    }
}