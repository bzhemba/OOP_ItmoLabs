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
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Exceptions.ComponentsExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Validator;

public class CheckXmpCompatibility : Validator
{
    public override bool Check(Cpu cpu, Bios bios, Motherboard motherboard, CoolingSystem.CoolingSystem coolingSystem, Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemCases.SystemUnit systemUnit, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile)
    {
        if (motherboard != null && xmpProfile != null && (!motherboard.Chipset.HaveXmp || !xmpProfile.IsCompatible(cpu)))
        {
            throw new IncompatibilityProblemException("XMP incompatibility");
        }

        return motherboard != null && CheckNext(cpu, bios, motherboard, coolingSystem, ram, videoCard, ssd, hdd, systemUnit, powerUnit, wifiAdapter, xmpProfile);
    }
}