namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputerConfigurator.Models;

public class Socket
{
    public Socket(SocketName name)
    {
        Name = name;
    }

    public SocketName Name { get; }

    public bool IsCompatible(Socket socket)
    {
        if (socket != null && socket.Name != Name)
        {
            return false;
        }

        return true;
    }
}