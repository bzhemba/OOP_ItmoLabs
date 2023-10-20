namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public class CpuWithVideoCoreDecorator : CpuDecorator
{
    public CpuWithVideoCoreDecorator(CpuDecorator cpuDecorator)
        : base(cpuDecorator)
    {
    }

    public override Cpu GetDecoratedCpu(Cpu cpu)
    {
        Cpu decoratedCpu = base.GetDecoratedCpu(cpu);
        decoratedCpu.HasVideoCore = true;
    }
}