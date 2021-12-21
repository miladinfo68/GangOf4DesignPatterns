using System.Text;

namespace DesignPatterns.Creational._4_Builder;

public class BurgerBuilder
{
    public int Size;
    public bool Cheese;
    public bool Pepperoni;
    public bool Lettuce;
    public bool Tomato;

    public BurgerBuilder(int size) => Size = size;

    public BurgerBuilder AddCheese()
    {
        Cheese = true;
        Console.WriteLine("[Cheese] Added to burger");
        return this;
    }

    public BurgerBuilder AddPepperoni()
    {
        Pepperoni = true;
        Console.WriteLine("[Pepperoni] Added to burger");
        return this;
    }

    public BurgerBuilder AddLettuce()
    {
        Lettuce = true;
        Console.WriteLine("[Lettuce] Added to burger");
        return this;
    }

    public BurgerBuilder AddTomato()
    {
        Tomato = true;
        Console.WriteLine("[Tomato] Added to burger");
        return this;
    }

    public Burger Build() => new Burger(this);
}

public class Burger
{
    public Burger(int size, bool cheese, bool pepperoni, bool lettuce, bool tomato)
    {
        _size = size;
        _cheese = cheese;
        _pepperoni = pepperoni;
        _lettuce = lettuce;
        _tomato = tomato;
    }

    private int _size;
    private bool _cheese;
    private bool _pepperoni;
    private bool _lettuce;
    private bool _tomato;

    public Burger(BurgerBuilder builder)
    {
        _size = builder.Size;
        _cheese = builder.Cheese;
        _pepperoni = builder.Pepperoni;
        _lettuce = builder.Lettuce;
        _tomato = builder.Tomato;
    }

    public string GetDescription() => $"This is {_size} inch Burger.";
}

public static class Builder2OutPut
{
    public static void Display()
    {
        var burger = new BurgerBuilder(4)
            .AddCheese()
            .AddPepperoni()
            .AddLettuce()
            .AddTomato()
            .Build();
        Console.WriteLine(burger.GetDescription());
    }
}