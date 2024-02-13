using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AssemblyValidation;
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
using Itmo.ObjectOrientedProgramming.Lab2.Registry;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class AssemblyTests
{
    public static IEnumerable<object[]> MotherBoardBuilderWithoutRamSocketTypesGenerator()
    {
        var mother = new MotherBoard.MotherBoardBuilder();
        mother
            .WithName("Mama")
            .WithSocket(new Socket("Socket1"))
            .WithPciLines(new Dictionary<PciLine, int>
            {
                { new PciLine("pci-1"), 4 },
            })
            .WithSataPortNumber(2)
            .WithSupportedJedecFormats(new List<JedecFrequencyFormat>()
            {
                new JedecFrequencyFormat(1000, 2.0f),
            })
            .WithSupportedDdrRamType(new DdrRamType("DDR4"))
            .WithFormFactor(new MotherFormFactor("Form1"))
            .WithSupportedBiosTypes(new List<BiosType>
            {
                new BiosType("Bios1"),
            });
        return new List<object[]>
        {
            new object[] { mother },
        };
    }

    public static IEnumerable<object[]> ProcessorBuilderGenerator()
    {
        var processor = new Processor.ProcessorBuilder();

        processor
            .WithName("Intel i7-9900K")
            .WithSupportedSocket(new Socket("Socket1"))
            .WithSupportedFrequencies(new List<Frequency>
            {
                new Frequency(123),
            })
            .WithCoreFrequency(1000)
            .WithCoreNumber(8)
            .WithHeatMass(100)
            .WithPower(50)
            .WithMinimumRecommendedPower(300);
        return new List<object[]>
        {
            new object[] { processor },
        };
    }

    public static IEnumerable<object[]> ComputerCaseBuilderGenerator()
    {
        var computerCase = new ComputerCase.ComputerCaseBuilder();

        computerCase
            .WithName("SuperCase1")
            .WithDimensions(new ComputerCaseDimensions(500, 500))
            .WithCoolerMaxHeight(100)
            .WithMaxVideoCardDimensions(new VideoCardDimensions(100, 100))
            .WithSupportedMotherFormFactor(new MotherFormFactor("Form1"));

        return new List<object[]>
        {
            new object[] { computerCase },
        };
    }

    public static IEnumerable<object[]> CoolerBuilderGenerator()
    {
        var coolerSystem = new CoolerSystem.CoolerSystemBuilder();

        coolerSystem
            .WithName("Freezing")
            .WithWeight(50)
            .WithMaxNeutralizedHeatMass(200)
            .WithSupportedSockets(new List<Socket>
            {
                new Socket("Socket1"),
            });

        return new List<object[]>
        {
            new object[] { coolerSystem },
        };
    }

    public static IEnumerable<object[]> BiosBuilderGenerator()
    {
        var bios = new Bios.BiosBuilder();

        bios
            .WithName("Alpha")
            .WithType(new BiosType("Type"))
            .WithSupportedProcessors(new List<string>
            {
                "Intel i7-9900K",
            });

        return new List<object[]>
        {
            new object[] { bios },
        };
    }

    public static IEnumerable<object[]> VideoCardBuilderGenerator()
    {
        var videoCard = new VideoCard.VideoCardBuilder();

        videoCard
            .WithName("Nvidia GeForce Ultra")
            .WithMemory(10)
            .WithChipFrequency(2000)
            .WithDimensions(new VideoCardDimensions(200, 200))
            .WithPower(50)
            .WithMinimumRecommendedPower(300)
            .WithPciLine(new PciLine("pci-1"));

        return new List<object[]>
        {
            new object[] { videoCard },
        };
    }

    public static IEnumerable<object[]> CompleteAssemblyElementsGenerator()
    {
        MotherBoard mother = new MotherBoard.MotherBoardBuilder()
            .WithName("Mama")
            .WithSocket(new Socket("Socket1"))
            .WithPciLines(new Dictionary<PciLine, int>
            {
                { new PciLine("pci-1"), 4 },
            })
            .WithSataPortNumber(2)
            .WithSupportedJedecFormats(new List<JedecFrequencyFormat>()
            {
                new JedecFrequencyFormat(1000, 2.0f),
            })
            .WithSupportedDdrRamType(new DdrRamType("DDR4"))
            .WithFormFactor(new MotherFormFactor("Form1"))
            .WithSupportedBiosTypes(new List<BiosType>
            {
                new BiosType("Bios1"),
            })
            .WithAvailableRamSocketTypes(new Dictionary<RamProfile, int>
            {
                { new RamProfile("RamProfile1"), 2 },
            })
            .Build();

        Processor processor = new Processor.ProcessorBuilder()
            .WithName("Intel i7-9900K")
            .WithSupportedSocket(new Socket("Socket1"))
            .WithSupportedFrequencies(new List<Frequency>
            {
                new Frequency(1000),
            })
            .WithCoreFrequency(1000)
            .WithCoreNumber(8)
            .WithHeatMass(100)
            .WithPower(100)
            .WithMinimumRecommendedPower(300)
            .Build();

        ComputerCase computerCase = new ComputerCase.ComputerCaseBuilder()
            .WithName("SuperCase1")
            .WithDimensions(new ComputerCaseDimensions(500, 500))
            .WithCoolerMaxHeight(100)
            .WithMaxVideoCardDimensions(new VideoCardDimensions(100, 100))
            .WithSupportedMotherFormFactor(new MotherFormFactor("Form1"))
            .Build();

        CoolerSystem coolerSystem = new CoolerSystem.CoolerSystemBuilder()
            .WithName("Freezing")
            .WithWeight(50)
            .WithMaxNeutralizedHeatMass(200)
            .WithSupportedSockets(new List<Socket>
            {
                new Socket("Socket1"),
            })
            .Build();

        Bios bios = new Bios.BiosBuilder()
            .WithName("Alpha")
            .WithType(new BiosType("Bios1"))
            .WithSupportedProcessors(new List<string>
            {
                "Intel i7-9900K",
            })
            .Build();

        VideoCard videoCard = new VideoCard.VideoCardBuilder()
            .WithName("Nvidia GeForce Ultra")
            .WithMemory(10)
            .WithChipFrequency(2000)
            .WithDimensions(new VideoCardDimensions(200, 200))
            .WithPower(100)
            .WithMinimumRecommendedPower(300)
            .WithPciLine(new PciLine("pci-1"))
            .Build();

        RandomAccessMemory randomAccessMemory = new RandomAccessMemory.RandomAccessMemoryBuilder()
            .WithName("MamaMilaRamu")
            .WithType(new DdrRamType("RDR4"))
            .WithPower(60)
            .WithProfile(new RamProfile("RamProfile1"))
            .WithRamSize(16)
            .WithSupportedJedecFormats(new List<JedecFrequencyFormat>
            {
                new JedecFrequencyFormat(1000, 2.0f),
            })
            .Build();

        var storageDevice = new SsdStorageDevice("SsdA", 10, 10, 1000, new PciLine("pci-1"));
        var powerUnit = new PowerUnit("PW1", 500);

        Assembly.ComputerAssembly computerAssembly = new Assembly.ComputerAssembly.AssemblyBuilder()
            .WithProcessor(processor)
            .WithComputerCase(computerCase)
            .WithMotherBoardElement(mother)
            .WithBios(bios)
            .WithVideoCard(videoCard)
            .WithCoolerSystem(coolerSystem)
            .WithStorageDevices(new List<IStorageDevice>
            {
                storageDevice,
            })
            .WithPowerUnit(powerUnit)
            .WithRandomAccessElements(new List<IRandomAccessMemory>
            {
                randomAccessMemory,
            })
            .Build();

        return new List<object[]>
        {
            new object[]
            {
                computerAssembly,
            },
        };
    }

    public static IEnumerable<object[]> StorageDeviceGenerator()
    {
        var storageDevice = new SsdStorageDevice("SsdA", 10, 10, 1000, new PciLine("pci-1"));

        return new List<object[]>
        {
            new object[] { storageDevice },
        };
    }

    public static IEnumerable<object[]> PowerUnitGenerator()
    {
        var powerUnit = new PowerUnit("PW1", 500);

        return new List<object[]>
        {
            new object[] { powerUnit },
        };
    }

    [Theory]
    [MemberData(nameof(ProcessorBuilderGenerator))]
    public void RegistryAddingTest(Processor.ProcessorBuilder processorBuilder)
    {
        IRegistry registry = new Registry.Registry();
        registry.Register(processorBuilder.Build());

        registry.TryGetElement("Intel i7-9900K", out Processor? processor);

        Assert.NotNull(processor);
        Assert.Equal(50, processor.Power);
    }

    [Theory]
    [MemberData(nameof(MotherBoardBuilderWithoutRamSocketTypesGenerator))]
    public void MotherBoardWithoutRamSocketTypesCannotBeBuiltTest(MotherBoard.MotherBoardBuilder motherBoard)
    {
        Assert.Throws<ComponentBuilderException>(motherBoard.Build);
    }

    [Theory]
    [MemberData(nameof(MotherBoardBuilderWithoutRamSocketTypesGenerator))]
    public void MotherBoardWithAllElementsMustBeBuildTest(MotherBoard.MotherBoardBuilder motherBoardBuilder)
    {
        IRegistry registry = new Registry.Registry();
        motherBoardBuilder.WithAvailableRamSocketTypes(new Dictionary<RamProfile, int>
        {
            { new RamProfile("RamProfile1"), 2 },
        });

        registry.Register(motherBoardBuilder.Build());
        registry.TryGetElement("Mama", out MotherBoard? motherBoard);

        Assert.NotNull(motherBoard);
        Assert.Equal(new MotherFormFactor("Form1"), motherBoard.FormFactor);
    }

    [Theory]
    [MemberData(nameof(CompleteAssemblyElementsGenerator))]
    public void CompletedAssemblyMustBeBuiltTest(
        Assembly.ComputerAssembly computerAssembly)
    {
        Assert.IsType<BuildResult.BuildSuccess>(new AssemblyValidator(computerAssembly).BuildAssembly());
    }

    [Theory]
    [MemberData(nameof(CompleteAssemblyElementsGenerator))]
    public void AssemblyWithNotEnoughPowerMustBeBuiltTest(
        Assembly.ComputerAssembly computerAssembly)
    {
        computerAssembly = new Assembly.ComputerAssembly.AssemblyBuilder(computerAssembly)
            .WithPowerUnit(new PowerUnit("PW2", 300))
            .Build();

        Assert.IsType<BuildResult.BuildSuccess>(new AssemblyValidator(computerAssembly).BuildAssembly());
    }

    [Theory]
    [MemberData(nameof(CompleteAssemblyElementsGenerator))]
    public void AssemblyWithNotEnoughCoolerStrengthMustBeBuiltWithoutWarrantyTest(
        Assembly.ComputerAssembly computerAssembly)
    {
        computerAssembly = new Assembly.ComputerAssembly.AssemblyBuilder(computerAssembly)
            .WithCoolerSystem(new CoolerSystem.CoolerSystemBuilder()
                .WithName("Less freezing")
                .WithWeight(50)
                .WithMaxNeutralizedHeatMass(50)
                .WithSupportedSockets(new List<Socket>
                {
                    new("Socket1"),
                })
                .Build())
            .Build();

        Assert.IsType<BuildResult.BuildWithoutWarrantySuccess>(new AssemblyValidator(computerAssembly).BuildAssembly());
    }

    [Theory]
    [MemberData(nameof(CompleteAssemblyElementsGenerator))]
    public void AssemblyWithNotCompatibleMustNotBeBuilt(
        Assembly.ComputerAssembly computerAssembly)
    {
        computerAssembly = new Assembly.ComputerAssembly.AssemblyBuilder(computerAssembly)
            .WithProcessor(new Processor.ProcessorBuilder()
                .WithName("Intel i8-9900K")
                .WithSupportedSocket(new Socket("Socket2"))
                .WithSupportedFrequencies(new List<Frequency>
                {
                    new Frequency(1000),
                })
                .WithCoreFrequency(1000)
                .WithCoreNumber(8)
                .WithHeatMass(100)
                .WithPower(100)
                .WithMinimumRecommendedPower(300)
                .Build())
            .Build();

        Assert.IsType<BuildResult.BuildFail>(new AssemblyValidator(computerAssembly).BuildAssembly());
    }
}