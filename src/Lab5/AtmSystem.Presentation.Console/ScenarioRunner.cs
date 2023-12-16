using AtmSystem.Presentation.Console.Login;
using AtmSystem.Presentation.Console.Scenarios.SetSystemPassword;
using Spectre.Console;

namespace AtmSystem.Presentation.Console;

public class ScenarioRunner
{
    private readonly IEnumerable<IAdminScenarioProvider> _adminProviders;
    private readonly IEnumerable<IUserScenarioProvider> _userProviders;
    private readonly IEnumerable<LoginAdminScenarioProvider> _loginAdminProviders;
    private readonly IEnumerable<LoginUserScenarioProvider> _loginUserProviders;

    public ScenarioRunner(
        IEnumerable<IAdminScenarioProvider> adminProviders,
        IEnumerable<IUserScenarioProvider> userProviders,
        IEnumerable<LoginAdminScenarioProvider> loginAdminProviders,
        IEnumerable<LoginUserScenarioProvider> loginUserProviders)
    {
        _adminProviders = adminProviders;
        _userProviders = userProviders;
        _loginAdminProviders = loginAdminProviders;
        _loginUserProviders = loginUserProviders;
    }

    public void Run(string choice)
    {
        switch (choice)
        {
            case "User":
            {
                IScenario? loginScenario = GetLoginUserScenarios();
                loginScenario?.Run();

                IEnumerable<IScenario> scenarios = GetUserScenarios();

                SelectionPrompt<IScenario> userSelector = new SelectionPrompt<IScenario>()
                    .Title("Select action")
                    .AddChoices(scenarios)
                    .UseConverter(x => x.Name);

                IScenario scenario = AnsiConsole.Prompt(userSelector);
                scenario.Run();
                break;
            }

            case "Admin":
            {
                IScenario? loginScenario = GetLoginAdminScenarios();
                bool validation = true;
                try
                {
                    loginScenario?.Run();
                }
                catch (ArgumentException)
                {
                    AnsiConsole.WriteLine("[red]Wrong system password[/]");
                    validation = false;
                }

                if (validation)
                {
                    IEnumerable<IScenario> scenarios = GetAdminScenarios();

                    SelectionPrompt<IScenario> userSelector = new SelectionPrompt<IScenario>()
                        .Title("Select action")
                        .AddChoices(scenarios)
                        .UseConverter(x => x.Name);

                    IScenario scenario = AnsiConsole.Prompt(userSelector);
                    scenario.Run();
                    AnsiConsole.Clear();
                    break;
                }
                else
                {
                    AnsiConsole.Clear();
                    string[] choices = { "Admin", "User" };
                    SelectionPrompt<string> selector = new SelectionPrompt<string>()
                        .Title("Select mode")
                        .PageSize(10)
                        .AddChoices(choices);
                    string choice2 = AnsiConsole.Prompt(selector);
                    Run(choice2);
                    break;
                }
            }
        }
    }

    public IScenario? GetSystemPasswordScenario()
    {
        foreach (IAdminScenarioProvider provider in _adminProviders)
        {
            if (provider is SetSystemPasswordScenarioProvider)
            {
                if (provider.TryGetScenario(out IScenario? scenario))
                    return scenario;
            }
        }

        return null;
    }

    private IEnumerable<IScenario> GetUserScenarios()
    {
        foreach (IUserScenarioProvider provider in _userProviders)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }

    private IEnumerable<IScenario> GetAdminScenarios()
    {
        foreach (IAdminScenarioProvider provider in _adminProviders)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }

    private IScenario? GetLoginUserScenarios()
    {
        foreach (LoginUserScenarioProvider provider in _loginUserProviders)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                return scenario;
        }

        return null;
    }

    private IScenario? GetLoginAdminScenarios()
    {
        foreach (LoginAdminScenarioProvider provider in _loginAdminProviders)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                return scenario;
        }

        return null;
    }
}