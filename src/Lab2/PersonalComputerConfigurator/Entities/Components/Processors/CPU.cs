using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Processors;

public class CPU
{
    private Socket _socket;
    private CoresAmount _coresAmount;
    private CoresFrequency _coresFrequency;
    private TDP _tdp;
    private MemoryFrequency _memoryFrequency;
    private PowerConsumption _powerConsumption;
    private bool _hasVideoCore;
    public CPU(Socket socket, CoresAmount coresAmount, CoresFrequency coresFrequency, TDP tdp, bool hasVideoCore, MemoryFrequency memoryFrequency, PowerConsumption powerConsumption)
    {
        _socket = socket;
        _coresAmount = coresAmount;
        _coresFrequency = coresFrequency;
        _tdp = tdp;
        _hasVideoCore = hasVideoCore;
        _memoryFrequency = memoryFrequency;
        _powerConsumption = powerConsumption;
    }
}