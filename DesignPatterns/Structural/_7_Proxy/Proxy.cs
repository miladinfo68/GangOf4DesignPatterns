namespace DesignPatterns.Structural._7_Proxy;

// Using the proxy pattern, a class represents the functionality of another class

// A proxy, in its most general form, is a class functioning as an interface to something
// else. A proxy is a wrapper or agent object that is being called by the client to access
// the real serving object behind the scenes. Use of the proxy can simply be forwarding
// to the real object, or can provide additional logic. In the proxy extra functionality can
// be provided, for example caching when operations on the real object are resource
// intensive, or checking preconditions before operations on the real object are invoked.



// another example would be some sort of data-mapper implementation. For example, I
// recently made an ODM (Object Data Mapper) for MongoDB using this pattern where I
// wrote a proxy around mongo classes while utilizing the magic method __call() . All the
// method calls were proxied to the original mongo class and result retrieved was returned as
// it is but in case of find or findOne data was mapped to the required class objects and
// the object was returned instead of Cursor .

public interface IDoor
{
    void Open();
    void Close();
}

public class LabDoor : IDoor
{
    public void Open() => Console.WriteLine("Closing lab door");

    public void Close() => Console.WriteLine("Opening lab door");
}

public class SecuredDoor : IDoor
{
    private IDoor mDoor;

    public SecuredDoor(IDoor door)
    {
        mDoor = door;
    }

    public void Open(string password)
    {
        if (Authenticate(password)) mDoor.Open();
        else Console.WriteLine("Big no! It ain't possible.");
    }

    private bool Authenticate(string password) => password == "$ecr@t";

    public void Open() => mDoor.Open();

    public void Close() => mDoor.Close();
}

public static class ProxyOutPut
{
    public static void Display()
    {
        var door = new SecuredDoor(new LabDoor());
        door.Open("invalid"); // Big no! It ain't possible.
        
        door.Open("$ecr@t"); // Opening lab door
        door.Close(); // Closing lab door
    }
}