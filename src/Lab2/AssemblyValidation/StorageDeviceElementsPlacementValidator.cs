using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.StorageDeviceComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;

public class StorageDeviceElementsPlacementValidator : IComponentPlacementValidator
{
    private readonly IMotherBoard _motherBoard;
    private readonly IEnumerable<IStorageDevice> _storageDeviceElements;

    public StorageDeviceElementsPlacementValidator(
        IMotherBoard motherBoard,
        IEnumerable<IStorageDevice> storageDeviceElements)
    {
        _motherBoard = motherBoard;
        _storageDeviceElements = storageDeviceElements;
    }

    public bool Validate(ref BuildResult result)
    {
        if (!_storageDeviceElements.Any())
        {
            result = new BuildResult.BuildFail(
                "There must be at least one storage device in assembly");
            return false;
        }

        if (_motherBoard.SataPortNumber < _storageDeviceElements
                .Count(storageDevice => storageDevice is HddStorageDevice
                                        || ((SsdStorageDevice)storageDevice).SupportedPciLine is null))
        {
            result = new BuildResult.BuildFail(
                "Storage devices cannot be placed because not enough Sata ports are available");
            return false;
        }

        return true;
    }
}