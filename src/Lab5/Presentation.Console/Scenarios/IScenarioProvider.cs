using System.Diagnostics.CodeAnalysis;

namespace Presentation.Console.Scenarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}