using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

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
        return new Xmp(
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)),
            _voltage ?? throw new ArgumentNullException(nameof(_voltage)));
    }
}