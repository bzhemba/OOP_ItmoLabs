using Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Services;

public interface IEngineServices
{
    double LaunchCostC(Engine engine, int time);
    double LaunchCostE(Engine engine, int time);
    double LaunchCostJump(Engine engine, int time);
}