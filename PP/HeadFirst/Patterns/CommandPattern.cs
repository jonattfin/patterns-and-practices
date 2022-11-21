namespace HeadFirst.Patterns;

public class CommandPattern : BasePattern
{
    public override void Run()
    {
        var remote = new RemoteControl();
        var light = new Light();

        const int slot = 0;
        
        remote.SetCommand(slot, new LightOnCommand(light),  new LightOffCommand(light));
        
        remote.OnButtonWasPushed(slot);
        remote.UndoButtonWasPushed(slot);
        
        remote.OffButtonWasPushed(slot);
        remote.UndoButtonWasPushed(slot);
        
    }

    public override string Name => "Command";
    public override string Definition { get; }
}

public class RemoteControl
{
    private readonly int _maxSlots;
    
    private readonly ICommand[] onCommands;
    private readonly ICommand[] offCommands;
    private ICommand _undoCommand;

    public RemoteControl(int maxSlots = 7)
    {
        _maxSlots = maxSlots;

        onCommands = new ICommand[maxSlots];
        offCommands = new ICommand[maxSlots];

        for (var i = 0; i < maxSlots; i++)
        {
            onCommands[i] = new NoCommand();
            offCommands[i] = new NoCommand();
        }
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        CheckBoundaries(slot);

        onCommands[slot] = onCommand;
        offCommands[slot] = offCommand;
    }

    public void OnButtonWasPushed(int slot)
    {
        CheckBoundaries(slot);
        
        onCommands[slot].Execute();
        _undoCommand = onCommands[slot];
    }

    public void OffButtonWasPushed(int slot)
    {
        CheckBoundaries(slot);

        offCommands[slot].Execute();
        _undoCommand = offCommands[slot];
    }

    public void UndoButtonWasPushed(int slot)
    {
        CheckBoundaries(slot);
        
        _undoCommand.Undo();
    }

    private void CheckBoundaries(int slot)
    {
        if (slot < 0 || slot > _maxSlots - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(slot));
        }
    }
}

public interface ICommand
{
    void Execute();
    void Undo();
}

public class NoCommand : ICommand
{
    public void Execute()
    {
        // do nothing
    }

    public void Undo()
    {
        // do nothing
    }
}

class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}

class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }
}

public class Light
{
    public void On()
    {
        Console.WriteLine("Light On");
    }

    public void Off()
    {
        Console.WriteLine("Light Off");
    }
}