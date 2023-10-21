namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;

public class Chipset : IChipset
{
    public Chipset(ChipsetType chipsetType)
    {
        Type = chipsetType;
    }

    public ChipsetType Type { get; }
    public bool HaveXmp { get; }
}