namespace DesignPatterns.Creational._3_AbstractFactory;

// A factory of factories; a factory that groups the individual but related/dependent
// factories together without specifying their concrete classes
// When there are interrelated dependencies with not-that-simple creation logic involved


public interface IDoor
{
    void Description();
}

public class WoodenDoor : IDoor
{
    public void Description() => Console.WriteLine("I am a wooden door");
}

public class IronDoor : IDoor
{
    public void Description() => Console.WriteLine("I am a iron door");
}

interface IDoorFittingExpert
{
    void Description();
}

public class Welder : IDoorFittingExpert
{
    public void Description() => Console.WriteLine("I can only fit iron doors");
}

public class Carpenter : IDoorFittingExpert
{
    public void Description() => Console.WriteLine("I can only fit wooden doors");
}

interface IDoorFactory
{
    IDoor MakeDoor();
    IDoorFittingExpert MakeFittingExpert();
}

class IronDoorFactory : IDoorFactory
{
    public IDoor MakeDoor() => new IronDoor();
    public IDoorFittingExpert MakeFittingExpert() => new Welder();
}

class WoodenDoorFactory : IDoorFactory
{
    public IDoor MakeDoor() => new WoodenDoor();
    public IDoorFittingExpert MakeFittingExpert() => new Carpenter();
}

public static class AbstractFactoryOutPut
{
    public static void Display()
    {
        var woodenDoorFactory = new WoodenDoorFactory();
        var woodenDoor = woodenDoorFactory.MakeDoor();
        var woodenDoorFittingExpert = woodenDoorFactory.MakeFittingExpert();
        woodenDoor.Description(); //Output : I am a wooden door
        woodenDoorFittingExpert.Description();//Output : I can only fit woooden doors
        
        var ironDoorFactory = new IronDoorFactory();
        var ironDoor = ironDoorFactory.MakeDoor();
        var ironDoorFittingExpert = ironDoorFactory.MakeFittingExpert();
        ironDoor.Description();//Output : I am a iron door
        ironDoorFittingExpert.Description();//Output : I can only fit iron doors
    }
}