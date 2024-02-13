using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.RandomAccessMemoryComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class RandomAccessMemoryPlacementValidator : IComponentPlacementValidator
{
    private readonly IMotherBoard _motherBoard;
    private readonly IEnumerable<IRandomAccessMemory> _randomAccessMemoryElements;

    public RandomAccessMemoryPlacementValidator(
        IMotherBoard motherBoard,
        IEnumerable<IRandomAccessMemory> randomAccessMemoryElements)
    {
        _motherBoard = motherBoard;
        _randomAccessMemoryElements = randomAccessMemoryElements;
    }

    public bool Validate(ref BuildResult result)
    {
        foreach (IRandomAccessMemory randomAccessMemory in _randomAccessMemoryElements)
        {
            if (!_motherBoard.SupportedJedecFormats.Any(jedecFrequencyFormat =>
                    randomAccessMemory.SupportedJedecFormats.Contains(jedecFrequencyFormat)))
            {
                result = new BuildResult.BuildFail(
                    "One of RAMs is not supported by mother board");
                return false;
            }

            if (!randomAccessMemory.SupportedXmpProfiles.All(xmpProfile =>
                    _motherBoard.SupportedXmpProfiles.Contains(xmpProfile)))
            {
                if (result is BuildResult.BuildSuccess success)
                {
                    if (success is not BuildResult.BuildWithoutWarrantySuccess)
                        result = new BuildResult.BuildWithoutWarrantySuccess(success);
                    success.AddMessage(
                        "Some of XMP profiles is not supported by mother board");
                }
            }
        }

        return true;
    }
}