namespace DesignPatterns.Creational._5_Prototype;

// Create object based on an existing object through cloning
// When an object is required that is similar to existing object or when the creation would be
// expensive as compared to cloning
interface IFigure : ICloneable
{
    void GetInfo();
}

public class Circle : IFigure
{
    readonly int _radius;

    public Circle(int r)
    {
        _radius = r;
    }

    public object Clone()
    {
        return new Circle(_radius);
    }

    public void GetInfo()
    {
        Console.WriteLine($"Circle with radius {_radius}");
    }
}

public class Rectangle : IFigure
{
    readonly int _width;
    readonly int _height;

    public Rectangle(int w, int h)
    {
        _width = w;
        _height = h;
    }

    public object Clone()
    {
        return new Rectangle(_width, _height);
    }

    public void GetInfo()
    {
        Console.WriteLine($"Rectangle height {_height} and width {_width}");
    }
}

public static class PrototypeOutPut
{
    public static void Display()
    {
        IFigure figure = new Rectangle(30, 40);
        IFigure clonedFigure = (IFigure) figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();

        figure = new Circle(30);
        clonedFigure = (IFigure) figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();

        Console.WriteLine($"Rectangle==CloneRectangle ? {figure == clonedFigure}");
    }
}