using System.Collections.Generic;
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
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.ComponentsExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;
using Xunit;
using FormFactor = Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.MotherboardCharacteristics.FormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PersonalComputerConfiguratorTest
{
    private static Repository _repository = new Repository();
    private IList<Cpu> _cpuStorage = _repository.СpuList;
    private IList<Bios> _biosStorage = _repository.BiosList;
    private IList<CoolingSystem> _coolingSystemStorage = _repository.CoolingSystems;
    private IList<Hdd> _hddStorage = _repository.Hdds;
    private IList<Motherboard> _motherboardStorage = _repository.Motherboards;
    private IList<PowerUnit> _powerUnitStorage = _repository.PowerUnits;
    private IList<Ram> _ramStorage = _repository.Rams;
    private IList<Ssd> _ssdStorage = _repository.SsdList;
    private IList<SystemUnit> _systemCaseStorage = _repository.SystemCases;
    private IList<VideoCard> _videoCardStorage = _repository.VideoCards;
    private IList<WifiAdapter> _wifiAdapterStorage = _repository.WifiAdapters;
    private IList<Xmp> _xmpStorage = _repository.Xmps;
    private IList<Computer> _computerStorage = _repository.Computers;
    [Fact]
    public void ConfigurateCompatiblePC()
    {
        IComputerBuilder computerBuilder = new ComputerBuilder();
        Cpu cpu = _cpuStorage[0];
        Motherboard motherboard = _motherboardStorage[2];
        Bios bios = _biosStorage[0];
        CoolingSystem coolingSystem = _coolingSystemStorage[0];
        PowerUnit powerUnit = _powerUnitStorage[0];
        Ram ram = _ramStorage[0];
        Ssd ssd = _ssdStorage[0];
        SystemUnit systemUnit = _systemCaseStorage[1];
        VideoCard videoCard = _videoCardStorage[0];
        Xmp xmp = _xmpStorage[0];
        (AddNotification notification,  _) = computerBuilder.WithMotherBoard(motherboard).WithCpu(cpu).WithBios(bios).WithCoolingSystem(coolingSystem)
            .WithRam(ram).WithXmp(xmp).WithVideoCard(videoCard).WithSsd(ssd).WithHdd(null).WithSystemCase(systemUnit)
            .WithPowerUnit(powerUnit).WithWifiAdapter(null).Build();
        Assert.Equal(new Success(), notification);
    }

    [Fact]
    public void ConfiguratePCWithPeakLoadWarning()
    {
        Computer computer = _computerStorage[2];
        var newComputer = new ComputerDirector();
        newComputer = computer.Direct(newComputer);
        PowerUnit newPowerUnit = new PowerUnitBuilder().WithPeakload(new PeakLoad(300)).Build();
        (AddNotification? notification, _) = newComputer.WithPowerUnit(newPowerUnit).Build();
        Assert.Equal(new Success(), notification);
    }

    [Fact]
    public void ConfiguratePCWithTDPWarning()
    {
        IComputerBuilder computerBuilder = new ComputerBuilder();
        Cpu cpu = _cpuStorage[0];
        CpuBuilder cpuWithModifiedTdp = cpu.Clone();
        cpuWithModifiedTdp.WithTDP(new Tdp(200));
        Motherboard motherboard = _motherboardStorage[2];
        Bios bios = _biosStorage[0];
        CoolingSystem coolingSystem = _coolingSystemStorage[0];
        PowerUnit powerUnit = _powerUnitStorage[0];
        Ram ram = _ramStorage[0];
        Hdd hdd = _hddStorage[0];
        SystemUnit systemUnit = _systemCaseStorage[1];
        VideoCard videoCard = _videoCardStorage[0];
        Xmp xmp = _xmpStorage[0];
        WifiAdapter wifiAdapter = _wifiAdapterStorage[1];
        (AddNotification? notification, _) = computerBuilder.WithMotherBoard(motherboard).WithCpu(cpu).WithBios(bios).WithCoolingSystem(coolingSystem)
            .WithRam(ram).WithXmp(xmp).WithVideoCard(videoCard).WithSsd(null).WithHdd(hdd).WithSystemCase(systemUnit)
            .WithPowerUnit(powerUnit).WithWifiAdapter(wifiAdapter).Build();
        Assert.Equal(new Success(), notification);
    }

    [Fact]
    public void ConfiguratePCWithIncompatibileSocketsThrowExceptionTest()
    {
        IComputerBuilder computerBuilder = new ComputerBuilder();
        Cpu cpu = _cpuStorage[3];
        CpuBuilder cpuWithModifiedTdp = cpu.Clone();
        cpuWithModifiedTdp.WithTDP(new Tdp(200));
        Motherboard motherboard = new MotherboardBuilder().WithSocket(Socket.SocketG2)
            .WithChipset(new Chipset(ChipsetType.W480, true)).WithFormFactor(FormFactor.MiniItx)
            .WithDdrVersion(new DdrVersion(2)).BiosTypeVersion(new BiosTypeVersion(BiosType.Phoenix, new BiosVersion("1.00.24")))
            .WithSlotsAmount(new SlotsAmount(4)).WithWifiModule(true).WithPciLinesAmount(new PciLinesAmount(23))
            .WithPciLinesAmount(new PciLinesAmount(21)).WithSataPortsAmount(new SataPortsAmount(12)).Build();
        Bios bios = _biosStorage[0];
        CoolingSystem coolingSystem = _coolingSystemStorage[1];
        PowerUnit powerUnit = _powerUnitStorage[1];
        Ram ram = _ramStorage[1];
        Hdd hdd = _hddStorage[1];
        SystemUnit systemUnit = _systemCaseStorage[1];
        VideoCard videoCard = _videoCardStorage[0];
        Xmp xmp = _xmpStorage[0];
        WifiAdapter wifiAdapter = _wifiAdapterStorage[1];
        Assert.Throws<IncompatibilityProblemException>(() => computerBuilder.WithMotherBoard(motherboard).WithCpu(cpu)
            .WithBios(bios).WithCoolingSystem(coolingSystem)
            .WithRam(ram).WithXmp(xmp).WithVideoCard(videoCard).WithSsd(null).WithHdd(hdd).WithSystemCase(systemUnit)
            .WithPowerUnit(powerUnit).WithWifiAdapter(wifiAdapter).Build());
    }
}