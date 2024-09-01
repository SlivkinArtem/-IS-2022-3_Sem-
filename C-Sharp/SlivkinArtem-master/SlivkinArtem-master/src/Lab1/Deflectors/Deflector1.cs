using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1;

// Класс дефлектора Deflector1 реализует интерфейс IPhotonDeflector
public class Deflector1 : Deflector
{
    private const int Deflector1Hp = 1;
    public Deflector1() 
        : base(Deflector1Hp)
    {
    }
}
