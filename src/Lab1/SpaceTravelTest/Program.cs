using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravelTest;

internal class Program
    {
        public static void Main()
        {
            var augur = new Augur();
            var stella = new Stella();
            var spaceShipServices = new SpaceShipService();
            var spaceShips = new Collection<ISpaceShip>();
            spaceShips.Add(augur);
            spaceShips.Add(stella);
            string theBest = spaceShipServices.TheBestForInscreasedDensityOfSpace(spaceShips);
            Console.WriteLine(theBest);
        }
    }