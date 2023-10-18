using System.Collections.Generic;
using System.IO;
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
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CoolingSystemCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.CPUDetails;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.HddCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.WiFiAdapterCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.XmpProfileCharacteristics;
using FormFactor = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics.FormFactor;
using Type = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics.Type;
using Version = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Repository;

public class Repository
{
    private const int CoresAmountIntelCeleron = 2;
    private const int CoresFrequencyIntelCeleron = 1050;
    private const int TdpIntelCeleron = 58;
    private const int MemoryFrequencyIntelCeleron = 2666;
    private const int PowerConsumptionIntelCeleron = 70;

    private const int CoresAmountIntelPentium = 2;
    private const int CoresFrequencyIntelPentium = 1000;
    private const int TdpIntelPentium = 54;
    private const int MemoryFrequencyIntelPentium = 2133;
    private const int PowerConsumptionIntelPentium = 65;

    private const int CoresAmountAMDPhenom = 4;
    private const int CoresFrequencyAMDPhenom = 3000;
    private const int TdpAMDPhenom = 125;
    private const int MemoryFrequencyAMDPhenom = 1600;
    private const int PowerConsumptionAMDPhenom = 95;

    private const int CoresAmountIntelCorei7 = 8;
    private const int CoresFrequencyIntelCorei7 = 4000;
    private const int TdpIntelCorei7 = 140;
    private const int MemoryFrequencyIntelCorei7 = 2400;
    private const int PowerConsumptionIntelCorei7 = 95;

    private static Cpu _amdPhenomCpu = new CpuBuilder().WithSocket(Socket.SocketAm4)
        .WithCoresAmount(new CoresAmount(CoresAmountAMDPhenom)).WithCoresFrequency(new CoresFrequency(CoresFrequencyAMDPhenom))
        .WithMemoryFrequency(new MemoryFrequency(MemoryFrequencyAMDPhenom)).WithVideoCore(false)
        .WithPowerConsumption(new PowerConsumption(PowerConsumptionAMDPhenom)).WithTDP(new TDP(TdpAMDPhenom)).Build();

    private static Cpu _intelCorei7Cpu = new CpuBuilder().WithSocket(Socket.Lga1155)
        .WithCoresAmount(new CoresAmount(CoresAmountIntelCorei7)).WithCoresFrequency(new CoresFrequency(CoresFrequencyIntelCorei7))
        .WithMemoryFrequency(new MemoryFrequency(MemoryFrequencyIntelCorei7)).WithVideoCore(false)
        .WithPowerConsumption(new PowerConsumption(PowerConsumptionIntelCorei7)).WithTDP(new TDP(TdpIntelCorei7)).Build();

    private static Cpu _intelCeleronCpu = new CpuBuilder().WithSocket(Socket.SocketAm4)
        .WithCoresAmount(new CoresAmount(CoresAmountIntelCeleron)).WithCoresFrequency(new CoresFrequency(CoresFrequencyIntelCeleron))
        .WithMemoryFrequency(new MemoryFrequency(MemoryFrequencyIntelCeleron)).WithVideoCore(true)
        .WithPowerConsumption(new PowerConsumption(PowerConsumptionIntelCeleron)).WithTDP(new TDP(TdpIntelCeleron)).Build();
    private static Cpu _intelPentiumCpu = new CpuBuilder().WithSocket(Socket.Lga1200)
        .WithCoresAmount(new CoresAmount(CoresAmountIntelPentium)).WithCoresFrequency(new CoresFrequency(CoresFrequencyIntelPentium))
        .WithMemoryFrequency(new MemoryFrequency(MemoryFrequencyIntelPentium)).WithVideoCore(true)
        .WithPowerConsumption(new PowerConsumption(PowerConsumptionIntelPentium)).WithTDP(new TDP(TdpIntelPentium)).Build();

    private static IReadOnlyCollection<Cpu> _supportiveCpus1 = new List<Cpu>() { _intelPentiumCpu, _intelCorei7Cpu };
    private static IReadOnlyCollection<Cpu> _supportiveCpus2 = new List<Cpu>() { _intelCeleronCpu, _amdPhenomCpu };

    private static Bios _bios1 = new BiosBuilder().WithType(Type.Ami).WithVersion(new Version("2.02.2")).WithSupportiveCpus(_supportiveCpus1).Build();
    private static Bios _bios2 = new BiosBuilder().WithType(Type.Intel).WithVersion(new Version("3.02.22")).WithSupportiveCpus(_supportiveCpus2).Build();

    private static CoolingSystem _coolerMasterCooler = new CoolingSystemBuilder()
        .WithDimensions(new Dimensions(120, 120, 25)).WithSupportiveSockets(new List<Socket> { Socket.SocketAm4, Socket.Lga1155 })
        .WithMaxTdp(new MaxTdp(150)).Build();

