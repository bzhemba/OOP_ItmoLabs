using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.PowerUnitCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;

public class PowerUnit
{
    private const int RecommendedPowerStock = 100;
    private PeakLoad _peakLoad;
    public PowerUnit(PeakLoad peakLoad)
    {
        _peakLoad = peakLoad;
    }

    public Notification IsPeakLoadEnough(Cpu cpuWithoutVideoCore, Hdd? hdd, Ssd? ssd, Ram ram, VideoCard? videocard, WifiAdapter? wifiAdapter)
    {
        int totalPowerConsumption = 0;
        if (cpuWithoutVideoCore != null && ram != null) totalPowerConsumption = cpuWithoutVideoCore.PowerConsumption.Watt + ram.PowerConsumption.Watt;
        if (hdd != null)
        {
            totalPowerConsumption += hdd.PowerConsumption.Watt;
        }
        else if (ssd != null)
        {
            totalPowerConsumption += ssd.PowerConsumption.Watt;
        }

        if (wifiAdapter != null)
        {
            totalPowerConsumption += wifiAdapter.PowerConsumption.Watt;
        }

        if (videocard != null)
        {
            totalPowerConsumption += videocard.PowerConsumption.Watt;
        }

        return (_peakLoad.Watt - totalPowerConsumption) switch
        {
            >= RecommendedPowerStock => new Ok(),
            < RecommendedPowerStock and >= 0 => new NonComplianceOfRecommendedPeakLoad(),
            _ => new IncompatibilityProblem(null),
        };
    }

    public PowerUnitBuilder Direct(PowerUnitBuilder builder)
    {
        if (builder != null)
        {
            builder.WithPeakload(_peakLoad).Build();
            return builder;
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }
    }
}