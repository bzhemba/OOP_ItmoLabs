using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceTravelTest3
{
    private Vaklas _vaklas;
    private Augur _augur;
    private Meridian _meridian;
    public SpaceTravelTest3()
    {
        _vaklas = new Vaklas();
        _augur = new Augur();
        _meridian = new Meridian();
    }

    [Theory]
    [InlineData(typeof(Vaklas))]
    [InlineData(typeof(Augur))]
    [InlineData(typeof(Meridian))]
    public void SpaceWhaleInNebulaeOfNitrineParticles(Type t)
    {
        // Arrange
        var spaceWhales = new Collection<SpaceWhale?>() { new SpaceWhale() };
        var nebulaeOfNitrineParticles = new NebulaeOfNitrineParticles(100, spaceWhales);

        // Act
        bool result = false;
        if (t == typeof(Vaklas))
        {
            result = nebulaeOfNitrineParticles.PassingEnvironment(_vaklas);
        }

        if (t == typeof(Augur))
        {
            result = nebulaeOfNitrineParticles.PassingEnvironment(_augur);
        }

        if (t == typeof(Meridian))
        {
            _meridian.AntinitrineEmitterON();
            result = nebulaeOfNitrineParticles.PassingEnvironment(_meridian);
        }

        // Assert
        Assert.True(result);
    }
}