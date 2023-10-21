using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public interface ICpu
{
    public Amount CoresAmount { get; }
    public Frequency CoresFrequency { get; }
    public PowerConsumption PowerConsumption { get; }

    public Frequency MemoryFrequency { get; }

    public Socket Socket { get; }

    public Tdp Tdp { get; }
    public bool HasVideoCore { get; }
}