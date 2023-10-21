using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public abstract class CpuDecorator : ICpu
{
    private Cpu _cpuDecorator;
    protected CpuDecorator(Cpu cpu)
    {
        _cpuDecorator = cpu;
    }

    public Amount CoresAmount => _cpuDecorator.CoresAmount;
    public Frequency CoresFrequency => _cpuDecorator.CoresFrequency;
    public PowerConsumption PowerConsumption => _cpuDecorator.PowerConsumption;
    public Frequency MemoryFrequency => _cpuDecorator.MemoryFrequency;
    public Socket Socket => _cpuDecorator.Socket;
    public Tdp Tdp => _cpuDecorator.Tdp;
    public abstract bool HasVideoCore { get; }
}