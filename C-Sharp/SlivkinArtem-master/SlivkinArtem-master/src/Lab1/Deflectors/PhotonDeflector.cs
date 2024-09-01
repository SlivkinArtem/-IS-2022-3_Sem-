using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PhotonDeflector : Deflector
{
    private const int PhotonDeflectorHp = 3;
    public PhotonDeflector() 
        : base(PhotonDeflectorHp)
    {
    }
}