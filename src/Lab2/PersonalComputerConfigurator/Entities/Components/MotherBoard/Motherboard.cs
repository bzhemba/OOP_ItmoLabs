using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using FormFactor = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics.FormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

public class Motherboard
{
    private Socket _cpuSocket;
    private PciLinesAmount _pciLinesAmount;
    private SataPortsAmount _sataPortsAmount;
    private Chipset _chipset;
    private DdrVersion _supportiveDdrVersion;
    private SlotsAmount _ramSlotsAmount;
    private FormFactor _formFactor;
    private BiosTypeVersion _biosTypeVersion;

    public Motherboard(Socket cpuSocket, PciLinesAmount pciLinesAmount, SataPortsAmount sataPortsAmount, Chipset chipset, DdrVersion supportiveDdrVersion, SlotsAmount ramSlotsAmount, FormFactor formFactor, BiosTypeVersion biosTypeVersion)
    {
        _cpuSocket = cpuSocket;
        _pciLinesAmount = pciLinesAmount;
        _sataPortsAmount = sataPortsAmount;
        _chipset = chipset;
        _supportiveDdrVersion = supportiveDdrVersion;
        _ramSlotsAmount = ramSlotsAmount;
        _formFactor = formFactor;
        _biosTypeVersion = biosTypeVersion;
    }
}