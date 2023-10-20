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

public class CheckExistence : Validator
{
    public override Notification Check(Cpu cpu, Bios bios, Motherboard motherboard, CoolingSystem.Cooler cooler, Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemCases.SystemUnit systemUnit, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile)
    {
        if ((cpu != null && bios != null && motherboard != null && ram != null && systemUnit != null && powerUnit != null && cooler != null) && (ssd != null || hdd != null) && (cpu.HasVideoCore || videoCard != null))
        {
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
                powerUnit,
                wifiAdapter,
                xmpProfile);
        }
        else
        {
            return new MissingComponent("Some components are missing");
        }
    }
}