namespace DesignPatterns.Structural._1_Adapter;

// Adapter pattern lets you wrap an otherwise incompatible object in an adapter to
// make it compatible with another class.

public interface ILion
{
    void Roar();
}

public interface IWildDog
{
    void Bark();
}

public class AsiaLion : ILion
{
    public void Roar() => Console.WriteLine("AsiaLion ---> Ohh Ohh ");
}

public class AfricanLion : ILion
{
    public void Roar() => Console.WriteLine("AfricanLion ---> Ohh Ohh ");
}

public class WildDog : IWildDog
{
    public void Bark() => Console.WriteLine("WildDog ---> Hop Hop");
}

class WildDogAdapter : ILion
{
    private WildDog wDog;
    public WildDogAdapter(WildDog dog) => wDog = dog;
    public void Roar()
    {
        Console.WriteLine("mapping [Lion's Roar] to [Dog's Bark]");
        wDog.Bark();
    }
}


public static class AdapterOutPut
{
    public static void Display()
    {
        var wildDog = new WildDog();
        wildDog.Bark();
        
        var wildDogAdapter = new WildDogAdapter(wildDog);
        wildDogAdapter.Roar();
    }
}