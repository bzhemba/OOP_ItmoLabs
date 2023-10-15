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
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

public class Computer : IComputerConfigurator
{
    private Cpu _cpu;
    private Bios? _bios;
    private CoolingSystem _coolingSystem;
    private Hdd? _hdd;
    private Motherboard _motherboard;
    private PowerUnit _powerUnit;
    private Ram _ram;
    private Ssd? _ssd;
    private SystemCase _systemCase;
    private VideoCard? _videoCard;
    private WifiAdapter? _wifiAdapter;
    private Xmp? _xmp;

    private Computer(Cpu cpu, Bios bios, CoolingSystem coolingSystem, Hdd hdd, Motherboard motherboard, PowerUnit powerUnit, Ram ram, Ssd ssd, SystemCase systemCase, VideoCard videoCard, WifiAdapter wifiAdapter, Xmp xmp)
    {
        _cpu = cpu;
        _bios = bios;
        _coolingSystem = coolingSystem;
        _hdd = hdd;
        _motherboard = motherboard;
        _powerUnit = powerUnit;
        _ram = ram;
        _ssd = ssd;
        _systemCase = systemCase;
        _videoCard = videoCard;
        _wifiAdapter = wifiAdapter;
        _xmp = xmp;
    }

    public IComputerBuilder Direct(ComputerBuilder builder)
    {
        if (builder != null)
        {
            builder
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}