using System.Collections.Generic;
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
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.NullObjectExceptions;

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

    public Cpu GetCpuWith(CpuCriteria criteria)
    {
        foreach (Cpu cpu in СpuList)
        {
            if (criteria != null
                && (criteria.MemoryFrequency == null || cpu.MemoryFrequency.Mhz == criteria.MemoryFrequency.Mhz)
                && (criteria.CoresFrequency == null || cpu.CoresFrequency.Mhz == criteria.CoresFrequency.Mhz)
                && (criteria.PowerConsumption == null || cpu.PowerConsumption.Watt == criteria.PowerConsumption.Watt))
            {
                return cpu;
            }
        }

        throw new NullObjectException();
    }

    public Motherboard GetMotherboardWith(MotherboardCriteria criteria)
    {
        foreach (Motherboard motherboard in Motherboards)
        {
            if (criteria != null
                && (criteria.SupportiveDdrVersion == null ||
                    motherboard.SupportiveDdrVersion.Version == criteria.SupportiveDdrVersion.Version)
                && (criteria.CpuSocket == null || motherboard.CpuSocket.Name == criteria.CpuSocket.Name)
                && (criteria.BiosVersion == null || motherboard.BiosVersion.V == criteria.BiosVersion.V)
                && (criteria.BiosType == null || motherboard.BiosType == criteria.BiosType))
            {
                return motherboard;
            }
        }

        throw new NullObjectException();
    }

    public Bios GetBiosWith(BiosCriteria criteria)
    {
        foreach (Bios bios in BiosList)
        {
            if (criteria != null
                && (criteria.BiosVersion == null || bios.BiosVersion.V == criteria.BiosVersion.V)
                && (criteria.BiosType == null || bios.BiosType == criteria.BiosType))
            {
                return bios;
            }
        }

        throw new NullObjectException();
    }

    public Ram GetRamWith(RamCriteria criteria)
    {
        foreach (Ram ram in Rams)
        {
            if (criteria != null
                && (criteria.DdrVersion == null || ram.DdrVersion == criteria.DdrVersion)
                && (criteria.PowerConsumption == null || ram.PowerConsumption.Watt == criteria.PowerConsumption.Watt)
                && (criteria.FormFactor == null || ram.FormFactor == criteria.FormFactor)
                && (criteria.MemorySize == null || ram.MemorySize.Gb == criteria.MemorySize.Gb))
            {
                return ram;
            }
        }

        throw new NullObjectException();
    }

    public SystemUnit GetSystemUnitWith(SystemUnitCriteria criteria)
    {
        foreach (SystemUnit systemUnit in SystemCases)
        {
            if (criteria != null
                && (criteria.Dimensions == null || (systemUnit.Dimensions.Length == criteria.Dimensions.Length
                                                    && systemUnit.Dimensions.Width == criteria.Dimensions.Width &&
                                                    systemUnit.Dimensions.Height == criteria.Dimensions.Height))
                && (criteria.CardDimensions == null ||
                    (systemUnit.CardDimensions.Length == criteria.CardDimensions.Length &&
                     systemUnit.CardDimensions.Width == criteria.CardDimensions.Width)))
            {
                return systemUnit;
            }
        }

        throw new NullObjectException();
    }

    public Xmp GetXmpWith(XmpCriteria criteria)
    {
        foreach (Xmp xmp in Xmps)
        {
            if (criteria != null
                && (criteria.Frequency == null || xmp.Frequency.Mhz == criteria.Frequency.Mhz)
                && (criteria.Voltage == null || xmp.Voltage.V == criteria.Voltage.V))
            {
                return xmp;
            }
        }

        throw new NullObjectException();
    }

    public Ssd GetSsdWith(SsdCriteria criteria)
    {
        foreach (Ssd ssd in SsdList)
        {
            if (criteria != null
                && (criteria.PowerConsumption == null || ssd.PowerConsumption.Watt == criteria.PowerConsumption.Watt)
                && (criteria.Connection == null || ssd.Connection == criteria.Connection)
                && (criteria.Capacity == null || ssd.Capacity.Gb == criteria.Capacity.Gb)
                && (criteria.Speed == null || ssd.Speed.MbS == criteria.Speed.MbS))
            {
                return ssd;
            }
        }

        throw new NullObjectException();
    }

    public Hdd GetHddWith(HddCriteria criteria)
    {
        foreach (Hdd hdd in Hdds)
        {
            if (criteria != null
                && (criteria.PowerConsumption == null || hdd.PowerConsumption.Watt == criteria.PowerConsumption.Watt)
                && (criteria.Capacity == null || hdd.Capacity.Gb == criteria.Capacity.Gb)
                && (criteria.SpindleSpeed == null || hdd.SpindleSpeed.MbS == criteria.SpindleSpeed.MbS))
            {
                return hdd;
            }
        }

        throw new NullObjectException();
    }

    public Cooler GetCoolerWith(CoolerCriteria criteria)
    {
        foreach (Cooler cooler in CoolingSystems)
        {
            if (criteria != null
                && (criteria.Dimensions == null || (cooler.Dimensions.Length == criteria.Dimensions.Length
                                                    && cooler.Dimensions.Width == criteria.Dimensions.Width
                                                    && cooler.Dimensions.Height == criteria.Dimensions.Height))
                && (criteria.MaxTdp == null || cooler.MaxTdp.Watt == criteria.MaxTdp.Watt))
            {
                return cooler;
            }
        }

        throw new NullObjectException();
    }

    public PowerUnit GetPowerUnitWith(PowerUnitCriteria criteria)
    {
        foreach (PowerUnit powerUnit in PowerUnits)
        {
            if (criteria != null
                && (criteria.PeakLoad == null || powerUnit.PeakLoad.Watt == criteria.PeakLoad.Watt))
            {
                return powerUnit;
            }
        }

        throw new NullObjectException();
    }

    public VideoCard GetVideocardWith(VideocardCriteria criteria)
    {
        foreach (VideoCard videocard in VideoCards)
        {
            if (criteria != null
                && (criteria.PowerConsumption == null ||
                    videocard.PowerConsumption.Watt == criteria.PowerConsumption.Watt)
                && (criteria.Dimensions == null || (videocard.Dimensions.Width == criteria.Dimensions.Width &&
                                                    videocard.Dimensions.Length == criteria.Dimensions.Length))
                && (criteria.VideoMemoryAmount == null ||
                    videocard.VideoMemoryAmount.Gb == criteria.VideoMemoryAmount.Gb))
            {
                return videocard;
            }
        }

        throw new NullObjectException();
    }

    public WifiAdapter GetWifiAdapterdWith(WifiAdapterCriteria criteria)
    {
        foreach (WifiAdapter wifiAdapter in WifiAdapters)
        {
            if (criteria != null
                && (criteria.PowerConsumption == null ||
                    wifiAdapter.PowerConsumption.Watt == criteria.PowerConsumption.Watt)
                && (criteria.StandartVersion == null ||
                    wifiAdapter.StandartVersion.Version == criteria.StandartVersion.Version))
            {
                return wifiAdapter;
            }
        }

        throw new NullObjectException();
    }

    public PersonalComputer GetComputerWith(ComputerCriteria criteria)
    {
        foreach (PersonalComputer computer in Computers)
        {
            if (criteria != null
                && ((criteria.Cpu == null || ((criteria.Cpu.MemoryFrequency == null ||
                                               computer.Cpu.MemoryFrequency.Mhz == criteria.Cpu.MemoryFrequency.Mhz)
                                              && (criteria.Cpu.CoresFrequency == null ||
                                                  computer.Cpu.CoresFrequency.Mhz == criteria.Cpu.CoresFrequency.Mhz)
                                              && (criteria.Cpu.PowerConsumption == null ||
                                                  computer.Cpu.PowerConsumption.Watt ==
                                                  criteria.Cpu.PowerConsumption.Watt)))

                    && (criteria.Motherboard == null || ((criteria.Motherboard.SupportiveDdrVersion == null ||
                                                          computer.Motherboard.SupportiveDdrVersion.Version ==
                                                          criteria.Motherboard.SupportiveDdrVersion.Version)
                                                         && (criteria.Motherboard.CpuSocket == null ||
                                                             computer.Motherboard.CpuSocket.Name ==
                                                             criteria.Motherboard.CpuSocket.Name)
                                                         && (criteria.Motherboard.BiosVersion == null ||
                                                             computer.Motherboard.BiosVersion.V ==
                                                             criteria.Motherboard.BiosVersion.V)
                                                         && (criteria.Motherboard.BiosType == null ||
                                                             computer.Motherboard.BiosType ==
                                                             criteria.Motherboard.BiosType)))

                    && (criteria.Bios == null || ((criteria.Bios.BiosVersion == null ||
                                                   computer.Bios.BiosVersion.V == criteria.Bios.BiosVersion.V)
                                                  && (criteria.Bios.BiosType == null ||
                                                      computer.Bios.BiosType == criteria.Bios.BiosType)))

                    && (criteria.Ram == null || ((criteria.Ram.DdrVersion == null ||
                                                  computer.Ram.DdrVersion.Version == criteria.Ram.DdrVersion.Version)
                                                 && (criteria.Ram.PowerConsumption == null ||
                                                     computer.Ram.PowerConsumption.Watt ==
                                                     criteria.Ram.PowerConsumption.Watt)
                                                 && (criteria.Ram.FormFactor == null ||
                                                     computer.Ram.FormFactor == criteria.Ram.FormFactor)
                                                 && (criteria.Ram.MemorySize == null || computer.Ram.MemorySize.Gb ==
                                                     criteria.Ram.MemorySize.Gb)))

                    && (criteria.PowerUnit == null || (criteria.PowerUnit.PeakLoad == null ||
                                                       computer.PowerUnit.PeakLoad.Watt ==
                                                       criteria.PowerUnit.PeakLoad.Watt))))
            {
                return computer;
            }
        }

        throw new NullObjectException();
    }
}