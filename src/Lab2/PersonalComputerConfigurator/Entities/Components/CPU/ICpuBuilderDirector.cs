namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public interface ICpuBuilderDirector
{
    ICpuBuilder Direct(ICpuBuilder cpuBuilder);
}