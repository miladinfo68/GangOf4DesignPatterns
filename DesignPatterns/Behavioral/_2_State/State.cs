namespace DesignPatterns.Behavioral._2_State;

public interface IState
{
    void Change(Context context);
}
    
public class Context
{
    private IState _state;
    public Context(IState newState) => _state = newState;
    public void Request() => _state.Change(this);
    public IState State
    {
        get => _state;
        set => _state = value;
    }
}

public class ImplementStateA : IState
{
    public void Change(Context context)
    {
        Console.WriteLine("ImplementStateA's Handle changed state from A to B");
        context.State = new ImplementStateB();
    }
}
    
public class ImplementStateB : IState
{
    public void Change(Context context)
    {
        Console.WriteLine("ImplementStateB's Handle changed state from B to A");
        context.State = new ImplementStateA();
    }
}


public static class StateOutPut
{
    public static void Display()
    {
        var contextA = new Context(new ImplementStateA());
        var contextB = new Context(new ImplementStateB());
            
        contextA.Request();
        contextB.Request();

    }
}