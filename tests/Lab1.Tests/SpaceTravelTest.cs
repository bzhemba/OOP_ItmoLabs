using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class SpaceTravelTest
{
    [Theory]
    [InlineData(typeof(PleasureShuttle))]
    [InlineData(typeof(Augur))]
    public void PassingTheIncreasedDensityOfSpace(Type t)
    {
        // Arrange
        List<Engine> augurEngines = new() { new EngineClassE(), new JumpingEngineAlpha() };
        List<DeflectorClassThree> augurDeflectors = new() { new DeflectorClassThree() };
        HullClassThree augurHull = new();
        var augur = new Augur(augurDeflectors, augurHull, augurEngines);
        HullClassOne shuttleHull = new();
        Collection<Engine> shuttleEngine = new() { new EngineClassC() };
        var pleasureShuttle = new PleasureShuttle(shuttleHull, shuttleEngine);
        var antimatterFlares =
        new Collection<AntimatterFlare>() { new AntimatterFlare() };
        var subspaceChannel = new SubspaceChannel(70, antimatterFlares);
        var subspaceChannels = new Collection<SubspaceChannel>();
        subspaceChannels.Add(subspaceChannel);
        var increasedDensityOfSpace = new IncreasedDensityOfSpace(subspaceChannels);
        if (t == typeof(Augur))
        {
            Assert.Equal(TravelResult.LossOfShip, increasedDensityOfSpace.PassingEnvironment(augur));
        }

        if (t == typeof(PleasureShuttle))
        {
            Assert.Equal(TravelResult.ShipDestruction, increasedDensityOfSpace.PassingEnvironment(pleasureShuttle));
        }
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void PassingTheIncreasedDensityOfSpaceOnVaklas(bool havePhotonDeflector)
    {
        // Arrange
        Collection<Engine> vaklasEngines = new() { new EngineClassE(), new JumpingEngineGamma() };
        List<DeflectorClassOne> vaklasDeflectors = new() { new DeflectorClassOne() };
        HullClassTwo vaklasHull = new();
        var vaklas = new Vaklas(vaklasDeflectors, vaklasHull, vaklasEngines);

        var antimatterFlares =
            new Collection<AntimatterFlare>() { new AntimatterFlare() };
        var subspaceChannel = new SubspaceChannel(20, antimatterFlares);
        var subspaceChannels = new Collection<SubspaceChannel>();
        subspaceChannels.Add(subspaceChannel);
        var increasedDensityOfSpace = new IncreasedDensityOfSpace(subspaceChannels);
        var spaceShipServices = new SpaceShipService();

        // Act
        TravelResult result;
        if (havePhotonDeflector)
        {
            vaklas.AddPhotonDeflector();
            result = increasedDensityOfSpace.PassingEnvironment(vaklas);
            Assert.Equal(TravelResult.Success, result);
            spaceShipServices.GetReport(vaklas, increasedDensityOfSpace.Distance);
        }

        if (havePhotonDeflector == false)
        {
            Assert.Equal(TravelResult.CrewDeath, increasedDensityOfSpace.PassingEnvironment(vaklas));
        }
    }

    [Theory]
    [InlineData(typeof(Vaklas))]
    [InlineData(typeof(Augur))]
    [InlineData(typeof(Meridian))]
    public void SpaceWhaleInNebulaeOfNitrineParticles(Type t)
    {
        // Arrange
        Collection<Engine> vaklasEngines = new() { new EngineClassE(), new JumpingEngineGamma() };
        List<DeflectorClassOne> vaklasDeflectors = new() { new DeflectorClassOne() };
        HullClassTwo vaklasHull = new();
        var vaklas = new Vaklas(vaklasDeflectors, vaklasHull, vaklasEngines);
        List<Engine> augurEngines = new() { new EngineClassE(), new JumpingEngineAlpha() };
        List<DeflectorClassThree> augurDeflectors = new() { new DeflectorClassThree() };
        HullClassThree augurHull = new();
        var augur = new Augur(augurDeflectors, augurHull, augurEngines);
        List<DeflectorClassTwo> meridianDeflectors = new() { new DeflectorClassTwo() };
        HullClassTwo hull = new();
        Collection<Engine> meridianEngine = new() { new EngineClassE() };
        var meridian = new Meridian(meridianDeflectors, hull, meridianEngine);
        var spaceWhales = new Collection<SpaceWhale>() { new SpaceWhale() };
        var nebulaeOfNitrineParticles = new NebulaeOfNitrineParticles(100, spaceWhales);
        var spaceShipServices = new SpaceShipService();

        // Act
        TravelResult result;
        if (t == typeof(Vaklas))
        {
            Assert.Equal(TravelResult.ShipDestruction, nebulaeOfNitrineParticles.PassingEnvironment(vaklas));
        }

        if (t == typeof(Augur))
        {
            result = nebulaeOfNitrineParticles.PassingEnvironment(augur);
            Assert.Equal(TravelResult.Success, result);
            spaceShipServices.GetReport(augur, nebulaeOfNitrineParticles.Distance);
        }

        if (t == typeof(Meridian))
        {
            meridian.AntinitrineEmitterON();
            result = nebulaeOfNitrineParticles.PassingEnvironment(meridian);
            Assert.Equal(TravelResult.Success, result);
            spaceShipServices.GetReport(meridian, nebulaeOfNitrineParticles.Distance);
        }
    }

    [Fact]
    public void RouteInSpace()
    {
        // Arrange
        HullClassOne shuttleHull = new();
        Collection<Engine> shuttleEngine = new() { new EngineClassC() };
        var pleasureShuttle = new PleasureShuttle(shuttleHull, shuttleEngine);
        Collection<Engine> vaklasEngines = new() { new EngineClassE(), new JumpingEngineGamma() };
        List<DeflectorClassOne> vaklasDeflectors = new() { new DeflectorClassOne() };
        HullClassTwo vaklasHull = new();
        var vaklas = new Vaklas(vaklasDeflectors, vaklasHull, vaklasEngines);
        var spaceShipServices = new SpaceShipService();
        var spaceShips = new Collection<ISpaceShip>();
        spaceShips.Add(vaklas);
        spaceShips.Add(pleasureShuttle);
        TheBestSpaceShip theBest = spaceShipServices.GeTheBestByPrice(spaceShips, 100);

        // Act
        bool result;
        result = theBest.SpaceShip is PleasureShuttle;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void RouteInIncreasedDensityOfSpace()
    {
        // Arrange
        List<Engine> augurEngines = new() { new EngineClassE(), new JumpingEngineAlpha() };
        List<DeflectorClassThree> augurDeflectors = new() { new DeflectorClassThree() };
        HullClassThree augurHull = new();
        var augur = new Augur(augurDeflectors, augurHull, augurEngines);
        Collection<Engine> stellaEngines = new() { new EngineClassC(), new JumpingEngineOmega() };
        List<DeflectorClassOne> stellaDeflectors = new() { new DeflectorClassOne() };
        HullClassOne stellaHull = new();
        var stella = new Stella(stellaDeflectors, stellaHull, stellaEngines);

        var spaceShipServices = new SpaceShipService();
        var spaceShips = new Collection<ISpaceShip>();
        spaceShips.Add(augur);
        spaceShips.Add(stella);
        TheBestSpaceShip theBest = spaceShipServices.GetTheBestForInscreasedDensityOfSpace(spaceShips);

        // Act
        bool result;
        result = theBest.SpaceShip is Stella;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void RouteInNebulaeOfNitrineParticles()
    {
        // Arrange
        HullClassOne shuttleHull = new();
        Collection<Engine> shuttleEngine = new() { new EngineClassC() };
        var pleasureShuttle = new PleasureShuttle(shuttleHull, shuttleEngine);
        Collection<Engine> vaklasEngines = new() { new EngineClassE(), new JumpingEngineGamma() };
        List<DeflectorClassOne> vaklasDeflectors = new() { new DeflectorClassOne() };
        HullClassTwo vaklasHull = new();
        var vaklas = new Vaklas(vaklasDeflectors, vaklasHull, vaklasEngines);
        var spaceShipServices = new SpaceShipService();
        var spaceShips = new Collection<ISpaceShip>();
        spaceShips.Add(pleasureShuttle);
        spaceShips.Add(vaklas);
        TheBestSpaceShip theBest = spaceShipServices.GetTheBestForNebulaeOfNitrineParticles(spaceShips);

        // Act
        bool result;
        result = theBest.SpaceShip is Vaklas;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SpaceRoute()
    {
        var asteroids = new Collection<Asteroid>() { new Asteroid() };
        var space1 = new Space(200, null, asteroids);
        var antimatterFlares = new Collection<AntimatterFlare>() { new AntimatterFlare() };
        var subspaceChannel1 = new SubspaceChannel(40, antimatterFlares);
        var subspaceChannel2 = new SubspaceChannel(40, null);
        var subspaceChannels = new Collection<SubspaceChannel>();
        subspaceChannels.Add(subspaceChannel1);
        subspaceChannels.Add(subspaceChannel2);
        var route1 = new List<PathSection>();
        var pathSection1 = new PathSection(space1, 100);
        route1.Add(pathSection1);
        HullClassOne hull = new();
        Collection<Engine> engine = new() { new EngineClassC() };
        var pleasureShuttle = new PleasureShuttle(hull, engine);
        bool result = false;
        int f = 0;
        foreach (PathSection pathSection in route1)
        {
            if (pathSection.Environment.PassingEnvironment(pleasureShuttle) == TravelResult.ShipDestruction)
            {
                f = 1;
                break;
            }
        }

        if (f == 0)
        {
            result = true;
        }

        Assert.True(result);
        }

    [Fact]
    public void SpaceRoute1()
    {
        var meteorites2 = new Collection<Meteorite>() { new Meteorite() };
        var space3 = new Space(50, meteorites2, null);
        var antimatterFlares = new Collection<AntimatterFlare>() { new AntimatterFlare() };
        var subspaceChannel1 = new SubspaceChannel(40, antimatterFlares);
        var subspaceChannel2 = new SubspaceChannel(40, null);
        var subspaceChannels = new Collection<SubspaceChannel?>();
        subspaceChannels.Add(subspaceChannel1);
        subspaceChannels.Add(subspaceChannel2);
        var route1 = new List<PathSection>();
        var pathSection3 = new PathSection(space3, 150);
        route1.Add(pathSection3);
        HullClassOne hull = new();
        Collection<Engine> engine = new() { new EngineClassC() };
        var pleasureShuttle = new PleasureShuttle(hull, engine);
        foreach (PathSection pathSection in route1)
        {
            Assert.Equal(TravelResult.ShipDestruction, pathSection.Environment.PassingEnvironment(pleasureShuttle));
        }
    }

    [Fact]
    public void SpaceRoute2()
{
    var asteroids = new Collection<Asteroid>() { new Asteroid() };
    var meteorites2 = new Collection<Meteorite>() { new Meteorite() };
    var space1 = new Space(200, null, asteroids);
    var space3 = new Space(50, meteorites2, null);
    var antimatterFlares = new Collection<AntimatterFlare>() { new AntimatterFlare() };
    var subspaceChannel1 = new SubspaceChannel(20, antimatterFlares);
    var subspaceChannel2 = new SubspaceChannel(10, null);
    var subspaceChannels = new Collection<SubspaceChannel?>();
    subspaceChannels.Add(subspaceChannel1);
    subspaceChannels.Add(subspaceChannel2);
    var whales = new Collection<SpaceWhale>() { new SpaceWhale() };
    var nebulaeOfNitrineParticles = new NebulaeOfNitrineParticles(400, whales);
    var pathSection1 = new PathSection(space1, 100);
    var pathSection3 = new PathSection(space3, 150);
    var pathSection5 = new PathSection(nebulaeOfNitrineParticles, 50);
    var route2 = new List<PathSection>();
    route2.Add(pathSection5);
    route2.Add(pathSection1);
    route2.Add(pathSection3);
    List<DeflectorClassTwo> deflectors = new() { new DeflectorClassTwo() };
    HullClassTwo hull = new();
    Collection<Engine> engine = new() { new EngineClassE() };
    var meridian = new Meridian(deflectors, hull, engine);
    meridian.AntinitrineEmitterON();
    int f = 0;
    bool result = false;
    foreach (PathSection pathSection in route2)
    {
        if (pathSection.Environment.PassingEnvironment(meridian) == TravelResult.ShipDestruction)
        {
            f = 1;
            break;
        }
    }

    if (f == 0)
    {
        result = true;
    }

    Assert.True(result);
}

    [Fact]
    public void SpaceRoute3()
    {
        var asteroids = new Collection<Asteroid>() { new Asteroid() };
        var meteorites = new Collection<Meteorite>() { new Meteorite(), new Meteorite(), new Meteorite(), new Meteorite(), new Meteorite() };
        var space1 = new Space(200, null, asteroids);
        var space2 = new Space(50, meteorites, null);
        var antimatterFlares = new Collection<AntimatterFlare>() { new AntimatterFlare() };
        var subspaceChannel1 = new SubspaceChannel(40, antimatterFlares);
        var subspaceChannel2 = new SubspaceChannel(40, null);
        var subspaceChannels = new Collection<SubspaceChannel?>();
        subspaceChannels.Add(subspaceChannel1);
        subspaceChannels.Add(subspaceChannel2);
        var route3 = new List<PathSection>();
        var pathSection1 = new PathSection(space1, 100);
        var pathSection2 = new PathSection(space2, 200);
        route3.Add(pathSection2);
        route3.Add(pathSection1);
        List<DeflectorClassTwo> deflectors = new() { new DeflectorClassTwo() };
        HullClassTwo hull = new();
        Collection<Engine> engine = new() { new EngineClassE() };
        var meridian = new Meridian(deflectors, hull, engine);
        int f = 0;
        bool result = false;
        foreach (PathSection pathSection in route3)
        {
            if (pathSection.Environment.PassingEnvironment(meridian) == TravelResult.ShipDestruction)
            {
                f = 1;
                break;
            }
        }

        if (f == 0)
        {
            result = true;
        }

        Assert.True(result);
    }

    [Fact]

    public void SpaceRoute4()
    {
        var meteorites = new Collection<Meteorite>() { new Meteorite(), new Meteorite(), new Meteorite(), new Meteorite(), new Meteorite() };
        var space2 = new Space(50, meteorites, null);
        var antimatterFlares = new Collection<AntimatterFlare>() { new AntimatterFlare() };
        var subspaceChannel1 = new SubspaceChannel(20, antimatterFlares);
        var subspaceChannel2 = new SubspaceChannel(10, null);
        var subspaceChannels = new Collection<SubspaceChannel>();
        subspaceChannels.Add(subspaceChannel1);
        subspaceChannels.Add(subspaceChannel2);
        var increasedDensityOfSpace = new IncreasedDensityOfSpace(subspaceChannels);
        var route4 = new List<PathSection>();
        var pathSection2 = new PathSection(space2, 200);
        var pathSection4 = new PathSection(increasedDensityOfSpace, 300);
        route4.Add(pathSection2);
        route4.Add(pathSection4);
        List<Engine> engines = new() { new EngineClassE(), new JumpingEngineAlpha() };
        List<DeflectorClassThree> deflectors = new() { new DeflectorClassThree() };
        HullClassThree hull = new();
        var augur = new Augur(deflectors, hull, engines);
        augur.AddPhotonDeflector();
        bool result = false;
        int f = 0;
        foreach (PathSection pathSection in route4)
        {
            if (pathSection.Environment.PassingEnvironment(augur) == TravelResult.ShipDestruction ||
                pathSection.Environment.PassingEnvironment(augur) == TravelResult.CrewDeath)
            {
                f = 1;
                break;
            }
        }

        if (f == 0)
        {
            result = true;
        }

        Assert.True(result);
    }
}
