using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceTravelTest7
{
    [Fact]
    public void SpaceRoute()
    {
        var asteroids = new Collection<Asteroid?>() { new Asteroid() };
        var space1 = new Space(200, null, asteroids);
        var antimatterFlares = new Collection<AntimatterFlare?>() { new AntimatterFlare() };
        var subspaceChannel1 = new SubspaceChannel(40, antimatterFlares);
        var subspaceChannel2 = new SubspaceChannel(40, null);
        var subspaceChannels = new Collection<SubspaceChannel?>();
        subspaceChannels.Add(subspaceChannel1);
        subspaceChannels.Add(subspaceChannel2);
        var route1 = new List<PathSection>();
        var pathSection1 = new PathSection(space1, 100);
        route1.Add(pathSection1);
        var pleasureShuttle = new PleasureShuttle();
        bool result = false;
        int f = 0;
        foreach (PathSection pathSection in route1)
        {
            if (pathSection.Environment.PassingEnvironment(pleasureShuttle) == false)
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
        var meteorites2 = new Collection<Meteorite?>() { new Meteorite() };
        var space3 = new Space(50, meteorites2, null);
        var antimatterFlares = new Collection<AntimatterFlare?>() { new AntimatterFlare() };
        var subspaceChannel1 = new SubspaceChannel(40, antimatterFlares);
        var subspaceChannel2 = new SubspaceChannel(40, null);
        var subspaceChannels = new Collection<SubspaceChannel?>();
        subspaceChannels.Add(subspaceChannel1);
        subspaceChannels.Add(subspaceChannel2);
        var route1 = new List<PathSection>();
        var pathSection3 = new PathSection(space3, 150);
        route1.Add(pathSection3);
        var pleasureShuttle = new PleasureShuttle();
        bool result = false;
        int f = 0;
        foreach (PathSection pathSection in route1)
        {
            if (pathSection.Environment.PassingEnvironment(pleasureShuttle) == false)
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
    public void SpaceRoute2()
{
    var asteroids = new Collection<Asteroid?>() { new Asteroid() };
    var meteorites2 = new Collection<Meteorite?>() { new Meteorite() };
    var space1 = new Space(200, null, asteroids);
    var space3 = new Space(50, meteorites2, null);
    var antimatterFlares = new Collection<AntimatterFlare?>() { new AntimatterFlare() };
    var subspaceChannel1 = new SubspaceChannel(20, antimatterFlares);
    var subspaceChannel2 = new SubspaceChannel(10, null);
    var subspaceChannels = new Collection<SubspaceChannel?>();
    subspaceChannels.Add(subspaceChannel1);
    subspaceChannels.Add(subspaceChannel2);
    var whales = new Collection<SpaceWhale?>() { new SpaceWhale() };
    var nebulaeOfNitrineParticles = new NebulaeOfNitrineParticles(400, whales);
    var pathSection1 = new PathSection(space1, 100);
    var pathSection3 = new PathSection(space3, 150);
    var pathSection5 = new PathSection(nebulaeOfNitrineParticles, 50);
    var route2 = new List<PathSection>();
    route2.Add(pathSection5);
    route2.Add(pathSection1);
    route2.Add(pathSection3);
    var vaklas = new Vaklas();
    vaklas.AntinitrineEmitterON();
    int f = 0;
    bool result = false;
    foreach (PathSection pathSection in route2)
    {
        if (pathSection.Environment.PassingEnvironment(vaklas) == false)
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
        var asteroids = new Collection<Asteroid?>() { new Asteroid() };
        var meteorites = new Collection<Meteorite?>() { new Meteorite(), new Meteorite(), new Meteorite(), new Meteorite(), new Meteorite() };
        var space1 = new Space(200, null, asteroids);
        var space2 = new Space(50, meteorites, null);
        var antimatterFlares = new Collection<AntimatterFlare?>() { new AntimatterFlare() };
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
        var meridian = new Meridian();
        int f = 0;
        bool result = false;
        foreach (PathSection pathSection in route3)
        {
            if (pathSection.Environment.PassingEnvironment(meridian) == false)
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
        var meteorites = new Collection<Meteorite?>() { new Meteorite(), new Meteorite(), new Meteorite(), new Meteorite(), new Meteorite() };
        var space2 = new Space(50, meteorites, null);
        var antimatterFlares = new Collection<AntimatterFlare?>() { new AntimatterFlare() };
        var subspaceChannel1 = new SubspaceChannel(20, antimatterFlares);
        var subspaceChannel2 = new SubspaceChannel(10, null);
        var subspaceChannels = new Collection<SubspaceChannel?>();
        subspaceChannels.Add(subspaceChannel1);
        subspaceChannels.Add(subspaceChannel2);
        var increasedDensityOfSpace = new IncreasedDensityOfSpace(subspaceChannels);
        var route4 = new List<PathSection>();
        var pathSection2 = new PathSection(space2, 200);
        var pathSection4 = new PathSection(increasedDensityOfSpace, 300);
        route4.Add(pathSection2);
        route4.Add(pathSection4);
        var augur = new Augur();
        augur.AddPhotonDeflector();
        bool result = false;
        int f = 0;
        foreach (PathSection pathSection in route4)
        {
            if (pathSection.Environment.PassingEnvironment(augur) == false)
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