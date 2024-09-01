using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class JumpEngine
{
    protected JumpEngine(int speed, Distance? range)
    {
        Speed = speed;
        Range = range;
    }
    public int Speed { get; }
    public Distance? Range { get; }
    
    public int TotalTime { get; protected set; }
    public int TotalGravitationFuel { get; protected set; }
    public abstract void CalculateTime(Distance? distance);
    public abstract void CalculateGravitationFuel();
}