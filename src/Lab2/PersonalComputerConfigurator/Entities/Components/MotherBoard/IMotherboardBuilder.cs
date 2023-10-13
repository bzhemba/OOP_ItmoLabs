using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using FormFactor = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics.FormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithSocket(Socket cpuSocket);
    IMotherboardBuilder WithPciLinesAmount(PciLinesAmount pciLinesAmount);
    IMotherboardBuilder WithSataPortsAmount(SataPortsAmount sataPortsAmount);
    IMotherboardBuilder WithChipset(Chipset chipset);
    IMotherboardBuilder WithDdrVersion(DdrVersion supportiveDdrVersion);
    IMotherboardBuilder WithSlotsAmount(SlotsAmount ramSlotsAmount);
    IMotherboardBuilder WithFormFactor(FormFactor formFactor);
    IMotherboardBuilder BiosTypeVersion(BiosTypeVersion biosTypeVersion);
    Motherboard Build();
}