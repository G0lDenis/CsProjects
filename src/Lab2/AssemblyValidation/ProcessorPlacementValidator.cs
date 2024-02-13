using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ProcessorComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.RandomAccessMemoryComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class ProcessorPlacementValidator : IComponentPlacementValidator
{
    private readonly IMotherBoard _motherBoard;
    private readonly IEnumerable<IRandomAccessMemory> _randomAccessMemoryElements;
    private readonly IProcessor _processor;

    public ProcessorPlacementValidator(
        IMotherBoard motherBoard,
        IEnumerable<IRandomAccessMemory> randomAccessMemoryElements,
        IProcessor processor)
    {
        _motherBoard = motherBoard;
        _randomAccessMemoryElements = randomAccessMemoryElements;
        _processor = processor;
    }

    public bool Validate(ref BuildResult result)
    {
        if (_motherBoard.SupportedSocket.Name != _processor.SupportedSocket.Name)
        {
            result = new BuildResult.BuildFail(
                "Processor cannot be placed on motherboard because of different socket bases");
            return false;
        }

        foreach (IRandomAccessMemory randomAccessMemory in _randomAccessMemoryElements)
        {
            if (!randomAccessMemory.SupportedJedecFormats.All(jedecFormat =>
                    _processor.SupportedFrequencies.Contains(jedecFormat.FrequencyValue)))
            {
                result = new BuildResult.BuildFail(
                    "Processor is not compatible with one of RAM elements");
                return false;
            }
        }

        return true;
    }
}