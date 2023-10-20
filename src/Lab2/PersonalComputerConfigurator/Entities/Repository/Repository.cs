using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;
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

    public IList<Cpu> GetCpuWith(CpuCriteria criteria)
    {
        return СpuList.Where(cpu => criteria != null
                                    && (cpu.MemoryFrequency == criteria.MemoryFrequency || criteria.MemoryFrequency == null)
                                    && (cpu.CoresFrequency == criteria.CoresFrequency || criteria.CoresFrequency == null)
                                    && (cpu.PowerConsumption == criteria.PowerConsumption || criteria.PowerConsumption == null)).ToList();
    }

    public IList<Motherboard> GetMotherboardWith(MotherboardCriteria criteria)
    {
        return Motherboards.Where(motherboard => criteria != null
                                    && (motherboard.SupportiveDdrVersion == criteria.SupportiveDdrVersion || criteria.SupportiveDdrVersion == null)
                                    && (motherboard.CpuSocket == criteria.CpuSocket || criteria.CpuSocket == null)
                                    && (motherboard.BiosVersion == criteria.BiosVersion || criteria.BiosVersion == null)
                                    && (motherboard.BiosType == criteria.BiosType || criteria.BiosType == null)).ToList();
    }

    public IList<Bios> GetBiosWith(BiosCriteria criteria)
    {
        return BiosList.Where(bios => criteria != null
                                                 && (bios.BiosVersion == criteria.BiosVersion || criteria.BiosVersion == null)
                                                 && (bios.BiosType == criteria.BiosType || criteria.BiosType == null)).ToList();
    }

    public IList<Ram> GetRamWith(RamCriteria criteria)
    {
        return Rams.Where(ram => criteria != null
                                      && (ram.DdrVersion == criteria.DdrVersion || criteria.DdrVersion == null)
                                      && (ram.PowerConsumption == criteria.PowerConsumption || criteria.PowerConsumption == null)
                                      && (ram.FormFactor == criteria.FormFactor || criteria.FormFactor == null)
                                      && (ram.MemorySize == criteria.MemorySize || criteria.MemorySize == null)).ToList();
    }

    public IList<SystemUnit> GetSystemUnitWith(SystemUnitCriteria criteria)
    {
        return SystemCases.Where(systemUnit => criteria != null
                                 && (systemUnit.Dimensions == criteria.Dimensions || criteria.Dimensions == null)
                                 && (systemUnit.CardDimensions == criteria.CardDimensions || criteria.CardDimensions == null)).ToList();
    }

    public IList<Xmp> GetXmpWith(XmpCriteria criteria)
    {
        return Xmps.Where(xmp => criteria != null
                                               && (xmp.Frequency == criteria.Frequency || criteria.Frequency == null)
                                               && (xmp.Voltage == criteria.Voltage || criteria.Voltage == null)).ToList();
    }

    public IList<Ssd> GetSsdWith(SsdCriteria criteria)
    {
        return SsdList.Where(ssd => criteria != null
                                        && (ssd.PowerConsumption == criteria.PowerConsumption || criteria.PowerConsumption == null)
                                        && (ssd.Connection == criteria.Connection || criteria.Connection == null)
                                        && (ssd.Capacity == criteria.Capacity || criteria.Capacity == null)
                                        && (ssd.Speed == criteria.Speed || criteria.Speed == null)).ToList();
    }

    public IList<Hdd> GetHddWith(HddCriteria criteria)
    {
        return Hdds.Where(hdd => criteria != null
                                    && (hdd.PowerConsumption == criteria.PowerConsumption || criteria.PowerConsumption == null)
                                    && (hdd.Capacity == criteria.Capacity || criteria.Capacity == null)
                                    && (hdd.SpindleSpeed == criteria.SpindleSpeed || criteria.SpindleSpeed == null)).ToList();
    }

    public IList<Cooler> GetCoolerWith(CoolerCriteria criteria)
    {
        return CoolingSystems.Where(cooler => criteria != null
                                 && (cooler.Dimensions == criteria.Dimensions || criteria.Dimensions == null)
                                 && (cooler.MaxTdp == criteria.MaxTdp || criteria.MaxTdp == null)).ToList();
    }

    public IList<PowerUnit> GetPowerUnitWith(PowerUnitCriteria criteria)
    {
        return PowerUnits.Where(poweUnit => criteria != null
                                              && (poweUnit.PeakLoad == criteria.PeakLoad || criteria.PeakLoad == null)).ToList();
    }

    public IList<VideoCard> GetVideocardWith(VideocardCriteria criteria)
    {
        return VideoCards.Where(videocard => criteria != null
                                            && (videocard.PowerConsumption == criteria.PowerConsumption || criteria.PowerConsumption == null)
                                            && (videocard.Dimensions == criteria.Dimensions || criteria.Dimensions == null)
                                            && (videocard.VideoMemoryAmount == criteria.VideoMemoryAmount || criteria.VideoMemoryAmount == null)).ToList();
    }

    public IList<WifiAdapter> GetWifiAdapterdWith(WifiAdapterCriteria criteria)
    {
        return WifiAdapters.Where(wifiAdapter => criteria != null
                                             && (wifiAdapter.PowerConsumption == criteria.PowerConsumption || criteria.PowerConsumption == null)
                                             && (wifiAdapter.StandartVersion == criteria.StandartVersion || criteria.StandartVersion == null)).ToList();
    }

    public IList<PersonalComputer> GetComputerWith(ComputerCriteria criteria)
    {
        return Computers.Where(computer => criteria != null
                                           && ((criteria.Cpu == null || ((computer.Cpu.MemoryFrequency == criteria.Cpu.MemoryFrequency || criteria.Cpu.MemoryFrequency == null)
                                                && (computer.Cpu.CoresFrequency == criteria.Cpu.CoresFrequency || criteria.Cpu.CoresFrequency == null)
                                                && (computer.Cpu.PowerConsumption == criteria.Cpu.PowerConsumption || criteria.Cpu.PowerConsumption == null)))

                                           && (criteria.Motherboard == null || ((computer.Motherboard.SupportiveDdrVersion == criteria.Motherboard.SupportiveDdrVersion || criteria.Motherboard.SupportiveDdrVersion == null)
                                           && (computer.Motherboard.CpuSocket == criteria.Motherboard.CpuSocket || criteria.Motherboard.CpuSocket == null)
                                           && (computer.Motherboard.BiosVersion == criteria.Motherboard.BiosVersion || criteria.Motherboard.BiosVersion == null)
                                           && (computer.Motherboard.BiosType == criteria.Motherboard.BiosType || criteria.Motherboard.BiosType == null)))

                                           && (criteria.Bios == null || ((computer.Bios.BiosVersion == criteria.Bios.BiosVersion || criteria.Bios.BiosVersion == null)
                                           && (computer.Bios.BiosType == criteria.Bios.BiosType || criteria.Bios.BiosType == null)))

                                           && (criteria.Ram == null || ((computer.Ram.DdrVersion == criteria.Ram.DdrVersion || criteria.Ram.DdrVersion == null)
                                           && (computer.Ram.PowerConsumption == criteria.Ram.PowerConsumption || criteria.Ram.PowerConsumption == null)
                                           && (computer.Ram.FormFactor == criteria.Ram.FormFactor || criteria.Ram.FormFactor == null)
                                           && (computer.Ram.MemorySize == criteria.Ram.MemorySize || criteria.Ram.MemorySize == null)))

                                           && (criteria.SystemUnit == null || ((computer.SystemUnit.Dimensions == criteria.SystemUnit.Dimensions || criteria.SystemUnit.Dimensions == null)
                                           && (computer.SystemUnit.CardDimensions == criteria.SystemUnit.CardDimensions || criteria.SystemUnit.CardDimensions == null)))

                                           && (criteria.Cooler == null || ((computer.Cooler.Dimensions == criteria.Cooler.Dimensions || criteria.Cooler.Dimensions == null)
                                           && (computer.Cooler.MaxTdp == criteria.Cooler.MaxTdp || criteria.Cooler.MaxTdp == null)))

                                           && (criteria.PowerUnit == null || (computer.PowerUnit.PeakLoad == criteria.PowerUnit.PeakLoad || criteria.PowerUnit.PeakLoad == null)))).ToList();
    }
}