namespace DesignPatterns.Creational._6_Singleton;

//Ensures that only one object of a particular class is ever created
public class President
{
    private static readonly Lazy<President> _singleton =
        new Lazy<President>(() => new President());

    //Hiding the Constructor
    private President()
    {
    }

    public static President GetInstance() => _singleton.Value;
}

public static class SingletonOutPut
{
    public static void Display()
    {
        President a = President.GetInstance();
        President b = President.GetInstance();
        President c = President.GetInstance();
        Console.WriteLine($"a==b==c {(a == b) && (b == c)}"); //Output : true
    }
}