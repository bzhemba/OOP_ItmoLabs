namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;

public class XmpChipsetDecorator
{
    private Chipset _chipset;
    public XmpChipsetDecorator(Chipset chipset)
    {
        _chipset = chipset;
        if (chipset != null) Type = chipset.Type;
    }

    private ChipsetType Type { get; }
    private bool HaveXmp { get; } = true;
}