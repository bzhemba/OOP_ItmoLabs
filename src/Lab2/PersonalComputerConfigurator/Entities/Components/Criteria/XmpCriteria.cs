using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class XmpCriteria
{
    public XmpCriteria(Voltage? voltage, Frequency? frequency)
    {
        Voltage = voltage;
        Frequency = frequency;
    }

    public Voltage? Voltage { get; }

    public Frequency? Frequency { get; }
}