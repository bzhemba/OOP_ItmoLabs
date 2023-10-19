using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class Cpu : IClone<CpuBuilder>
{
    private Amount _amount;
    private Frequency _coresFrequency;

    public Cpu(Socket socket, Amount amount, Frequency coresFrequency, Tdp tdp, bool hasVideoCore, Frequency memoryFrequency, PowerConsumption powerConsumption)
    {
        Socket = socket;
        _amount = amount;
        _coresFrequency = coresFrequency;
        Tdp = tdp;
        HasVideoCore = hasVideoCore;
        MemoryFrequency = memoryFrequency;
        PowerConsumption = powerConsumption;
    }

    public PowerConsumption PowerConsumption { get; }

    public Frequency MemoryFrequency { get; }

    public Socket Socket { get; }

    public Tdp Tdp { get; }

    public bool HasVideoCore { get; }
    public CpuBuilder Clone()
    {
        var cpuBuilder = new CpuBuilder();
        cpuBuilder.WithCoresAmount(_amount);
        cpuBuilder.WithSocket(Socket);
        cpuBuilder.WithPowerConsumption(PowerConsumption);
        cpuBuilder.WithMemoryFrequency(MemoryFrequency);
        cpuBuilder.WithCoresFrequency(_coresFrequency);
        cpuBuilder.WithTDP(Tdp);
        return cpuBuilder;
    }
}