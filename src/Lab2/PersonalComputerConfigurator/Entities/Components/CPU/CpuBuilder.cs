using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;

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
        if (coresAmount is { Amount: > 0 })
        {
            _coresAmount = coresAmount;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of cores amount");
        }
    }

    public CpuBuilder WithCoresFrequency(CoresFrequency coresFrequency)
    {
        if (coresFrequency is { Frequency: > 0 })
        {
            _coresFrequency = coresFrequency;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of cores frequency");
        }
    }

    public CpuBuilder WithTDP(TDP tdp)
    {
        if (tdp is { Watt: > 0 })
        {
            _tdp = tdp;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of TDP");
        }
    }

    public CpuBuilder WithMemoryFrequency(MemoryFrequency memoryFrequency)
    {
        if (memoryFrequency is { Mhz: > 0 })
        {
            _memoryFrequency = memoryFrequency;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of memory frequency");
        }
    }

    public CpuBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        if (powerConsumption is { Watt: > 0 })
        {
            _powerConsumption = powerConsumption;
            return this;
        }
        else
        {
            throw new IncorrectFormatException($"Incorrect format of power consumption");
        }
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