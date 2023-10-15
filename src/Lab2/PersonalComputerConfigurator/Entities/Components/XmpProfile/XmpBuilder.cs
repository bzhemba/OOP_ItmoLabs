using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.XmpProfileCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.NullObjectExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.XmpProfile;

public class XmpBuilder
{
    private IReadOnlyCollection<int>? _timings;
    private Voltage? _voltage;
    private Frequency? _frequency;
    public XmpBuilder WithTimings(IReadOnlyCollection<int> timings)
    {
        _timings = timings;
        return this;
    }

    public XmpBuilder WithVoltage(Voltage voltage)
    {
        _voltage = voltage;
        return this;
    }

    public XmpBuilder WithFrequency(Frequency frequency)
    {
        _frequency = frequency;
        return this;
    }

    public Xmp Build()
    {
        if (_timings != null && _voltage != null && _frequency != null)
        {
            return new Xmp(_timings, _frequency, _voltage);
        }
        else
        {
            throw new NullObjectException("Unable to create component, some parts are missing");
        }
    }
}