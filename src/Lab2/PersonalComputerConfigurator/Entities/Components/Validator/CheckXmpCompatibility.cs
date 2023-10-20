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

public class CheckXmpCompatibility : Validator
{
    public override Notification Check(Cpu cpu, Bios bios, Motherboard motherboard, CoolingSystem.Cooler cooler, Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemCases.SystemUnit systemUnit, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile)
    {
        if (motherboard != null && xmpProfile != null && (!motherboard.Chipset.HaveXmp || !xmpProfile.IsCompatible(cpu)))
        {
            return new IncompatibilityProblem("XMP incompatibility");
        }

        return CheckNext(
            cpu,
            bios,
            motherboard ?? throw new ArgumentNullException(nameof(motherboard)),
            cooler,
            ram,
            videoCard,
            ssd,
            hdd,
            systemUnit,
            powerUnit,
            wifiAdapter ?? throw new ArgumentNullException(nameof(wifiAdapter)),
            xmpProfile);
        }
    }