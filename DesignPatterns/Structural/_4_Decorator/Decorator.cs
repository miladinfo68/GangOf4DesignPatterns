namespace DesignPatterns.Structural._4_Decorator;

// Decorator pattern lets you dynamically change the behavior of an object at run time
// by wrapping them in an object of a decorator class

public interface ICoffee
{
    int GetCost();
    string GetDescription();
}

public class SimpleCoffee : ICoffee
{
    public int GetCost() => 5;
    public string GetDescription() => "Simple Coffee";
}

public class MilkCoffee : ICoffee
{
    private readonly ICoffee mCoffee;
    public MilkCoffee(ICoffee coffee) => mCoffee = coffee;
    public int GetCost() => mCoffee.GetCost() + 1;
    public string GetDescription() => String.Concat(mCoffee.GetDescription(), ", milk");
}

public class WhipCoffee : ICoffee
{
    private readonly ICoffee mCoffee;
    public WhipCoffee(ICoffee coffee) => mCoffee = coffee;
    public int GetCost() => mCoffee.GetCost() + 1;
    public string GetDescription() => String.Concat(mCoffee.GetDescription(), ", whip");
}

public class VanillaCoffee : ICoffee
{
    private readonly ICoffee mCoffee;
    public VanillaCoffee(ICoffee coffee) => mCoffee = coffee;
    public int GetCost() => mCoffee.GetCost() + 1;
    public string GetDescription() => String.Concat(mCoffee.GetDescription(), ", vanilla");
}


public static class DecoratorOutPut
{
    public static void Display()
    {
        var myCoffee = new SimpleCoffee();
        Console.WriteLine($"{myCoffee.GetCost():c}"); // $ 5.00
        Console.WriteLine(myCoffee.GetDescription()); // Simple Coffee
        
        var milkCoffee = new MilkCoffee(myCoffee);
        Console.WriteLine($"{milkCoffee.GetCost():c}"); // $ 6.00
        Console.WriteLine(milkCoffee.GetDescription()); // Simple Coffee, milk
        
        var whipCoffee = new WhipCoffee(milkCoffee);
        Console.WriteLine($"{whipCoffee.GetCost():c}"); // $ 7.00
        Console.WriteLine(whipCoffee.GetDescription()); // Simple Coffee, milk, whip
        
        var vanillaCoffee = new VanillaCoffee(whipCoffee);
        Console.WriteLine($"{vanillaCoffee.GetCost():c}"); // $ 8.00
        Console.WriteLine(vanillaCoffee.GetDescription());
    }
}