    private static CoolingSystem _noctuaCooler = new CoolingSystemBuilder()
        .WithDimensions(new Dimensions(140, 140, 25)).WithSupportiveSockets(new List<Socket> { Socket.SocketG2, Socket.Lga1155 })
        .WithMaxTdp(new MaxTdp(200)).Build();

    private static Hdd _hdd1 = new HddBuilder().WithCapacity(new Capacity(1000)).WithSpindleSpeed(new SpindleSpeed(7200)).WithPowerConsumption(new PowerConsumption(10)).Build();
    private static Hdd _hdd2 = new HddBuilder().WithCapacity(new Capacity(2000)).WithSpindleSpeed(new SpindleSpeed(5400)).WithPowerConsumption(new PowerConsumption(8)).Build();
    private static Motherboard _motherboard1 = new MotherboardBuilder()
        .WithSocket(Socket.SocketAm4)
        .WithPciLinesAmount(new PciLinesAmount(4))
        .WithSataPortsAmount(new SataPortsAmount(6))
        .WithChipset(new Chipset(ChipsetType.B460, true))
        .WithDdrVersion(new DdrVersion(4))
        .WithSlotsAmount(new SlotsAmount(4))
        .WithFormFactor(FormFactor.Аtx)
        .BiosTypeVersion(new BiosTypeVersion(Type.Uefi, new Version("01.2.23")))
        .WithWifiModule(true)
        .Build();

    private static Motherboard _motherboard2 = new MotherboardBuilder()
        .WithSocket(Socket.Lga1200)
        .WithPciLinesAmount(new PciLinesAmount(3))
        .WithSataPortsAmount(new SataPortsAmount(4))
        .WithChipset(new Chipset(ChipsetType.H470, true))
        .WithDdrVersion(new DdrVersion(4))
        .WithSlotsAmount(new SlotsAmount(2))
        .WithFormFactor(FormFactor.MicroAtx)
        .BiosTypeVersion(new BiosTypeVersion(Type.Intel, new Version("3.02.22")))
        .WithWifiModule(false)
        .Build();

    private static Motherboard _motherboard3 = new MotherboardBuilder()
        .WithSocket(Socket.Lga1155)
        .WithPciLinesAmount(new PciLinesAmount(5))
        .WithSataPortsAmount(new SataPortsAmount(8))
        .WithChipset(new Chipset(ChipsetType.Q470, true))
        .WithDdrVersion(new DdrVersion(4))
        .WithSlotsAmount(new SlotsAmount(8))
        .WithFormFactor(FormFactor.MiniAtx)
        .BiosTypeVersion(new BiosTypeVersion(Type.Ami, new Version("2.02.2")))
        .WithWifiModule(false)
        .Build();
    private static PowerUnit _powerUnit1 = new PowerUnitBuilder().WithPeakload(new PeakLoad(1000)).Build();
    private static PowerUnit _powerUnit2 = new PowerUnitBuilder().WithPeakload(new PeakLoad(2000)).Build();
    private static Xmp _xmp1 = new XmpBuilder()
        .WithTimings(new List<int> { 15, 17, 17, 35 })
        .WithVoltage(new Voltage(1.35))
        .WithFrequency(new Frequency(3200))
        .Build();

    private static Xmp _xmp2 = new XmpBuilder()
        .WithTimings(new List<int> { 16, 18, 18, 36 })
        .WithVoltage(new Voltage(1.2))
        .WithFrequency(new Frequency(2666))
        .Build();

    private static Ram _ram1 = new RamBuilder()
        .WithMemorySize(new MemorySize(8))
        .WithFormFactor(Models.RamCharacterisics.FormFactor.Dimm)
        .WithXmp(_xmp1)
        .WithDdrVersion(new DdrVersion(4))
        .WithPowerConsumption(new PowerConsumption(10))
        .WithSupportiveFrequencyVoltagePairs(new List<FrequencyVoltagePair>
        {
            new FrequencyVoltagePair(3200, 1.35),
            new FrequencyVoltagePair(2400, 1.2),
        })
        .Build();

