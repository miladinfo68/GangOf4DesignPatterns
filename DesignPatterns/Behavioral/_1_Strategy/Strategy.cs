namespace DesignPatterns.Behavioral._1_Strategy;
// Strategy (or Policy) pattern allows you to switch the algorithm or strategy based upon the situation.

public interface ITravelStrategy
{
    void Travel(string fromA, string toB, string duration, string cost);
}

public class TravelByCar : ITravelStrategy
{
    public void Travel(string fromA, string toB, string duration, string cost)
    {
        Console.WriteLine($"Travel by [Car] from {fromA} to {toB} take long {duration} hour's and cost is {cost}$");
    }
}
public class TravelByShip : ITravelStrategy
{
    public void Travel(string fromA, string toB, string duration, string cost)
    {
        Console.WriteLine($"Travel by [Ship] from {fromA} to {toB} take long {duration} hour's and cost is {cost}$");
    }
}
public class TravelByPlane : ITravelStrategy
{
    public void Travel(string fromA, string toB, string duration, string cost)
    {
        Console.WriteLine($"Travel by [Plane] from {fromA} to {toB} take long {duration} hour's and cost is {cost}$");
    }
}

public static class StrategyOutPut
{
    public static void Display()
    {
        ITravelStrategy strategy;
        
        strategy = new TravelByCar();
        strategy.Travel("Los Angles" ,"New Yourk" ,"8" ,"10");
        
        strategy = new TravelByShip();
        strategy.Travel("Los Angles" ,"New Yourk" ,"5" ,"5");
        
        
        strategy = new TravelByCar();
        strategy.Travel("Los Angles" ,"New Yourk" ,"1" ,"200");
    }
}