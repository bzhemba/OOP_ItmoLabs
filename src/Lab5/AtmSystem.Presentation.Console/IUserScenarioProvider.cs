using System.Diagnostics.CodeAnalysis;

namespace AtmSystem.Presentation.Console;

public interface IUserScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}