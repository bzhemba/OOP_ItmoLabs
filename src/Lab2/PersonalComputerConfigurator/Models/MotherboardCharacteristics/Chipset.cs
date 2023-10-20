namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;

public class Chipset
{
    public Chipset(ChipsetType chipsetType)
    {
        Type = chipsetType;
    }

    public ChipsetType Type { get; }
    public bool HaveXmp { get; }
}