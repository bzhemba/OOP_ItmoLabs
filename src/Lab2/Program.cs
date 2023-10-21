// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCases;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Repository;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.SsdCharacteristics;
// using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.VideoCardCharacteristics;
//
// namespace Itmo.ObjectOrientedProgramming.Lab2;
//
// internal class Program
// {
//     private const int CoresAmountIntelCeleron = 2;
//     private const int CoresFrequencyIntelCeleron = 1050;
//     private const int TdpIntelCeleron = 58;
//     private const int MemoryFrequencyIntelCeleron = 2666;
//     private const int PowerConsumptionIntelCeleron = 70;
//
//     private const int CoresAmountIntelPentium = 2;
//     private const int CoresFrequencyIntelPentium = 1000;
//     private const int TdpIntelPentium = 54;
//     private const int MemoryFrequencyIntelPentium = 3200;
//     private const int PowerConsumptionIntelPentium = 65;
//
//     private const int CoresAmountAMDPhenom = 4;
//     private const int CoresFrequencyAMDPhenom = 3000;
//     private const int TdpAMDPhenom = 125;
//     private const int MemoryFrequencyAMDPhenom = 2100;
//     private const int PowerConsumptionAMDPhenom = 95;
//
//     private const int CoresAmountIntelCorei7 = 8;
//     private const int CoresFrequencyIntelCorei7 = 4000;
//     private const int TdpIntelCorei7 = 140;
//     private const int MemoryFrequencyIntelCorei7 = 3500;
//     private const int PowerConsumptionIntelCorei7 = 95;
//     private static Cpu _amdPhenomCpu = new CpuBuilder().WithSocket(new Socket(new SocketName("SocketAm4")))
//         .WithCoresAmount(new Amount(CoresAmountAMDPhenom)).WithCoresFrequency(new Frequency(CoresFrequencyAMDPhenom))
//         .WithMemoryFrequency(new Frequency(MemoryFrequencyAMDPhenom))
//         .WithPowerConsumption(new PowerConsumption(PowerConsumptionAMDPhenom))
//         .WithTDP(new Tdp(TdpAMDPhenom)).Build();
//
//     private static Cpu _intelCorei7Cpu = new CpuBuilder().WithSocket(new Socket(new SocketName("Lga1155")))
//         .WithCoresAmount(new Amount(CoresAmountIntelCorei7)).WithCoresFrequency(new Frequency(CoresFrequencyIntelCorei7))
//         .WithMemoryFrequency(new Frequency(MemoryFrequencyIntelCorei7))
//         .WithPowerConsumption(new PowerConsumption(PowerConsumptionIntelCorei7)).WithTDP(new Tdp(TdpIntelCorei7)).Build();
//
//     private static Cpu _intelCeleronCpu = new CpuBuilder().WithSocket(new Socket(new SocketName("SocketAm4")))
//         .WithCoresAmount(new Amount(CoresAmountIntelCeleron)).WithCoresFrequency(new Frequency(CoresFrequencyIntelCeleron))
//         .WithMemoryFrequency(new Frequency(MemoryFrequencyIntelCeleron))
//         .WithPowerConsumption(new PowerConsumption(PowerConsumptionIntelCeleron)).WithTDP(new Tdp(TdpIntelCeleron)).Build();
//
//     private static Cpu _intelPentiumCpu = new CpuBuilder().WithSocket(new Socket(new SocketName("Lga1200")))
//         .WithCoresAmount(new Amount(CoresAmountIntelPentium)).WithCoresFrequency(new Frequency(CoresFrequencyIntelPentium))
//         .WithMemoryFrequency(new Frequency(MemoryFrequencyIntelPentium))
//         .WithPowerConsumption(new PowerConsumption(PowerConsumptionIntelPentium)).WithTDP(new Tdp(TdpIntelPentium)).Build();
//
//     private static ICollection<Cpu> _supportiveCpus1 = new List<Cpu>() { _intelPentiumCpu, _intelCorei7Cpu };
//     private static ICollection<Cpu> _supportiveCpus2 = new List<Cpu>() { _intelCeleronCpu, _amdPhenomCpu };
//
//     private static Bios _bios1 = new BiosBuilder().WithType(BiosType.Intel).WithVersion(new BiosVersion("2.02.2")).WithSupportiveCpus(_supportiveCpus1).Build();
//     private static Bios _bios2 = new BiosBuilder().WithType(BiosType.Ami).WithVersion(new BiosVersion("3.02.22")).WithSupportiveCpus(_supportiveCpus2).Build();
//
//     private static Cooler _coolerMasterCooler = new CoolingSystemBuilder()
//         .WithDimensions(new Dimensions(120, 120, 25)).WithSupportiveSockets(new List<Socket> { new Socket(new SocketName("SocketAm4")), new Socket(new SocketName("Lga1200")) })
//         .WithMaxTdp(new Tdp(150)).Build();
//
//     private static Cooler _noctuaCooler = new CoolingSystemBuilder()
//         .WithDimensions(new Dimensions(140, 140, 25)).WithSupportiveSockets(new List<Socket> { new Socket(new SocketName("SocketG2")), new Socket(new SocketName("Lga1155")) })
//         .WithMaxTdp(new Tdp(200)).Build();
//
//     private static Hdd _hdd1 = new HddBuilder().WithCapacity(new Capacity(1000)).WithSpindleSpeed(new Speed(7200)).WithPowerConsumption(new PowerConsumption(10)).Build();
//     private static Hdd _hdd2 = new HddBuilder().WithCapacity(new Capacity(2000)).WithSpindleSpeed(new Speed(5400)).WithPowerConsumption(new PowerConsumption(8)).Build();
//     private static Motherboard _motherboard1 = new MotherboardBuilder()
//         .WithSocket(new Socket(new SocketName("SocketAm4")))
//         .WithPciLinesAmount(new Amount(4))
//         .WithSataPortsAmount(new Amount(6))
//         .WithChipset(new Chipset(ChipsetType.B460))
//         .WithDdrVersion(new DdrVersion(4))
//         .WithSlotsAmount(new Amount(4))
//         .WithFormFactor(FormFactor.Аtx)
//         .WithBiosType(BiosType.Uefi)
//         .WithBiosVersion(new BiosVersion("01.2.23"))
//         .WithWifiModule(true)
//         .Build();
//
//     private static Motherboard _motherboard2 = new MotherboardBuilder()
//         .WithSocket(new Socket(new SocketName("Lga1155")))
//         .WithPciLinesAmount(new Amount(3))
//         .WithSataPortsAmount(new Amount(4))
//         .WithChipset(new Chipset(ChipsetType.H470))
//         .WithDdrVersion(new DdrVersion(5))
//         .WithSlotsAmount(new Amount(2))
//         .WithFormFactor(FormFactor.MicroAtx)
//         .WithBiosType(BiosType.Intel)
//         .WithBiosVersion(new BiosVersion("3.02.22"))
//         .WithWifiModule(false)
//         .Build();
//
//     private static Motherboard _motherboard3 = new MotherboardBuilder()
//         .WithSocket(new Socket(new SocketName("Lga1200")))
//         .WithPciLinesAmount(new Amount(5))
//         .WithSataPortsAmount(new Amount(8))
//         .WithChipset(new Chipset(ChipsetType.Q470))
//         .WithDdrVersion(new DdrVersion(4))
//         .WithSlotsAmount(new Amount(8))
//         .WithFormFactor(FormFactor.MiniAtx)
//         .WithBiosType(BiosType.Ami)
//         .WithBiosVersion(new BiosVersion("2.02.2"))
//         .WithWifiModule(false)
//         .Build();
//     private static PowerUnit _powerUnit1 = new PowerUnitBuilder().WithPeakload(new PeakLoad(1000)).Build();
//     private static PowerUnit _powerUnit2 = new PowerUnitBuilder().WithPeakload(new PeakLoad(500)).Build();
//     private static Xmp _xmp1 = new XmpBuilder()
//         .WithTimings(new List<int> { 15, 17, 17, 35 })
//         .WithVoltage(new Voltage(1.35))
//         .WithFrequency(new Frequency(3200))
//         .Build();
//
//     private static Xmp _xmp2 = new XmpBuilder()
//         .WithTimings(new List<int> { 16, 18, 18, 36 })
//         .WithVoltage(new Voltage(1.2))
//         .WithFrequency(new Frequency(2000))
//         .Build();
//
//     private static Ram _ram1 = new RamBuilder()
//         .WithMemorySize(new MemorySize(8))
//         .WithFormFactor(RamFormFactor.Dimm)
//         .WithXmp(_xmp1)
//         .WithDdrVersion(new DdrVersion(4))
//         .WithPowerConsumption(new PowerConsumption(10))
//         .WithSupportiveFrequencyVoltagePairs(new List<(Frequency Frequency, Voltage Voltage)>
//         {
//             (new Frequency(3200), new Voltage(1.35)),
//             (new Frequency(2400), new Voltage(1.2)),
//         })
//         .Build();
//
//     private static Ram _ram2 = new RamBuilder()
//         .WithMemorySize(new MemorySize(16))
//         .WithFormFactor(RamFormFactor.SoDimm)
//         .WithXmp(_xmp1)
//         .WithDdrVersion(new DdrVersion(4))
//         .WithPowerConsumption(new PowerConsumption(12))
//         .WithSupportiveFrequencyVoltagePairs(new List<(Frequency Frequency, Voltage Voltage)>
//         {
//             (new Frequency(2666), new Voltage(1.35)),
//             (new Frequency(2133), new Voltage(1.2)),
//         })
//         .Build();
//
//     private static Ram _ram3 = new RamBuilder()
//         .WithMemorySize(new MemorySize(8))
//         .WithFormFactor(RamFormFactor.Dimm)
//         .WithXmp(_xmp1)
//         .WithDdrVersion(new DdrVersion(5))
//         .WithPowerConsumption(new PowerConsumption(10))
//         .WithSupportiveFrequencyVoltagePairs(new List<(Frequency Frequency, Voltage Voltage)>
//         {
//             (new Frequency(4800), new Voltage(2.35)),
//         })
//         .Build();
//     private static Ssd _ssd1 = new SsdBuilder()
//         .WithConnection(Connection.Sata)
//         .WithCapacity(new Capacity(500))
//         .WithMaxSpeed(new Speed(550))
//         .WithPowerConsumption(new PowerConsumption(2))
//         .Build();
//     private static Ssd _ssd2 = new SsdBuilder()
//         .WithConnection(Connection.Pci)
//         .WithCapacity(new Capacity(1000))
//         .WithMaxSpeed(new Speed(3500))
//         .WithPowerConsumption(new PowerConsumption(4))
//         .Build();
//     private static Ssd _ssd3 = new SsdBuilder()
//         .WithConnection(Connection.Pci)
//         .WithCapacity(new Capacity(4096))
//         .WithMaxSpeed(new Speed(5000))
//         .WithPowerConsumption(new PowerConsumption(7))
//         .Build();
//     private static SystemUnit _systemUnit1 = new SystemUnitBuilder()
//         .WithVideoCardDimensions(new VideoCardDimensions(280, 128))
//         .WithSupportiveFormFactors(new List<FormFactor> { FormFactor.MiniAtx, FormFactor.MicroAtx })
//         .WithDimensions(new Dimensions(400, 200, 350))
//         .Build();
//     private static SystemUnit _systemUnit2 = new SystemUnitBuilder()
//         .WithVideoCardDimensions(new VideoCardDimensions(320, 140))
//         .WithSupportiveFormFactors(new List<FormFactor> { FormFactor.Аtx, FormFactor.MiniAtx })
//         .WithDimensions(new Dimensions(350, 170, 300))
//         .Build();
//     private static SystemUnit _systemUnit3 = new SystemUnitBuilder()
//         .WithVideoCardDimensions(new VideoCardDimensions(320, 140))
//         .WithSupportiveFormFactors(new List<FormFactor> { FormFactor.Аtx, FormFactor.MicroAtx })
//         .WithDimensions(new Dimensions(400, 190, 189))
//         .Build();
//     private static VideoCard _videoCard1 = new VideoCardBuilder()
//         .WithVideoCardDimensions(new VideoCardDimensions(280, 128))
//     .WithVideoMemoryAmount(new MemorySize(8))
//     .WithPciVersion(new VersionNumber(3))
//     .WithChipFrequency(new Frequency(1600))
//     .WithPowerConsumption(new PowerConsumption(120))
//     .Build();
//     private static VideoCard _videoCard2 = new VideoCardBuilder()
//         .WithVideoCardDimensions(new VideoCardDimensions(320, 140))
//         .WithVideoMemoryAmount(new MemorySize(16))
//         .WithPciVersion(new VersionNumber(4))
//         .WithChipFrequency(new Frequency(2000))
//         .WithPowerConsumption(new PowerConsumption(150))
//         .Build();
//     private static WifiAdapter _wifiAdapter1 = new WifiAdapterBuilder()
//         .WithStandartVersion(new VersionNumber(4))
//         .WithPciVersion(new VersionNumber(3))
//         .WithPowerConsumption(new PowerConsumption(5))
//         .Build();
//     private static WifiAdapter _wifiAdapter2 = new WifiAdapterBuilder()
//         .WithStandartVersion(new VersionNumber(6))
//         .WithPciVersion(new VersionNumber(4))
//         .WithPowerConsumption(new PowerConsumption(8))
//         .Build();
//
//     private static PersonalComputer _personalComputerDexp = new PersonalComputer(
//         _intelPentiumCpu,
//         _bios1,
//         _coolerMasterCooler,
//         null,
//         _motherboard3,
//         _powerUnit1,
//         _ram1,
//         _ssd1,
//         _systemUnit2,
//         _videoCard1,
//         null,
//         _xmp1);
//     private static PersonalComputer _personalComputerGigabyte = new PersonalComputer(
//         _intelCorei7Cpu,
//         _bios1,
//         _noctuaCooler,
//         null,
//         _motherboard2,
//         _powerUnit1,
//         _ram3,
//         _ssd3,
//         _systemUnit3,
//         _videoCard1,
//         _wifiAdapter1,
//         _xmp1);
//     private static PersonalComputer _personalComputerAsus = new PersonalComputer(
//         _amdPhenomCpu,
//         _bios2,
//         _coolerMasterCooler,
//         _hdd2,
//         _motherboard1,
//         _powerUnit2,
//         _ram1,
//         null,
//         _systemUnit2,
//         _videoCard2,
//         null,
//         null);
//     private static Repository _repository = new Repository();
//     public static void Main()
//     {
//         FillRepository(_repository);
//         IComputerBuilder computerBuilder = new ComputerBuilder();
//         var cpuCriteria = new CpuCriteria(null, null, null, new Socket(new SocketName("Lga1200")));
//         var motherboardCriteria = new MotherboardCriteria(new DdrVersion(4), new Socket(new SocketName("Lga1200")), BiosType.Ami, null);
//         var biosCriteria = new BiosCriteria(BiosType.Ami, null);
//         var coolerCriteria = new CoolerCriteria(new Dimensions(120, 120, 25), new Tdp(150));
//         var powerUnitCriteria = new PowerUnitCriteria(new PeakLoad(1000));
//         var ramCriteria = new RamCriteria(null, RamFormFactor.Dimm, new PowerConsumption(10), new DdrVersion(4));
//         var ssdCriteria = new SsdCriteria(Connection.Sata, new Capacity(500), new Speed(550), new PowerConsumption(2));
//         var systemUnitCriteria =
//             new SystemUnitCriteria(new VideoCardDimensions(320, 140), new Dimensions(400, 200, 350));
//         var videocardCriteria = new VideocardCriteria(null, null, new VideoCardDimensions(280, 128));
//         var xmpCriteria = new XmpCriteria(new Voltage(1.35), new Frequency(3200));
//         Cpu compatibleCpu = _repository.GetCpuWith(cpuCriteria);
//         Console.WriteLine(1111);
//         Console.WriteLine(compatibleCpu.MemoryFrequency);
//         Motherboard motherboard = _repository.GetMotherboardWith(motherboardCriteria).First();
//         Bios bios = _repository.GetBiosWith(biosCriteria).First();
//         Cooler cooler = _repository.GetCoolerWith(coolerCriteria).First();
//         PowerUnit powerUnit = _repository.GetPowerUnitWith(powerUnitCriteria).First();
//         Ram ram = _repository.GetRamWith(ramCriteria).First();
//         Ssd ssd = _repository.GetSsdWith(ssdCriteria).First();
//         SystemUnit systemUnit = _repository.GetSystemUnitWith(systemUnitCriteria).First();
//         VideoCard videoCard = _repository.GetVideocardWith(videocardCriteria).First();
//         Xmp xmp = _repository.GetXmpWith(xmpCriteria).First();
//         Notification newComputer = computerBuilder.WithMotherBoard(motherboard).WithCpu(compatibleCpu).WithBios(bios).WithCoolingSystem(cooler)
//             .WithRam(ram).WithXmp(xmp).WithVideoCard(videoCard).WithSsd(ssd).WithHdd(null).WithSystemCase(systemUnit)
//             .WithPowerUnit(powerUnit).WithWifiAdapter(null).Build();
//         Console.WriteLine(newComputer);
//     }
//
//     private static void FillRepository(Repository repository)
//     {
//         if (repository != null)
//         {
//             repository.AddCpu(_intelPentiumCpu);
//             repository.AddCpu(_intelCorei7Cpu);
//             repository.AddCpu(_intelCeleronCpu);
//             repository.AddCpu(_amdPhenomCpu);
//
//             repository.AddBios(_bios1);
//             repository.AddBios(_bios2);
//
//             repository.AddCoolingSystem(_noctuaCooler);
//             repository.AddCoolingSystem(_coolerMasterCooler);
//
//             repository.AddHdd(_hdd1);
//             repository.AddHdd(_hdd2);
//
//             repository.AddMotherboard(_motherboard1);
//             repository.AddMotherboard(_motherboard2);
//             repository.AddMotherboard(_motherboard3);
//
//             repository.AddPowerUnit(_powerUnit1);
//             repository.AddPowerUnit(_powerUnit2);
//
//             repository.AddRam(_ram1);
//             repository.AddRam(_ram2);
//             repository.AddRam(_ram3);
//
//             repository.AddSsd(_ssd1);
//             repository.AddSsd(_ssd2);
//             repository.AddSsd(_ssd3);
//
//             repository.AddSystemUnit(_systemUnit1);
//             repository.AddSystemUnit(_systemUnit2);
//             repository.AddSystemUnit(_systemUnit3);
//
//             repository.AddVideoCard(_videoCard1);
//             repository.AddVideoCard(_videoCard2);
//
//             repository.AddWifiAdapter(_wifiAdapter1);
//             repository.AddWifiAdapter(_wifiAdapter2);
//
//             repository.AddXmp(_xmp1);
//             repository.AddXmp(_xmp2);
//
//             repository.AddComputer(_personalComputerAsus);
//             repository.AddComputer(_personalComputerDexp);
//             repository.AddComputer(_personalComputerGigabyte);
//         }
//     }
// }