using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class Cpu : ICpuBuilderDirector
{
    private CoresAmount _coresAmount;
    private CoresFrequency _coresFrequency;
    private MemoryFrequency _memoryFrequency;
    private PowerConsumption _powerConsumption;

    public Cpu(Socket socket, CoresAmount coresAmount, CoresFrequency coresFrequency, TDP tdp, bool hasVideoCore, MemoryFrequency memoryFrequency, PowerConsumption powerConsumption)
    {
        Socket = socket;
        _coresAmount = coresAmount;
        _coresFrequency = coresFrequency;
        Tdp = tdp;
        HasVideoCore = hasVideoCore;
        _memoryFrequency = memoryFrequency;
        _powerConsumption = powerConsumption;
    }

    public Socket Socket { get; }

    public TDP Tdp { get; }

    public bool HasVideoCore { get; }
    public ICpuBuilder Direct(ICpuBuilder cpuBuilder)
    {
        if (cpuBuilder != null)
        {
            cpuBuilder.WithCoresAmount(_coresAmount);
            cpuBuilder.WithSocket(Socket);
            cpuBuilder.WithPowerConsumption(_powerConsumption);
            cpuBuilder.WithMemoryFrequency(_memoryFrequency);
            cpuBuilder.WithCoresFrequency(_coresFrequency);
            cpuBuilder.WithTDP(Tdp);
            return cpuBuilder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}