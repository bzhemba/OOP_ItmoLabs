using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.PU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.SystemCases;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.Notifications;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Validator;

public abstract class Validator
{
    private Validator? _nextHandler;
    protected DisclaimerOfWarrantyObligations? Disclaimer { get; set; }
    protected NonComplianceOfRecommendedPeakLoad? Recommendation { get; set; }
    public static Validator Link(Validator head, params Validator[] chain)
    {
        Validator internalHead = head;
        if (chain == null) return head;
        foreach (Validator nextLink in chain)
        {
            if (internalHead != null) internalHead._nextHandler = nextLink;
            internalHead = nextLink;
        }

        return head;
    }

    public abstract Notification Check(Cpu cpu, Bios bios, Motherboard motherboard, Cooler cooler, Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemUnit systemUnit, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile);
    protected Notification CheckNext(Cpu cpu, Bios bios, Motherboard motherboard, Cooler cooler,  Ram ram, VideoCard? videoCard, Ssd? ssd, Hdd? hdd, SystemUnit systemUnit, PowerUnit powerUnit, WifiAdapter? wifiAdapter, Xmp? xmpProfile)
    {
        if (_nextHandler == null)
        {
            return new Success(
                new PersonalComputer(
                cpu,
                bios,
                cooler,
                hdd,
                motherboard,
                powerUnit,
                ram,
                ssd,
                systemUnit,
                videoCard,
                wifiAdapter,
                xmpProfile),
                Disclaimer,
                Recommendation);
        }

        return _nextHandler.Check(cpu, bios, motherboard, cooler, ram, videoCard, ssd, hdd, systemUnit, powerUnit, wifiAdapter, xmpProfile);
    }
}