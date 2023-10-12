using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class CpuFactory : ICpuFactory
{
    public Cpu CreateIntelCeleronCpu()
    {
     const int CoresAmount = 2;
     const int CoresFrequency = 1050;
     const int Tdp = 58;
     const int MemoryFrequency = 2666;
     const int PowerConsumption = 70;
     return new CpuBuilder().WithSocket(Socket.SocketAm4)
         .WithCoresAmount(new CoresAmount(CoresAmount)).WithCoresFrequency(new CoresFrequency(CoresFrequency))
         .WithMemoryFrequency(new MemoryFrequency(MemoryFrequency)).WithVideoCore(true)
         .WithPowerConsumption(new PowerConsumption(PowerConsumption)).WithTDP(new TDP(Tdp)).Build();
    }

    public Cpu CreateAmdAthlonCpu()
    {
        const int CoresAmount = 2;
        const int CoresFrequency = 1000;
        const int Tdp = 35;
        const int MemoryFrequency = 2667;
        const int PowerConsumption = 67;
        return new CpuBuilder().WithSocket(Socket.Lga1200)
            .WithCoresAmount(new CoresAmount(CoresAmount)).WithCoresFrequency(new CoresFrequency(CoresFrequency))
            .WithMemoryFrequency(new MemoryFrequency(MemoryFrequency)).WithVideoCore(true)
            .WithPowerConsumption(new PowerConsumption(PowerConsumption)).WithTDP(new TDP(Tdp)).Build();
    }

    public Cpu CreateIntelPentiumCpu()
    {
        const int CoresAmount = 2;
        const int CoresFrequency = 1000;
        const int Tdp = 54;
        const int MemoryFrequency = 2133;
        const int PowerConsumption = 65;
        return new CpuBuilder().WithSocket(Socket.Lga1155)
            .WithCoresAmount(new CoresAmount(CoresAmount)).WithCoresFrequency(new CoresFrequency(CoresFrequency))
            .WithMemoryFrequency(new MemoryFrequency(MemoryFrequency)).WithVideoCore(true)
            .WithPowerConsumption(new PowerConsumption(PowerConsumption)).WithTDP(new TDP(Tdp)).Build();
    }
}