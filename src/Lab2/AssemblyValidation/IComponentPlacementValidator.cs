using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public interface IComponentPlacementValidator
{
    public bool Validate(ref BuildResult result);
}