    private static Ram _ram2 = new RamBuilder()
        .WithMemorySize(new MemorySize(16))
        .WithFormFactor(Models.RamCharacterisics.FormFactor.SoDimm)
        .WithXmp(_xmp1)
        .WithDdrVersion(new DdrVersion(4))
        .WithPowerConsumption(new PowerConsumption(12))
        .WithSupportiveFrequencyVoltagePairs(new List<FrequencyVoltagePair>
        {
            new FrequencyVoltagePair(2666, 1.35),
            new FrequencyVoltagePair(2133, 1.2),
        })
        .Build();
    private static Ssd _ssd1 = new SsdBuilder()
        .WithConnection(Connection.Sata)
        .WithCapacity(new Capacity(500))
        .WithMaxSpeed(new MaxSpeed(550))
        .WithPowerConsumption(new PowerConsumption(2))
        .Build();
    private static Ssd _ssd2 = new SsdBuilder()
        .WithConnection(Connection.Pci)
        .WithCapacity(new Capacity(1000))
        .WithMaxSpeed(new MaxSpeed(3500))
        .WithPowerConsumption(new PowerConsumption(4))
        .Build();
    private static SystemCase _systemCase1 = new SystemCaseBuilder()
        .WithVideoCardDimensions(new VideoCardDimensions(280, 128))
        .WithSupportiveFormFactors(new List<FormFactor> { FormFactor.MiniAtx, FormFactor.MicroAtx })
        .WithDimensions(new Dimensions(400, 200, 350))
        .Build();
    private static SystemCase _systemCase2 = new SystemCaseBuilder()
        .WithVideoCardDimensions(new VideoCardDimensions(320, 140))
        .WithSupportiveFormFactors(new List<FormFactor> { FormFactor.Аtx, FormFactor.MicroAtx })
        .WithDimensions(new Dimensions(350, 150, 300))
        .Build();
    private static VideoCard _videoCard1 = new VideoCardBuilder()
        .WithVideoCardDimensions(new VideoCardDimensions(280, 128))
    .WithVideoMemoryAmount(new VideoMemoryAmount(8))
    .WithPciVersion(new PciVersion(3))
    .WithChipFrequency(new ChipFrequency(1600))
    .WithPowerConsumption(new PowerConsumption(120))
    .Build();
    private static VideoCard _videoCard2 = new VideoCardBuilder()
        .WithVideoCardDimensions(new VideoCardDimensions(320, 140))
        .WithVideoMemoryAmount(new VideoMemoryAmount(16))
        .WithPciVersion(new PciVersion(4))
        .WithChipFrequency(new ChipFrequency(2000))
        .WithPowerConsumption(new PowerConsumption(150))
        .Build();
    private static WifiAdapter _wifiAdapter1 = new WifiAdapterBuilder()
        .WithStandartVersion(new StandartVersion(4))
        .WithBluetoothModule(true)
        .WithPciVersion(new PciVersion(3))
        .WithPowerConsumption(new PowerConsumption(5))
        .Build();
    private static WifiAdapter _wifiAdapter2 = new WifiAdapterBuilder()
        .WithStandartVersion(new StandartVersion(6))
        .WithBluetoothModule(false)
        .WithPciVersion(new PciVersion(4))
        .WithPowerConsumption(new PowerConsumption(8))
        .Build();

    private static IComputerBuilder _builderDexp = new ComputerBuilder();
    private static Computer.Computer _computerDexp = _builderDexp.WithMotherBoard(_motherboard2).WithCpu(_intelPentiumCpu).WithBios()
    public IList<Cpu> СpuList { get; } = new List<Cpu>() { _intelPentiumCpu, _intelCeleronCpu, _intelCorei7Cpu, _amdPhenomCpu };
    public IList<Bios> BiosList { get; } = new List<Bios>() { _bios1, _bios2 };
    public IList<CoolingSystem> CoolingSystems { get; } = new List<CoolingSystem>() { _coolerMasterCooler, _noctuaCooler };
    public IList<Hdd> Hdds { get; } = new List<Hdd>() { _hdd1, _hdd2 };
    public IList<Motherboard> Motherboards { get; } = new List<Motherboard>() { _motherboard1, _motherboard2, _motherboard3 };
    public IList<PowerUnit> PowerUnits { get; } = new List<PowerUnit>() { _powerUnit1, _powerUnit2 };
    public IList<Ram> Rams { get; } = new List<Ram>() { _ram1, _ram2 };
    public IList<Ssd> SsdList { get; } = new List<Ssd>() { _ssd1, _ssd2 };
    public IList<SystemCase> SystemCases { get; } = new List<SystemCase>() { _systemCase1, _systemCase2 };
    public IList<VideoCard> VideoCards { get; } = new List<VideoCard>() { _videoCard1, _videoCard2 };
    public IList<WifiAdapter> WifiAdapters { get; } = new List<WifiAdapter>() { _wifiAdapter1, _wifiAdapter2 };
    public IList<Xmp> Xmps { get; } = new List<Xmp>() { _xmp1, _xmp2 };
    public IList<Computer.Computer> Computers { get; } = new List<Computer.Computer>();

    public void AddCpu(Cpu cpu)
    {
        СpuList.Add(cpu);
    }

    public void AddBios(Bios bios)
    {
        BiosList.Add(bios);
    }

    public void AddCoolingSystem(CoolingSystem coolingSystem)
    {
        CoolingSystems.Add(coolingSystem);
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

    public void AddSystemCase(SystemCase systemCase)
    {
        SystemCases.Add(systemCase);
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

    public void AddComputer(Computer.Computer computer)
    {
        Computers.Add(computer);
    }
}