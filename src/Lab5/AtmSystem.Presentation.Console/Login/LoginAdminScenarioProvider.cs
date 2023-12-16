using System.Diagnostics.CodeAnalysis;
using ATMSystem.Application.Contracts.Users;

namespace AtmSystem.Presentation.Console.Login;

public class LoginAdminScenarioProvider : IAdminScenarioProvider
{
    private readonly IAdminService _adminService;

    public LoginAdminScenarioProvider(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new LoginAdminScenario(_adminService);
        return true;
    }
}