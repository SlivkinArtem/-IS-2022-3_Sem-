namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class CpuWithVideoCore : CpuDecorator
{
    public CpuWithVideoCore(ICpu cpu) 
        : base(cpu)
    {
    }
}