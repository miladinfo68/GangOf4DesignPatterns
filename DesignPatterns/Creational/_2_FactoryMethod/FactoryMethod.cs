namespace DesignPatterns.Creational._2_FactoryMethod;

// It provides a way to delegate the instantiation logic to child classes.
// Useful when there is some generic processing in a class but the required sub-class is
// dynamically decided at runtime. Or putting it in other words, when the client doesn't know
// what exact sub-class it might need

public interface IInterviewer
{
    void AskQuestions();
}

public class Developer : IInterviewer
{
    public void AskQuestions() => Console.WriteLine("Asking about design patterns!");
}

public class Accounter : IInterviewer
{
    public void AskQuestions() => Console.WriteLine("Asking about accounting!");
}


public abstract class HiringManager
{
    // Factory method
    abstract protected IInterviewer MakeInterviewer { get; }
    public void TakeInterview() => MakeInterviewer.AskQuestions();
}


public class DevelopmentManager : HiringManager
{
    protected override IInterviewer MakeInterviewer=>new Developer();
}

public class AccountingManager : HiringManager
{
    protected override IInterviewer MakeInterviewer=>new Accounter();
}



public static class FactoryMethodOutPut
{
    public static void Display()
    {
        var devManager = new DevelopmentManager();
        devManager.TakeInterview(); //Output : Asking about design patterns!
        
        var marketingManager = new AccountingManager();
        marketingManager.TakeInterview();
    }
}