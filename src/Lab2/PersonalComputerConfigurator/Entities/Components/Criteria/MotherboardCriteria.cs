using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.BiosCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models.RamCharacterisics;

namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Criteria;

public class MotherboardCriteria
{
    public MotherboardCriteria(DdrVersion? supportiveDdrVersion, Socket? cpuSocket, BiosType? biosType, BiosVersion? biosVersion)
    {
        SupportiveDdrVersion = supportiveDdrVersion;
        CpuSocket = cpuSocket;
        BiosType = biosType;
        BiosVersion = biosVersion;
    }

    public DdrVersion? SupportiveDdrVersion { get; }
    public Socket? CpuSocket { get; }
    public BiosType? BiosType { get; }
    public BiosVersion? BiosVersion { get; }
}