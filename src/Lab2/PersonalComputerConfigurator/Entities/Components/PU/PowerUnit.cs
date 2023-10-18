using System.Runtime.Serialization;
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
    private PeakLoad _peakLoad;

    public AddNotification IsPeakLoadEnough(Cpu cpu, Hdd? hdd, Ssd? ssd, Ram ram, VideoCard? videocard, WifiAdapter? wifiAdapter)
    {
        int totalPowerConsumption = 0;
        if (cpu != null && ram != null) totalPowerConsumption = cpu.PowerConsumption.Watt + ram.PowerConsumption.Watt;
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
            >= 100 => new Ok(),
            < 100 and >= 0 => new NonComplianceOfRecommendedPeakLoad(),
            _ => new IncompatibilityProblem(null),
        };
    }

    public PowerUnit(PeakLoad peakLoad)
    {
        _peakLoad = peakLoad;
    }
}