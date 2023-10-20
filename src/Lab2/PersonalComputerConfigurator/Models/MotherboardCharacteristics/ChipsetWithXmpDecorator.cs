namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;

public class ChipsetWithXmpDecorator : ChipsetDecorator
{
    public ChipsetWithXmpDecorator(Chipset chipset)
        : base(chipset)
    {
    }

    public override bool HaveXmp => true;
}