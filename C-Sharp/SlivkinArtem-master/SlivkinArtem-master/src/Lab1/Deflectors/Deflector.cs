namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class Deflector
{
    protected Deflector(int hp)
    {
        HP = hp;
    }
    
    public int HP { get; }
}
