using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.IncorrectFormatExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

public class MotherboardBuilder
{
    private Socket? _cpuSocket;
    private Amount? _pciLinesAmount;
    private Amount? _sataPortsAmount;
    private Chipset? _chipset;
    private DdrVersion? _supportiveDdrVersion;
    private Amount? _ramSlotsAmount;
    private FormFactor _formFactor;
    private BiosType? _biosType;
    private BiosVersion? _biosVersion;
    private bool _hasWifiModule;
    public MotherboardBuilder WithSocket(Socket cpuSocket)
    {
        _cpuSocket = cpuSocket;
        return this;
    }

    public MotherboardBuilder WithPciLinesAmount(Amount pciLinesAmount)
    {
            _pciLinesAmount = pciLinesAmount;
            return this;
    }

    public MotherboardBuilder WithSataPortsAmount(Amount sataPortsAmount)
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
        if (supportiveDdrVersion is { Version: > 0 })
        {
            _supportiveDdrVersion = supportiveDdrVersion;
            return this;
        }

        throw new IncorrectFormatException($"Incorrect format of version");
    }

    public MotherboardBuilder WithSlotsAmount(Amount ramSlotsAmount)
    {
            _ramSlotsAmount = ramSlotsAmount;
            return this;
    }

    public MotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder WithBiosType(BiosType biosType)
    {
        _biosType = biosType;
        return this;
    }

    public MotherboardBuilder WithBiosVersion(BiosVersion biosVersion)
    {
        _biosVersion = biosVersion;
        return this;
    }

    public MotherboardBuilder WithWifiModule(bool hasModule)
    {
        _hasWifiModule = hasModule;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _cpuSocket ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _pciLinesAmount ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _sataPortsAmount ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _chipset ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _supportiveDdrVersion ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _ramSlotsAmount ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _formFactor,
            _biosType ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _biosVersion ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _hasWifiModule);
    }
}