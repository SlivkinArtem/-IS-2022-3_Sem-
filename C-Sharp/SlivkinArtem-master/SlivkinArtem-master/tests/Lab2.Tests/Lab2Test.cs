using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;
using Xunit;
using Version = Itmo.ObjectOrientedProgramming.Lab2.Records.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Lab2Test
{
    public static IEnumerable<object[]> Parameters()
    {
        yield return new object[]
        {
            new Socket(new SocketName("Intel 2020-2030")), // cpu
            new Tdp(300),
            new PowerConsumption(50),
            new Frequency(2000),
            new Count(5),
            new Socket(new SocketName("Intel 2020-2030")), // motherboard
            new FormFactor("ATX"),
            new Count(3),
            new Count(3),
            new Dimensions(50, 50),
            new Ddr(5),
            new Count(3),
            new Chipset(new List<Frequency>
            {
                new Frequency(2000),
                new Frequency(2500),
                new Frequency(3000),
            }),
            new Socket(new SocketName("Intel 2020-2030")), // cooler
            new Dimensions(20, 20),
            new Tdp(400),
            new Count(300), // ram
            new Frequency(2000),
            new List<XmpProfile>()
            {
                new XmpProfile(new Frequency(2000)),
            },
            new FormFactor("ATX"),
            new PowerConsumption(300),
            new Ddr(5),
            new Count(300), // videoCard
            new Version("5.0"),
            new Frequency(2000),
            new PowerConsumption(300),
            new Dimensions(20, 20),
            new Capacity(32), // ssd
            new PowerConsumption(10),
            new Speed(200),
            new Dimensions(60, 60), // systemCase
            new Dimensions(150, 150),
            new List<FormFactor>()
            {
                new FormFactor("ATX"),
            },
            new PowerUnit(new Load(500)), // powerUnit
        };
    }

    [Theory]
    [MemberData(nameof(Parameters))]
    public void SuccessAssembling(
        Socket cpuSocket,
        Tdp cpuTdp,
        PowerConsumption cpuPowerConsumption,
        Frequency cpuFrequency,
        Count cpuCoreCount,
        Socket motherBoardSocket,
        FormFactor motherBoardFormFactor,
        Count motherBoardSataPorts,
        Count motherBoardRamSlots,
        Dimensions motherBoardDimensions,
        Ddr motherBoardSupportDdr,
        Count motherBoardPciELanes,
        Chipset motherBoardChipset,
        Socket coolerSocket,
        Dimensions coolerDimensions,
        Tdp coolerTdp,
        Count ramAmountOfAvailableMemory,
        Frequency ramSupportedJedecFrequency,
        IEnumerable<XmpProfile> ramAvailableXmrProfiles,
        FormFactor ramFormFactor,
        PowerConsumption ramPowerConsumption,
        Ddr ramDdrType,
        Count videoCardVideoMemoryAmount,
        Version videoCardPciEVerison,
        Frequency videoCardChipFrequency,
        PowerConsumption videoCardPowerConsumption,
        Dimensions videoCardDimensions,
        Capacity sddCapacity,
        PowerConsumption ssdPowerConsumption,
        Speed ssdMaxSpeed,
        Dimensions systemCaseMaxVideoCardDimensions,
        Dimensions systemCaseDimensions,
        IEnumerable<FormFactor> systemCaseSupportedMBFormFactor,
        PowerUnit powerUnitP)
    {
        // arrange
        ValidateParams(new List<object?>
        {
            cpuSocket, cpuTdp, cpuPowerConsumption, cpuFrequency, cpuCoreCount,
            motherBoardSocket, motherBoardFormFactor, motherBoardSataPorts,
            motherBoardRamSlots, motherBoardDimensions, motherBoardPciELanes,
            motherBoardChipset, motherBoardSupportDdr, coolerSocket,
            coolerDimensions, coolerTdp, ramAmountOfAvailableMemory,
            ramSupportedJedecFrequency, ramAvailableXmrProfiles,
            ramFormFactor, ramPowerConsumption, ramDdrType, videoCardVideoMemoryAmount,
            videoCardPciEVerison, videoCardChipFrequency, videoCardPowerConsumption,
            videoCardDimensions, sddCapacity, ssdPowerConsumption, ssdMaxSpeed,
            systemCaseMaxVideoCardDimensions, systemCaseDimensions,
            systemCaseSupportedMBFormFactor, powerUnitP,
        });

        // act
        CpuBuilder cpuBuilder1 = Cpu.Builder
            .SetSocket(new Socket(new SocketName("Intel 2020-2030")))
            .SetTdp(new Tdp(300))
            .SetCpuPowerConsumption(new PowerConsumption(50))
            .SetCoreClock(new Frequency(2000))
            .SetNumberOfCores(new Count(5));
        Cpu cpu1 = cpuBuilder1.Build();

        MotherBoardBuilder motherBoardBuilder = MotherBoard.Builder
            .SetSocket(motherBoardSocket)
            .SetFormFactor(motherBoardFormFactor)
            .SetSataPorts(motherBoardSataPorts)
            .SetRamSlots(motherBoardRamSlots)
            .SetDimensions(motherBoardDimensions)
            .SetDdr(motherBoardSupportDdr)
            .SetPciELanes(motherBoardPciELanes)
            .SetChipset(motherBoardChipset);
        MotherBoard motherBoard = motherBoardBuilder.Build();

        BiosBuilder biosBuilder = Bios.Builder;
        biosBuilder.AddCpu(cpu1);
        Bios bios = biosBuilder.Build();

        CoolerBuilder coolerBuilder = Cooler.Builder;
        coolerBuilder.AddSocket(coolerSocket);
        coolerBuilder.SetSize(coolerDimensions);
        coolerBuilder.SetTdp(coolerTdp);
        Cooler cooler = coolerBuilder.Build();

        RamBuilder ramBuilder = Ram.Builder
            .SetAmountOfAvailableMemory(ramAmountOfAvailableMemory)
            .SetAvailableXmrProfiles(ramAvailableXmrProfiles.ToList())
            .SetDdr(ramDdrType)
            .SetFormFactor(ramFormFactor)
            .SetRamPowerConsumption(ramPowerConsumption)
            .SetSupportedJedecFrequency(ramSupportedJedecFrequency);
        Ram ram = ramBuilder.Build();

        VideoCardBuilder videoCardBuilder = VideoCard.Builder
            .SetVideoMemoryAmount(videoCardVideoMemoryAmount)
            .SetPciEVersion(videoCardPciEVerison)
            .SetChipFrequency(videoCardChipFrequency)
            .SetVideoCardPowerConsumption(videoCardPowerConsumption)
            .SetDimensions(videoCardDimensions);
        VideoCard videoCard = videoCardBuilder.Build();

        SsdBuilder ssdBuilder = Ssd.Builder
            .SetCapacity(sddCapacity)
            .SetPowerConsumption(ssdPowerConsumption)
            .SetMaxSpeed(ssdMaxSpeed);
        Ssd ssd = ssdBuilder.Build();

        SystemCaseBuilder systemCaseBuilder = SystemCase.Builder
            .SetMaxVideoCardDimensions(systemCaseMaxVideoCardDimensions)
            .SetDimensions(systemCaseDimensions)
            .SetSupportedMotherBoardFormFactors(systemCaseSupportedMBFormFactor.ToList());
        SystemCase systemCase = systemCaseBuilder.Build();

        PowerUnit powerUnit = powerUnitP;
        ComputerBuilder computerBuilder = new ComputerBuilder()
            .BuildWithBios(bios)
            .BuildWithSsd(ssd)
            .BuildWithVideoCard(videoCard)
            .BuildWithPowerUnit(powerUnit)
            .BuildWithMotherBoard(motherBoard)
            .BuildWithCpu(cpu1)
            .BuildWithCooler(cooler)
            .BuildWithRam(ram)
            .BuildWithSystemCase(systemCase);

        // assert
        Assert.NotNull(computerBuilder);
    }

    [Theory]
    [MemberData(nameof(Parameters))]
    public void IncompatibleSockets(
        Socket cpuSocket,
        Tdp cpuTdp,
        PowerConsumption cpuPowerConsumption,
        Frequency cpuFrequency,
        Count cpuCoreCount,
        Socket motherBoardSocket,
        FormFactor motherBoardFormFactor,
        Count motherBoardSataPorts,
        Count motherBoardRamSlots,
        Dimensions motherBoardDimensions,
        Ddr motherBoardSupportDdr,
        Count motherBoardPciELanes,
        Chipset motherBoardChipset,
        Socket coolerSocket,
        Dimensions coolerDimensions,
        Tdp coolerTdp,
        Count ramAmountOfAvailableMemory,
        Frequency ramSupportedJedecFrequency,
        IEnumerable<XmpProfile> ramAvailableXmrProfiles,
        FormFactor ramFormFactor,
        PowerConsumption ramPowerConsumption,
        Ddr ramDdrType,
        Count videoCardVideoMemoryAmount,
        Version videoCardPciEVerison,
        Frequency videoCardChipFrequency,
        PowerConsumption videoCardPowerConsumption,
        Dimensions videoCardDimensions,
        Capacity sddCapacity,
        PowerConsumption ssdPowerConsumption,
        Speed ssdMaxSpeed,
        Dimensions systemCaseMaxVideoCardDimensions,
        Dimensions systemCaseDimensions,
        IEnumerable<FormFactor> systemCaseSupportedMBFormFactor,
        PowerUnit powerUnitP)
    {
        // arrange
        ValidateParams(new List<object?>
        {
            cpuSocket, cpuTdp, cpuPowerConsumption, cpuFrequency, cpuCoreCount,
            motherBoardSocket, motherBoardFormFactor, motherBoardSataPorts,
            motherBoardRamSlots, motherBoardDimensions, motherBoardPciELanes,
            motherBoardChipset, motherBoardSupportDdr, coolerSocket,
            coolerDimensions, coolerTdp, ramAmountOfAvailableMemory,
            ramSupportedJedecFrequency, ramAvailableXmrProfiles,
            ramFormFactor, ramPowerConsumption, ramDdrType, videoCardVideoMemoryAmount,
            videoCardPciEVerison, videoCardChipFrequency, videoCardPowerConsumption,
            videoCardDimensions, sddCapacity, ssdPowerConsumption, ssdMaxSpeed,
            systemCaseMaxVideoCardDimensions, systemCaseDimensions,
            systemCaseSupportedMBFormFactor, powerUnitP,
        });

        // act
        CpuBuilder cpuBuilder1 = Cpu.Builder
            .SetSocket(new Socket(new SocketName("Intel 2020-2030")))
            .SetTdp(new Tdp(300))
            .SetCpuPowerConsumption(new PowerConsumption(50))
            .SetCoreClock(new Frequency(2000))
            .SetNumberOfCores(new Count(5));
        Cpu cpu1 = cpuBuilder1.Build();

        MotherBoardBuilder motherBoardBuilder = MotherBoard.Builder
            .SetSocket(new Socket(new SocketName("Intel 2010-2020"))) // переопределил сокет чтобы словить эксепшн
            .SetFormFactor(motherBoardFormFactor)
            .SetSataPorts(motherBoardSataPorts)
            .SetRamSlots(motherBoardRamSlots)
            .SetDimensions(motherBoardDimensions)
            .SetDdr(motherBoardSupportDdr)
            .SetPciELanes(motherBoardPciELanes)
            .SetChipset(motherBoardChipset);
        MotherBoard motherBoard = motherBoardBuilder.Build();

        BiosBuilder biosBuilder = Bios.Builder;
        biosBuilder.AddCpu(cpu1);
        Bios bios = biosBuilder.Build();

        CoolerBuilder coolerBuilder = Cooler.Builder;
        coolerBuilder.AddSocket(coolerSocket);
        coolerBuilder.SetSize(coolerDimensions);
        coolerBuilder.SetTdp(coolerTdp);
        Cooler cooler = coolerBuilder.Build();

        RamBuilder ramBuilder = Ram.Builder
            .SetAmountOfAvailableMemory(ramAmountOfAvailableMemory)
            .SetAvailableXmrProfiles(ramAvailableXmrProfiles.ToList())
            .SetDdr(ramDdrType)
            .SetFormFactor(ramFormFactor)
            .SetRamPowerConsumption(ramPowerConsumption)
            .SetSupportedJedecFrequency(ramSupportedJedecFrequency);
        Ram ram = ramBuilder.Build();

        VideoCardBuilder videoCardBuilder = VideoCard.Builder
            .SetVideoMemoryAmount(videoCardVideoMemoryAmount)
            .SetPciEVersion(videoCardPciEVerison)
            .SetChipFrequency(videoCardChipFrequency)
            .SetVideoCardPowerConsumption(videoCardPowerConsumption)
            .SetDimensions(videoCardDimensions);
        VideoCard videoCard = videoCardBuilder.Build();

        SsdBuilder ssdBuilder = Ssd.Builder
            .SetCapacity(sddCapacity)
            .SetPowerConsumption(ssdPowerConsumption)
            .SetMaxSpeed(ssdMaxSpeed);
        Ssd ssd = ssdBuilder.Build();

        SystemCaseBuilder systemCaseBuilder = SystemCase.Builder
            .SetMaxVideoCardDimensions(systemCaseMaxVideoCardDimensions)
            .SetDimensions(systemCaseDimensions)
            .SetSupportedMotherBoardFormFactors(systemCaseSupportedMBFormFactor.ToList());
        SystemCase systemCase = systemCaseBuilder.Build();

        PowerUnit powerUnit = powerUnitP;

        ComputerBuilderException exception = Assert.Throws<ComputerBuilderException>(() =>
        {
            Computer computer = new ComputerBuilder()
                .BuildWithBios(bios)
                .BuildWithSsd(ssd)
                .BuildWithVideoCard(videoCard)
                .BuildWithPowerUnit(powerUnit)
                .BuildWithMotherBoard(motherBoard)
                .BuildWithCpu(cpu1)
                .BuildWithCooler(cooler)
                .BuildWithRam(ram)
                .BuildWithSystemCase(systemCase)
                .Build();
        });
        Assert.Equal("MotherBoard and Cpu sockets are Incompatible", exception.Message);
    }

    [Theory]
    [MemberData(nameof(Parameters))]
    public void InvalidTdpChars(
        Socket cpuSocket,
        Tdp cpuTdp,
        PowerConsumption cpuPowerConsumption,
        Frequency cpuFrequency,
        Count cpuCoreCount,
        Socket motherBoardSocket,
        FormFactor motherBoardFormFactor,
        Count motherBoardSataPorts,
        Count motherBoardRamSlots,
        Dimensions motherBoardDimensions,
        Ddr motherBoardSupportDdr,
        Count motherBoardPciELanes,
        Chipset motherBoardChipset,
        Socket coolerSocket,
        Dimensions coolerDimensions,
        Tdp coolerTdp,
        Count ramAmountOfAvailableMemory,
        Frequency ramSupportedJedecFrequency,
        IEnumerable<XmpProfile> ramAvailableXmrProfiles,
        FormFactor ramFormFactor,
        PowerConsumption ramPowerConsumption,
        Ddr ramDdrType,
        Count videoCardVideoMemoryAmount,
        Version videoCardPciEVerison,
        Frequency videoCardChipFrequency,
        PowerConsumption videoCardPowerConsumption,
        Dimensions videoCardDimensions,
        Capacity sddCapacity,
        PowerConsumption ssdPowerConsumption,
        Speed ssdMaxSpeed,
        Dimensions systemCaseMaxVideoCardDimensions,
        Dimensions systemCaseDimensions,
        IEnumerable<FormFactor> systemCaseSupportedMBFormFactor,
        PowerUnit powerUnitP)
    {
        // arrange
        ValidateParams(new List<object?>
        {
            cpuSocket, cpuTdp, cpuPowerConsumption, cpuFrequency, cpuCoreCount,
            motherBoardSocket, motherBoardFormFactor, motherBoardSataPorts,
            motherBoardRamSlots, motherBoardDimensions, motherBoardPciELanes,
            motherBoardChipset, motherBoardSupportDdr, coolerSocket,
            coolerDimensions, coolerTdp, ramAmountOfAvailableMemory,
            ramSupportedJedecFrequency, ramAvailableXmrProfiles,
            ramFormFactor, ramPowerConsumption, ramDdrType, videoCardVideoMemoryAmount,
            videoCardPciEVerison, videoCardChipFrequency, videoCardPowerConsumption,
            videoCardDimensions, sddCapacity, ssdPowerConsumption, ssdMaxSpeed,
            systemCaseMaxVideoCardDimensions, systemCaseDimensions,
            systemCaseSupportedMBFormFactor, powerUnitP,
        });

        // act
        CpuBuilder cpuBuilder1 = Cpu.Builder
            .SetSocket(new Socket(new SocketName("Intel 2020-2030")))
            .SetTdp(new Tdp(300))
            .SetCpuPowerConsumption(new PowerConsumption(50))
            .SetCoreClock(new Frequency(2000))
            .SetNumberOfCores(new Count(5));
        Cpu cpu1 = cpuBuilder1.Build();

        MotherBoardBuilder motherBoardBuilder = MotherBoard.Builder
            .SetSocket(motherBoardSocket)
            .SetFormFactor(motherBoardFormFactor)
            .SetSataPorts(motherBoardSataPorts)
            .SetRamSlots(motherBoardRamSlots)
            .SetDimensions(motherBoardDimensions)
            .SetDdr(motherBoardSupportDdr)
            .SetPciELanes(motherBoardPciELanes)
            .SetChipset(motherBoardChipset);
        MotherBoard motherBoard = motherBoardBuilder.Build();

        BiosBuilder biosBuilder = Bios.Builder;
        biosBuilder.AddCpu(cpu1);
        Bios bios = biosBuilder.Build();

        CoolerBuilder coolerBuilder = Cooler.Builder;
        coolerBuilder.AddSocket(coolerSocket);
        coolerBuilder.SetSize(coolerDimensions);
        coolerBuilder.SetTdp(new Tdp(100));  // переопределил tdp чтобы словить эксепшн
        Cooler cooler = coolerBuilder.Build();

        RamBuilder ramBuilder = Ram.Builder
            .SetAmountOfAvailableMemory(ramAmountOfAvailableMemory)
            .SetAvailableXmrProfiles(ramAvailableXmrProfiles.ToList())
            .SetDdr(ramDdrType)
            .SetFormFactor(ramFormFactor)
            .SetRamPowerConsumption(ramPowerConsumption)
            .SetSupportedJedecFrequency(ramSupportedJedecFrequency);
        Ram ram = ramBuilder.Build();

        VideoCardBuilder videoCardBuilder = VideoCard.Builder
            .SetVideoMemoryAmount(videoCardVideoMemoryAmount)
            .SetPciEVersion(videoCardPciEVerison)
            .SetChipFrequency(videoCardChipFrequency)
            .SetVideoCardPowerConsumption(videoCardPowerConsumption)
            .SetDimensions(videoCardDimensions);
        VideoCard videoCard = videoCardBuilder.Build();

        SsdBuilder ssdBuilder = Ssd.Builder
            .SetCapacity(sddCapacity)
            .SetPowerConsumption(ssdPowerConsumption)
            .SetMaxSpeed(ssdMaxSpeed);
        Ssd ssd = ssdBuilder.Build();

        SystemCaseBuilder systemCaseBuilder = SystemCase.Builder
            .SetMaxVideoCardDimensions(systemCaseMaxVideoCardDimensions)
            .SetDimensions(systemCaseDimensions)
            .SetSupportedMotherBoardFormFactors(systemCaseSupportedMBFormFactor.ToList());
        SystemCase systemCase = systemCaseBuilder.Build();

        PowerUnit powerUnit = powerUnitP;

        ComputerBuilderException exception = Assert.Throws<ComputerBuilderException>(() =>
        {
            Computer computer = new ComputerBuilder()
                .BuildWithSsd(ssd)
                .BuildWithVideoCard(videoCard)
                .BuildWithPowerUnit(powerUnit)
                .BuildWithMotherBoard(motherBoard)
                .BuildWithCpu(cpu1)
                .BuildWithCooler(cooler)
                .BuildWithRam(ram)
                .BuildWithSystemCase(systemCase)
                .Build();
        });
        Assert.Equal("Invalid tdp chars: cooler TDP is less then Cpu TDP", exception.Message);
    }

    private static void ValidateParams(IEnumerable<object?> objects)
    {
        if (objects.Any(p => p == null))
        {
            throw new ArgumentNullException(nameof(objects));
        }
    }
}