using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCase;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Validator;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

// Class for modifying existing computer
public class ComputerDirector
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
    public ComputerDirector WithMotherBoard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ComputerDirector WithCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public ComputerDirector WithBios(Bios? bios)
    {
        _bios = bios;
        return this;
    }

    public ComputerDirector WithCoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public ComputerDirector WithRam(Ram ram)
    {
        _ram = ram;
        return this;
    }

    public ComputerDirector WithXmp(Xmp? xmp)
    {
        _xmp = xmp;
        return this;
    }

    public ComputerDirector WithVideoCard(VideoCard? videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public ComputerDirector WithSsd(Ssd? ssd)
    {
        _ssd = ssd;
        return this;
    }

    public ComputerDirector WithHdd(Hdd? hdd)
    {
        _hdd = hdd;
        return this;
    }

    public ComputerDirector WithSystemCase(SystemCase systemCase)
    {
        _systemCase = systemCase;
        return this;
    }

    public ComputerDirector WithPowerUnit(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public ComputerDirector WithWifiAdapter(WifiAdapter? wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public (AddNotification Notification,  Computer? Computer) Build()
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
        if ((_cpu != null && _motherboard != null && _bios != null && _coolingSystem != null && _ram != null && _systemCase != null && _powerUnit != null) &&
            validator.Check(_cpu, _bios, _motherboard, _coolingSystem, _ram, _videoCard, _ssd, _hdd, _systemCase, _powerUnit, _wifiAdapter, _xmp))
        {
            return (new Success(), new Computer(_cpu, _bios, _coolingSystem, _hdd, _motherboard, _powerUnit, _ram, _ssd, _systemCase, _videoCard, _wifiAdapter, _xmp));
        }
        else
        {
            return (new SomethingWentWrong(), null);
        }
    }
}