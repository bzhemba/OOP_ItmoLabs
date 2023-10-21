namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class ComputerCriteria
{
    public ComputerCriteria(CpuCriteria? cpu, BiosCriteria? bios, MotherboardCriteria? motherboard, PowerUnitCriteria? powerUnit, RamCriteria? ram)
    {
        Cpu = cpu;
        Bios = bios;
        Motherboard = motherboard;
        PowerUnit = powerUnit;
        Ram = ram;
    }

    public CpuCriteria? Cpu { get; }
    public BiosCriteria? Bios { get; }
    public MotherboardCriteria? Motherboard { get; }
    public PowerUnitCriteria? PowerUnit { get; }
    public RamCriteria? Ram { get; }
}