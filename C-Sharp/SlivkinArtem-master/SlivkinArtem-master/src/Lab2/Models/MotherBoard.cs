using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class MotherBoard
{
    public MotherBoard(
        Socket? socket, 
        FormFactor? formFactor, 
        Count? sataPorts, 
        Count? ramSlots, 
        Dimensions? dimensions, 
        Ddr? ddr, 
        Count? pciELanes, 
        Chipset? chipset)
    {
        FormFactor = formFactor;
        SataPorts = sataPorts;
        RamSlots = ramSlots;
        Dimensions = dimensions;
        Ddr = ddr;
        PciELanes = pciELanes;
        Chipset = chipset;
        Socket = socket;
    }
    
    public static MotherBoardBuilder Builder => new MotherBoardBuilder();
    public Dimensions? Dimensions { get; private set; }
    public Socket? Socket { get; }
    public Ddr? Ddr { get; }
    public Count? PciELanes { get; }
    public Chipset? Chipset { get; }
    public Count? SataPorts { get; }
    public Count? RamSlots { get; }
    public FormFactor? FormFactor { get; }
} 