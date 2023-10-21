namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class CpuWithVideoCoreDecorator : CpuDecorator
{
    public CpuWithVideoCoreDecorator(Cpu cpu)
        : base(cpu)
    {
    }

    public override bool HasVideoCore => true;
}