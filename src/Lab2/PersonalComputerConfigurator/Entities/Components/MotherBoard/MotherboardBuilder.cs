using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;
using FormFactor = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics.FormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

public class MotherboardBuilder
{
    private Socket _cpuSocket;
    private PciLinesAmount? _pciLinesAmount;
    private SataPortsAmount? _sataPortsAmount;
    private Chipset? _chipset;
    private DdrVersion? _supportiveDdrVersion;
    private SlotsAmount? _ramSlotsAmount;
    private FormFactor _formFactor;
    private BiosTypeVersion? _biosTypeVersion;
    private bool _hasWifiModule;
    public MotherboardBuilder WithSocket(Socket cpuSocket)
    {
        _cpuSocket = cpuSocket;
        return this;
    }

    public MotherboardBuilder WithPciLinesAmount(PciLinesAmount pciLinesAmount)
    {
        _pciLinesAmount = pciLinesAmount;
        return this;
    }

    public MotherboardBuilder WithSataPortsAmount(SataPortsAmount sataPortsAmount)
    {
        _sataPortsAmount = sataPortsAmount;
        return this;
    }

    public MotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder WithDdrVersion(DdrVersion supportiveDdrVersion)
    {
        _supportiveDdrVersion = supportiveDdrVersion;
        return this;
    }

    public MotherboardBuilder WithSlotsAmount(SlotsAmount ramSlotsAmount)
    {
        _ramSlotsAmount = ramSlotsAmount;
        return this;
    }

    public MotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder BiosTypeVersion(BiosTypeVersion biosTypeVersion)
    {
        _biosTypeVersion = biosTypeVersion;
        return this;
    }

    public MotherboardBuilder WithWifiModule(bool hasModule)
    {
        _hasWifiModule = hasModule;
        return this;
    }

    public Motherboard Build()
    {
        if (_formFactor != default
            && _cpuSocket != default
            && _pciLinesAmount != null && _sataPortsAmount != null && _chipset != null
            && _supportiveDdrVersion != null && _ramSlotsAmount != null && _formFactor != default && _biosTypeVersion != null)
        {
            return new Motherboard(_cpuSocket, _pciLinesAmount, _sataPortsAmount, _chipset, _supportiveDdrVersion, _ramSlotsAmount, _formFactor, _biosTypeVersion, _hasWifiModule);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}