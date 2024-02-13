using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Components.BiosComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ComputerCaseComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.CoolerSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnitComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.ProcessorComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.RandomAccessMemoryComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.StorageDeviceComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WifiAdapterComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Assembly;

public class ComputerAssembly
{
    private ComputerAssembly(
        IMotherBoard motherBoardElement,
        IProcessor processorElement,
        ICoolerSystem coolerSystemElement,
        IBios biosElement,
        IComputerCase computerCaseElement,
        IVideoCard? videoCardElement,
        IEnumerable<IRandomAccessMemory> randomAccessMemoryElements,
        IWifiAdapter? wifiAdapterElement,
        IPowerUnit powerUnitElement,
        IEnumerable<IStorageDevice> storageDeviceElements)
    {
        MotherBoardElement = motherBoardElement;
        ProcessorElement = processorElement;
        CoolerSystemElement = coolerSystemElement;
        BiosElement = biosElement;
        ComputerCaseElement = computerCaseElement;
        VideoCardElement = videoCardElement;
        RandomAccessMemoryElements = randomAccessMemoryElements;
        WifiAdapterElement = wifiAdapterElement;
        PowerUnitElement = powerUnitElement;
        StorageDeviceElements = storageDeviceElements;
    }

    public IMotherBoard MotherBoardElement { get; }

    public IProcessor ProcessorElement { get; }

    public ICoolerSystem CoolerSystemElement { get; }

    public IBios BiosElement { get; }

    public IComputerCase ComputerCaseElement { get; }

    public IVideoCard? VideoCardElement { get; }

    public IEnumerable<IRandomAccessMemory> RandomAccessMemoryElements { get; }

    public IWifiAdapter? WifiAdapterElement { get; }

    public IPowerUnit PowerUnitElement { get; }

    public IEnumerable<IStorageDevice> StorageDeviceElements { get; }

    public class AssemblyBuilder
    {
        private IMotherBoard? _motherBoardElement;

        private IProcessor? _processorElement;

        private ICoolerSystem? _coolerSystemElement;

        private IBios? _biosElement;

        private IComputerCase? _computerCaseElement;

        private IVideoCard? _videoCardElement;

        private IEnumerable<IRandomAccessMemory>? _randomAccessMemoryElements;

        private IWifiAdapter? _wifiAdapterElement;

        private IPowerUnit? _powerUnitElement;

        private IEnumerable<IStorageDevice>? _storageDeviceElements;

        public AssemblyBuilder()
        {
        }

        public AssemblyBuilder(ComputerAssembly baseComputerAssembly)
        {
            _motherBoardElement = baseComputerAssembly.MotherBoardElement.Clone();
            _processorElement = baseComputerAssembly.ProcessorElement.Clone();
            _coolerSystemElement = baseComputerAssembly.CoolerSystemElement.Clone();
            _biosElement = baseComputerAssembly.BiosElement.Clone();
            _computerCaseElement = baseComputerAssembly.ComputerCaseElement.Clone();
            _videoCardElement = baseComputerAssembly.VideoCardElement?.Clone();
            _randomAccessMemoryElements = baseComputerAssembly.RandomAccessMemoryElements
                .Select(ramElement => ramElement.Clone());
            _wifiAdapterElement = baseComputerAssembly.WifiAdapterElement?.Clone();
            _powerUnitElement = baseComputerAssembly.PowerUnitElement.Clone();
            _storageDeviceElements = baseComputerAssembly.StorageDeviceElements
                .Select(storageDevice => storageDevice.Clone());
        }

        public AssemblyBuilder WithMotherBoardElement(IMotherBoard motherBoard)
        {
            _motherBoardElement = motherBoard;
            return this;
        }

        public AssemblyBuilder WithProcessor(IProcessor processor)
        {
            _processorElement = processor;
            return this;
        }

        public AssemblyBuilder WithCoolerSystem(ICoolerSystem coolerSystem)
        {
            _coolerSystemElement = coolerSystem;
            return this;
        }

        public AssemblyBuilder WithBios(IBios bios)
        {
            _biosElement = bios;
            return this;
        }

        public AssemblyBuilder WithComputerCase(IComputerCase computerCase)
        {
            _computerCaseElement = computerCase;
            return this;
        }

        public AssemblyBuilder WithVideoCard(IVideoCard videoCard)
        {
            _videoCardElement = videoCard;
            return this;
        }

        public AssemblyBuilder WithRandomAccessElements(IEnumerable<IRandomAccessMemory> randomAccessMemoryElements)
        {
            _randomAccessMemoryElements = randomAccessMemoryElements;
            return this;
        }

        public AssemblyBuilder WithWifiAdapter(IWifiAdapter wifiAdapter)
        {
            _wifiAdapterElement = wifiAdapter;
            return this;
        }

        public AssemblyBuilder WithPowerUnit(IPowerUnit powerUnit)
        {
            _powerUnitElement = powerUnit;
            return this;
        }

        public AssemblyBuilder WithStorageDevices(IEnumerable<IStorageDevice> storageDevice)
        {
            _storageDeviceElements = storageDevice;
            return this;
        }

        public ComputerAssembly Build()
        {
            return new ComputerAssembly(
                _motherBoardElement ?? throw new AssemblyBuilderException("Unable to create assembly without motherboard"),
                _processorElement ?? throw new AssemblyBuilderException("Unable to create assembly without processor"),
                _coolerSystemElement ?? throw new AssemblyBuilderException("Unable to create assembly without cooler system"),
                _biosElement ?? throw new AssemblyBuilderException("Unable to create assembly without BIOS"),
                _computerCaseElement ?? throw new AssemblyBuilderException("Unable to create assembly without computer case"),
                _videoCardElement,
                _randomAccessMemoryElements ?? throw new AssemblyBuilderException("Unable to create assembly without RAM elements"),
                _wifiAdapterElement,
                _powerUnitElement ?? throw new AssemblyBuilderException("Unable to create assembly without power unit"),
                _storageDeviceElements ?? throw new AssemblyBuilderException("Unable to create assembly without storage device"));
        }
    }
}