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

    public ISpaceShip TheBestByPrice(Collection<ISpaceShip> spaceShips, int time)
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

        IOrderedEnumerable<KeyValuePair<double, ISpaceShip>> sortedDict =
            from entry in spaceShipsCost orderby entry.Key ascending select entry;
        KeyValuePair<double, ISpaceShip> first = sortedDict.First();
        Console.WriteLine($"The best Space Ship for Space is {first.Value}, total cost: {first.Key}");
        return first.Value;
    }

    public ISpaceShip TheBestForInscreasedDensityOfSpace(Collection<ISpaceShip> spaceShips)
    {
        var spaceShipsJumpingRange = new Dictionary<int, ISpaceShip>();
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

        IOrderedEnumerable<KeyValuePair<int, ISpaceShip>> sortedDict =
            from entry in spaceShipsJumpingRange orderby entry.Key ascending select entry;
        KeyValuePair<int, ISpaceShip> last = sortedDict.Last();
        Console.WriteLine($"The best Space Ship for Space is {last.Value}, jump range: {last.Key}");
        return last.Value;
    }

    public ISpaceShip TheBestForNebulaeOfNitrineParticles(Collection<ISpaceShip> spaceShips)
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

        IOrderedEnumerable<KeyValuePair<double, ISpaceShip>> sortedDict =
            from entry in spaceShipsEnginePower orderby entry.Key ascending select entry;
        KeyValuePair<double, ISpaceShip> last = sortedDict.Last();
        Console.WriteLine($"The best Space Ship for Space is {last.Value}, power: {last.Key}");
        return last.Value;
    }

    public ISpaceShip TheBestForSpace(Collection<ISpaceShip> spaceShips)
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

        IOrderedEnumerable<KeyValuePair<double, ISpaceShip>> sortedDict =
            from entry in spaceShipsEnginePower orderby entry.Key ascending select entry;
        KeyValuePair<double, ISpaceShip> first = sortedDict.First();
        Console.WriteLine($"The best Space Ship for Space is {first.Value}, power: {first.Key}");
        return first.Value;
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