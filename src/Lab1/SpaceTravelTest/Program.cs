using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravelTest;

internal class Program
    {
        public static void Main()
        {
            IEngineServices engineServices = new EngineServices();
            var engine = new EngineE();
            engine.AddFuel(1900);
            Console.WriteLine(engineServices.LaunchCostE(engine, 60));
            var spaceShip = new Vaklas();
            spaceShip.AddDeflector(2);
            var meteorites = new Meteorite();
            spaceShip.CollisionWithMeteorite(meteorites);
        }
    }