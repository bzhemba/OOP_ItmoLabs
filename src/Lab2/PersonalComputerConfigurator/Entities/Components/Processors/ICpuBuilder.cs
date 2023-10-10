using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Processors;

public interface ICpuBuilder
{
    ICpuBuilder WithSocket(Socket socket);
    ICpuBuilder WithCoresAmount(CoresAmount coresAmount);
    ICpuBuilder WithCoresFrequency(CoresFrequency coresFrequency);
    ICpuBuilder WithTDP(TDP tdp);
    ICpuBuilder WithMemoryFrequency(MemoryFrequency memoryFrequency);
    ICpuBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    ICpuBuilder WithVideoCore(bool hasVideoCore);
    CPU Create();
}