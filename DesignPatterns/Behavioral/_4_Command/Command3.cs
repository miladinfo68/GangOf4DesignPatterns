namespace DesignPatterns.Behavioral._4_Command;

public interface ICommand3
{
    void Execute();
    void Undo();
    void Redo();
}

class TurnOn : ICommand3
{
    private Lamp _lamp;
    public TurnOn(Lamp lamp) => _lamp = lamp;
    public void Execute() => _lamp.TurnOn();
    public void Undo() => _lamp.TurnOff();
    public void Redo() => Execute();
}

class TurnOff : ICommand3
{
    private Lamp _lamp;
    public TurnOff(Lamp lamp) => _lamp = lamp;
    public void Execute() => _lamp.TurnOff();
    public void Undo() => _lamp.TurnOn();
    public void Redo() => Execute();
}

public class Lamp //invoker
{
    public void TurnOn() => Console.WriteLine("Bulb has been lit");
    public void TurnOff() => Console.WriteLine("Bulb has been off!");
}

public static class RemoteControl2 //Invoker
{
    public static void Change(ICommand3 command) => command.Execute();
}

public static class Command3OutPut
{
    public static void Display()
    {
        var lamp = new Lamp();
        var turnOn = new TurnOn(lamp);
        var turnOff = new TurnOff(lamp);
        RemoteControl2.Change(turnOn); 
        RemoteControl2.Change(turnOff); 
    }
}