using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class MotherBoardBuilder
{
    private Socket? _socket;
    private Count? _pciELanes;
    private Count? _sataPorts;
    private Chipset? _chipset;
    private Ddr? _ddr;
    private Count? _ramSlots;
    private FormFactor? _formFactor;
    private Dimensions? _dimensions;

    public MotherBoardBuilder SetSocket(Socket? socket)
    {
        ArgumentNullException.ThrowIfNull(socket);
        this._socket = socket;
        return this;
    }

    public MotherBoardBuilder SetPciELanes(Count? pciELanes)
    {
        ArgumentNullException.ThrowIfNull(pciELanes);
        this._pciELanes = pciELanes;
        return this;
    }

    public MotherBoardBuilder SetSataPorts(Count? sataPorts)
    {
        ArgumentNullException.ThrowIfNull(sataPorts);
        this._sataPorts = sataPorts;
        return this;
    }

    public MotherBoardBuilder SetChipset(Chipset? chipset)
    {
        ArgumentNullException.ThrowIfNull(chipset);
        this._chipset = chipset;
        return this;
    }

    public MotherBoardBuilder SetDdr(Ddr? ddr)
    {
        ArgumentNullException.ThrowIfNull(ddr);
        this._ddr = ddr;
        return this;
    }

    public MotherBoardBuilder SetRamSlots(Count? ramSlots)
    {
        ArgumentNullException.ThrowIfNull(ramSlots);
        this._ramSlots = ramSlots;
        return this;
    }

    public MotherBoardBuilder SetFormFactor(FormFactor? formFactor)
    {
        ArgumentNullException.ThrowIfNull(formFactor);
        this._formFactor = formFactor;
        return this;
    }
    
    public MotherBoardBuilder SetDimensions(Dimensions? dimensions)
    {
        ArgumentNullException.ThrowIfNull(dimensions);
        this._dimensions = dimensions;
        return this;
    }

    public MotherBoard Build()
    {
        return new MotherBoard(_socket, _formFactor, _sataPorts, _ramSlots, _dimensions, _ddr, _pciELanes, _chipset);
    }
}