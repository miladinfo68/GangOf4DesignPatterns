namespace DesignPatterns.Creational._4_Builder;

// Allows you to create different flavors of an object while avoiding constructor
// pollution. Useful when there could be several flavors of an object. Or when there are a
// lot of steps involved in creation of an object.

// When there could be several flavors of an object and to avoid the constructor telescoping.
// The key difference from the factory pattern is that; factory pattern is to be used when the
// creation is a one step process while builder pattern is to be used when the creation is a
// multi step process.


    public enum DoughType
    {
        Neapolitan_Pizza_Dough = 1,
        NewYorkStyle_Pizza_Dough = 2,
        SquarePan_Pizza_Dough = 3
    }

    public enum CheeseType
    {
        American = 1,
        Swiss = 2,
    }

    public enum PizzaSize
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    public class Pizza
    {
        public Pizza() { }

        public Pizza(DoughType doughType, bool isRedPepper, PizzaSize size, CheeseType cheeseType, List<string> vegetables)
        {
            this.DoughType = doughType;
            this.IsRedPepper = isRedPepper;
            this.Size = size;
            this.CheeseType = cheeseType;
            this.Vegetables = vegetables;
        }
        public DoughType DoughType { get; set; }
        public bool IsRedPepper { get; set; } = false;
        public PizzaSize Size { get; set; }
        public CheeseType CheeseType { get; set; }
        public List<string> Vegetables { get; set; }

        public void PizzaContent()
        {
            Console.WriteLine("Pizza with {0}", DoughType);
            Console.WriteLine($"IS Red Peeper : {IsRedPepper}");
            Console.WriteLine("Size: {0}", Size);
            Console.WriteLine("Cheese Type: {0}", CheeseType);
            Console.WriteLine($"Vegetables: {string.Join(",", Vegetables)}");
        }
    }


    public abstract class AbstractPizzaBuilder
    {
        protected Pizza _pizza;
        public void CreateNewPizza() => _pizza = new Pizza();
        public abstract void AddSize();
        public abstract void AddDough();
        public abstract void AddCheese();
        public abstract void AddPepper();
        public abstract void AddVegetables();
        public Pizza GetPizza() => _pizza;
    }
    public class ConcreteLargePizza : AbstractPizzaBuilder
    {
        public override void AddCheese()
        {
            _pizza.CheeseType = CheeseType.Swiss;
        }

        public override void AddDough()
        {
            _pizza.DoughType = DoughType.NewYorkStyle_Pizza_Dough;
        }

        public override void AddPepper()
        {
            _pizza.IsRedPepper = true;
        }

        public override void AddSize()
        {
            _pizza.Size = PizzaSize.Medium;
        }

        public override void AddVegetables()
        {
            _pizza.Vegetables = new List<string> { "Nana", "Reyhan" };
        }
    }

    public class ConcreteSmallPizza : AbstractPizzaBuilder
    {
        public override void AddCheese()
        {
            _pizza.CheeseType = CheeseType.Swiss;
        }

        public override void AddDough()
        {
            _pizza.DoughType = DoughType.NewYorkStyle_Pizza_Dough;
        }

        public override void AddPepper()
        {
            _pizza.IsRedPepper = false;
        }

        public override void AddSize()
        {
            _pizza.Size = PizzaSize.Small;
        }

        public override void AddVegetables()
        {
            _pizza.Vegetables = new List<string> { "Nana", "Reyhan", "Geshniz" };
        }
    }
    //Director
    public class PizzaMaker
    {
        private readonly AbstractPizzaBuilder _builder;
        public PizzaMaker(AbstractPizzaBuilder builder) => _builder = builder;
        public void BuildPizza()
        {
            _builder.CreateNewPizza();
            _builder.AddSize();
            _builder.AddDough();
            _builder.AddCheese();
            _builder.AddPepper();
            _builder.AddVegetables();
        }
        public Pizza GetPizza() => _builder.GetPizza();
    }






public static class BuilderOutPut
{
    public static void Display()
    {
        Console.WriteLine("Builder design pattern use to make complex objects with a lot of props in ctor !!!!");
        Console.WriteLine("\n*******************\tCreate Object by Constructor\n");
        var pizza = new Pizza(DoughType.Neapolitan_Pizza_Dough, true, PizzaSize.Large, CheeseType.American, new List<string> { "Tomato", "Capsicum", "Corn" });
        pizza.PizzaContent();
        Console.WriteLine("\n*******************\tCreate Object by Builder\n");
        
        var largePizzaMaker = new PizzaMaker(new ConcreteLargePizza());
        largePizzaMaker.BuildPizza();
        var pizza1 = largePizzaMaker.GetPizza();
        pizza1.PizzaContent();
        
        Console.WriteLine("\n*******************\tCreate Object by Builder\n");
        var smallPizzaMaker = new PizzaMaker(new ConcreteSmallPizza());
        smallPizzaMaker.BuildPizza();
        var pizza2 = smallPizzaMaker.GetPizza();
        pizza2.PizzaContent();
    }
}