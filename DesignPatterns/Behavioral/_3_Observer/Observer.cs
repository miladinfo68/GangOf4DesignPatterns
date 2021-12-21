namespace DesignPatterns.Behavioral._3_Observer;
// This pattern is used when there are one too many relationships between objects 
// such as if one object is modified, its dependent objects are to be notified automatically. 
// State Design Pattern is used to alter the behavior of an object when it’s internal state changes. In this pattern, an object is created which represent various states and a context object whose behavior varies as it's state object changes.
//      
// This pattern uses state pattern .
// mvc paradigm uses this pattern and main con is leak of memory if we don't remover listener after register event 

public abstract class Observable // or Subject or event publisher
{
    private List<Observer> _observers = new List<Observer>();
    public void Attach(Observer o) => _observers.Add(o);
    public void Dettach(Observer o) => _observers.Remove(o);
    public abstract bool ChangeAppState { get; set; }

    protected void NotifyToAllObservers() =>
        _observers.ForEach(ob => ob.UpdateAppState());

    public void DettachAll()
    {
        if (_observers != null && _observers.Count > 0)
            _observers.RemoveAll(x=>1==1);
    }
}

public abstract class Observer //or Subscriber or Event listener
{
    protected Observable Observable;
    public abstract void UpdateAppState();
}

public class LampSwitch : Observable
{
    private bool _state = false; //false =off , true=on

    public override bool ChangeAppState
    {
        set
        {
            _state = value;
            NotifyToAllObservers();
        }
        get => _state;
    }
}

public class RedLampObserver : Observer
{
    private bool _on = false;

    public override void UpdateAppState()
    {
        _on = !_on;
        var onState = _on ? "ON" : "OFF";
        Console.WriteLine($"RedLamp now is [{onState}]");
    }
}

public class GreenLampObserver : Observer
{
    private bool _on = false;

    public override void UpdateAppState()
    {
        _on = !_on;
        var onState = _on ? "ON" : "OFF";
        Console.WriteLine($"GreenLamp now is [{onState}]");
    }
}

public class BlueLampObserver : Observer
{
    private bool _on = false;

    public override void UpdateAppState()
    {
        _on = !_on;
        var onState = _on ? "ON" : "OFF";
        Console.WriteLine($"BluLamp now is [{onState}]");
    }
}

public static class ObserverOutPut
{
    public static void Display()
    {
        var redLamp = new RedLampObserver();
        var greenLamp = new GreenLampObserver();
        var blueLamp = new BlueLampObserver();

        var lampSwitch = new LampSwitch();
        lampSwitch.Attach(redLamp);
        lampSwitch.Attach(greenLamp);
        lampSwitch.Attach(blueLamp);

        lampSwitch.ChangeAppState = true;
        lampSwitch.ChangeAppState = false;

        lampSwitch.DettachAll();
        // lampSwitch.Dettach(redLamp);
        // lampSwitch.Dettach(greenLamp);
        // lampSwitch.Dettach(blueLamp);
    }
}