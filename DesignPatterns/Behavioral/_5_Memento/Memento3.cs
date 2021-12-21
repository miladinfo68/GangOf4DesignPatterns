using System;
using System.Threading;

namespace DesignPatterns.Behavioral._5_Memento;

//'Originator' Class
public class Player
{
    public int Level;
    public int Score;
    public string Health;
    public int lifeline = 3;

    public Memento3 CreateMarker(Player player)
    {
        return new Memento3(player.Level, player.Score, player.Health);
    }

    public void RestoreLevel(Memento3 playerMemento)
    {
        Level = playerMemento.Level;
        Score = playerMemento.Score;
        Health = playerMemento.Health;
        lifeline -= 1;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("Level: " + Level);
        Console.WriteLine("Score: " + Score);
        Console.WriteLine("Health: " + Health);
        Console.WriteLine("Lifeline left: " + lifeline);
    }
}


//'Memento' class
public class Memento3
{
    public int Level;
    public int Score;
    public string Health;

    public Memento3(int level, int score, string health)
    {
        Level = level;
        Score = score;
        Health = health;
    }
}

//'CareTaker' class
public class CareTaker
{
    // store a checkpoint for already crossed level
    public Memento3 LevelMarker;
}



//'client'
public static class Memento3OutPut
{
    public static void Display()
    {
        // player has completed level 1
        Player player = new Player();
        player.Level = 1;
        player.Score = 100;
        player.Health = "100%";
        Console.WriteLine("----------- Player info after completing level 1 ---------------------");
        player.DisplayPlayerInfo();
        // when player completes any level then create checkpoint for that level.
        CareTaker careTaker = new CareTaker();
        careTaker.LevelMarker = player.CreateMarker(player);

        // sleep is only added to show some delay..
        Thread.Sleep(2000);

        player.Level = 2;
        player.Score = 130;
        player.Health = "80%";
        Console.WriteLine("--------------- Player info in level 2 --------------------------------");
        player.DisplayPlayerInfo();

        // if players loses all the lifeline then restore the game from level 1
        player.RestoreLevel(careTaker.LevelMarker);
        Console.WriteLine("------------- Player info after restoring level 1 data ----------------");
        player.DisplayPlayerInfo();
    }
}