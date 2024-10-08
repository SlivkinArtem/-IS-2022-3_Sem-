﻿using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.HullDurabilities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meridian : Ship
{
    public Meridian(HullDurability hullDurability, Deflector? deflector, PhotonDeflector? photonDeflector,  Engine? engine, JumpEngine? jumpEngine, SizeType size) 
    : base(hullDurability, deflector,  photonDeflector, engine, jumpEngine, size, true)
    {
    }
}