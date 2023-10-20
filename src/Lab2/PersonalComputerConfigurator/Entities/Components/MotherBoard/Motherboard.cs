using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;

public class Motherboard : ICloneable
{
    private Socket _cpuSocket;
    private Amount _pciLinesAmount;
    private Amount _sataPortsAmount;
    private DdrVersion _supportiveDdrVersion;
    private Amount _ramSlotsAmount;
    private BiosType _biosType;
    private BiosVersion _biosVersion;

    public Motherboard(
        Socket cpuSocket,
        Amount pciLinesAmount,
        Amount sataPortsAmount,
        Chipset chipset,
        DdrVersion supportiveDdrVersion,
        Amount ramSlotsAmount,
        FormFactor formFactor,
        BiosType biosType,
        BiosVersion biosVersion,
        bool hasWifiModule)
    {
        _cpuSocket = cpuSocket;
        _pciLinesAmount = pciLinesAmount;
        _sataPortsAmount = sataPortsAmount;
        Chipset = chipset;
        _supportiveDdrVersion = supportiveDdrVersion;
        _ramSlotsAmount = ramSlotsAmount;
        Formfactor = formFactor;
        _biosType = biosType;
        _biosVersion = biosVersion;
        HasWifiModule = hasWifiModule;
    }

    public FormFactor Formfactor { get; }

    public Chipset Chipset { get; }

    public bool HasWifiModule { get; }

    public object Clone()
    {
        var motherboardBuilder = new MotherboardBuilder();
        motherboardBuilder.WithSocket(_cpuSocket);
        motherboardBuilder.WithChipset(Chipset);
        motherboardBuilder.WithFormFactor(Formfactor);
        motherboardBuilder.WithDdrVersion(_supportiveDdrVersion);
        motherboardBuilder.WithSlotsAmount(_ramSlotsAmount);
        motherboardBuilder.WithBiosType(_biosType);
        motherboardBuilder.WithBiosVersion(_biosVersion);
        motherboardBuilder.WithPciLinesAmount(_pciLinesAmount);
        motherboardBuilder.WithSataPortsAmount(_sataPortsAmount);
        return motherboardBuilder;
    }

    public bool IsCompatible(Cpu cpu)
    {
        return cpu != null && _cpuSocket.IsCompatible(cpu.Socket);
    }

    public bool IsCompatible(Ram ram)
    {
        return ram?.DdrVersion.Version == _supportiveDdrVersion.Version;
    }

    public MotherboardBuilder Direct(MotherboardBuilder builder)
    {
        if (builder != null)
        {
            builder.WithSocket(_cpuSocket).WithChipset(Chipset).WithDdrVersion(_supportiveDdrVersion)
                .WithBiosVersion(_biosVersion).WithBiosType(_biosType).WithFormFactor(Formfactor)
                .WithSlotsAmount(_ramSlotsAmount).WithSataPortsAmount(_sataPortsAmount)
                .WithPciLinesAmount(_pciLinesAmount).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}