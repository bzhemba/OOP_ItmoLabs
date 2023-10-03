using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.IncorrectFormatExceptions;
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

    public string TheBestByPrice(Collection<ISpaceShip> spaceShips, int time)
    {
        if (time < 0)
        {
            throw new IncorrectFormatException($"Time can't be a negative number");
        }

        var spaceShipsCost = new Dictionary<string, double>();
        if (spaceShips != null)
        {
            foreach (ISpaceShip spaceShip in spaceShips)
            {
                spaceShipsCost.Add(spaceShip.Name, LaunchTotalCost(spaceShip, time));
            }
        }

        IOrderedEnumerable<KeyValuePair<string, double>> sortedDict =
            from entry in spaceShipsCost orderby entry.Value ascending select entry;
        KeyValuePair<string, double> first = sortedDict.First();
        return first.Key;
    }

    public string TheBestForInscreasedDensityOfSpace(Collection<ISpaceShip> spaceShips)
    {
        var spaceShipsJumpingRange = new Dictionary<string, int>();
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

                spaceShipsJumpingRange.Add(spaceShip.Name, maxJumpRange);
            }
        }

        IOrderedEnumerable<KeyValuePair<string, int>> sortedDict =
            from entry in spaceShipsJumpingRange orderby entry.Value ascending select entry;
        KeyValuePair<string, int> last = sortedDict.Last();
        return last.Key;
    }

    public string TheBestForNebulaeOfNitrineParticles(Collection<ISpaceShip> spaceShips)
    {
        var spaceShipsEnginePower = new Dictionary<string, double>();
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

                spaceShipsEnginePower.Add(spaceShip.Name, sumPower);
            }
        }

        IOrderedEnumerable<KeyValuePair<string, double>> sortedDict =
            from entry in spaceShipsEnginePower orderby entry.Value ascending select entry;
        KeyValuePair<string, double> last = sortedDict.Last();
        return last.Key;
    }

    public string TheBestForSpace(Collection<ISpaceShip> spaceShips)
    {
        var spaceShipsEnginePower = new Dictionary<string, double>();
        if (spaceShips != null)
        {
            foreach (ISpaceShip spaceShip in spaceShips)
            {
                foreach (Engine engine in spaceShip.Engines)
                {
                    if (engine.GetType().IsAssignableFrom(typeof(EngineClassC)))
                        spaceShipsEnginePower.Add(spaceShip.Name, engine.Power());
                }
            }
        }

        IOrderedEnumerable<KeyValuePair<string, double>> sortedDict =
            from entry in spaceShipsEnginePower orderby entry.Value ascending select entry;
        KeyValuePair<string, double> first = sortedDict.First();
        return first.Key;
    }

    public void GetReport(ISpaceShip spaceShip, double distance)
    {
        if (distance < 0)
        {
            throw new IncorrectFormatException($"Distance can't be a negative number");
        }

        if (spaceShip != null)
        {
            int time = (int)(distance / spaceShip.ComputeSpeed());
            double totalCost = LaunchTotalCost(spaceShip, time);
            Console.WriteLine($"Travel time: {time} \n Flight cost: {totalCost}");
        }
    }
}