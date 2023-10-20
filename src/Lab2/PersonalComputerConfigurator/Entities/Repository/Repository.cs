using System.Collections.Generic;
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
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Repository;

public class Repository
{
    public IList<Cpu> СpuList { get; } = new List<Cpu>();
    public IList<Bios> BiosList { get; } = new List<Bios>();
    public IList<Cooler> CoolingSystems { get; } = new List<Cooler>();
    public IList<Hdd> Hdds { get; } = new List<Hdd>();
    public IList<Motherboard> Motherboards { get; } = new List<Motherboard>();
    public IList<PowerUnit> PowerUnits { get; } = new List<PowerUnit>();
    public IList<Ram> Rams { get; } = new List<Ram>();
    public IList<Ssd> SsdList { get; } = new List<Ssd>();
    public IList<SystemUnit> SystemCases { get; } = new List<SystemUnit>();
    public IList<VideoCard> VideoCards { get; } = new List<VideoCard>();
    public IList<WifiAdapter> WifiAdapters { get; } = new List<WifiAdapter>();
    public IList<Xmp> Xmps { get; } = new List<Xmp>();
    public IList<Computer.PersonalComputer> Computers { get; } = new List<Computer.PersonalComputer>();

    public void AddCpu(Cpu cpu)
    {
        СpuList.Add(cpu);
    }

    public void AddBios(Bios bios)
    {
        BiosList.Add(bios);
    }

    public void AddCoolingSystem(Cooler cooler)
    {
        CoolingSystems.Add(cooler);
    }

    public void AddHdd(Hdd hdd)
    {
        Hdds.Add(hdd);
    }

    public void AddMotherboard(Motherboard motherboard)
    {
        Motherboards.Add(motherboard);
    }

    public void AddPowerUnit(PowerUnit powerUnit)
    {
        PowerUnits.Add(powerUnit);
    }

    public void AddRam(Ram ram)
    {
        Rams.Add(ram);
    }

    public void AddSsd(Ssd ssd)
    {
        SsdList.Add(ssd);
    }

    public void AddSystemUnit(SystemUnit systemUnit)
    {
        SystemCases.Add(systemUnit);
    }

    public void AddVideoCard(VideoCard videoCard)
    {
        VideoCards.Add(videoCard);
    }

    public void AddWifiAdapter(WifiAdapter wifiAdapter)
    {
        WifiAdapters.Add(wifiAdapter);
    }

    public void AddXmp(Xmp xmp)
    {
        Xmps.Add(xmp);
    }

    public void AddComputer(PersonalComputer personalComputer)
    {
        Computers.Add(personalComputer);
    }
}