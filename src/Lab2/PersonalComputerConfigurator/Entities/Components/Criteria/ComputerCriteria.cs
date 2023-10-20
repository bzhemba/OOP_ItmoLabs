namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class ComputerCriteria
{
    public ComputerCriteria(CpuCriteria? cpu, BiosCriteria? bios, CoolerCriteria? cooler, MotherboardCriteria? motherboard, PowerUnitCriteria? powerUnit, RamCriteria? ram, SystemUnitCriteria? systemUnit)
    {
        Cpu = cpu;
        Bios = bios;
        Cooler = cooler;
        Motherboard = motherboard;
        PowerUnit = powerUnit;
        Ram = ram;
        SystemUnit = systemUnit;
    }

    public CpuCriteria? Cpu { get; }
    public BiosCriteria? Bios { get; }
    public CoolerCriteria? Cooler { get; }
    public MotherboardCriteria? Motherboard { get; }
    public PowerUnitCriteria? PowerUnit { get; }
    public RamCriteria? Ram { get; }
    public SystemUnitCriteria? SystemUnit { get; }
}