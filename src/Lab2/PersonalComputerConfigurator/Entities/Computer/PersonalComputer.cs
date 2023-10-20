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

public class PersonalComputer
{
    internal PersonalComputer(
        Cpu cpu,
        Bios bios,
        Cooler cooler,
        Hdd? hdd,
        Motherboard motherboard,
        PowerUnit powerUnit,
        Ram ram,
        Ssd? ssd,
        SystemUnit systemUnit,
        VideoCard? videoCard,
        WifiAdapter? wifiAdapter,
        Xmp? xmp)
    {
        Cpu = cpu;
        Bios = bios;
        Cooler = cooler;
        Hdd = hdd;
        Motherboard = motherboard;
        PowerUnit = powerUnit;
        Ram = ram;
        Ssd = ssd;
        SystemUnit = systemUnit;
        Videocard = videoCard;
        WifiAdapter = wifiAdapter;
        Xmp = xmp;
    }

    public Cpu Cpu { get; }
    public Bios Bios { get; }
    public Cooler Cooler { get; }
    public Hdd? Hdd { get; }
    public Motherboard Motherboard { get; }
    public PowerUnit PowerUnit { get; }
    public Ram Ram { get; }
    public Ssd? Ssd { get; }
    public SystemUnit SystemUnit { get; }
    public VideoCard? Videocard { get; }
    public WifiAdapter? WifiAdapter { get; }
    public Xmp? Xmp { get; }

    public ComputerDirector Direct(ComputerDirector builder)
    {
        if (builder != null)
        {
            builder.WithMotherBoard(Motherboard).WithCpu(Cpu).WithBios(Bios).WithCoolingSystem(Cooler)
                .WithRam(Ram).WithXmp(Xmp).WithVideoCard(Videocard).WithSsd(Ssd).WithHdd(Hdd)
                .WithSystemCase(SystemUnit).WithPowerUnit(PowerUnit).WithWifiAdapter(WifiAdapter);
            return builder;
        }
        else
        {
            throw new NullObjectException("Builder is empty");
        }
    }
}