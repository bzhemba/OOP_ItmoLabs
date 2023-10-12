using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class Cpu
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
}