using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class AssemblyValidator
{
    private readonly Assembly.ComputerAssembly _computerAssembly;

    public AssemblyValidator(Assembly.ComputerAssembly computerAssembly)
    {
        _computerAssembly = computerAssembly;
    }

    public BuildResult BuildAssembly()
    {
        BuildResult result = new BuildResult.BuildSuccess();

        IEnumerable<IComponentPlacementValidator> validations = new List<IComponentPlacementValidator>
        {
            new MotherBoardPlacementValidator(
                _computerAssembly.ComputerCaseElement,
                _computerAssembly.MotherBoardElement),
            new RandomAccessMemoryPlacementValidator(
                _computerAssembly.MotherBoardElement,
                _computerAssembly.RandomAccessMemoryElements),
            new ProcessorPlacementValidator(
                _computerAssembly.MotherBoardElement,
                _computerAssembly.RandomAccessMemoryElements,
                _computerAssembly.ProcessorElement),
            new BiosPlacementValidator(
                _computerAssembly.MotherBoardElement,
                _computerAssembly.ProcessorElement,
                _computerAssembly.BiosElement),
            new CoolerSystemPlacementValidator(
                _computerAssembly.ComputerCaseElement,
                _computerAssembly.MotherBoardElement,
                _computerAssembly.ProcessorElement,
                _computerAssembly.CoolerSystemElement),
            new VideoCardPlacementValidator(
                _computerAssembly.ComputerCaseElement,
                _computerAssembly.ProcessorElement,
                _computerAssembly.VideoCardElement),
            new WifiAdapterPlacementValidator(
                _computerAssembly.MotherBoardElement,
                _computerAssembly.WifiAdapterElement),
            new StorageDeviceElementsPlacementValidator(
                _computerAssembly.MotherBoardElement,
                _computerAssembly.StorageDeviceElements),
            new PowerUnitPlacementValidator(
                _computerAssembly.ProcessorElement,
                _computerAssembly.VideoCardElement,
                _computerAssembly.RandomAccessMemoryElements,
                _computerAssembly.WifiAdapterElement,
                _computerAssembly.PowerUnitElement),
            new PciLinesConnectionValidator(
                _computerAssembly.MotherBoardElement,
                _computerAssembly.VideoCardElement,
                _computerAssembly.WifiAdapterElement,
                _computerAssembly.StorageDeviceElements),
        };

        foreach (IComponentPlacementValidator validator in validations)
        {
            if (!validator.Validate(ref result))
                return result;
        }

        return result;
    }
}