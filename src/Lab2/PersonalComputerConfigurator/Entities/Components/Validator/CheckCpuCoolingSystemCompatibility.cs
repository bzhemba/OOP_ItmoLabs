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

public class CheckCpuCoolingSystemCompatibility : Validator
{
    public override bool Check(Cpu cpu, Bios bios, Motherboard motherboard, CoolingSystem.CoolingSystem coolingSystem, Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemCase.SystemCase systemCase, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile)
    {
        if (coolingSystem != null && coolingSystem.IsCompatible(cpu))
        {
            return CheckNext(cpu, bios, motherboard, coolingSystem, ram, videoCard, ssd, hdd, systemCase, powerUnit, wifiAdapter, xmpProfile);
        }
        else
        {
            DisclaimerOfWarrantyObligations = new DisclaimerOfWarrantyObligations(null);
            return coolingSystem != null && CheckNext(cpu, bios, motherboard, coolingSystem, ram, videoCard, ssd, hdd, systemCase, powerUnit, wifiAdapter, xmpProfile);
        }
    }
}