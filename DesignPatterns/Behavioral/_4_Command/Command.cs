namespace DesignPatterns.Behavioral._4_Command;

// Allows you to encapsulate actions in objects. The key idea behind this pattern is to
// provide the means to decouple client from receiver.

// In object-oriented programming, the command pattern is a behavioral design pattern
// in which an object is used to encapsulate all information needed to perform an action
// or trigger an event at a later time. This information includes the method name, the
// object that owns the method and values for the method parameters.


// Command pattern can also be used to implement a transaction based system. Where you
// keep maintaining the history of commands as soon as you execute them. If the final
// command is successfully executed, all good otherwise just iterate through the history and
// keep executing the undo on all the executed commands.



//e.g : ordering in restaurant 
//customer(client) --> order(command) --> waiter(invoker) --> chef(receiver)

//e.g : switch tv channels by remote control
//user(client) --> hit buttons or on/off(command) --> remote control(invoker) --> tv(receiver)



public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public void IncreasePrice(decimal amount)
    {
        Price += amount;
        Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
    }

    public void DecreasePrice(decimal amount)
    {
        if (Price > amount)
        {
            Price -= amount;
            Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
        }
        else
            Console.WriteLine($"Can't decrease {amount} from {Price}$.");
    }

    public override string ToString() => $"Current price for the {Name} product is {Price}$.";
}

public interface ICommand
{
    void Redo();
    void Undo();
}

public enum AppActions
{
    INC,
    DEC
}

public class ProductCommand : ICommand
{
    private readonly AppActions _action;
    private readonly Product _product;
    private readonly decimal _amount;

    public ProductCommand(Product product, AppActions action, decimal amount)
    {
        _product = product;
        _action = action;
        _amount = amount;
    }

    public void Redo()
    {
        if (_action == AppActions.INC)
            _product.IncreasePrice(_amount);
        else
            _product.DecreasePrice(_amount);
    }

    public void Undo()
    {
        if (_action == AppActions.INC)
            _product.DecreasePrice(_amount);
        else
            _product.IncreasePrice(_amount);
    }
}

public interface IInvoker
{
    public void SetCommands(ICommand command);
}

// Commands list Invoker
public class ProductPriceManger : IInvoker, ICommand //receiver
{
    private readonly List<ICommand> _commands;
    private ICommand _command;
    public ProductPriceManger() => _commands = new List<ICommand>();
    public void SetCommands(ICommand command) => _commands.Add(command);

    public void Redo()
    {
        _commands.Add(_command);
        _command.Redo();
    }

    public void Undo()
    {
        foreach (var command in Enumerable.Reverse(_commands)) command.Undo();
    }
}

public static class CommandOutPut
{
    public static void Display()
    {
        var ppm = new ProductPriceManger();
        var product = new Product("cell phone", 1000);
    }
}