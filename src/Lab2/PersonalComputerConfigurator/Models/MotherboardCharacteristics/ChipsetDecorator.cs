namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;

public abstract class ChipsetDecorator : IChipset
{
    private Chipset _chipset;
    protected ChipsetDecorator(Chipset chipset)
    {
        _chipset = chipset;
    }

    public ChipsetType Type => _chipset.Type;
    public abstract bool HaveXmp { get; }
}