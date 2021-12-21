namespace DesignPatterns.Structural._6_Flyweight;

public enum BeverageType
{
    BubbleMilk, FoamMilk, OolongMilk, CoconutMilk
}
public interface IBeverage
{
    void Drink();
}

public class BubbleMilkTea : IBeverage
{
    public BubbleMilkTea()
    {
        Console.WriteLine("Initializing a Bubble Milk Tea instance");
    }

    public void Drink()
    {
        Console.WriteLine("hmmm... this is bubble milk tea");
    }
}
//-------------------------
public class FoamMilkTea : IBeverage
{

    public FoamMilkTea()
    {
        Console.WriteLine("Initializing a Foam Milk Tea instance");
    }

    public void Drink()
    {
        Console.WriteLine("hmmm... this is foam milk tea");
    }
}
//-------------------------
public class OolingMilkTea : IBeverage
{

    public OolingMilkTea()
    {
        Console.WriteLine("Initializing an Oolong Milk Tea instance");
    }

    public void Drink()
    {
        Console.WriteLine("hmmm... this is oolong milk tea");
    }
}
//-------------------------
public class CoconutMilkTea : IBeverage
{
    public CoconutMilkTea()
    {
        Console.WriteLine("Initializing a Coconut Milk Tea instance");
    }

    public void Drink()
    {
        Console.WriteLine("hmmm... this is coconut milk tea");
    }
}
//-------------------------

public class BeverageFlyweightFactory
{
    private readonly Dictionary<BeverageType, IBeverage> _beverages;

    public BeverageFlyweightFactory()
    {
        _beverages = new Dictionary<BeverageType, IBeverage>();
    }

    public IBeverage MakeBeverage(BeverageType type)
    {
        _beverages.TryGetValue(type, out var beverage);
        if (beverage != null) return beverage;
     
        switch (type)
        {
            case BeverageType.BubbleMilk:
                beverage = new BubbleMilkTea();
                _beverages.Add(BeverageType.BubbleMilk, beverage);
                break;
            case BeverageType.FoamMilk:
                beverage = new FoamMilkTea();
                _beverages.Add(BeverageType.FoamMilk, beverage);
                break;
            case BeverageType.OolongMilk:
                beverage = new OolingMilkTea();
                _beverages.Add(BeverageType.OolongMilk, beverage);
                break;
            case BeverageType.CoconutMilk:
                beverage = new CoconutMilkTea();
                _beverages.Add(BeverageType.CoconutMilk, beverage);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        return beverage;
    }
}

public class BubbleTeaShop
{
    private List<IBeverage> takeAwayOrders;

    public BubbleTeaShop()
    {
        takeAwayOrders = new List<IBeverage>();
        TakeOrders();
    }

    private void TakeOrders()
    {
        var factory = new BeverageFlyweightFactory();

        takeAwayOrders.Add(factory.MakeBeverage(BeverageType.BubbleMilk));
        takeAwayOrders.Add(factory.MakeBeverage(BeverageType.BubbleMilk));
        takeAwayOrders.Add(factory.MakeBeverage(BeverageType.CoconutMilk));
        takeAwayOrders.Add(factory.MakeBeverage(BeverageType.FoamMilk));
        takeAwayOrders.Add(factory.MakeBeverage(BeverageType.OolongMilk));
        takeAwayOrders.Add(factory.MakeBeverage(BeverageType.OolongMilk));
    }

    public void Enumerate()
    {
        Console.WriteLine("Enumerating take away orders\n");
        foreach (var beverage in takeAwayOrders)  beverage.Drink();
    }
}





public static class Flyweight2OutPut
{
    public static void Display()
    {
        var teaShop = new BubbleTeaShop();
        teaShop.Enumerate();
    }
}