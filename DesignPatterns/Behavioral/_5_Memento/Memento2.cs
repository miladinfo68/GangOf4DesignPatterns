namespace DesignPatterns.Behavioral._5_Memento;

public class BaseClass
{
    public virtual string Name { get; set; }
    public virtual string Phone { get; set; }
    public virtual string Address { get; set; }
}

/// <summary>
/// The Originator class, which is the class for which we want to save Mementos for its state.
/// </summary>
public class FoodSupplier : BaseClass
{
    public FoodSupplier()
    {
    }

    public FoodSupplier(string name, string phone, string address)
    {
        Name = name;
        Phone = phone;
        Address = address;
    }

    public Memento SaveMemento()
    {
        Console.WriteLine("\nSaving current state\n");
        Console.WriteLine($"Current Sate : Name = {Name}, Phone = {Phone}, Address = {Address}");
        return new Memento(Name, Phone, Address);
    }

    public void RestoreMemento(Memento memento)
    {
        Name = memento.Name;
        Phone = memento.Phone;
        Address = memento.Address;
        Console.WriteLine("\nRestoring previous state\n");
        Console.WriteLine($"Current Sate : Name = {Name}, Phone = {Phone}, Address = {Address}");
    }
}

public class Memento : BaseClass
{
    public Memento(string name, string phone, string address)
    {
        Name = name;
        Phone = phone;
        Address = address;
    }
}

/// <summary>
/// The Caretaker class.  
/// This class never examines the contents of any Memento and is
/// responsible for keeping that memento.
/// </summary>
class SupplierMemory
{
    public Memento Memento { get; set; }
}

public static class Memento2OutPut
{
    public static void Display()
    {
        //Here's a new supplier for our restaurant
        FoodSupplier s = new FoodSupplier("Harold Karstark","(482) 555-1172","");

        // Let's store that entry in our database.
        SupplierMemory m = new SupplierMemory();
        m.Memento = s.SaveMemento();
        
        Console.WriteLine("-----------------------------------------");
        // Continue changing originator
        s.Address = "548 S Main St. Nowhere, KS";
        // m.Memento = s.SaveMemento();
        
        Console.WriteLine("-----------------------------------------");
        // Crap, gotta undo that entry, I entered the wrong address
        s.RestoreMemento(m.Memento);
    }
}