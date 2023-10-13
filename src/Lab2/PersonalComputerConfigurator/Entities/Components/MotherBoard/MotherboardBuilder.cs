using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;
using FormFactor = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics.FormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

public class MotherboardBuilder : IMotherboardBuilder
{
    private Socket _cpuSocket;
    private PciLinesAmount? _pciLinesAmount;
    private SataPortsAmount? _sataPortsAmount;
    private Chipset? _chipset;
    private DdrVersion? _supportiveDdrVersion;
    private SlotsAmount? _ramSlotsAmount;
    private FormFactor _formFactor;
    private BiosTypeVersion? _biosTypeVersion;
    public IMotherboardBuilder WithSocket(Socket cpuSocket)
    {
        _cpuSocket = cpuSocket;
        return this;
    }

    public IMotherboardBuilder WithPciLinesAmount(PciLinesAmount pciLinesAmount)
    {
        _pciLinesAmount = pciLinesAmount;
        return this;
    }

    public IMotherboardBuilder WithSataPortsAmount(SataPortsAmount sataPortsAmount)
    {
        _sataPortsAmount = sataPortsAmount;
        return this;
    }

    public IMotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithDdrVersion(DdrVersion supportiveDdrVersion)
    {
        _supportiveDdrVersion = supportiveDdrVersion;
        return this;
    }

    public IMotherboardBuilder WithSlotsAmount(SlotsAmount ramSlotsAmount)
    {
        _ramSlotsAmount = ramSlotsAmount;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder BiosTypeVersion(BiosTypeVersion biosTypeVersion)
    {
        _biosTypeVersion = biosTypeVersion;
        return this;
    }

    public Motherboard Build()
    {
        if (_formFactor != default
            && _cpuSocket != default
            && _pciLinesAmount != null && _sataPortsAmount != null && _chipset != null
            && _supportiveDdrVersion != null && _ramSlotsAmount != null && _formFactor != default && _biosTypeVersion != null)
        {
            return new Motherboard(_cpuSocket, _pciLinesAmount, _sataPortsAmount, _chipset, _supportiveDdrVersion, _ramSlotsAmount, _formFactor, _biosTypeVersion);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}