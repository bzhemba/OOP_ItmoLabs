using System;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Validator;

public class CheckPowerUnit : Validator
{
    public override Notification Check(Cpu cpu, Bios bios, Motherboard motherboard, CoolingSystem.Cooler cooler, Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemCases.SystemUnit systemUnit, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile)
    {
        Notification result = new Ok();
        if (powerUnit != null)
        {
            result = powerUnit.IsPeakLoadEnough(cpu, hdd, ssd, ram, videoCard, wifiAdapter);
        }

        switch (result)
        {
            case NonComplianceOfRecommendedPeakLoad:
                Recommendation = new NonComplianceOfRecommendedPeakLoad();
                return CheckNext(
                    cpu,
                    bios,
                    motherboard,
                    cooler,
                    ram,
                    videoCard,
                    ssd,
                    hdd,
                    systemUnit,
                    powerUnit ?? throw new ArgumentNullException(nameof(powerUnit)),
                    wifiAdapter,
                    xmpProfile);
            case IncompatibilityProblem:
                return new IncompatibilityProblem("Power Unit incompatibility");
            default:
                return CheckNext(
                    cpu,
                    bios,
                    motherboard,
                    cooler,
                    ram,
                    videoCard,
                    ssd,
                    hdd,
                    systemUnit,
                    powerUnit ?? throw new ArgumentNullException(nameof(powerUnit)),
                    wifiAdapter,
                    xmpProfile);
        }
    }
}