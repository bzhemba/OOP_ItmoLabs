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
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Validator;

public abstract class Validator
{
    private Validator? _nextHandler;
    public AddNotification Notification { get; protected set; } = new Ok();
    public DisclaimerOfWarrantyObligations? DisclaimerOfWarrantyObligations { get; protected set; }
    public static Validator Link(Validator head, params Validator[] chain)
    {
        Validator internalHead = head;
        if (chain != null)
        {
            foreach (Validator nextLink in chain)
            {
                if (internalHead != null) internalHead._nextHandler = nextLink;
                internalHead = nextLink;
            }
        }

        return head;
    }

    public abstract bool Check(Cpu cpu, Bios bios, Motherboard motherboard, CoolingSystem.CoolingSystem coolingSystem, Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemCase.SystemCase systemCase, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile);
    protected bool CheckNext(Cpu cpu, Bios bios, Motherboard motherboard, CoolingSystem.CoolingSystem coolingSystem,  Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemCase.SystemCase systemCase, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile)
    {
        return _nextHandler == null || _nextHandler.Check(cpu, bios, motherboard, coolingSystem, ram, videoCard, ssd, hdd, systemCase, powerUnit, wifiAdapter, xmpProfile);
    }
}