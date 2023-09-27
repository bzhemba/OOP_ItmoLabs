using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceTravelTest6
{
    [Fact]
    public void RouteInNebulaeOfNitrineParticles()
    {
        // Arrange
        var pleasureShuttle = new PleasureShuttle();
        var vaklas = new Vaklas();
        var spaceShipServices = new SpaceShipService();
        var spaceShips = new Collection<ISpaceShip>();
        spaceShips.Add(pleasureShuttle);
        spaceShips.Add(vaklas);
        string theBest = spaceShipServices.TheBestForNebulaeOfNitrineParticles(spaceShips);

        // Act
        bool result;
        result = theBest == "Vaklas";

        // Assert
        Assert.True(result);
    }
}