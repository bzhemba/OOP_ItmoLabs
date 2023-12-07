using System.Diagnostics.CodeAnalysis;

namespace AtmSystem.Presentation.Console;

public interface IAdminScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}