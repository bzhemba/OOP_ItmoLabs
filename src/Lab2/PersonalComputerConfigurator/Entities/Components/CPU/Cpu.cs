using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class Cpu : IClone<CpuBuilder>
{
    private CoresAmount _coresAmount;
    private CoresFrequency _coresFrequency;
    private PowerConsumption _powerConsumption;

    public Cpu(Socket socket, CoresAmount coresAmount, CoresFrequency coresFrequency, TDP tdp, bool hasVideoCore, MemoryFrequency memoryFrequency, PowerConsumption powerConsumption)
    {
        Socket = socket;
        _coresAmount = coresAmount;
        _coresFrequency = coresFrequency;
        Tdp = tdp;
        HasVideoCore = hasVideoCore;
        MemoryFrequency = memoryFrequency;
        _powerConsumption = powerConsumption;
    }

    public MemoryFrequency MemoryFrequency { get; }

    public Socket Socket { get; }

    public TDP Tdp { get; }

    public bool HasVideoCore { get; }
    public CpuBuilder Clone()
    {
        var cpuBuilder = new CpuBuilder();
        cpuBuilder.WithCoresAmount(_coresAmount);
        cpuBuilder.WithSocket(Socket);
        cpuBuilder.WithPowerConsumption(_powerConsumption);
        cpuBuilder.WithMemoryFrequency(MemoryFrequency);
        cpuBuilder.WithCoresFrequency(_coresFrequency);
        cpuBuilder.WithTDP(Tdp);
        return cpuBuilder;
    }
}