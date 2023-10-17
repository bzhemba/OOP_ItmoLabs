using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using FormFactor = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics.FormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

public class Motherboard : IClone<MotherboardBuilder>, ICheckCompatibility
{
    private Socket _cpuSocket;
    private PciLinesAmount _pciLinesAmount;
    private SataPortsAmount _sataPortsAmount;
    private DdrVersion _supportiveDdrVersion;
    private SlotsAmount _ramSlotsAmount;
    private BiosTypeVersion _biosTypeVersion;

    public Motherboard(Socket cpuSocket, PciLinesAmount pciLinesAmount, SataPortsAmount sataPortsAmount, Chipset chipset, DdrVersion supportiveDdrVersion, SlotsAmount ramSlotsAmount, FormFactor formFactor, BiosTypeVersion biosTypeVersion, bool hasWifiModule)
    {
        _cpuSocket = cpuSocket;
        _pciLinesAmount = pciLinesAmount;
        _sataPortsAmount = sataPortsAmount;
        Chipset = chipset;
        _supportiveDdrVersion = supportiveDdrVersion;
        _ramSlotsAmount = ramSlotsAmount;
        Formfactor = formFactor;
        _biosTypeVersion = biosTypeVersion;
        HasWifiModule = hasWifiModule;
    }

    public FormFactor Formfactor { get; }

    public Chipset Chipset { get; }

    public bool HasWifiModule { get; }

    public MotherboardBuilder Clone()
    {
        var motherboardBuilder = new MotherboardBuilder();
        motherboardBuilder.WithSocket(_cpuSocket);
        motherboardBuilder.WithChipset(Chipset);
        motherboardBuilder.WithFormFactor(Formfactor);
        motherboardBuilder.WithDdrVersion(_supportiveDdrVersion);
        motherboardBuilder.WithSlotsAmount(_ramSlotsAmount);
        motherboardBuilder.BiosTypeVersion(_biosTypeVersion);
        motherboardBuilder.WithPciLinesAmount(_pciLinesAmount);
        motherboardBuilder.WithSataPortsAmount(_sataPortsAmount);
        return motherboardBuilder;
    }

    public bool IsCompatible(Cpu cpu)
    {
        return cpu?.Socket == _cpuSocket;
    }

    public bool IsCompatible(Ram ram)
    {
        return ram?.DdrVersion.Version == _supportiveDdrVersion.Version;
    }
}