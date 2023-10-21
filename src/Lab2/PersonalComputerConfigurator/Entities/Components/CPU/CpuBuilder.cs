using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class CpuBuilder
{
    private Socket? _socket;
    private Amount? _coresAmount;
    private Frequency? _coresFrequency;
    private Tdp? _tdp;
    private Frequency? _memoryFrequency;
    private PowerConsumption? _powerConsumption;

    public CpuBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public CpuBuilder WithCoresAmount(Amount amount)
    {
            _coresAmount = amount;
            return this;
        }

    public CpuBuilder WithCoresFrequency(Frequency coresFrequency)
    {
            _coresFrequency = coresFrequency;
            return this;
    }

    public CpuBuilder WithTDP(Tdp tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuBuilder WithMemoryFrequency(Frequency memoryFrequency)
    {
            _memoryFrequency = memoryFrequency;
            return this;
    }

    public CpuBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
            _powerConsumption = powerConsumption;
            return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _coresAmount ?? throw new ArgumentNullException(nameof(_coresAmount)),
            _coresFrequency ?? throw new ArgumentNullException(nameof(_coresFrequency)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _memoryFrequency ?? throw new ArgumentNullException(nameof(_memoryFrequency)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}