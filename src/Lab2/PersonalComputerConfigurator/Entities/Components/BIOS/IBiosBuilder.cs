using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.BIOS;

public interface IBiosBuilder
{
    IBiosBuilder WithType(Type type);
    IBiosBuilder WithVersion(Version version);
    IBiosBuilder WithSupportiveCpus(IReadOnlyCollection<Cpu> cpus);
    Bios Build();
}