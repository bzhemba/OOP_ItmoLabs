using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class SpaceTravelTest1
{
    private PleasureShuttle _pleasureShuttle;
    private Augur _augur;

    public SpaceTravelTest1()
    {
        _pleasureShuttle = new PleasureShuttle();
        _augur = new Augur();
    }

    [Theory]
    [InlineData(typeof(PleasureShuttle))]
    [InlineData(typeof(Augur))]
    public void PassingTheIncreasedDensityOfSpace(Type t)
    {
        // Arrange
        var antimatterFlares =
        new Collection<AntimatterFlare?>() { new AntimatterFlare() };
        var subspaceChannel = new SubspaceChannel(70, antimatterFlares);
        var subspaceChannels = new Collection<SubspaceChannel?>();
        subspaceChannels.Add(subspaceChannel);
        var increasedDensityOfSpace = new IncreasedDensityOfSpace(subspaceChannels);

        // Act
        bool result = false;
        if (t == typeof(Augur))
        {
            result = increasedDensityOfSpace.PassingEnvironment(_augur);
        }

        if (t == typeof(PleasureShuttle))
        {
            result = increasedDensityOfSpace.PassingEnvironment(_pleasureShuttle);
        }

        // Assert
        Console.WriteLine(result);
        Assert.True(result);
    }
}