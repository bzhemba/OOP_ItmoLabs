using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class CpuBuilder
{
    private Socket _socket;
    private CoresAmount? _coresAmount;
    private CoresFrequency? _coresFrequency;
    private TDP? _tdp;
    private MemoryFrequency? _memoryFrequency;
    private PowerConsumption? _powerConsumption;
    private bool _hasVideoCore;

    public CpuBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public CpuBuilder WithCoresAmount(CoresAmount coresAmount)
    {
        _coresAmount = coresAmount;
        return this;
    }

    public CpuBuilder WithCoresFrequency(CoresFrequency coresFrequency)
    {
        _coresFrequency = coresFrequency;
        return this;
    }

    public CpuBuilder WithTDP(TDP tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuBuilder WithMemoryFrequency(MemoryFrequency memoryFrequency)
    {
        _memoryFrequency = memoryFrequency;
        return this;
    }

    public CpuBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public CpuBuilder WithVideoCore(bool hasVideoCore)
    {
        _hasVideoCore = hasVideoCore;
        return this;
    }

    public Cpu Build()
    {
        if (_socket != default && _coresAmount != null && _coresFrequency != null
            && _tdp != null && _memoryFrequency != null && _powerConsumption != null)
        {
            return new Cpu(_socket, _coresAmount, _coresFrequency, _tdp, _hasVideoCore, _memoryFrequency, _powerConsumption);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}