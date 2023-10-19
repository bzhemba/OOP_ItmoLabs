using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCases;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

public class Computer
{
    private Cpu _cpu;
    private Bios _bios;
    private CoolingSystem _coolingSystem;
    private Hdd? _hdd;
    private Motherboard _motherboard;
    private PowerUnit _powerUnit;
    private Ram _ram;
    private Ssd? _ssd;
    private SystemUnit _systemUnit;
    private VideoCard? _videoCard;
    private WifiAdapter? _wifiAdapter;
    private Xmp? _xmp;

    internal Computer(Cpu cpu, Bios bios, CoolingSystem coolingSystem, Hdd? hdd, Motherboard motherboard, PowerUnit powerUnit, Ram ram, Ssd? ssd, SystemUnit systemUnit, VideoCard? videoCard, WifiAdapter? wifiAdapter, Xmp? xmp)
    {
        _cpu = cpu;
        _bios = bios;
        _coolingSystem = coolingSystem;
        _hdd = hdd;
        _motherboard = motherboard;
        _powerUnit = powerUnit;
        _ram = ram;
        _ssd = ssd;
        _systemUnit = systemUnit;
        _videoCard = videoCard;
        _wifiAdapter = wifiAdapter;
        _xmp = xmp;
    }

    public ComputerDirector Direct(ComputerDirector builder)
    {
        if (builder != null)
        {
            builder.WithMotherBoard(_motherboard).WithCpu(_cpu).WithBios(_bios).WithCoolingSystem(_coolingSystem)
                .WithRam(_ram).WithXmp(_xmp).WithVideoCard(_videoCard).WithSsd(_ssd).WithHdd(_hdd)
                .WithSystemCase(_systemUnit).WithPowerUnit(_powerUnit).WithWifiAdapter(_wifiAdapter);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}