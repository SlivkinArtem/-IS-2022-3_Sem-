namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class CommandExecutor
{
    private readonly ICommand _connect;
    private readonly ICommand _disconnect;
    private readonly ICommand _move;
    private readonly ICommand _copy;
    private readonly ICommand _rename;
    private readonly ICommand _delete;
    
    public CommandExecutor(ICommand connect, ICommand disconnect, ICommand move, ICommand copy, ICommand rename, ICommand delete /*, другие параметры команд*/)
    {
        _connect = connect;
        _disconnect = disconnect;
        _move = move;
        _copy = copy;
        _rename = rename;
        _delete = delete;
    }

    public void ExecuteConnectCommand()
    {
        _connect.Execute();
    }

    public void ExecuteDisconnectCommand()
    {
        _disconnect.Execute();
    }
    public void ExecuteMoveCommand()
    {
        _move.Execute();
    }
    
    public void ExecuteCopyCommand()
    {
        _copy.Execute();
    }
    
    public void ExecuteRenameCommand()
    {
        _rename.Execute();
    }
    
    public void ExecuteDeleteCommand()
    {
        _delete.Execute();
    }
}