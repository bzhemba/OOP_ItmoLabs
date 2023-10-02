using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public class SpaceShipService : ISpaceShipService
{
    public double LaunchCost(EngineClassE? engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        return engine.ConsumedFuel(time) * (int)FuelExchange.ActivePlasmaCost;
    }

    public double LaunchCost(JumpingEngineAlpha? engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        return engine.ConsumedFuel(time) * (int)FuelExchange.GravitonMatterCost;
    }

    public double LaunchCost(JumpingEngineOmega? engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        return engine.ConsumedFuel(time) * (int)FuelExchange.GravitonMatterCost;
    }

    public double LaunchCost(JumpingEngineGamma? engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        return engine.ConsumedFuel(time) * (int)FuelExchange.GravitonMatterCost;
    }

    public double LaunchCost(EngineClassC? engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        return engine.ConsumedFuel(time) * (int)FuelExchange.ActivePlasmaCost;
    }

    public double LaunchTotalCost(ISpaceShip? spaceShip, int time)
    {
        double totalCost = 0;
        if (spaceShip != null)
        {
            foreach (Engine engine in spaceShip.Engines)
            {
                if (engine.GetType().IsAssignableFrom(typeof(EngineClassC)))
                {
                    totalCost += LaunchCost(engine as EngineClassC, time);
                }

                if (engine.GetType().IsAssignableFrom(typeof(EngineClassE)))
                {
                    totalCost += LaunchCost(engine as EngineClassE, time);
                }

                if (engine.GetType().IsAssignableFrom(typeof(JumpingEngineGamma)))
                {
                    totalCost += LaunchCost(engine as JumpingEngineGamma, time);
                }

                if (engine.GetType().IsAssignableFrom(typeof(JumpingEngineAlpha)))
                {
                    totalCost += LaunchCost(engine as JumpingEngineAlpha, time);
                }

                if (engine.GetType().IsAssignableFrom(typeof(JumpingEngineOmega)))
                {
                    totalCost += LaunchCost(engine as JumpingEngineOmega, time);
                }
            }
        }

        return totalCost;
    }

    public string TheBestByPrice(Collection<ISpaceShip> spaceShips, int time)
    {
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
}