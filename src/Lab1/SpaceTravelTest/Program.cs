using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravelTest;

internal class Program
    {
        public static void Main()
        {
            IEngineServices engineServices = new EngineServices();
            var engine = new EngineE(1200);
            Console.WriteLine(engine.FuelAmount);
            Console.WriteLine(engineServices.LaunchCostE(engine, 60));
            Console.WriteLine(engine.FuelAmount);
        }
    }