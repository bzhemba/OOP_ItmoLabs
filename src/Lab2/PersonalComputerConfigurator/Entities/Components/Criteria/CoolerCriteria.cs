using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class CoolerCriteria
{
    public CoolerCriteria(Dimensions? dimensions, Tdp? maxTdp)
    {
        Dimensions = dimensions;
        MaxTdp = maxTdp;
    }

    public Dimensions? Dimensions { get; }
    public Tdp? MaxTdp { get; }
}