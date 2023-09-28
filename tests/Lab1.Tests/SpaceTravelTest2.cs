using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class SpaceTravelTest2
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void PassingTheIncreasedDensityOfSpaceOnVaklas(bool havePhotonDeflector)
    {
        // Arrange
        var vaklas = new Vaklas();
        var antimatterFlares =
            new Collection<AntimatterFlare?>() { new AntimatterFlare() };
        var subspaceChannel = new SubspaceChannel(30, antimatterFlares);
        var subspaceChannels = new Collection<SubspaceChannel?>();
        subspaceChannels.Add(subspaceChannel);
        var increasedDensityOfSpace = new IncreasedDensityOfSpace(subspaceChannels);

        // Act
        bool result = false;
        if (havePhotonDeflector)
        {
            vaklas.AddPhotonDeflector();
            result = increasedDensityOfSpace.PassingEnvironment(vaklas);
        }

        if (havePhotonDeflector == false)
        {
            result = increasedDensityOfSpace.PassingEnvironment(vaklas);
        }

        // Assert
        Assert.True(result);
    }
}