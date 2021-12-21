namespace DesignPatterns.Structural._5_Facade;

// Facade pattern provides a simplified interface to a complex subsystem.
public class Computer
{
    public void GetElectricShock() => Console.WriteLine("Ouch!");
    public void MakeSound() => Console.WriteLine("Beep beep!");
    public void ShowLoadingScreen() => Console.WriteLine("Loading..");
    public void Bam() => Console.WriteLine("Ready to be used!");
    public void CloseEverything() => Console.WriteLine("Bup bup bup buzzzz!");
    public void Sooth() => Console.WriteLine("Zzzzz");
    public void PullCurrent() => Console.WriteLine("Haaah!");
}

public class ComputerFacade
{
    private readonly Computer mComputer;
    public ComputerFacade(Computer computer)
    {
        this.mComputer = computer;
    }
    public void TurnOn()
    {
        mComputer.GetElectricShock();
        mComputer.MakeSound();
        mComputer.ShowLoadingScreen();
        mComputer.Bam();
    }
    
    public void TurnOff()
    {
        mComputer.CloseEverything();
        mComputer.PullCurrent();
        mComputer.Sooth();
    }
}

public static class FecadeOutPut
{
    public static void Display()
    {
        var computer = new ComputerFacade(new Computer());
        computer.TurnOn(); // Ouch! Beep beep! Loading.. Ready to be used!
        Console.WriteLine();
        computer.TurnOff(); // Bup bup buzzz! Haah! Zzzzz
        Console.ReadLine();
    }
}