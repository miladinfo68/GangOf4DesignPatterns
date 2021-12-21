namespace DesignPatterns.Creational._1_SimpleFactory;

// Simple factory simply generates an instance for client without exposing any
// instantiation logic to the client

// When creating an object is not just a few assignments and involves some logic, it makes
// sense to put it in a dedicated factory instead of repeating the same code everywhere
public interface IDoor
{
    int GetHeight();
    int GetWidth();
}

public partial class WoodenDoor : IDoor
{
    private int Height { get; set; }
    private int Width { get; set; }

    public WoodenDoor(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public int GetHeight() => Height;
    public int GetWidth() => Width;
}

public static class DoorFactory
{
    public static IDoor MakeDoor(int height, int width) => new WoodenDoor(height ,width);
}

public static class SimpleFactoryOutPut
{
    public static void Display()
    {
        var door = DoorFactory.MakeDoor(80, 30);
        Console.WriteLine($"Height of Door : {door.GetHeight()}");
        Console.WriteLine($"Width of Door : {door.GetWidth()}");
    }
}