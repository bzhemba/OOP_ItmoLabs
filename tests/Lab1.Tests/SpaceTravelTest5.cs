using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceTravelTest5
{
    [Fact]
    public void RouteInIncreasedDensityOfSpace()
    {
        // Arrange
        var augur = new Augur();
        var stella = new Stella();
        var spaceShipServices = new SpaceShipService();
        var spaceShips = new Collection<ISpaceShip>();
        spaceShips.Add(augur);
        spaceShips.Add(stella);
        string theBest = spaceShipServices.TheBestForInscreasedDensityOfSpace(spaceShips);

        // Act
        bool result;
        result = theBest == "Stella";

        // Assert
        Assert.True(result);
    }
}