namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public interface ICpuFactory
{
    Cpu CreateIntelCeleronCpu();
    Cpu CreateAmdAthlonCpu();
    Cpu CreateIntelPentiumCpu();
}