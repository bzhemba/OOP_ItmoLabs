using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.Users;

namespace AtmSystem.Presentation.Console.Scenarios.SetSystemPassword;

public class SetSystemPasswordScenarioProvider : IAdminScenarioProvider
{
    private readonly IAdminService _adminService;

    public SetSystemPasswordScenarioProvider(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new SetSystemPasswordScenario(_adminService);
        return true;
    }
}