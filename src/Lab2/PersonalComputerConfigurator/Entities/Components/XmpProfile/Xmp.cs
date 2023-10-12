using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.XmpProfileCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;

public class Xmp
{
    private IReadOnlyCollection<int> _timings;

    public Xmp(IReadOnlyCollection<int> timings, Frequency frequency, Voltage voltage)
    {
        _timings = timings;
        Frequency = frequency;
        Voltage = voltage;
    }

    public Voltage Voltage { get; }

    public Frequency Frequency { get; }
}