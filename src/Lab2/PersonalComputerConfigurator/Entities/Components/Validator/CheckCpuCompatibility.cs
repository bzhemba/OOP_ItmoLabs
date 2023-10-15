namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Entities.Components.Validator;

public class CheckCpuCompatibility : Validator
{
    public NotificationSystem IsCompatible(Cpu cpu)
    {
        return _supportiveCpus.Any(supportiveCpu => cpu == supportiveCpu)
            ? NotificationSystem.Ok : NotificationSystem.IncompatibilityProblem;
    }

    public Validator HadleRequest()
    {
        throw new System.NotImplementedException();
    }
}