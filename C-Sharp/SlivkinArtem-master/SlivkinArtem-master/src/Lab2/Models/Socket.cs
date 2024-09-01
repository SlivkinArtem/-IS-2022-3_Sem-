using Itmo.ObjectOrientedProgramming.Lab2.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Socket
{
    public Socket(SocketName? socketName)
    {
        SocketName = socketName;
    }

    public SocketName? SocketName { get; private set; }
}