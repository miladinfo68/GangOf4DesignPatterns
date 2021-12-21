namespace DesignPatterns.Structural._3_Composite;

public class MenuComponent
{
    public virtual void Add(MenuComponent component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(MenuComponent component)
    {
        throw new NotImplementedException();
    }

    public virtual MenuComponent GetChild(int i)
    {
        throw new NotImplementedException();
    }

    public virtual string Name { get; }
    public virtual string Description { get; }
    public virtual bool Vegetarian { get; }
    public virtual double Price { get; }

    public virtual void Print()
    {
        throw new NotImplementedException();
    }
}

public class MenuItem : MenuComponent
{
    public MenuItem(string name, string description, double price, bool isveg)
    {
        Name = name;
        Description = description;
        Price = price;
        Vegetarian = isveg;
    }

    public override string Name { get; }

    public override string Description { get; }

    public override double Price { get; }

    public override bool Vegetarian { get; }

    public override void Print()
    {
        Console.WriteLine($"{Name} : {Price}  {(Vegetarian ? '+' : '*')} \n {Description}");
    }
}


public class Menu : MenuComponent
{
    List<MenuComponent> _components = new List<MenuComponent>();

    public Menu(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public override void Add(MenuComponent component)
    {
        _components.Add(component);
    }

    public override void Remove(MenuComponent component)
    {
        _components.Remove(component);
    }

    public override MenuComponent GetChild(int i)
    {
        return _components[i];
    }

    public override string Name { get; }

    public override string Description { get; }

    public override void Print()
    {
        Console.WriteLine(Name);
        Console.WriteLine("___________");
        foreach (var menuComponent in _components)
        {
            menuComponent.Print();
        }
        Console.WriteLine();
    }
}


public class Client
{
    private readonly MenuComponent _menus;

    public Client(MenuComponent menus)
    {
        _menus = menus;
    }

    public void Print()
    {
        _menus.Print();
    }
}

public static class Composite2OutPut
{
    public static void Display()
    {
        var breakfast = new Menu("Breakfast", "Pancake House");
        var lunch = new Menu("Lunch", "Deli Diner");
        var dinner = new Menu("Dinner", "Dinneroni");

        var dessert = new Menu("Dessert", "Ice Cream");

        var menu = new Menu("All", "McDonalds");

        breakfast.Add(new MenuItem("Waffles", "Butterscotch waffles", 140, false));
        breakfast.Add(new MenuItem("Corn Flakes", "Kellogs", 80, true));

        lunch.Add(new MenuItem("Burger", "Cheese and Onion Burger", 250, true));
        lunch.Add(new MenuItem("Sandwich", "Chicken Sandwich", 280, false));

        dinner.Add(new MenuItem("Pizza", "Cheese and Tomato Pizza", 210, true));
        dinner.Add(new MenuItem("Pasta", "Chicken Pasta", 280, false));

        dessert.Add(new MenuItem("Ice Cream", "Vanilla and Chocolate", 120, true));
        dessert.Add(new MenuItem("Cake", "Choclate Cake Slice", 180, false));

        dinner.Add(dessert);
        menu.Add(breakfast);
        menu.Add(lunch);
        menu.Add(dinner);

        menu.Print();
    }
}