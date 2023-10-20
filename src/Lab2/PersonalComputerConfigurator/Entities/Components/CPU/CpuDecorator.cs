namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;

public abstract class CpuDecorator : Cpu
{
    private CpuDecorator _cpuDecorator;
    protected CpuDecorator(CpuDecorator cpuDecorator)
    {
        _cpuDecorator = cpuDecorator;
    }

    public virtual Cpu GetDecoratedCpu(Cpu cpu) { return cpu; }
}