using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

public class ComputerBuilder : IComputerBuilder, IMotherboardBuilder, ICpuBuilder, IBiosBuilder, ICoolingSystemBuilder, IRamBuilder,
    IXmpBuilder, IVideoCardBuilder, ISsdBuilder, IHddBuilder, ISystemCaseBuilder, IPowerUnitBuilder, IWifiAdapterBuilder
{
    private Cpu? _cpu;
    private Bios? _bios;
    private CoolingSystem? _coolingSystem;
    private Hdd? _hdd;
    private Motherboard? _motherboard;
    private PowerUnit? _powerUnit;
    private Ram? _ram;
    private Ssd? _ssd;
    private SystemCase? _systemCase;
    private VideoCard? _videoCard;
    private WifiAdapter? _wifiAdapter;
    private Xmp? _xmp;
    public IMotherboardBuilder WithMotherBoard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ICpuBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IBiosBuilder WithBios(Bios? bios)
    {
        _bios = bios;
        return this;
    }

    public ICoolingSystemBuilder WithCoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IRamBuilder WithRam(Ram ram)
    {
        _ram = ram;
        return this;
    }

    public IXmpBuilder WithXmp(Xmp? xmp)
    {
        _xmp = xmp;
        return this;
    }

    public IVideoCardBuilder WithVideoCard(VideoCard? videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public ISsdBuilder WithSsd(Ssd? ssd)
    {
        _ssd = ssd;
        return this;
    }

    public IHddBuilder WithHdd(Hdd? hdd)
    {
        _hdd = hdd;
        return this;
    }

    public ISystemCaseBuilder WithSystemCase(SystemCase systemCase)
    {
        _systemCase = systemCase;
        return this;
    }

    public IPowerUnitBuilder WithPowerUnit(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IWifiAdapterBuilder WithWifiAdapter(WifiAdapter? wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public Computer Build()
    {
        var validateDetails = new List<NotificationSystem>();
        
    }
}