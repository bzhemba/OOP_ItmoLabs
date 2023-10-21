namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;

public interface IChipset
{
    public ChipsetType Type { get; }
    public bool HaveXmp { get; }
}