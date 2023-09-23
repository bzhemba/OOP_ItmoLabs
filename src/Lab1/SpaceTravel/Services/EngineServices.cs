using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Exceptions.EngineExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public class EngineServices : IEngineServices
{
    public double LaunchCostE(Engine engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        // поправить, чтобы выводил не 0
        return engine.ConsumedFuel(time) * (int)FuelExchange.DefaultCost;
    }

    public double LaunchCostJump(Engine engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        Console.WriteLine((int)FuelExchange.GravitonMatterCost);
        return engine.ConsumedFuel(time) * (int)FuelExchange.GravitonMatterCost;
    }

    public double LaunchCostC(Engine engine, int time)
    {
        if (engine == null)
        {
            throw new EngineDoesntExistExeption($"Engine doesn't exist");
        }

        Console.WriteLine((int)FuelExchange.ActivePlasmaCost);
        return engine.ConsumedFuel(time) * (int)FuelExchange.ActivePlasmaCost;
    }
}