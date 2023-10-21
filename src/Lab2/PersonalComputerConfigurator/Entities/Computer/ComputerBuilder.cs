using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCases;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Validator;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

public class ComputerBuilder : IComputerBuilder, IMotherboardBuilder, ICpuBuilder, IBiosBuilder, ICoolingSystemBuilder, IRamBuilder,
    IXmpBuilder, IVideoCardBuilder, ISsdBuilder, IHddBuilder, ISystemUnitBuilder, IPowerUnitBuilder, IWifiAdapterBuilder
{
    private Cpu? _cpu;
    private Bios? _bios;
    private Cooler? _coolingSystem;
    private Hdd? _hdd;
    private Motherboard? _motherboard;
    private PowerUnit? _powerUnit;
    private Ram? _ram;
    private Ssd? _ssd;
    private SystemUnit? _systemCase;
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

    public ICoolingSystemBuilder WithCoolingSystem(Cooler cooler)
    {
        _coolingSystem = cooler;
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

    public ISystemUnitBuilder WithSystemCase(SystemUnit systemUnit)
    {
        _systemCase = systemUnit;
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

    public Notification Build()
    {
        var validator = Validator.Link(
            new CheckExistence(),
            new CheckMotherboardCpuCompatibility(),
            new CheckBiosCpuCompatibility(),
            new CheckMotherboardRamCompatibility(),
            new CheckCpuCoolingSystemCompatibility(),
            new CheckCoolingSystemCpuSocketCompatibility(),
            new CheckPowerUnit(),
            new CheckXmpCompatibility(),
            new CheckWifiModule(),
            new CheckSystemCaseDimensions());
        if (_cpu != null && _motherboard != null && _bios != null && _coolingSystem != null && _ram != null &&
            _systemCase != null && _powerUnit != null)
        {
            return validator.Check(
                _cpu,
                _bios,
                _motherboard,
                _coolingSystem,
                _ram,
                _videoCard,
                _ssd,
                _hdd,
                _systemCase,
                _powerUnit,
                _wifiAdapter,
                _xmp);
        }

        return new MissingComponent("Some components are missing");
    }
}