using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.HullDurabilities;

public abstract class HullDurability
{
    protected HullDurability(int hp)
    {
        if (hp < 0)
        {
            throw new ArgumentNullException();
        }
        else
        {
            HP = hp;
        }
    }
    public int HP { get; }
}
