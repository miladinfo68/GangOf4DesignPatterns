namespace DesignPatterns.Behavioral._4_Command;

internal interface ICommand2
{
    void Execute();
    void Undo();
}
//-----------------------------
internal  class Light
{
    private readonly string _name;
    public Light(string name) => _name = name;
    internal void On() => Console.WriteLine($"{_name} Light On");
    internal void Off() => Console.WriteLine($"{_name} Light Off");
}
//-----------------------------
internal class LightOnCommand : ICommand2
{
    private readonly Light _light;
    public LightOnCommand(Light light) => _light = light;
    public void Execute() => _light.On();
    public void Undo() => _light.Off();
}
//-----------------------------
internal class LightOffCommand : ICommand2
{
    private readonly Light _light;
    public LightOffCommand(Light light) => _light = light;
    public void Execute() => _light.Off();
    public void Undo() => _light.On();
}
//-----------------------------
internal class MacroCommand : ICommand2
{
    private readonly ICommand2[] _commands;
    public MacroCommand(ICommand2[] commands) => _commands = commands;

    public void Execute()
    {
        foreach (var item in _commands) item.Execute();
    }

    public void Undo()
    {
        foreach (var item in _commands) item.Undo();
    }
}
//-----------------------------
internal class Garage
{
    private readonly string _name;
    public Garage(string name) => _name = name;
    internal void Open() => Console.WriteLine($"{_name} Garage Opened");
    internal void Close() => Console.WriteLine($"{_name} Garage Closed");
}
//-----------------------------
internal class GarageDoorCloseCommand : ICommand2
{
    private readonly Garage _garage;
    public GarageDoorCloseCommand(Garage g) => _garage = g;
    public void Execute() => _garage.Close();
    public void Undo() => _garage.Open();
}
//-----------------------------
internal struct OnOffStruct
{
    public ICommand2 On;
    public ICommand2 Off;
}
//-----------------------------
internal class NoCommand : ICommand2
{
    public void Execute() => Console.WriteLine("No Command Assigned");
    public void Undo() => Execute();
}
//-----------------------------
internal class RemoteControl
{
    private readonly ICommand2[] _offCommand;
    private readonly ICommand2[] _onCommand;
    private ICommand2 _undoCommand;

    public RemoteControl(int slots)
    {
        _onCommand = new ICommand2[slots];
        _offCommand = new ICommand2[slots];

        var none = new NoCommand();
        _undoCommand = none;
        for (var i = 0; i < slots; i++)
        {
            _onCommand[i] = none;
            _offCommand[i] = none;
        }
    }


    public OnOffStruct this[int i]
    {
        set
        {
            _onCommand[i] = value.On;
            _offCommand[i] = value.Off;
        }
    }

    public void PushOn(int slot)
    {
        _onCommand[slot].Execute();
        _undoCommand = _offCommand[slot];
    }

    public void PushOff(int slot)
    {
        _offCommand[slot].Execute();
        _undoCommand = _onCommand[slot];
    }

    public void PushUndo()
    {
        _undoCommand.Execute();
    }
}
//-----------------------------
internal class GarageDoorOpenCommand : ICommand2
{
    private readonly Garage _garage;
    public GarageDoorOpenCommand(Garage g) => _garage = g;
    public void Execute() => _garage.Open();
    public void Undo() => _garage.Close();
}

internal static class Command2OutPut
{
    internal static void Display()
    {
        var remote = new RemoteControl(3);


        var bike = new Garage("Bike");
        var bikeDoorClose = new GarageDoorCloseCommand(bike);
        var bikeDoorOpen = new GarageDoorOpenCommand(bike);

        var car = new Garage("Car");
        var carDoorClose = new GarageDoorCloseCommand(car);
        var carDoorOpen = new GarageDoorOpenCommand(car);

        var garageButton = new OnOffStruct
        {
            On = bikeDoorOpen,
            Off = bikeDoorClose
        };

        remote[0] = garageButton;
        remote.PushOn(0);
        remote.PushUndo();
        remote.PushUndo();
        remote.PushOff(0);


        Console.WriteLine();
        var light = new Light("Hall");

        ICommand2[] partyOn = { new LightOffCommand(light), bikeDoorOpen, carDoorOpen };
        ICommand2[] partyOff = { new LightOnCommand(light), bikeDoorClose, carDoorClose };


        remote[2] = new OnOffStruct { On = new MacroCommand(partyOn), Off = new MacroCommand(partyOff) };

        try
        {
            remote.PushOn(2);
            Console.WriteLine();
            remote.PushOff(2);
        }
        catch (Exception)
        {
            Console.WriteLine("Oops");
        }
    }
}