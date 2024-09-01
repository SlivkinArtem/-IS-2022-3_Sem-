using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CoolerBuilder
{
    private Dimensions? _dimensions;
    private List<Socket?> _supportedSockets = new List<Socket?>();
    private Tdp? _tdp;

    public CoolerBuilder SetSize(Dimensions? dimensions)
    {
        ArgumentNullException.ThrowIfNull(dimensions);
        _dimensions = dimensions;
        return this;
    }
    
    public void AddSocket(Socket? socket)
    {
        ArgumentNullException.ThrowIfNull(socket);
        _supportedSockets.Add(socket);
    }
    
    public CoolerBuilder SetTdp(Tdp? tdp)
    {
        ArgumentNullException.ThrowIfNull(tdp);
        this._tdp = tdp;
        return this;
    }

    public Cooler Build()
    {
        return new Cooler(_dimensions, _supportedSockets, _tdp);
    }
}