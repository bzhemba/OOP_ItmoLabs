using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravelTest;

internal class Program
    {
        public static void Main()
        {
            var augur = new Augur();
            var stella = new Stella();
            var spaceShips = new Collection<ISpaceShip>();
            spaceShips.Add(augur);
            spaceShips.Add(stella);
            var vaklas = new Vaklas();
            var antimatterFlares =
                new Collection<AntimatterFlare?>() { new AntimatterFlare() };
            var subspaceChannel = new SubspaceChannel(40, antimatterFlares);
            var subspaceChannels = new Collection<SubspaceChannel?>();
            subspaceChannels.Add(subspaceChannel);
            var increasedDensityOfSpace = new IncreasedDensityOfSpace(subspaceChannels);
            vaklas.AddPhotonDeflector();
            Console.WriteLine(increasedDensityOfSpace.PassingEnvironment(vaklas));
        }
    }