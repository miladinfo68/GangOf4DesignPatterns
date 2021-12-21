namespace DesignPatterns.Structural._6_Flyweight;

// It is used to minimize memory usage or computational expenses by sharing as much
// as possible with similar objects

// Anything that will be cached or shared is flyweight.
// Types of tea here will be flyweights.

public class KarakTea
{
}

// Acts as a factory and saves the tea
public class TeaMaker
{
    private Dictionary<string, KarakTea> mAvailableTea = new Dictionary<string, KarakTea>();

    public KarakTea Make(string preference)
    {
        if (!mAvailableTea.ContainsKey(preference))
            mAvailableTea[preference] = new KarakTea();
        return mAvailableTea[preference];
    }
}

public class TeaShop
{
    private Dictionary<int, KarakTea> mOrders = new Dictionary<int, KarakTea>();
    private readonly TeaMaker mTeaMaker;

    public TeaShop(TeaMaker teaMaker)
    {
        mTeaMaker = teaMaker;
    }

    public void TakeOrder(string teaType, int table)
    {
        mOrders[table] = mTeaMaker.Make(teaType);
    }

    public void Serve()
    {
        foreach (var table in mOrders.Keys)
            Console.WriteLine($"Serving Tea to table # {table}");
    }
}

public static class FlyweightOutPut
{
    public static void Display()
    {
        var teaMaker = new TeaMaker();
        var teaShop = new TeaShop(teaMaker);
        teaShop.TakeOrder("less sugar", 1);
        teaShop.TakeOrder("more milk", 2);
        teaShop.TakeOrder("without sugar", 5);
        teaShop.Serve();
    }
}