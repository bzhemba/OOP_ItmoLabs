using System.Diagnostics.CodeAnalysis;

namespace AtmSystem.Presentation.Console;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}