using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceTravelTest4
{
    [Fact]
    public void RouteInSpace()
    {
        // Arrange
        var pleasureShuttle = new PleasureShuttle();
        var vaklas = new Vaklas();
        var spaceShipServices = new SpaceShipService();
        var spaceShips = new Collection<ISpaceShip>();
        spaceShips.Add(vaklas);
        spaceShips.Add(pleasureShuttle);
        string theBest = spaceShipServices.TheBestByPrice(spaceShips, 100);

        // Act
        bool result;
        result = theBest == "Pleasure Shuttle";

        // Assert
        Assert.True(result);
    }
}