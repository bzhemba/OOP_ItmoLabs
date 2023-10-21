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
    private Amount _pciLinesAmount;
    private Amount _sataPortsAmount;
    private Amount _ramSlotsAmount;

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
        CpuSocket = cpuSocket;
        _pciLinesAmount = pciLinesAmount;
        _sataPortsAmount = sataPortsAmount;
        Chipset = chipset;
        SupportiveDdrVersion = supportiveDdrVersion;
        _ramSlotsAmount = ramSlotsAmount;
        Formfactor = formFactor;
        BiosType = biosType;
        BiosVersion = biosVersion;
        HasWifiModule = hasWifiModule;
    }

    public DdrVersion SupportiveDdrVersion { get; }
    public Socket CpuSocket { get; }
    public BiosType BiosType { get; }
    public BiosVersion BiosVersion { get; }

    public FormFactor Formfactor { get; }

    public Chipset Chipset { get; }

    public bool HasWifiModule { get; }

    public object Clone()
    {
        var motherboardBuilder = new MotherboardBuilder();
        motherboardBuilder.WithSocket(CpuSocket);
        motherboardBuilder.WithChipset(Chipset);
        motherboardBuilder.WithFormFactor(Formfactor);
        motherboardBuilder.WithDdrVersion(SupportiveDdrVersion);
        motherboardBuilder.WithSlotsAmount(_ramSlotsAmount);
        motherboardBuilder.WithBiosType(BiosType);
        motherboardBuilder.WithBiosVersion(BiosVersion);
        motherboardBuilder.WithPciLinesAmount(_pciLinesAmount);
        motherboardBuilder.WithSataPortsAmount(_sataPortsAmount);
        return motherboardBuilder;
    }

    public bool IsCompatible(Cpu cpu)
    {
        return cpu != null && CpuSocket.IsCompatible(cpu.Socket);
    }

    public bool IsCompatible(Ram ram)
    {
        return ram?.DdrVersion.Version == SupportiveDdrVersion.Version;
    }

    public MotherboardBuilder Direct(MotherboardBuilder builder)
    {
        if (builder != null)
        {
            builder.WithSocket(CpuSocket).WithChipset(Chipset).WithDdrVersion(SupportiveDdrVersion)
                .WithBiosVersion(BiosVersion).WithBiosType(BiosType).WithFormFactor(Formfactor)
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