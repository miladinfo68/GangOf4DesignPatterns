namespace DesignPatterns.Structural._2_Bridge;

// Bridge pattern is about preferring composition over inheritance. Implementation
// details are pushed from a hierarchy to another object with a separate hierarchy.

interface IWebPage
{
    string GetContent();
}

public interface ITheme
{
    string Color { get; }
}

public class NightTheme : ITheme
{
    public string Color => "Dark";
}

public class DayTheme : ITheme
{
    public string Color => "White";
}

public class HomePage : IWebPage
{
    protected ITheme _theme;
    public HomePage(ITheme theme) => _theme = theme;
    public string GetContent() => $"Home Page's theme is {_theme.Color}";
}

public class AboutPage : IWebPage
{
    protected ITheme _theme;
    public AboutPage(ITheme theme) => _theme = theme;
    public string GetContent() => $"About Page's theme is {_theme.Color}";
}

public class ContactUsPage : IWebPage
{
    protected ITheme _theme;
    public ContactUsPage(ITheme theme) => _theme = theme;
    public string GetContent() => $"ContactUs Page's theme is {_theme.Color}";
}

public static class BridgeOutPut
{
    public static void Display()
    {
        var darkTheme = new NightTheme();
        var lightTheme = new DayTheme();
        
        var home = new HomePage(darkTheme);
        var about = new AboutPage(lightTheme);
        var contactus = new ContactUsPage(lightTheme);

        Console.WriteLine(home.GetContent()); 
        Console.WriteLine(about.GetContent()); 
        Console.WriteLine(contactus.GetContent()); 
    }
}