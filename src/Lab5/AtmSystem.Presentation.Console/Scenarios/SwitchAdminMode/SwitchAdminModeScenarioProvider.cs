using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.Users;

namespace AtmSystem.Presentation.Console.Scenarios.SwitchAdminMode;

public class SwitchAdminModeScenarioProvider : IUserScenarioProvider
{
    private IAdminService _adminService;

    public SwitchAdminModeScenarioProvider(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new SwitchAdminModeScenario(_adminService);
        return true;
    }
}