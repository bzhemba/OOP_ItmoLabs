using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
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
        if (pciLinesAmount is { Amount: > 0 })
        {
            _pciLinesAmount = pciLinesAmount;
            return this;
        }

        throw new IncorrectFormatException($"Incorrect format of amount");
    }

    public MotherboardBuilder WithSataPortsAmount(SataPortsAmount sataPortsAmount)
    {
        if (sataPortsAmount is { Amount: > 0 })
        {
            _sataPortsAmount = sataPortsAmount;
            return this;
        }

        throw new IncorrectFormatException($"Incorrect format of amount");
    }

    public MotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder WithDdrVersion(DdrVersion supportiveDdrVersion)
    {
        if (supportiveDdrVersion is { Version: > 0 })
        {
            _supportiveDdrVersion = supportiveDdrVersion;
            return this;
        }

        throw new IncorrectFormatException($"Incorrect format of version");
    }

    public MotherboardBuilder WithSlotsAmount(SlotsAmount ramSlotsAmount)
    {
        if (ramSlotsAmount is { Amount: > 0 })
        {
            _ramSlotsAmount = ramSlotsAmount;
            return this;
        }

        throw new IncorrectFormatException($"Incorrect format of amount");
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
        if (_pciLinesAmount != null && _sataPortsAmount != null && _chipset != null
            && _supportiveDdrVersion != null && _ramSlotsAmount != null && _biosTypeVersion != null)
        {
            return new Motherboard(_cpuSocket, _pciLinesAmount, _sataPortsAmount, _chipset, _supportiveDdrVersion, _ramSlotsAmount, _formFactor, _biosTypeVersion, _hasWifiModule);
        }

        throw new NullObjectException("Unable to create component, some parts are missing");
    }
}